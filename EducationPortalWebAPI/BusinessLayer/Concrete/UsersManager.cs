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
    public class UsersManager : IUsersService
    {
        private IUsersDal _usersDal;
        public UsersManager(IUsersDal usersDal)
        {
            _usersDal = usersDal;
        }

        public Task<int> MemberLogin(string email, string password)
        {
            return _usersDal.MemberLogin(email, password);
        }

        public Task<int> TrainerLogin(string email, string password)
        {
            return _usersDal.TrainerLogin(email, password);
        }
    }
}
