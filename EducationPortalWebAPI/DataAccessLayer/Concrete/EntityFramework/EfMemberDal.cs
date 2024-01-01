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
    public class EfMemberDal : IMemberDal
    {
        private SqlDbContext _context;
        private PasswordTransaction _transaction;

        public EfMemberDal(SqlDbContext context,PasswordTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
        }

        public Task<int> GetByEmail(string email)
        {
            try
            {
                int ID = _context.Member.Where(t => t.Email == email).Select(t => t.ID).FirstOrDefault();
                return Task.FromResult(ID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<int> Insert(MemberDto memberDto)
        {
            try
            {
                Member member = new Member();
                member.FirstName = memberDto.FirstName;
                member.LastName = memberDto.LastName;
                member.Email = memberDto.Email;
                member.MobileNumber = memberDto.MobileNumber;

                _transaction.CreatePasswordHash(memberDto.Password, out byte[] PasswordHash, out byte[] PasswordSalt);
                member.PasswordHash = PasswordHash;
                member.PasswordSalt = PasswordSalt;

                _context.Member.Add(member);
                _context.SaveChanges();
                return Task.FromResult(member.ID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<int> Update(MemberDto memberDto)
        {
            try
            {
                var member = _context.Member.Where(m => m.Email == memberDto.Email).FirstOrDefault();
                if (member != null)
                {
                    member.Email = memberDto.Email;
                    member.MobileNumber = memberDto.MobileNumber;

                    _transaction.CreatePasswordHash(memberDto.Password, out byte[] PasswordHash, out byte[] PasswordSalt);
                    member.PasswordHash = PasswordHash;
                    member.PasswordSalt = PasswordSalt;

                    _context.Member.Update(member);
                    _context.SaveChanges();
                    return Task.FromResult(member.ID);
                }
                else
                {
                    return Task.FromResult(0);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
