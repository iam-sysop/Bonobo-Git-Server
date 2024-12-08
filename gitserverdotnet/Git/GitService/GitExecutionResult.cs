using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gitserverdotnet.Git.GitService
{
    public class GitExecutionResult
    {
        public GitExecutionResult(bool hasError)
        {
            this.HasError = hasError;
        }

        public bool HasError { get; private set; }
    }
}