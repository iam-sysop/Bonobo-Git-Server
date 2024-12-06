using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.UI.WebControls;



namespace gitserverdotnet.App_Start
{
    public class GitConfig
    {
        private static readonly string _gitBin = ConfigurationManager.AppSettings["GitPath"];
        private static readonly string _gitRoot = ConfigurationManager.AppSettings["GitHomePath"];

        public static void VerifyGitInstall()
        {

            // if 32bit, version locked at 2.41.0.3
            // if win 7, win 8, srv 2008R2, srv 2012: version locked at 2.46.2 unless 32 bit then 2.41.0.3
            // if win 10+, server 2016+, version unlocked above 2.47.1

            Version _git32vPref = new Version("2.41.0.3");
            Version _git64vLegacy = new Version("2.46.2.0");
            Version _git64vPrefMin = new Version("2.47.1.0");

            bool _is64bitIIS = Environment.Is64BitOperatingSystem && Environment.Is64BitProcess;
            bool _isLegacyOS = false;
            bool _isValidOS = true;

            if (HttpRuntime.IISVersion != null)
            {
                Version _iisVersion = HttpRuntime.IISVersion;
                if (_iisVersion.Major < 7 || (_iisVersion.Major == 7 && _iisVersion.Minor < 5)) _isValidOS = false;
                if (_iisVersion.Major < 10) _isLegacyOS = true;
            }
            else
            {
                _isValidOS = false;
            }

            if (!_isValidOS) throw new ApplicationException("gitserver.net is NOT running on a valid version of Windows/IIS.");

            Log.Information("Verifying git is installed and available...");
            Log.Information("GIT EXE: {0}", _gitBin);

            Version _gitInstalled = new Version();

            if (File.Exists(HostingEnvironment.MapPath(_gitBin)))
            {
                FileVersionInfo _gitBinaryVersion = FileVersionInfo.GetVersionInfo(HostingEnvironment.MapPath(_gitBin));
                string _gitFileVersion = string.Format("{0}.{1}.{2}.{3}", _gitBinaryVersion.FileMajorPart, _gitBinaryVersion.FileMinorPart, _gitBinaryVersion.FileBuildPart, _gitBinaryVersion.FilePrivatePart);
                Log.Information("FOUND: {0} - binary version: {1}", _gitBinaryVersion.FileName, _gitFileVersion);
                _gitInstalled = Version.Parse(_gitFileVersion);
            }

            if (_is64bitIIS)
            {
                if (_isLegacyOS)
                {
                    if (_gitInstalled < _git64vLegacy)
                    {
                        // technically we should replace whatever git we find with what we need here because "too new" is not compatible with the underlying OS and "could" cause problems.
                        installGit(_git64vLegacy);
                    }
                }
                else
                {
                    if (_gitInstalled < _git64vPrefMin)
                    {
                        // we need to upgrade the found version to current preferred.
                        installGit(_git64vPrefMin);
                    }
                }
            }
            else
            {
                if (_gitInstalled.CompareTo(_git32vPref) != 0)
                {
                    // technically we should replace whatever git we find with what we need here because "too new" is not truly 32bit compatible and "could" cause problems.
                    installGit(_git32vPref);
                }
            }
        }

        


        private static void installGit(Version version, bool x64 = true)
        {
            if (version == null) throw new ArgumentNullException("Requested Git version to install cannot be null.");

            string _gitReleaseVer = string.Concat("v", version.Major, ".", version.Minor, ".", version.Build, ".windows.", version.Revision > 0 ? version.Revision.ToString() : "1");
            string _gitPkgVer = string.Concat(version.Major, ".", version.Minor, ".", version.Build, version.Revision > 0 ? version.Revision.ToString() : "");
            string _gitPkgName = string.Format("MinGit-{0}-{1}-bit.zip", _gitPkgVer, x64 ? "64" : "32");
            string _gitPkgURL = string.Format("git-for-windows/git/releases/download/{0}/{1}", _gitReleaseVer, _gitPkgName);
            string _gitDestPath = HostingEnvironment.MapPath(_gitRoot);
            string _gitDestPkg = string.Concat(_gitDestPath, "/pkgs/", _gitPkgName);

            Log.Information("Git Package to Install: {0}", _gitPkgURL);

            Directory.CreateDirectory(string.Concat(_gitDestPath, "/pkgs"));
            
            using (HttpClient _client = new HttpClient())
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                try
                {
                    Task<Stream> _dlTask = Task.Run(() => _client.GetStreamAsync(string.Concat("https://github.com/", _gitPkgURL)));
                    _dlTask.Wait();

                    using (var _httpStream = _dlTask.Result)
                    {
                        using (FileStream _fileStream = new FileStream(_gitDestPkg, FileMode.OpenOrCreate))
                        {
                            _httpStream.CopyTo(_fileStream);
                        }
                    }       
                    


                }
                catch (Exception e)
                {
                    Log.Error(e, "Git Package DOWNLOAD ERROR");
                }



            }

            if (File.Exists(_gitDestPkg))
            {
                ZipFile.ExtractToDirectory(_gitDestPkg, _gitDestPath);

                // Fix etc/gitconfig to remove references to configs possibly outside this installation.

                File.Copy(string.Concat(_gitDestPath, "/etc/gitconfig"), string.Concat(_gitDestPath, "/etc/gitconfig.bak"), false);
                Helpers.IniConfigFileHelper _gitConfigHelper = new Helpers.IniConfigFileHelper(string.Concat(_gitDestPath,"/etc/gitconfig"));
                _gitConfigHelper.DeleteSection("include");
                

            }

        }



    }



}