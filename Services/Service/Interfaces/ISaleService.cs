using Domain.Models;
using Services.Service.Models.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service.Interfaces
{
    public interface ISaleService
    {
        IEnumerable<Product> ListProducts();
        Product RegisterProduct(string name, decimal price, string description);
        Product UpdateProduct(int id, string name, decimal price, string description);
        Product FetchProduct(int id);
        void DeleteProduct(int id);

        //void GenerateSaleData();

        List<SaleDTO> ListSales(int CustomerId);
        SaleDTO RegisterSale(DateTime date, int orderNo, CustomerDTO cus, Boolean finalised, int empId);
        Sale FetchSale(int id);
        SaleDTO UpdateSale(int id, DateTime date, int orderNo, CustomerDTO cus, Boolean finalised, int EmpId);
        void DeleteSale(int id);
        SaleDTO ConvertToDTO(Sale sale, Boolean finalised, SalePositionLead emp, CustomerDTO cus = null);
        SalePositionLead FindOrCreateSalePositionLead(Sale sale, CustomerDTO cus);
        void UpdateSalePositionLead(SalePositionLead emp, Boolean finalised);
        Sale FindOrCreateSaleLead(CustomerDTO cus, int orderNo, DateTime date, Boolean finalised);

        IEnumerable<SaleLineItem> ListSaleLineItems(int saleId);
        SaleLineItem RegisterSaleLineItem(int productId, int saleId, int qty, decimal amount);
        SaleLineItem FetchSaleLineItem(int id);
        SaleLineItem UpdateSaleLineItem(int id, int productId, int saleId, int qty, decimal amount);
        void DeleteSaleLineItem(int id);

        IEnumerable<Customer> GetAllCustomers();
        IEnumerable<EmployeeInPosition> GetAllEmployees();
        List<KPIDTO> GetGrossSaleComp();
        List<KPIDTO> GetGrossSaleCompDate();
        List<KPIDTO> GetCusSaleComp();

    }
}
