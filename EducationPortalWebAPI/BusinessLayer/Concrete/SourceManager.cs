using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Entity_Layer.ComplexTypes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SourceManager:ISourceService
    {
		private ISourceDal _sourceDal;

		public SourceManager(ISourceDal sourceDal)
		{
			_sourceDal = sourceDal;
		}

		public Task<bool> Upload(IFormFile file)
		{
			return _sourceDal.Upload(file);
		}

		public Task<bool> UploadSource(List<FilesDto> files, int educationID)
		{
			return _sourceDal.UploadSource(files,educationID);
		}
	}
}
