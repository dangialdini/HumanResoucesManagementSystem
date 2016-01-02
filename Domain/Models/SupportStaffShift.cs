using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public partial class SupportStaffShift
    {
        public int Id { get; set; }
        public int EmployeeInSupportPositionId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Title { get; set; }
        public virtual EmployeeInSupportPosition EmployeeInSupportPosition { get; set; }

        public Nullable<Boolean> IsAllDay { get; set; }
        public int RecurrenceId { get; set; }
        public string RecurrenceException { get; set; }
        public string RecurrenceRule { get; set; }
        public string StartTimezone { get; set; }
        public string EndTimezone { get; set; }
    }
}
