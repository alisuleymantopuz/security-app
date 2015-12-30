using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthorizationFramework.UI.Web.App_Start
{
    using System.Web.Optimization;

    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                                 "~/Content/bootstrap.css",
                                 "~/Content/bootstrap-theme.css"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                         "~/Scripts/jquery-{version}.js",
                         "~/Scripts/bootstrap.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}