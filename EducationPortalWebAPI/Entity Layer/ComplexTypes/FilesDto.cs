using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer.ComplexTypes
{
    public class FilesDto
    {
        public IFormFile File{ get; set; }
    }
}
