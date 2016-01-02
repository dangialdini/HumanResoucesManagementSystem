using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Areas.Development.Models
{
    public class ProjectDevelopmentViewModel
    {
        public int Id { get; set; }
        public int EnhancementRequestId { get; set; }
        public string EnhancementRequest { get; set; }
        public int ManagerId { get; set; }
        public System.DateTime Start { get; set; }
        public System.DateTime Finish { get; set; }
        public int EmployeeId { get; set; }
        public string Employee { get; set; }
        public List<TaskDevelopmentViewModel> Tasks { get; set; }
    }

    public class TaskDevelopmentViewModel
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int DeveloperId { get; set; }
        public string Description { get; set; }
        public System.DateTime Start { get; set; }
        public System.DateTime Finish { get; set; }
    }
}