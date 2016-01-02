using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Domain.Models;
using Services.Service.Interfaces;
using Kendo.Mvc.UI;
using UI.Areas.Management.Models;
using Services.Repositories.Interfaces;
using System.Collections.Generic;



namespace UI.Api
{
    public class SitesController : ApiController
    {
        private readonly ISiteService _serviceSite;
        private readonly ICustomerRepository _repoCustomer;
        private readonly IAddressRepository _repoAddress;

        public SitesController(ISiteService serviceSite, ICustomerRepository repoCustomer, IAddressRepository repoAddress)
        {
            _serviceSite = serviceSite;
            _repoCustomer = repoCustomer;
            _repoAddress = repoAddress;
        }

        [HttpGet]
        public IHttpActionResult GetSite()
        {
            var result = _serviceSite.AsQueryable()
                .Select(s => new
                {
                    s.Id,
                    s.AddressId,
                    s.CustomerId,
                    CustomerName = s.Customer.Name,
                    StreetAddress = s.Address.Street1,
                    Suburb = s.Address.Suburb.Name,
                    State = s.Address.Suburb.State.Name,
                    s.HeadQuarters,
                    s.Franchise,
                    s.Email,
                    s.Name,
                    s.Phone
                }).ToList();
            return Ok(result);
        }

        [Route("api/SiteCustomers")]
        [HttpGet]
        public IHttpActionResult GetSiteCustomers()
        {
            var model = _repoCustomer.AsQueryable()
                .Select(c => new
                {
                    Id = c.Id,
                    Name = c.Name

                }).ToList();

            return Ok(model);
        }

        [Route("api/SiteAddresses")]
        [HttpGet]
        public IHttpActionResult GetSiteAddresses(FilterRequest filter)
        {
            var model = _repoAddress.AsQueryable()
                .Select(a => new
                {
                    Id = a.Id,
                    Street1 = a.Street1,
                    Suburb = a.Suburb.Name,
                    Postcode = a.Suburb.Postcode,
                    State = a.Suburb.State.Name
                }).ToList();

            return Ok(model);
        }

        //Get Suburb Coordinates
        [Route("api/GetLocation")]
        [HttpGet]
        public IHttpActionResult GetSiteSuburb(int Id)
        {
            var model = _serviceSite.AsQueryable().Where(s => s.Id == Id)
                .Select(s => new
                {

                    Latitude = s.Address.Suburb.Latitude,
                    Longitude = s.Address.Suburb.Longitude,

                }).ToList();
            return Ok(model);
        }


        [Route("~/api/customer/{customerId}/sites")]
        public IHttpActionResult Get(int customerId, [DataSourceRequest] DataSourceRequest request)
        {

            var result = _serviceSite.AsQueryable().Where(s => s.CustomerId == customerId)
                .Select(s => new { Id = s.Id, CustomerId = s.CustomerId, Email = s.Email, Name = s.Name, Phone = s.Phone, Franchise = s.Franchise, HeadQuarters = s.HeadQuarters });
            return Ok(result.ToList());

        }

        //POST:
        [HttpPost]
        [ResponseType(typeof(Site))]
        public IHttpActionResult PostSite(ManagementSiteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var site = _serviceSite.CreateSite(model.CustomerId, model.AddressId, model.Name, model.Phone, model.Email, model.Franchise, model.HeadQuarters);
            model.Id = site.Id;
            model.CustomerName = site.Customer.Name;
            return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);

        }



        [HttpPut]
        public IHttpActionResult PutSite(Site site)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _serviceSite.UpdateDetails(site.Id, site.Name, site.Phone, site.Email, site.Franchise, site.HeadQuarters);

            return Ok(site);
        }


        //DELETE:
        [ResponseType(typeof(Site))]
        public IHttpActionResult DeleteSite(Site site)
        {
            _serviceSite.DeleteSite(site.Id);

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }

    public class FilterRequest
    {
        public string Logic { get; set; }
        public List<FilterRule> Filters { get; set; }
    }

    public class FilterRule
    {
        public string Value { get; set; }
        public string Field { get; set; }
        public string Operator { get; set; }
        public string IgnoreCase { get; set; }
    }
}
