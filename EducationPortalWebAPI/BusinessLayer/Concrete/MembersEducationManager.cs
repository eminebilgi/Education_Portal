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
    public class MembersEducationManager:IMembersEducationService
    {
        private IMembersEducationDal _membersEducationDal;
        public MembersEducationManager(IMembersEducationDal membersEducationDal)
        {
            _membersEducationDal = membersEducationDal;
        }

        public Task<bool> AddEducationStatus(MembersEducationDto dto)
        {
            return _membersEducationDal.AddEducationStatus(dto);
        }

        public Task<List<EducationListDto>> GetByMemberID(int memberID)
        {
            return _membersEducationDal.GetByMemberID(memberID);
        }

        public Task<List<Education>> GetByTrainerID(int trainerID)
        {
            return _membersEducationDal.GetByTrainerID(trainerID);
        }

        public Task<bool> Insert(MembersEducationDto dto)
        {
            return _membersEducationDal.Insert(dto);
        }
    }
}
