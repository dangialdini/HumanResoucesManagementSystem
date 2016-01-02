using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Project_Development
    {
        public Project_Development()
        {
            this.Task_Development = new List<Task_Development>();
        }

        public int Id { get; set; }
        public int EnhancementRequestId { get; set; }
        public int ManagerId { get; set; }
        public System.DateTime Start { get; set; }
        public System.DateTime Finish { get; set; }
        public virtual EmployeeInDevelopmentPosition EmployeeInDevelopmentPosition { get; set; }
        public virtual EnhancementRequest EnhancementRequest { get; set; }        
        public virtual ICollection<Task_Development> Task_Development { get; set; }
    }
}
