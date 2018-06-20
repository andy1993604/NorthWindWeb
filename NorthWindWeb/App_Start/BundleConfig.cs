using System.Web;
using System.Web.Optimization;

namespace NorthWindWeb
{
    public class BundleConfig
    {
        // 如需統合的詳細資訊，請瀏覽 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // 準備好可進行生產時，請使用 https://modernizr.com 的建置工具，只挑選您需要的測試。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      //"~/Scripts/bootstrap.js",
                      "~/Scripts/formValidation.min.js",
                      "~/Scripts/bootstrap3.2.0.min.js",
                      "~/Scripts/framework/bootstrapvalidation.min.js",
                      "~/Scripts/respond.js"));
            bundles.Add(new ScriptBundle("~/bundles/Kendo").Include(
                      "~/Scripts/Kendo/kendo.all.min.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap3.2.0.min.css",
                      //"~/Content/bootstrap-theme3.3.2.min.css",
                      "~/Content/formValidation.min.css",
                      //"~/Content/bootstrap.css",  
                     // "~/Content/site.css",
                      "~/Content/boo.css"
                    ));
            bundles.Add(new ScriptBundle("~/bundles/validate").Include(
                     // "~/Scripts/jquery.validate.min.js",
                     // "~/Scripts/jquery.validate.unobtrusive.min.js"
                     ));
            bundles.Add(new StyleBundle("~/Content/Kendo").Include(
                      "~/Content/Kendo/kendo.common-office365.min.css",
                      "~/Content/Kendo/kendo.office365.min.css"));
        }
    }
}
