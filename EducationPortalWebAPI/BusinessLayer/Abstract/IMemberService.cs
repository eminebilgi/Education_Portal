using Entity_Layer.ComplexTypes;
using Entity_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMemberService
    {
        Task<int> Insert(MemberDto memberDto);
        Task<int> Update(MemberDto memberDto);
        Task<int> GetByEmail(string email);

    }
}
