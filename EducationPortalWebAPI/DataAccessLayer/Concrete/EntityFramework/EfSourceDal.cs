using DataAccessLayer.Abstract;
using Entity_Layer.ComplexTypes;
using Entity_Layer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfSourceDal : ISourceDal
    {
        private SqlDbContext _context;
        public EfSourceDal(SqlDbContext context)
        {
            _context = context;
        }

        public Task<bool> Upload(IFormFile file)
        {
            try
            {
                string fileRoot = file.FileName.Split(".")[1];
                string folderPath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot", "Resources");

                string sourcesFolder = "";
                if (fileRoot == "mp4")
                {
                    sourcesFolder = Path.Combine(folderPath, "Videos");
                }
                else if (fileRoot == "jpg" || fileRoot == "png")
                {
                    sourcesFolder = Path.Combine(folderPath, "Images");
                }
                else if (fileRoot == "pdf" || fileRoot == "docx")
                {
                    sourcesFolder = Path.Combine(folderPath, "Articles");
                }

                if (!Directory.Exists(sourcesFolder))
                {
                    Directory.CreateDirectory(sourcesFolder);
                }
                sourcesFolder = Path.Combine(sourcesFolder, file.FileName);

                using (var stream = new FileStream(sourcesFolder, FileMode.Create))
                {
                    file.CopyToAsync(stream);
                    //Source source = new Source();
                    //source.EducationID = educationID;
                    //source.SourcePath = file.FileName;
                    //_context.Source.Add(source);
                    //_context.SaveChanges();
                    return Task.FromResult(true);
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public Task<bool> UploadSource(List<FilesDto> files, int educationID)
        {
            try
            {
                var education = _context.Education.Where(e => e.ID == educationID).FirstOrDefault();
                if (education != null)
                {
                    foreach (var file in files)
                    {
                        string fileRoot = file.File.FileName.Split(".")[1];
                        //string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Resources");

                        string sourcesFolder = "";
                        if (fileRoot == "mp4")
                        {
                            sourcesFolder = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Videos");
                        }
                        else if (fileRoot == "jpg" || fileRoot == "png")
                        {
                            sourcesFolder = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Images");
                        }
                        else if (fileRoot == "pdf" || fileRoot == "docx")
                        {
                            sourcesFolder = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Articles");
                        }

                        if (!Directory.Exists(sourcesFolder))
                        {
                            Directory.CreateDirectory(sourcesFolder);
                        }
                        sourcesFolder = Path.Combine(sourcesFolder, file.File.FileName);

                        using (var stream = new FileStream(sourcesFolder, FileMode.Create))
                        {
                            file.File.CopyToAsync(stream);
                            Source source = new Source();
                            source.EducationID = educationID;
                            source.SourcePath = file.File.FileName;
                            _context.Source.Add(source);
                            _context.SaveChanges();
                        }
                    }
                    return Task.FromResult(true);
                }
                else
                    return Task.FromResult(false);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
