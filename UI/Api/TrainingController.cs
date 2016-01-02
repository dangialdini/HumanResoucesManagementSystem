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
using UI.Areas.Training.Models;

namespace UI.Api
{
    public class TrainingController : ApiController
    {
       
        // GET: Training
        private readonly ITrainingService _serviceTraining;
        public TrainingController (ITrainingService serviceTraining)
        {
            _serviceTraining = serviceTraining;
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            var result = _serviceTraining.TrainingAsQueryable().Select(x => new TrainingViewModel
            {

                Id = x.Id,
                TrainingTypeId = x.TrainingTypeId,
                TrainingTypeName = x.TrainingType.Name,
                RatePerHour = x.RatePerHour
            }).ToList();
            return Ok(result);
        }
        [Route("api/Training/GetTrainingType")]
        public IHttpActionResult GetTrainingType()
        {
            var result = _serviceTraining.TrainingTypeAsQueryable().Select(t => new TrainingTypeViewModel
            {

                Id=t.Id,
                Name = t.Name

            }).ToList();
            return Ok(result);
        }
   

        //[ResponseType(typeof(Training))]
        [HttpPost]
        public IHttpActionResult Post(TrainingViewModel model)
        {

            var training = _serviceTraining.Create(model.TrainingTypeId, model.RatePerHour);
            model.Id = training.Id;
            model.TrainingTypeName = training.TrainingType.Name;
            return Created<TrainingViewModel>(Request.RequestUri + training.Id.ToString(), model);
        }

       
        [HttpPut]
        public IHttpActionResult Put(TrainingViewModel model)
        {
            var update = _serviceTraining.Update(model.Id, model.TrainingTypeId, model.RatePerHour);
            model.TrainingTypeName = update.TrainingType.Name;
            return Ok(model);
        }
        public IHttpActionResult Delete(TrainingViewModel model)
        {
            _serviceTraining.Delete(model.Id);
            return Ok();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}