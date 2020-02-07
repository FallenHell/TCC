using System.Web;
using System.Web.Optimization;

namespace GerenciaRH
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

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/bootstrap-theme.css"));

            //Inserção de novo layout
            bundles.Add(new StyleBundle("~/Content/materialcss").Include(
                    "~/assets/css/material-kit.min.css",
                    "~/assets/css/material-kit.css",
                    "~/assets/demo/demo.css",
                    "~/assets/css/material-kit.css?v=2.0.6"
                ));

            bundles.Add(new ScriptBundle("~/bundles/materialJs").Include(
                    "~/assets/js/core/bootstrap-material-design.js",
                    "~/assets/js/core/jquery.min.js",
                    "~/assets/js/core/popper.min.js",
                    "~/assets/js/plugins/bootstrap-datetimepicker.js",
                    "~/assets/js/plugins/jquery-sharrre.js",
                    "~/assets/js/plugins/moment.min.js",
                    "~/assets/js/plugins/nouslider.min.js",
                    "~/assets/js/material-kit.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/inputmask").Include(
            //~/Scripts/inputmask/dependencyLibs/inputmask.dependencyLib.js",  //if not using jquery
            "~/Scripts/inputmask/inputmask.js",
            "~/Scripts/inputmask/jquery.inputmask.js",
            "~/Scripts/inputmask/inputmask.extensions.js",
            "~/Scripts/inputmask/inputmask.date.extensions.js",
            //and other extensions you want to include
            "~/Scripts/inputmask/inputmask.numeric.extensions.js"));
        }
    }
}
