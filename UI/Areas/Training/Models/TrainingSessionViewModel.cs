using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Areas.Trainings.Models
{
    public class TrainingSessionViewModel : ISchedulerEvent
    {
     
        public int Id { get; set; }
        public int SiteId { get; set; }
        public int TrainingId { get; set; }
        public Nullable<int> EmployeeTrainerId { get; set; }
        public string EmployeeTrainerName { get; set; }
        public System.DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int DurationInMinutes { get; set; }
        public bool Delivered { get; set; }
        public string StartTimezone { get; set; }
        public string EndTimezone { get; set; }
        public int RecurrenceId { get; set; }
        public string RecurrenceRule { get; set; }
        public string RecurrenceException { get; set; }
        public bool IsAllDay { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
    public class SiteListModel
    {
        public int SiteId { get; set; }
        public string siteName { get; set; }
    }
    public class EmployeeListModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Title { get; set; }
    }
    public class TrainingListModel
    {
        public int TrainingId { get; set; }
        public string TrainingName { get; set; }
    }
}