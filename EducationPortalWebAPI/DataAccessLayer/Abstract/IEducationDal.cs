using Entity_Layer.ComplexTypes;
using Entity_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IEducationDal
    {
        Task<List<Education>> GetAllEducation();
        Task<int> AddEducation(EducationDto educationDto);
        Task<bool> DeleteEducation(int id);
        Task<bool> UpdateEducation(EducationDto educationDto, int id);
        Task<Education> GetEducationById(int id);
    }
}
