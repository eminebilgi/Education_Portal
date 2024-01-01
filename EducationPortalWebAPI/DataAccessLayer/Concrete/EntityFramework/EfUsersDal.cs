using DataAccessLayer.Abstract;
using Entity_Layer.ComplexTypes;
using Entity_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfUsersDal : IUsersDal
    {
        private SqlDbContext _context;
        private PasswordTransaction _transaction;
        public EfUsersDal(SqlDbContext context,PasswordTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
        }
       
        public Task<int> MemberLogin(string email, string password)
        {
            try
            {
                var users = _context.Member.FirstOrDefault(x => x.Email == email);
                if (users != null)
                {
                bool stat = _transaction.VerifyPassword(password, users.PasswordHash, users.PasswordSalt);
                    if (stat)
                    {
                        return Task.FromResult(users.ID);
                    }
                }
                return Task.FromResult(0);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<int> TrainerLogin(string email, string password)
        {
            try
            {
                var users = _context.Trainer.FirstOrDefault(x => x.Email == email);
                if (users != null)
                {
                    bool stat = _transaction.VerifyPassword(password, users.PasswordHash, users.PasswordSalt);
                    if (stat)
                    {
                        return Task.FromResult(users.ID);
                    }
                }
                return Task.FromResult(0);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
