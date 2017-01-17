using System.Web;
using System.Web.Optimization;

namespace AutoAuction.WEB
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery-ui.min.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/bootbox.min.js",
                "~/Scripts/moment.js",                           
                "~/Scripts/respond.js",
                "~/Scripts/datatables/jquery.datatables.js",
                "~/Scripts/datatables/datatables.bootstrap.js",
                "~/Scripts/datatables/dataTables.fixedColumns.min.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/fancybox").Include(
                "~/Scripts/fancybox/jquery.mousewheel-3.0.6.pack",
                "~/Scripts/fancybox/jquery.fancybox.js",
                "~/Scripts/fancybox/jquery.fancybox.pack"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap-darkly.css",
                "~/Content/jquery.bxslider.css",
                "~/Content/jquery-ui.min.css",
                "~/Content/jquery-ui.theme.min.css",
                "~/Content/jquery-ui.structure.min.css",
                "~/Content/fancybox/jquery.fancybox.css",
                "~/Content/datatables/css/datatables.bootstrap.css",
                "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/datetime/css").Include(
                "~/Content/jquery-ui.min.css",
                "~/Content/jquery-ui.theme.min.css",
                "~/Content/jquery-ui.structure.min.css"
                ));                 
        }
    }
}
