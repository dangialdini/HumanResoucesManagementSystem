using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class EmployeeInSupportPosition : EmployeeInPosition
    {
        public EmployeeInSupportPosition()
        {
            this.SupportStaffShift = new List<SupportStaffShift>();
        }

        public virtual ICollection<SupportStaffShift> SupportStaffShift { get; set; }


        public override EmployeeInPosition.PositionType Role
        {
            get { return PositionType.Support; }
        }
    }
}
