using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Entity_Layer.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MemberManager : IMemberService
    {
        private IMemberDal _memberDal;
        public MemberManager(IMemberDal memberDal)
        {
            _memberDal = memberDal;
        }

        public Task<int> GetByEmail(string email)
        {
            return _memberDal.GetByEmail(email);
        }

        public Task<int> Insert(MemberDto memberDto)
        {
            return _memberDal.Insert(memberDto);
        }

        public Task<int> Update(MemberDto memberDto)
        {
            return _memberDal.Update(memberDto);
        }
    }
}
