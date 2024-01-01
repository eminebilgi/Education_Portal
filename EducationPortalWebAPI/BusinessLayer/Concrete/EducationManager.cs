using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Entity_Layer.ComplexTypes;
using Entity_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class EducationManager : IEducationService
    {
        private IEducationDal _educationDal;
        public EducationManager(IEducationDal educationDal)
        {
            _educationDal = educationDal;
        }

        public Task<List<Education>> GetAllEducation()
        {
            return _educationDal.GetAllEducation();
        }


        public Task<int> AddEducation(EducationDto educationDto)
        {
            return _educationDal.AddEducation(educationDto);
        }

        public Task<bool> DeleteEducation(int id)
        {
            return _educationDal.DeleteEducation(id);
        }

        public Task<bool> UpdateEducation(EducationDto educationDto, int id)
        {
            return _educationDal.UpdateEducation(educationDto, id);
        }

        public Task<Education> GetEducationById(int id)
        {
            return _educationDal.GetEducationById(id);
        }
    }
}
