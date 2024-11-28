using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace gitserverdotnet.Git
{
    public interface IGitRepositoryLocator
    {
        DirectoryInfo GetRepositoryDirectoryPath(string repository);
    }
}