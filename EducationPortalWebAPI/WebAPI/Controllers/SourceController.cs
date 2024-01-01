using BusinessLayer.Abstract;
using Entity_Layer.ComplexTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EducationPortal.Controllers
{
    [Route("api/source")]
    [ApiController]
    public class SourceController : ControllerBase
    {
        private ISourceService _sourceService;
        public SourceController(ISourceService sourceService)
        {
            _sourceService = sourceService;
        }

        [HttpPost("upload/{educationID}")]
        public IActionResult Upload(List<FilesDto> files, int educationID)
        {
            try
            {
                int userID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                if (userID > 0)
                {
                    var res = _sourceService.UploadSource(files, educationID);
                    return Ok(res);
                }
                else
                    return BadRequest();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult UploadFile(IFormFile file)
        {
            try
            {
                //    int userID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                //    if (userID > 0)
                //    {
                var res = _sourceService.Upload(file);
                    return Ok(res);
                //}
                //else
                //    return BadRequest();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
