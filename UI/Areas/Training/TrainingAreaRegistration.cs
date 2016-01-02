using System.Web.Mvc;

namespace UI.Areas.Training
{
    public class TrainingAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Training";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {



            context.MapRoute(
              name: "Training_Customer",
              url: "Training/Customer/{action}/{id}",
              defaults: new { area = "", controller = "Customer", action = "Index", id = UrlParameter.Optional },
              namespaces: new string[] { "UI.Controllers" }
          );

            context.MapRoute(
             name: "Training_Employee",
             url: "Training/Employee/{action}/{id}",
             defaults: new { area = "", controller = "Employee", action = "Index", id = UrlParameter.Optional },
             namespaces: new string[] { "UI.Controllers" }
         );


            context.MapRoute(
             name: "Training_Schedule",
             url: "Training/Schedule/{action}/{id}",
             defaults: new { area = "", controller = "Schedule", action = "Index", id = UrlParameter.Optional },
             namespaces: new string[] { "UI.Controllers" }
        );

            context.MapRoute(
           name: "Training_Site",
           url: "Training/Site/{action}/{id}",
           defaults: new { area = "", controller = "Site", action = "Index", id = UrlParameter.Optional },
           namespaces: new string[] { "UI.Controllers" }
      );


            context.MapRoute(
               name: "Training_default",
               url: "Training/{controller}/{action}/{id}",
               defaults: new { action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "UI.Areas.Training.Controllers" }
           );
        }
    }
}