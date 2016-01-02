using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Task_Development
    {
        public Task_Development()
        {
            this.Task_Development1 = new List<Task_Development>();
            this.Task_Development2 = new List<Task_Development>();
        }

        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int DeveloperId { get; set; }
        public string Description { get; set; }
        public System.DateTime Start { get; set; }
        public System.DateTime Finish { get; set; }
        public virtual EmployeeInDevelopmentPosition EmployeeInDevelopmentPosition { get; set; }
        public virtual Project_Development Project_Development { get; set; }
        public virtual ICollection<Task_Development> Task_Development1 { get; set; }
        public virtual ICollection<Task_Development> Task_Development2 { get; set; }
    }
}
