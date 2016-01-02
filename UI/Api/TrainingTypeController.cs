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
using Services.Service.Interfaces;
using Domain.Models;
using Services.Service;
using UI.Areas.Training.Models;

namespace UI.Api
{
    public class TrainingTypeController : ApiController
    {
       // GET: TrainingType
        private readonly ITrainingService _serviceTraining;
        public TrainingTypeController (ITrainingService serviceTraining)
        {
            _serviceTraining = serviceTraining;
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            var result=_serviceTraining.TrainingTypeAsQueryable()
                .OrderBy(t=>t.Name)
                .Select(t=> new TrainingTypeViewModel {
                Id=t.Id,
                Name=t.Name,
                Description=t.Description,
                DurationInMinutes=t.DurationInMinutes
            }).ToList();
            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult Post(TrainingTypeViewModel model)
        {
           
            var trainingType = _serviceTraining.AddTrainingType(model.Name,model.Description,model.DurationInMinutes);
            model.Id = trainingType.Id;
            return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
        }
        [HttpPut]
        public IHttpActionResult Put(TrainingTypeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var update =  _serviceTraining.UpdateTrainingType(model.Id,model.Name,model.Description,model.DurationInMinutes );
            return Ok(model);
        }
        [HttpDelete]
        public IHttpActionResult Delete(TrainingTypeViewModel model)
        {
            _serviceTraining.DeleteTrainingType(model.Id);
            return Ok();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}
