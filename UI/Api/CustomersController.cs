using Domain.Models;
using System.Linq;
using Services.Service.Interfaces;
using Services.Repositories.Interfaces;
using Kendo.Mvc.UI;
using UI.Areas.Management.Models;
using System.Web.Http;
using System.Net.Http;
using System;



namespace UI.Api
{
    public class CustomersController : ApiController
    {
        private ICustomerService _customerService;
        private ICustomerRepository _customerRepository;
        private HRMSDBContext _context;
        private ICompanyRepository _companyRepository;


        public CustomersController(ICustomerService customerService, ICustomerRepository customerRepository, ICompanyRepository companyRepository, HRMSDBContext context)
        {
            _customerRepository = customerRepository;
            _companyRepository = companyRepository;
            _customerService = customerService;
            _context = context;

        }
        [Route("api/CustomersPerSuburb")]
        [HttpGet]
        public IHttpActionResult GetCustomersPerSuburb()
        {
            //var [] count = new 
            var model = _customerRepository.AsQueryable()
                .Select(c => new
                {
                    Id = c.Id,
                    Name = c.Name
                    //need to Fetch customer count for CustomerSite where its equal to a  == zone         

                }).ToList();

            return Ok(model);
        }

        //[Route("api/Companies")]
        //[HttpGet]
        //public IHttpActionResult GetCustomerCompanies()
        //{

        //    var model = _companyRepository.AsQueryable()
        //        .Select((c) => new
        //        {
        //            Name = c.Name

        //        }).ToList();

        //    return Ok(model);
        //}

        //GET: Customers
        public IHttpActionResult Get()
        {
            var result = _customerRepository.GetAll((p) => new ManagementCustomerViewModel()
            {
                Id = p.Id,
                CompanyId = p.CompanyId,
                Name = p.Name,
                Abn = p.Abn,
                Franchise = p.Franchise,
                Phone = p.Phone,
                Email = p.Email,

            }).ToList();

            return Ok(result);
        }

        public IHttpActionResult Get(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var model = _customerRepository.Get(id.Value, (p) => new ManagementCustomerViewModel()
            {
                Id = p.Id,
                CompanyId = p.CompanyId,
                Name = p.Name,
                Abn = p.Abn,
                Franchise = p.Franchise,
                Phone = p.Phone,
                Email = p.Email,
            });

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        ////OLD GET BEFORE SPA - WORKING/<controller>
        //[HttpGet]
        //public IHttpActionResult Get([DataSourceRequest] DataSourceRequest request)
        //{
        //    var result = _context.Customers
        //        .Select(p => new ManagementCustomerViewModel()
        //        {
        //            Id = p.Id,
        //            CompanyId = p.CompanyId,
        //            Name = p.Name,
        //            Abn = p.Abn,
        //            Franchise = p.Franchise,
        //            Phone = p.Phone,
        //            Email = p.Email

        //        });
        //    return Ok(result.ToList());
        //}

        //POST:
        [HttpPost]

        public IHttpActionResult Post(ManagementCustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = _customerService.RegisterCustomer(
                    companyId: model.CompanyId,
                    name: model.Name,
                    abn: model.Abn,
                    franchise: model.Franchise,
                    phone: model.Phone,
                    email: model.Email);

                model.Id = customer.Id;

                return Created<ManagementCustomerViewModel>(Request.RequestUri + model.Id.ToString(), model);
            }

            return BadRequest(ModelState);

        }

        //PUT:
        [HttpPut]

        public IHttpActionResult Update(ManagementCustomerViewModel model)
        {
            if (ModelState.IsValid)

                try
                {
                    var customer = _customerService.UpdateDetails(
                        id: model.Id,
                        name: model.Name,
                        abn: model.Abn,
                        franchise: model.Franchise,
                        phone: model.Phone,
                        email: model.Email);

                    return Ok(model);

                    //return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
                }
                catch (InvalidOperationException ex)
                {

                    return BadRequest(ex.Message);
                }

            {
                return BadRequest(ModelState);
            }
        }





        //DELETE:
        [HttpDelete]
        public IHttpActionResult Delete(ManagementCustomerViewModel model)
        {
            try
            {
                _customerService.DeleteCustomer(model.Id);

                return Ok();
            }
            catch (InvalidOperationException ex)
            {

                return BadRequest(ex.Message);
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
