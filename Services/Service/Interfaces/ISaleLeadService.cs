using Domain.Models;
using Services.Service.Models.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service.Interfaces
{
    public interface ISaleLeadService
    {
        SaleLead CreateSaleLead(int customerId, int stateId, int saleId, DateTime timestamp);
        SaleLead UpdateLead(int leadId, int stateId, int saleId, int customerId, DateTime timestamp);
        void DeleteLead(int leadId);
        IEnumerable<SaleLead> ListSaleLeads(int customerId);
        IQueryable<SaleLead> AsQueryable();
        IEnumerable<LeadActionDTO> ListLeadActions();
        LeadActionDTO RegisterLeadAction(DateTime nextContact, string notes, DateTime end, CustomerDTO cus, SaleDTO sale, EmployeeDTO emp);
        LeadActionDTO UpdateLeadAction(int actionId, string notes, DateTime nextContact, DateTime end, int splId);
        SalePositionLeadAction FetchLeadAction(int actionId);
        SalePositionLead FindOrCreateSalePositionLead(SaleLead saleLead);
        SaleLead FindOrCreateSaleLead(CustomerDTO cus, int orderNo, EmployeeDTO emp);
        void UpdateSalePositionLead(SalePositionLead emp, Boolean finalised);
        void RemoveLeadAction(int actionId);
        void ConvertSaleLead();



    }
}
