using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Position_Support : Position
    {

        public override EmployeeInPosition RegisterEmployee(Employee e, bool active)
        {
            var eip = new EmployeeInSupportPosition { Employee = e, Position = this, Active = active };
            this.EmployeeInPositions.Add(eip);
            return eip;
        }
    }
}
