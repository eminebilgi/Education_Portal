using Entity_Layer.ComplexTypes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISourceService
    {
        Task<bool> UploadSource(List<FilesDto> files, int educationID);
        Task<bool> Upload(IFormFile file);

    }
}
