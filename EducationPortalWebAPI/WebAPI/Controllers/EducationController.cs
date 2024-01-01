using BusinessLayer.Abstract;
using Entity_Layer.ComplexTypes;
using Entity_Layer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EducationPortal.Controllers
{
    [ApiController]
    [Route("api/education")]
    public class EducationController : ControllerBase
    {
        private readonly ILogger<EducationController> _logger;
        private IEducationService _educationService;
        public EducationController(ILogger<EducationController> logger, IEducationService educationService)
        {
            _educationService = educationService;
            _logger = logger;
        }

        [HttpGet("all")]
        public List<Education> GetAll()
        {
            try
            {
                int userID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                if (userID > 0)
                {
                    var list = _educationService.GetAllEducation().Result;
                    return list;
                }
                else return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<List<Education>> Get()
        {

            var list = _educationService.GetAllEducation().Result;
            return list;
        }

        [HttpPost("insert")]
        public IActionResult Insert([FromBody] EducationDto educationDto)
        {
            try
            {
                int userID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                if (userID > 0)
                {
                    int id = _educationService.AddEducation(educationDto).Result;
                    if (id != 0)
                        return Ok(id);
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

        [HttpDelete("delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {

                int userID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                if (userID > 0)
                {
                    var result = _educationService.DeleteEducation(id).Result;
                    return Ok(result);
                }
                else
                    return BadRequest();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] EducationDto dto)
        {
            try
            {
                int userID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                if (userID > 0)
                {
                    var result = _educationService.UpdateEducation(dto, id).Result;
                    return Ok(result);
                }
                else
                    return BadRequest();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                int userID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                if (userID > 0)
                {
                    var education = _educationService.GetEducationById(id);
                    return Ok(education);
                }
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
