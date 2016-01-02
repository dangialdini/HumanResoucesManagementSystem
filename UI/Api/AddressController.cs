using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Domain.Models;
using Services.Service.Interfaces;
using Services.Repositories.Interfaces;
using Kendo.Mvc.UI;
using UI.Areas.Management.Models;

namespace UI.Api
{
    public class AddressController : ApiController
    {
        private readonly IAddressService _serviceAddress;
        private readonly IAddressRepository _addressRepository;
        private readonly ISuburbRepository _suburbRepository;
        private HRMSDBContext _context;
        public AddressController(IAddressService serviceAddress, IAddressRepository addressRepository, HRMSDBContext context, ISuburbRepository suburbRepository)
        {
            _serviceAddress = serviceAddress; 
            _addressRepository = addressRepository;
            _context = context;
            _suburbRepository = suburbRepository;
        }


        //POST:

        [ResponseType(typeof(Address))]
        public IHttpActionResult RegisterAddress(Address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _serviceAddress.Create(address.SuburbId, address.Street1); 
            return CreatedAtRoute("DefaultApi", new { id = address.Id }, address);
        }

        //GET:

        [HttpGet]
        public IHttpActionResult Get([DataSourceRequest] DataSourceRequest request)
        {
            //var result = _context.Addresses
            //    .Select(a => new
            //    {
            //        Id = a.Id,
            //        FullAddress = a.Street1 + " " + a.Suburb.Name + ", " + a.Suburb.Postcode
            //            + " " + a.Suburb.State.Name
            //    });

            var result = _context.Addresses
                .Select(a => new
                {
                    Id = a.Id,
                    a.Street1,
                    a.Street2,
                    a.SuburbId,
                    SuburbName = a.Suburb.Name
                });

            return Ok(result.ToList());
        }

        [Route("api/AddressSuburbs")]
        [HttpGet]
        public IHttpActionResult GetSuburbs()
        {
            var model = _suburbRepository.AsQueryable()
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name

                }).ToList();

            return Ok(model);
        }



        //PUT:
        [HttpPut]

        public IHttpActionResult Update(Address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _serviceAddress.UpdateDetails(address.Id, address.Street1, address.Street2, address.SuburbId);
            //return Ok(model);

            return Ok(address);
        }

        //OLD STUFF FROM PETER(UNFINISHED)
        //[ResponseType(typeof(Address))]
        //public IHttpActionResult Get()
        //{

        //    var result = new List<object>();
        //    result.Add(new { Name = "A BOOST" });
        //    result.Add(new { Name = "B BOOST" });
        //    result.Add(new { Name = "C BOOST" });
        //    result.Add(new { Name = "D BOOST" });
        //    result.Add(new { Name = "E BOOST" });
        //    result.Add(new { Name = "F BOOST" });
        //    result.Add(new { Name = "G BOOST" });
        //    result.Add(new { Name = "H BOOST" });
        //    result.Add(new { Name = "I BOOST" });
        //    return Ok(result);
        //}

        //PUT:

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}