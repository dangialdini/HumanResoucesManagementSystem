using System.Web;
using System.Web.Optimization;

namespace UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendojs").Include(                
                "~/Scripts/kendo/2014.3.1411/jquery.min.js",
                "~/Scripts/kendo/2014.3.1411/jszip.min.js",
                "~/Scripts/kendo/2014.3.1411/kendo.all.min.js",
                "~/Scripts/kendo/2014.3.1411/kendo.aspnetmvc.min.js",
                "~/Scripts/kendo/2014.3.1411/kendo.timezones.min.js"                
                ));

            

            // CONTENT **

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/site.css",      
                "~/Content/bootstrap.css")); 
            
            bundles.Add(new StyleBundle("~/Content/kendocss").Include(
                "~/Content/kendo/2014.3.1411/kendo.common.min.css",
                "~/Content/kendo/2014.3.1411/kendo.mobile.all.min.css",
                "~/Content/kendo/2014.3.1411/kendo.dataviz.min.css",
                "~/Content/kendo/2014.3.1411/kendo.default.min.css",
                "~/Content/kendo/2014.3.1411/kendo.dataviz.default.min.css"));

            bundles.Add(new StyleBundle("~/Content/kendofioricss").Include(
                "~/Content/kendo/2014.3.1411/kendo.common-fiori.min.css",
                "~/Content/kendo/2014.3.1411/kendo.mobile.all.min.css",
                "~/Content/kendo/2014.3.1411/kendo.dataviz.min.css",
                "~/Content/kendo/2014.3.1411/kendo.fiori.min.css",
                "~/Content/kendo/2014.3.1411/kendo.dataviz.default.min.css"));
        }
    }
}
