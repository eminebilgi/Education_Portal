using BusinessLayer.Abstract;
using Entity_Layer.ComplexTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EducationPortal.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersService _usersService;
        private IMemberService _memberService;
        private ITrainerService _trainerService;

        public UsersController(IUsersService usersService, IMemberService memberService, ITrainerService trainerService)
        {
            _usersService = usersService;
            _memberService = memberService;
            _trainerService = trainerService;
        }

        [HttpPut("member")]
        public IActionResult UpdateMember([FromBody] MemberDto memberDto)
        {
            try
            {
                int memberID = _memberService.Update(memberDto).Result;
                if (memberID != 0)
                {
                    return Ok(memberID);
                }
                else
                    return NotFound();
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPut("trainer")]
        public IActionResult Updatetrainer([FromBody] TrainerDto trainerDto)
        {
            try
            {
                int memberID = _trainerService.Update(trainerDto).Result;
                if (memberID != 0)
                {
                    return Ok(memberID);
                }
                else
                    return NotFound();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
