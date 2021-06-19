using System.Web;
using System.Web.Optimization;

namespace Charity
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
                        "~/Scripts/js/modernizr-2.6.2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(               
                "~/Scripts/js/bootstrap.min.js",
                      "~/Scripts/js/respond.min.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(

                      "~/Content/css/bootstrap.css",
                      "~/Content/css/style.css"));
        }
    }
}
