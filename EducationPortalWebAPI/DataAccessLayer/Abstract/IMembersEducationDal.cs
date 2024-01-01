using Entity_Layer.ComplexTypes;
using Entity_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMembersEducationDal
    {
        Task<List<EducationListDto>> GetByMemberID(int memberID);
        Task<List<Education>> GetByTrainerID(int trainerID);
        Task<bool> Insert(MembersEducationDto dto);
        Task<bool> AddEducationStatus(MembersEducationDto dto);

    }
}
