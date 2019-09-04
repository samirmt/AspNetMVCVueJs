using System.Web;
using System.Web.Optimization;

namespace vuejs
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
                        "~/Scripts/umd/popper.min.js"));
            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/vue").Include(
                      "~/Scripts/vue.js",
                      "~/Scripts/axios.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/custom.css"));

            bundles.Add(new StyleBundle("~/Content/jquerydataTables").Include(
                      "~/Content/jquery.dataTables.min.css"));
            bundles.Add(new ScriptBundle("~/bundles/jquerydataTables").Include(
                      "~/Scripts/jquery.dataTables.min.js"));
            //LOGIN
            bundles.Add(new StyleBundle("~/Content/csslogin").Include(
                    "~/Content/bootstrap.css",
                    "~/Content/Login.css",
                    "~/Content/animate.css",
                    "~/Content/fontawesome.css"));
            //TOAST
            bundles.Add(new ScriptBundle("~/bundles/toast").Include(
                      "~/Scripts/toastr.min.js"));
            bundles.Add(new StyleBundle("~/Content/toast").Include(
                    "~/Content/toastr.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/vue").Include(
                      "~/Scripts/vue.min.js", "~/Scripts/axios.min.js"));
        }
    }
}
