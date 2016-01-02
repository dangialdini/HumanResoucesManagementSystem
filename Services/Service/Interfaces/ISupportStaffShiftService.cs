using Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Services.Service.Interfaces
{
    public interface ISupportStaffShiftService
    {
        IQueryable<SupportStaffShift> AsQueryable();        
        IQueryable<EmployeeInSupportPosition> EmpInSuppPosAsQueryable();
        SupportStaffShift Insert(DateTime start, DateTime end, string description, int empId, string color, string title, int recurrenceId, string recurrenceException, string recurrenceRule);
        SupportStaffShift Update(int id, DateTime start, DateTime end, string description, int empId, string color, string title, int recurrenceId, string recurrenceException, string recurrenceRule);
        void Delete(int id);
    }
}
