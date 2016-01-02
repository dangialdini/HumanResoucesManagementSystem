using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Employee : Person
    {
        public Employee()
        {
            this.EmployeeInPositions = new List<EmployeeInPosition>();
        }


        public virtual ICollection<EmployeeInPosition> EmployeeInPositions { get; set; }
    }
}
