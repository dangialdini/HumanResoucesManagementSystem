using System.Web.Mvc;

namespace UI.Areas.Administration
{
    public class AdministrationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administration";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {


            context.MapRoute(
                name: "Administration_Customer",
                url: "Administration/Customer/{action}/{id}",
                defaults: new {area="",controller="Customer", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "UI.Controllers" }
            );

            context.MapRoute(
              name: "Administration_Employee",
              url: "Administration/Employee/{action}/{id}",
              defaults: new { area = "", controller = "Employee", action = "Index", id = UrlParameter.Optional },
              namespaces: new string[] { "UI.Controllers" }
          );

            context.MapRoute(
            name: "Administration_Schedule",
            url: "Administration/Schedule/{action}/{id}",
            defaults: new { area = "", controller = "Schedule", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "UI.Controllers" }
        );


            context.MapRoute(
            name: "Administration_Site",
            url: "Administration/Site/{action}/{id}",
            defaults: new { area = "", controller = "Site", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "UI.Controllers" }
        );


            context.MapRoute(
                name:"Administration_default",
                url:"Administration/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] {"UI.Areas.Administration.Controllers" }
            );
        }
    }
}