using System;
using System.Configuration;
using System.IO;
using gitserverdotnet.Configuration;
using gitserverdotnet.Data;
using gitserverdotnet.Models;

namespace gitserverdotnet.Test.MembershipTests.ADTests
{
    class ADTestSupport :  IDisposable
    {
        private readonly string _testDirectory;

        public ADTestSupport()
        {
            _testDirectory = Path.Combine(Path.GetTempPath(), "gitserverdotnetAdTest");
            SafelyDeleteTestData();
            ConfigurationManager.AppSettings["ActiveDirectoryBackendPath"] = _testDirectory;
            ActiveDirectorySettings.LoadSettings();
            ADBackend.ResetSingletonForTesting();
        }

        private void SafelyDeleteTestData()
        {
            if (Directory.Exists(_testDirectory))
            {
                try
                {
                    Directory.Delete(_testDirectory, true);
                }
                catch
                {
                }
            }
        }

        public void Dispose()
        {
            SafelyDeleteTestData();
        }

        public UserModel CreateUser(string username, string password, string givenName, string surname, string email, Guid id)
        {
            var user = new UserModel
            {
                Username = username.ToLowerInvariant(),
                GivenName = givenName,
                Surname = surname,
                Email = email,
                Id = id
            };
            ADBackend.Instance.Users.Add(user);
            return user;
        }

    }
}