using System.Web.Mvc;

namespace UI.Areas.Support
{
    public class SupportAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Support";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "Support_Customer",
                url: "Support/Customer/{action}/{id}",
                defaults: new { area = "", controller = "Customer", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "UI.Controllers" }
                );

            context.MapRoute(
                name: "Support_Employee",
                url: "Support/Employee/{action}/{id}",
                defaults: new { area = "", controller = "Employee", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "UI.Controllers" }
                );

            context.MapRoute(
                name: "Support_Schedule",
                url: "Support/Schedule/{action}/{id}",
                defaults: new { area = "", controller = "Schedule", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "UI.Controllers" }
                );

            context.MapRoute(
                name: "Support_Site",
                url: "Support/Site/{action}/{id}",
                defaults: new { area = "", controller = "Site", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "UI.Controllers" }
                );

            context.MapRoute(
               name: "Support_default",
               url: "Support/{controller}/{action}/{id}",
               defaults: new { action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "UI.Areas.Support.Controllers" }
               );

            context.MapRoute(
                name: "Support_Ticket",
                url: "Support/Ticket/{action}/{id}",
                defaults: new { area = "", controller = "Ticket", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "UI.Controllers" }
                );

            context.MapRoute(
                name: "Support_SchedulerCharts",
                url: "Support/ScheduleChart/{action}/{id}",
                defaults: new { area = "", controller = "SchedulerCharts", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "UI.Controllers" }
                );
        }
    }
}