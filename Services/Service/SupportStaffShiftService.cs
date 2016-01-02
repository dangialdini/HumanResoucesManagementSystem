using Services.Repositories.Interfaces;
using Services.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Models;

namespace Services.Service
{
    public class SupportStaffShiftService : ISupportStaffShiftService
    {
        private readonly ISupportStaffShiftRepository _repoSupportStaffShift;
        private readonly IEmployeeInPositionRepository _repoEmpInSupportPos;
        private readonly IOfficeRepository _repoOffice;

        public SupportStaffShiftService(ISupportStaffShiftRepository repoSupportStaffShift, IEmployeeInPositionRepository repoEmployeeInPosition, IOfficeRepository repoOffice)
        {
            _repoSupportStaffShift = repoSupportStaffShift;
            _repoEmpInSupportPos = repoEmployeeInPosition;
            _repoOffice = repoOffice;
        }

        public IQueryable<SupportStaffShift> AsQueryable()
        {
            return _repoSupportStaffShift.AsQueryable();
        }
      
        public IQueryable<EmployeeInSupportPosition> EmpInSuppPosAsQueryable()
        {
            return _repoEmpInSupportPos.GetEmployeesInSupportPosition();
        }

        public SupportStaffShift Insert(DateTime start, DateTime end, string description, int empId, string color, string title, int recurrenceId, string recurrenceException, string recurrenceRule)
        {
            var entity = new SupportStaffShift
            {                
                StartTime = start,
                EndTime = end,
                Description = description,
                EmployeeInSupportPositionId = empId,
                Color = color,
                Title = title,
                RecurrenceId = recurrenceId,
                RecurrenceException = recurrenceException,
                RecurrenceRule = recurrenceRule
            };

            var specification = new SharpRepository.Repository.Specifications.Specification<EmployeeInPosition>(e=>e.Id == empId);
            specification.FetchStrategy = specification.FetchStrategy.Include(e => e.Employee);
            var employeeInSupportPosition = _repoEmpInSupportPos.Find(specification);
 
            _repoSupportStaffShift.Add(entity);
            return entity;
        }

        public SupportStaffShift Update(int id, DateTime start, DateTime end, string description, int empId, string color, string title, int recurrenceId, string recurrenceException, string recurrenceRule)
        {
            var entity = _repoSupportStaffShift.Get(id);

            entity.Id = id;
            entity.StartTime = start;
            entity.EndTime = end;
            entity.Description = description;
            entity.EmployeeInSupportPositionId = empId;
            entity.Color = color;
            entity.Title = title;
            entity.RecurrenceId = recurrenceId;
            entity.RecurrenceException = recurrenceException;
            entity.RecurrenceRule = recurrenceRule;
            _repoSupportStaffShift.Update(entity);
            return entity;
        }

        public void Delete(int id)
        {
            var entity = _repoSupportStaffShift.Get(id);
            _repoSupportStaffShift.Delete(entity);          
        }

    }
}
