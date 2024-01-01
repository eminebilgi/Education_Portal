using BusinessLayer.Abstract;
using Entity_Layer.ComplexTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EducationPortal.Controllers
{
    [Route("api/member")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private IMemberService _memberService;
        private IUsersService _usersService;
        public MemberController(IMemberService memberService, IUsersService usersService)
        {
            _memberService = memberService;
            _usersService = usersService;
        }

        [HttpPost]
        public IActionResult InsertMember([FromBody] MemberDto memberDto)
        {
            try
            {
                int userID = _memberService.Insert(memberDto).Result;
                if (userID != 0)
                {
                    return Ok(userID);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


    }

}
