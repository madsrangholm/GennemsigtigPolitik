using System.Web;
using System.Web.Optimization;

namespace GP.Website
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/Scripts/Chart.min.js",
                "~/Scripts/angular.min.js",
                "~/Scripts/angular-sanitize.min.js",
                "~/Scripts/angular-ui/ui-bootstrap-tpls.min.js",
                "~/Scripts/angular-ui/ui-bootstrap.min.js",
                "~/Scipts/i18n/angular-locale_da-dk.js",
                "~/Scripts/angular-chart.min.js")
            );

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/angular-chart.min.css",
                "~/Content/select.min.css",
                "~/Content/site.css"));
            BundleTable.EnableOptimizations = true;
        }
    }
}
