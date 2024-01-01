using Entity_Layer.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IUsersDal
    {
        Task<int> MemberLogin(string email, string password);
        Task<int> TrainerLogin(string email, string password);
    }
}
