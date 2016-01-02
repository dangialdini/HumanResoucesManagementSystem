using System.Web.Mvc;

namespace UI.Areas.Development
{
    public class DevelopmentAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Development";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            context.MapRoute(
            name: "Development_Customer",
            url: "Development/Customer/{action}/{id}",
            defaults: new { area = "", controller = "Customer", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "UI.Controllers" }
        );
            context.MapRoute(
             name: "Development_Employee",
             url: "Development/Employee/{action}/{id}",
             defaults: new { area = "", controller = "Employee", action = "Index", id = UrlParameter.Optional },
             namespaces: new string[] { "UI.Controllers" }
         );

            context.MapRoute(
               name: "Development_Schedule",
               url: "Development/Schedule/{action}/{id}",
               defaults: new { area = "", controller = "Schedule", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "UI.Controllers" }
          );

            context.MapRoute(
              name: "Development_Site",
              url: "Development/Site/{action}/{id}",
              defaults: new { area = "", controller = "Site", action = "Index", id = UrlParameter.Optional },
              namespaces: new string[] { "UI.Controllers" }
         );

            context.MapRoute(
          name: "Development_EnhancementRequest",
          url: "Development/EnhancementRequest/{action}/{id}",
          defaults: new { area = "", controller = "EnhancementRequest", action = "Index", id = UrlParameter.Optional },
          namespaces: new string[] { "UI.Areas.Development.Controllers" }
      );


            context.MapRoute(
                name:"Development_default",
                url:"Development/{controller}/{action}/{id}",
                defaults:new { action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "UI.Areas.Development.Controllers"}
            );
        }
    }
}