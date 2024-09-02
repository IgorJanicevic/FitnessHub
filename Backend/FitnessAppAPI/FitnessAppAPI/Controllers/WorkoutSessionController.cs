using System.Collections.Generic;
using System.Web.Http;
using FitnessAppAPI.Models;
using FitnessAppAPI.IServices;
using System.Net;
using System;
using System.Web.Http.Cors;

namespace FitnessAppAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/workoutsessions")]
    public class WorkoutSessionController : ApiController
    {
        private readonly IWorkoutSessionService _workoutSessionService;

        public WorkoutSessionController(IWorkoutSessionService workoutSessionService)
        {
            _workoutSessionService = workoutSessionService;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<WorkoutSession> GetAllWorkoutSessions()
        {
            return _workoutSessionService.GetAllWorkoutSessions();
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetWorkoutSessionById(int id)
        {
            var session = _workoutSessionService.GetWorkoutSessionById(id);
            if (session == null)
            {
                return NotFound();
            }
            return Ok(session);
        }

        [HttpGet]
        [Route("gym/{gymId:int}")]
        public IEnumerable<WorkoutSession> GetWorkoutSessionsByGymId(int gymId)
        {
            return _workoutSessionService.GetWorkoutSessionsByGymId(gymId);
        }

        [HttpGet]
        [Route("user/{userId:int}")]
        public IEnumerable<WorkoutSession> GetWorkoutSessionsByUserId(int userId)
        {
            return _workoutSessionService.GetWorkoutSessionsByUserId(userId);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult AddWorkoutSession(WorkoutSession workoutSession)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _workoutSessionService.AddWorkoutSession(workoutSession);
            return Ok(workoutSession);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult UpdateWorkoutSession(int id, WorkoutSession workoutSession)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != workoutSession.Id)
            {
                return BadRequest();
            }

            try
            {
                _workoutSessionService.UpdateWorkoutSession(workoutSession);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteWorkoutSession(int id)
        {
            try
            {
                var workoutSeassionsFound= _workoutSessionService.GetWorkoutSessionById(id);
                if (workoutSeassionsFound != null)
                {
                    _workoutSessionService.DeleteWorkoutSession(id);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
