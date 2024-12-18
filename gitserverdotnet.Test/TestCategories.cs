﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gitserverdotnet.Test
{
    public static class TestCategories
    {
        public const string IntegrationTest = "IntegrationTest";

        // User data storage type
        public const string StorageInternal = "StorageInternal";
        public const string StorageActiveDirectory = "StorageActiveDirectory";

        // Authentication types
        public const string AuthForms = "AuthForms";
        public const string AuthWindows = "AuthWindowsAuth";
        public const string AuthADFS = "AuthADFS";
    }
}
