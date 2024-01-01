using Entity_Layer.ComplexTypes;
using Entity_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMemberDal
    {
        Task<int> Insert(MemberDto memberDto);
        Task<int> Update(MemberDto memberDto);
        Task<int> GetByEmail(string email);

    }
}
