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
    [RoutePrefix("api/memberships")]
    public class MembershipController : ApiController
    {
        private readonly IMembershipService _membershipService;

        public MembershipController(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetMembershipById(int id)
        {
            try
            {
                var existingMembership = _membershipService.GetMembershipById(id);

                if (existingMembership == null)
                {
                    return NotFound();
                }
                return Ok(existingMembership);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("user/{userId}")]
        public IHttpActionResult GetMembershipsByUserId(int userId)
        {
            try
            {
                var memberships = _membershipService.GetMembershipsByUserId(userId);
                if (memberships == null)
                {
                    return NotFound();
                }
                return Ok(memberships);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult AddMembership([FromBody] Membership membership)
        {
            try
            {
                if (membership == null)
                {
                    return BadRequest("Invalid membership data");
                }

                _membershipService.AddMembership(membership);
                // return CreatedAtRoute("DefaultApi", new { id = membership.Id }, membership); //?? kreira rutu za uspesno kreiran objekat
                return Ok(membership);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult UpdateMembership(int id, [FromBody] Membership membership)
        {
            try
            {
                if(membership.Id!= id || membership == null)
                {
                    return BadRequest("Invalid membership data.");
                }

                var existingMembership = _membershipService.GetMembershipById(id);
                if(existingMembership == null)
                {
                    return NotFound();
                }

                _membershipService.UpdateMembership(membership);
                return Ok(membership);
            }catch(Exception)
            {
                return BadRequest("Error with update membership.");
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteMembership(int id)
        {
            try
            {
                var existingMembership= _membershipService.GetMembershipById(id);
                if( existingMembership == null)
                    return NotFound();

                _membershipService.DeleteMembership(id);
                return StatusCode(HttpStatusCode.NoContent);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
