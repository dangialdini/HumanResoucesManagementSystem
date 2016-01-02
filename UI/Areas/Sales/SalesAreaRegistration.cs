using System.Web.Mvc;

namespace UI.Areas.Sales
{
    public class SalesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Sales";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            context.MapRoute(
              name: "Sales_Customer",
              url: "Sales/Customer/{action}/{id}",
              defaults: new { area = "", controller = "Customer", action = "Index", id = UrlParameter.Optional },
              namespaces: new string[] { "UI.Controllers" }
          );

            context.MapRoute(
              name: "Sales_Employee",
              url: "Sales/Employee/{action}/{id}",
              defaults: new { area = "", controller = "Employee", action = "Index", id = UrlParameter.Optional },
              namespaces: new string[] { "UI.Controllers" }
          );

            context.MapRoute(
              name: "Sales_Site",
              url: "Sales/Site/{action}/{id}",
              defaults: new { area = "", controller = "Site", action = "Index", id = UrlParameter.Optional },
              namespaces: new string[] { "UI.Controllers" }
         );

            context.MapRoute(
              name: "Sales_Schedule",
              url: "Sales/Schedule/{action}/{id}",
              defaults: new { area = "", controller = "Schedule", action = "Index", id = UrlParameter.Optional },
              namespaces: new string[] { "UI.Controllers" }
         );


            context.MapRoute(
               name: "Sales_default",
               url: "Sales/{controller}/{action}/{id}",
               defaults: new { action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "UI.Areas.Sales.Controllers" }
           );
        }
    }
}