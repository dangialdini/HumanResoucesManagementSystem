using System;
using System.Linq;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Position
    {
        public Position()
        {
            this.EmployeeInPositions = new List<EmployeeInPosition>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<EmployeeInPosition> EmployeeInPositions { get; set; }

        public virtual EmployeeInPosition RegisterEmployee(Employee e, bool active)
        {
            var emp = this.EmployeeInPositions.FirstOrDefault(p => p.EmployeeId == e.Id);

            if (emp != null)
            {
                return emp;
            }

            emp = new EmployeeInPosition
            {
                PositionId = this.Id,
                EmployeeId = e.Id,
                Active = active

            };

            EmployeeInPositions.Add(emp);
            return emp; ;
        }
     
    }
}