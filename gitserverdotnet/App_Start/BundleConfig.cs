﻿using gitserverdotnet.Helpers;
using System.Web.Optimization;

namespace gitserverdotnet.App_Start
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
           
            bundles.Add(new ScriptBundle("~/bundledJs")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/jquery.validate*", "~/Content/uni/js/uni-form-validation.jquery.js", "~/Scripts/MicrosoftAjax.js", "~/Scripts/MicrosoftMvcAjax.js")
                .Include("~/Scripts/highlight.min.js")
                .Include("~/Scripts/clipboard.min.js"));

            bundles.Add(new StyleBundle("~/Content/bundledCss")
                .Include("~/Content/components/pure/pure-min.css", new CssRewriteUrlTransformWrapper())
                .Include("~/Content/components/font-awesome/css/font-awesome.min.css", new CssRewriteUrlTransformWrapper())
                .Include("~/Content/components/highlight/styles/github.min.css")
                .Include("~/Content/fonts.css", "~/Content/site.css"));
        }
    }
}