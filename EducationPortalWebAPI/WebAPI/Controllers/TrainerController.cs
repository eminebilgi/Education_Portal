using BusinessLayer.Abstract;
using Entity_Layer.ComplexTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EducationPortal.Controllers
{
    [Route("api/trainer")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private ITrainerService _trainerService;
        private IUsersService _usersService;
        public TrainerController(ITrainerService trainerService, IUsersService usersService)
        {
            _trainerService = trainerService;
            _usersService = usersService;
        }

        [HttpPost]
        public IActionResult InsertTrainer([FromBody] TrainerDto trainerDto)
        {
            try
            {
                int id = _trainerService.Insert(trainerDto).Result;
                if (id != 0)
                {
                    return Ok(id);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
