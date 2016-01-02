using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Position_Training : Position
    {
        public override EmployeeInPosition RegisterEmployee(Employee e, bool active)
        {
            var eip = new EmployeeInTrainingPosition { Employee = e, Position = this, Active = active };
            this.EmployeeInPositions.Add(eip);
            return eip;
        }
    }
}
