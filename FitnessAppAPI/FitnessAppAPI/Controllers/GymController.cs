using FitnessAppAPI.IServices;
using FitnessAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FitnessAppAPI.Controllers
{
    [RoutePrefix("api/gyms")]
    public class GymController : ApiController
    {
        private readonly IGymService _gymService;

        public GymController(IGymService gymService)
        {
            _gymService = gymService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetGymById(int id)
        {
            var gym = _gymService.GetGymById(id);
            if(gym != null)
            {
                return Ok(gym);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetGymsByLocation([FromUri] string location)
        {
            var gyms= _gymService.GetGymsByLocation(location);
            return Ok(gyms);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult AddGym([FromBody] Gym gym)
        {
            try {
                _gymService.AddGym(gym);
                return Ok();

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult UpdateGym(int id, [FromBody] Gym gym)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingGym = _gymService.GetGymById(id);
            if(existingGym == null)
            {
                return NotFound();
            }

            gym.Id = id;
            _gymService.UpdateGym(gym);
            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteGym(int id)
        {
            try
            {
                var existingGym = _gymService.GetGymById(id);
                if (existingGym == null)
                {
                    return NotFound();
                }

                _gymService.DeleteGym(id);
                return Ok();

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
