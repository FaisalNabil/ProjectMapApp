using System.Web;
using System.Web.Optimization;

namespace MangroveSpace
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/assets/back_assets/css").IncludeDirectory(
                "~/assets/back_assets/css", "*.css", true));

            bundles.Add(new ScriptBundle("~/assets/back_assets/js").IncludeDirectory(
                "~/assets/back_assets/js", "*.js", true));

            /* Alloy Editor */

            bundles.Add(new StyleBundle("~/assets/front_assets/libs/alloy-editor/assets").Include(
            "~/assets/front_assets/libs/alloy-editor/assets/alloy-editor-ocean-min.css"));

            bundles.Add(new ScriptBundle("~/assets/front_assets/libs/alloy-editor").Include(
                        "~/assets/front_assets/libs/alloy-editor/alloy-editor-all-min.js"));


            /* MapApp */
            bundles.Add(new StyleBundle("~/assets/front_assets/MapApp/css").IncludeDirectory(
                "~/assets/front_assets/MapApp/css", "*.css", true));

            bundles.Add(new ScriptBundle("~/assets/front_assets/MapApp/js").IncludeDirectory(
                "~/assets/front_assets/MapApp/js", "*.js", true));




            BundleTable.EnableOptimizations = false;
        }
    }
}
