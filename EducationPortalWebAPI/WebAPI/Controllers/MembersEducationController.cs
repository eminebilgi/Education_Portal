using BusinessLayer.Abstract;
using Entity_Layer.ComplexTypes;
using Entity_Layer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace EducationPortal.Controllers
{
    [Route("api/membersEdu")]
    [ApiController]
    public class MembersEducationController : ControllerBase
    {
        private IMembersEducationService _membersEducationService;
        public MembersEducationController(IMembersEducationService membersEducationService)
        {
            _membersEducationService = membersEducationService;
        }

        [HttpGet("trainer")]
        public Task<List<Education>> GetEducationsByTrainerID()
        {
            try
            {
                int trainerID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                if (trainerID > 0)
                {
                    var list = _membersEducationService.GetByTrainerID(trainerID);
                    return list;
                }
                else
                    return null;

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("member")]
        public Task<List<EducationListDto>> GetEducationsByMemberID()
        {
            try
            {
                int memberID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                if (memberID > 0)
                {
                    var list = _membersEducationService.GetByMemberID(memberID);
                    return list;
                }
                else
                    return null;

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("addStatus")]
        public IActionResult AddStatus([FromBody] MembersEducationDto dto)
        {
            try
            {
                int userID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                if (userID > 0)
                {
                    var res = _membersEducationService.AddEducationStatus(dto).Result;
                    if (res)
                        return Ok(res);
                    else
                        return NotFound();
                }
                else
                    return BadRequest();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("insert")]
        public IActionResult Insert([FromBody] MembersEducationDto dto)
        {
            try
            {
                int userID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                if (userID > 0)
                {
                    var res = _membersEducationService.Insert(dto).Result;
                    if (res)
                        return Ok(res);
                    else
                        return NotFound();
                }
                else
                    return BadRequest();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
