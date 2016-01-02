using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class EmployeeInDevelopmentPosition : EmployeeInPosition
    {
        public EmployeeInDevelopmentPosition()
        {
            this.Project_Development = new List<Project_Development>();
            this.Task_Development = new List<Task_Development>();
        }

        public virtual ICollection<Project_Development> Project_Development { get; set; }
        public virtual ICollection<Task_Development> Task_Development { get; set; }


        public override EmployeeInPosition.PositionType Role
        {
            get { return PositionType.Development; }
        }
    }
}
