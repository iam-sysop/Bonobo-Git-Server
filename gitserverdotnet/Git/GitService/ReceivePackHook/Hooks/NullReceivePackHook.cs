﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gitserverdotnet.Git.GitService.ReceivePackHook.Hooks
{
    public class NullReceivePackHook : IHookReceivePack
    {
        public void PrePackReceive(ParsedReceivePack receivePack)
        {
            // do nothing
        }

        public void PostPackReceive(ParsedReceivePack receivePack, GitExecutionResult result)
        {
            // do nothing
        }
    }
}