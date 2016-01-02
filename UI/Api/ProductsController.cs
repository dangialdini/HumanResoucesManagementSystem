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
    public class ProductsController : ApiController
    {
        private readonly ISaleService _serviceSale;
        public ProductsController(ISaleService serviceSale)
        {
            _serviceSale = serviceSale;
        }
        [Route("api/Products/{ProductId}")]
        [HttpGet]
        public IHttpActionResult Get(int ProductId = 0)
        {
            if (ProductId == 0)
            {
                var list = _serviceSale.ListProducts();
                var vMList = new List<ProductViewModel>();
                foreach (var product in list)
                {
                    var productVM = new ProductViewModel { ProductId = product.Id, Name = product.ProductName, UnitPrice = product.UnitPrice, Description = product.Description };
                    vMList.Add(productVM);
                }
                return Ok(vMList);
            }
            else
            {
                var product = _serviceSale.FetchProduct(ProductId);
                var productVM = new ProductViewModel { ProductId = product.Id, Name = product.ProductName, UnitPrice = product.UnitPrice, Description = product.Description };
                return Ok(productVM);
            }
        }
        [HttpGet]
        public IHttpActionResult Get()
        {

            var list = _serviceSale.ListProducts();
            var vMList = new List<ProductViewModel>();
            foreach (var product in list)
            {
                var productVM = new ProductViewModel { ProductId = product.Id, Name = product.ProductName, UnitPrice = product.UnitPrice, Description = product.Description };
                vMList.Add(productVM);
            }
            return Ok(vMList);

        }
        [HttpPost]
        public IHttpActionResult Post(ProductViewModel p)
        {
            var product = _serviceSale.RegisterProduct(p.Name, p.UnitPrice, p.Description);

            p.ProductId = product.Id;

            return Created<ProductViewModel>(Request.RequestUri + p.ProductId.ToString(), p);
        }
        [HttpPut]
        public IHttpActionResult Put(ProductViewModel p)
        {
            var product = _serviceSale.UpdateProduct(p.ProductId, p.Name, p.UnitPrice, p.Description);
            var productVM = new ProductViewModel { ProductId = product.Id, Name = product.ProductName, UnitPrice = product.UnitPrice, Description = product.Description };
            return Ok(productVM);
        }
        public IHttpActionResult Delete(ProductViewModel p)
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }
            else
            {
                _serviceSale.DeleteProduct(p.ProductId);
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