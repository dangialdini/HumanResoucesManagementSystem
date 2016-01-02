using System.Web.Mvc;

namespace UI.Areas.Management
{
    public class ManagementAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Management";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {

            context.MapRoute(
               name: "Management_Customer",
               url: "Management/Customer/{action}/{id}",
               defaults: new { area = "Management", controller = "Customer", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "UI.Controllers" }
           );

            context.MapRoute(
              name: "Management_Employee",
              url: "Management/Employee/{action}/{id}",
              defaults: new { area = "", controller = "Employee", action = "Index", id = UrlParameter.Optional },
              namespaces: new string[] { "UI.Controllers" }
           );

            context.MapRoute(
               name: "Management_Address",
               url: "Management/Address/{action}/{id}",
               defaults: new { area = "Management", controller = "Address", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "UI.Controllers" }
           );

            context.MapRoute(
              name: "Management_EnhancementRequest",
              url: "Management/EnhancementRequest/{action}/{id}",
              defaults: new { area = "Management", controller = "EnhancementRequest", action = "Index", id = UrlParameter.Optional },
              namespaces: new string[] { "UI.Controllers" }
          );
            context.MapRoute(
               name: "Management_Position",
               url: "Management/Position/{action}/{id}",
               defaults: new { area = "Management", controller = "Position", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "UI.Areas.Management.Controllers" }
          );

            context.MapRoute(
               name: "Management_ProjectDevelopment",
               url: "Management/ProjectDevelopment/{action}/{id}",
               defaults: new { area = "Management", controller = "ProjectDevelopment", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "UI.Controllers" }
           );

            context.MapRoute(
               name: "Management_Sales",
               url: "Management/Sales/{action}/{id}",
               defaults: new { area = "Management", controller = "Sales", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "UI.Controllers" }
           );

            context.MapRoute(
               name: "Management_Schedule",
               url: "Management/Schedule/{action}/{id}",
               defaults: new { area = "", controller = "Schedule", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "UI.Controllers" }
          );


            context.MapRoute(
               name: "Management_Site",
               url: "Management/Site/{action}/{id}",
               defaults: new { area = "Management", controller = "Site", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "UI.Controllers" }
          );


            context.MapRoute(
               name: "Management_default",
               url: "Management/{controller}/{action}/{id}",
               defaults: new { action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "UI.Areas.Management.Controllers" }
           );
        }
    }
}