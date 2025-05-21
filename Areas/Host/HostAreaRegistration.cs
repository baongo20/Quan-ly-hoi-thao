using System.Web.Mvc;

namespace Do_An.Areas.Host
{
    public class HostAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Host";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Host_default",
                "Host/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Do_An.Areas.Host.Controllers" } // Thêm namespace
            );
        }
    }
}