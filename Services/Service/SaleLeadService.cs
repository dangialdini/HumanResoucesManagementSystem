using Domain.Models;
using Services.Repositories.Interfaces;
using Services.Service.Interfaces;
using Services.Service.Models.Sales;
using SharpRepository.Repository.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class SaleLeadService : ISaleLeadService
    {
        private readonly ISaleLeadRepository _repoSaleLead;
        private readonly ISalePositionLeadRepository _repoSalePositionLead;
        private readonly ISalePositionLeadActionRepository _repoSalePositionLeadAction;
        private readonly IEmployeeInPositionRepository _repoEmployeeInPosition;
        private readonly ICustomerRepository _repoCustomer;
        private readonly ISaleRepository _repoSale;
        private readonly ISaleLeadStateRepository _repoSaleLeadState;
        public SaleLeadService(ISaleLeadRepository repoSaleLead, ISalePositionLeadRepository repoSalePositionLead, ISalePositionLeadActionRepository repoSalePositionLeadAction, IEmployeeInPositionRepository repoEmployeeInPosition, ICustomerRepository repoCustomer, ISaleRepository repoSale, ISaleLeadStateRepository repoSaleLeadState)
        {
            _repoSaleLead = repoSaleLead;
            _repoSalePositionLead = repoSalePositionLead;
            _repoSalePositionLeadAction = repoSalePositionLeadAction;
            _repoEmployeeInPosition = repoEmployeeInPosition;
            _repoCustomer = repoCustomer;
            _repoSale = repoSale;
            _repoSaleLeadState = repoSaleLeadState;
        }

        #region SaleLead
        public SaleLead CreateSaleLead(int customerId, int stateId, int saleId, DateTime timestamp)
        {
            if (saleId == 0)
            {
                var sale = new Sale { OrderNumber = 0, Date = DateTime.Now };
                _repoSale.Add(sale);
                var addedSale = _repoSale.AsQueryable().Where(o => o.OrderNumber == 0).ToList();
                saleId = addedSale.First().Id;
            }
            var lead = new SaleLead { CustomerId = customerId, StateId = stateId, SaleId = saleId, Timestamp = timestamp };
            _repoSaleLead.Add(lead);
            return lead;
        }

        public SaleLead UpdateLead(int leadId, int stateId, int saleId, int customerId, DateTime timestamp)
        {
            var lead = _repoSaleLead.Get(leadId);

            lead.Id = leadId;
            lead.StateId = stateId;
            lead.SaleId = saleId;
            lead.CustomerId = customerId;
            lead.Timestamp = timestamp;

            _repoSaleLead.Update(lead);

            return lead;
        }

        public void DeleteLead(int leadId)
        {
            SaleLead lead = _repoSaleLead.Get(leadId);
            List<SalePositionLead> leadpos = lead.SalePositionLeads.ToList();
            foreach (var pos in leadpos)
            {
                List<SalePositionLeadAction> leadposacts = pos.SalePositionLeadActions.ToList();
                _repoSalePositionLeadAction.Delete(leadposacts);
            }

            _repoSalePositionLead.Delete(leadpos);
            _repoSaleLead.Delete(lead);
        }

        public IEnumerable<SaleLead> ListSaleLeads(int customerId)
        {
            var spec = new Specification<SaleLead>(c => c.Customer.Id == customerId);
            var list = _repoSaleLead.FindAll(spec);
            return list;
        }
        public IQueryable<SaleLead> AsQueryable()
        {
            return _repoSaleLead.AsQueryable();
        }

        #endregion


        //public SaleLead RegisterSaleLead(int stateId, int customerId, int saleId)
        //{
        //    var lead = new SaleLead { StateId = stateId, CustomerId = customerId, SaleId = saleId };
        //    _repoSaleLead.Add(lead);
        //    return lead;
        //}

        public SalePositionLead AssignSalesEmployee(int employeeInSalesPositionId, int leadId)
        {
            var eip = _repoEmployeeInPosition.Get(employeeInSalesPositionId);
            var lead = _repoSaleLead.Get(leadId);
            var salesPositionLead = new SalePositionLead { EmployeeInSalePosition = (eip as EmployeeInSalePosition), SaleLead = lead };
            _repoSalePositionLead.Add(salesPositionLead);
            return salesPositionLead;
        }

        #region Lead Actions
        public IEnumerable<LeadActionDTO> ListLeadActions()
        {
            var actions = _repoSalePositionLeadAction.GetAll();
            var actionsDTO = new List<LeadActionDTO>();
            foreach (var a in actions)
            {
                var customer = _repoCustomer.AsQueryable().FirstOrDefault(x => x.Id == a.SalePositionLead.SaleLead.Customer.Id);
                var dto = new LeadActionDTO { ActionId = a.Id, Title = a.Notes, Employee = new EmployeeDTO { EmployeeId = a.SalePositionLead.EmployeeInSalePosition.Employee.Id, EmployeeName = a.SalePositionLead.EmployeeInSalePosition.Employee.Lastname + ", " + a.SalePositionLead.EmployeeInSalePosition.Employee.Firstname }, SalePositionLeadId = a.SalePositionLeadId, CustomerId = customer.Id, CustomerName = customer.Name, Sale = new SaleDTO { SaleId = a.SalePositionLead.SaleLead.Sale.Id, OrderNumber = a.SalePositionLead.SaleLead.Sale.OrderNumber }, EndContact = a.EndContact, NextContactDate = a.NextContactDate, Timestamp = a.Timestamp };
                actionsDTO.Add(dto);
            }
            return actionsDTO;
        }

        public LeadActionDTO RegisterLeadAction(DateTime nextContact, string title, DateTime end, CustomerDTO cus, SaleDTO sale, EmployeeDTO emp)
        {
            var saleLead = FindOrCreateSaleLead(cus, sale.OrderNumber, emp);
            var salePositionLead = FindOrCreateSalePositionLead(saleLead);
            var leadAction = new SalePositionLeadAction { SalePositionLead = salePositionLead, SalePositionLeadId = salePositionLead.Id, NextContactDate = nextContact, Notes = title, EndContact = end, Timestamp = DateTime.Now };
            _repoSalePositionLeadAction.Add(leadAction);
            var dtoTwo = new LeadActionDTO { ActionId = leadAction.Id, Title = leadAction.Notes, Employee = new EmployeeDTO { EmployeeId = leadAction.SalePositionLead.EmployeeInSalePosition.Employee.Id, EmployeeName = leadAction.SalePositionLead.EmployeeInSalePosition.Employee.Lastname + ", " + leadAction.SalePositionLead.EmployeeInSalePosition.Employee.Firstname }, CustomerId = cus.CustomerId, CustomerName = cus.CustomerName, Sale = new SaleDTO { SaleId = sale.SaleId, OrderNumber = sale.OrderNumber }, SalePositionLeadId = leadAction.SalePositionLeadId, EndContact = leadAction.EndContact, NextContactDate = leadAction.NextContactDate, Timestamp = leadAction.Timestamp };
            return dtoTwo;
        }

        public SaleLead FindOrCreateSaleLead(CustomerDTO cus, int orderNo, EmployeeDTO emp)
        {
            var cusSpec = new Specification<SalePositionLead>(c => c.SaleLead.CustomerId == cus.CustomerId);
            var saleSpec = new Specification<SalePositionLead>(s => s.SaleLead.Sale.OrderNumber == orderNo);
            var cusAndSale = cusSpec.And(saleSpec);
            var lead = _repoSalePositionLead.Find(cusAndSale);
            if (lead == null)
            {
                var cusNameSpec = new Specification<SalePositionLead>(c => c.SaleLead.Customer.Name == cus.CustomerName);
                var cusNameAndSale = cusNameSpec.And(saleSpec);
                lead = _repoSalePositionLead.Find(cusNameAndSale);
                if(lead == null)
                {
                    var empSpec = new Specification<SalePositionLead>(x => x.EmployeeInSalePosition.Employee.Id == emp.EmployeeId);
                    var otherCusSpec = new Specification<SalePositionLead>(v => v.SaleLead.Customer.Id == cus.CustomerId);
                    var otherAndEmp = empSpec.And(otherCusSpec);
                    lead = _repoSalePositionLead.Find(otherAndEmp);
                    if(lead==null)
                    {
                        var cusNameAndEmpSpec = empSpec.And(cusNameSpec);
                        lead = _repoSalePositionLead.Find(cusNameAndEmpSpec);
                        if(lead == null)
                        {
                            var customer = _repoCustomer.Get(cus.CustomerId);
                            var state = _repoSaleLeadState.AsQueryable().FirstOrDefault(x => x.Id > 0);
                            var l = CreateSaleLead(customer.Id, state.Id, 0, DateTime.Now);
                            _repoSaleLead.Add(l);
                            return l;
                        }
                        else
                        {
                            return lead.SaleLead;
                        }
                        
                    }
                    else
                    {
                        return lead.SaleLead;
                    }
                    
                }
                else
                {
                    return lead.SaleLead;
                }
                
            }
            else
            {
                return lead.SaleLead;
            }
        }
        public LeadActionDTO UpdateLeadAction(int actionId, string notes, DateTime nextContact, DateTime end, int splId)
        {
            var spl = _repoSalePositionLead.Get(splId);
            var action = _repoSalePositionLeadAction.Get(actionId);
            action.Notes = notes;
            action.NextContactDate = nextContact;
            action.EndContact = end;
            action.SalePositionLead = spl;
            action.SalePositionLeadId = splId;
            _repoSalePositionLeadAction.Update(action);
            var dto = new LeadActionDTO { ActionId = action.Id, Title = action.Notes, Employee = new EmployeeDTO { EmployeeId = action.SalePositionLead.EmployeeInSalePosition.Employee.Id, EmployeeName = action.SalePositionLead.EmployeeInSalePosition.Employee.Lastname + ", " + action.SalePositionLead.EmployeeInSalePosition.Employee.Firstname }, SalePositionLeadId = action.SalePositionLeadId, EndContact = action.EndContact, NextContactDate = action.NextContactDate, Timestamp = action.Timestamp, CustomerId = action.SalePositionLead.SaleLead.Customer.Id, CustomerName = action.SalePositionLead.SaleLead.Customer.Name, Sale = new SaleDTO { SaleId = action.SalePositionLead.SaleLead.Sale.Id, OrderNumber = action.SalePositionLead.SaleLead.Sale.OrderNumber } };
            return dto;
        }
        public SalePositionLeadAction FetchLeadAction(int actionId)
        {
            var action = _repoSalePositionLeadAction.Get(actionId);
            return action;
        }
        public void RemoveLeadAction(int actionId)
        {
            _repoSalePositionLeadAction.Delete(actionId);
        }

        public SalePositionLead FindOrCreateSalePositionLead(SaleLead saleLead)
        {
            var empSaleSpec = new Specification<SalePositionLead>(s => s.SaleLead.Id == saleLead.Id);
            var emp = _repoSalePositionLead.Find(empSaleSpec);
            if (emp == null)
            {
                var empPos = _repoEmployeeInPosition.GetEmployeeInSalePosition().FirstOrDefault(s => s.Position.Name == "Sales");
                emp = new SalePositionLead { FinalisedSale = false, SaleLead = saleLead, SaleLeadId = saleLead.Id, EmployeeInSalePosition = empPos, EmployeeInSalePostionId = empPos.Id };
                _repoSalePositionLead.Add(emp);
            }
            return emp;
        }
        public void UpdateSalePositionLead(SalePositionLead emp, Boolean finalised)
        {
            emp.FinalisedSale = finalised;
            _repoSalePositionLead.Update(emp);
        }

        #endregion

        public void ConvertSaleLead()
        {

        }
    }
}
