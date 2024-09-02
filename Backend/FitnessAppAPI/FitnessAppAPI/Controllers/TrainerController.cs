using FitnessAppAPI.IServices;
using FitnessAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FitnessAppAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/trainers")]
    public class TrainerController : ApiController
    {

        private readonly ITrainerService _trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllTrainers()
        {
            var trainers = _trainerService.GetAllTrainers();
            return Ok(trainers);
        }

        [HttpGet]
        [Route("gym/{gymId:int}")]
        public IHttpActionResult GetAllTrainersByGymId(int gymId)
        {
            try
            {
                var trainersFound = _trainerService.GetAllTrainersByGymId(gymId);
                if(trainersFound == null)
                {
                    return NotFound();
                }
                return Ok(trainersFound);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetTrainerById(int id)
        {
            try
            {
                var trainerFound= _trainerService.GetTrainerById(id);
                if(trainerFound == null)
                {
                    return NotFound();
                }
                return Ok(trainerFound);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult AddTrainer([FromBody] Trainer trainer)
        {
            try
            {
                _trainerService.AddTrainer(trainer);
                return Ok(trainer);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult UpdateTrainer(int id, [FromBody] Trainer trainer)
        {
            try
            {
                var existingTrainer = _trainerService.GetTrainerById(id);
                if(existingTrainer == null || existingTrainer.Id != trainer.Id)
                {
                    return BadRequest("Invalid data for trainer.");
                }
                _trainerService.UpdateTrainer(trainer);
                return Ok(trainer);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteTrainer(int id)
        {
            try
            {
                var existingTrainer = _trainerService.GetTrainerById(id);
                if (existingTrainer == null)
                    return NotFound();
                _trainerService.DeleteTrainer(id);
                return StatusCode(HttpStatusCode.NoContent);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
