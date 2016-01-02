using Kendo.Mvc.UI; //remove to remove filters
using Services.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UI.Models.Sales;

namespace UI.Api
{
    public class SaleLineItemsController : ApiController
    {
        private readonly ISaleService _serviceSale;
        public SaleLineItemsController(ISaleService serviceSale)
        {
            _serviceSale = serviceSale;
        }

        [HttpGet]
        [Route("api/Sales/{SaleId}/SaleLineItems")]
        public IHttpActionResult Get([DataSourceRequest] DataSourceRequest request, int SaleId = 0)
        {
            var list = _serviceSale.ListSaleLineItems(SaleId);
            var sliWViewModel = new List<SaleLineItemViewModel>();
            foreach (var sli in list)
            {
                var product = _serviceSale.FetchProduct(sli.ProductId);
                var vm = new SaleLineItemViewModel { UnitPrice = product.UnitPrice, Subtotal = sli.Amount * sli.Qty, SaleLineItemId = sli.Id, saleId = sli.SaleId, Qty = sli.Qty, Amount = sli.Amount, Product = new ProductViewModel { ProductId = product.Id, Name = product.ProductName } };
                sliWViewModel.Add(vm);
            }
            return Ok(sliWViewModel);
        }
        [HttpPost]
        [Route("api/SaleLineItems/{SaleId}/Sale")]
        public IHttpActionResult Post(SaleLineItemViewModel model, int SaleId = 0)
        {
            var sli = _serviceSale.RegisterSaleLineItem(model.Product.ProductId, SaleId, model.Qty, model.Amount);
            var product = _serviceSale.FetchProduct(sli.ProductId);
            var vm = new SaleLineItemViewModel { UnitPrice = product.UnitPrice, SaleLineItemId = sli.Id, saleId = sli.SaleId, Qty = sli.Qty, Amount = sli.Amount, Product = new ProductViewModel { ProductId = product.Id, Name = product.ProductName }, Subtotal = sli.Amount * sli.Qty };
            return Ok(vm);
        }
        [HttpPut]
        public IHttpActionResult Put(SaleLineItemViewModel model)
        {
            var sli = _serviceSale.UpdateSaleLineItem(model.SaleLineItemId, model.Product.ProductId, model.saleId, model.Qty, model.Amount);
            var product = _serviceSale.FetchProduct(sli.ProductId);
            var vm = new SaleLineItemViewModel { UnitPrice = product.UnitPrice, SaleLineItemId = sli.Id, saleId = sli.SaleId, Qty = sli.Qty, Amount = sli.Amount, Product = new ProductViewModel { ProductId = product.Id, Name = product.ProductName }, Subtotal = sli.Amount * sli.Qty };
            return Ok(vm);
        }
        public IHttpActionResult Delete(SaleLineItemViewModel model)
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }
            else
            {
                _serviceSale.DeleteSaleLineItem(model.SaleLineItemId);
                return Ok();
            }
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
