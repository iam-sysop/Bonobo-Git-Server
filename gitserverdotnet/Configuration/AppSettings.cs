﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace gitserverdotnet.Configuration
{
    public static class AppSettings
    {
        public static bool IsPushAuditEnabled
        {
            get
            {
                return bool.Parse(ConfigurationManager.AppSettings["IsPushAuditEnabled"] ?? "false");
            }
        }
    }
}