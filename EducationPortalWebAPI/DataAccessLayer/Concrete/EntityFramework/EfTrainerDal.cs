using DataAccessLayer.Abstract;
using Entity_Layer.ComplexTypes;
using Entity_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfTrainerDal : ITrainerDal
    {
        private SqlDbContext _context;
        private PasswordTransaction _transaction;
        public EfTrainerDal(SqlDbContext context, PasswordTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
        }

        public Task<int> GetByEmail(string email)
        {
            try
            {
                int ID = _context.Trainer.Where(t => t.Email == email).Select(t => t.ID).FirstOrDefault();
                return Task.FromResult(ID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<int> Insert(TrainerDto trainerDto)
        {
            try
            {
                Trainer trainer = new Trainer();
                trainer.FirstName = trainerDto.FirstName;
                trainer.LastName = trainerDto.LastName;
                trainer.Email = trainerDto.Email;
                trainer.MobileNumber = trainerDto.MobileNumber;

                _transaction.CreatePasswordHash(trainerDto.Password, out byte[] PasswordHash, out byte[] PasswordSalt);
                trainer.PasswordHash = PasswordHash;
                trainer.PasswordSalt = PasswordSalt;

                _context.Trainer.Add(trainer);
                _context.SaveChanges();
                return Task.FromResult(trainer.ID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Task<int> Update(TrainerDto trainerDto)
        {
            try
            {
                var trainer = _context.Trainer.Where(m => m.Email == trainerDto.Email).FirstOrDefault();
                if (trainer != null)
                {
                    trainer.Email = trainerDto.Email;
                    trainer.MobileNumber = trainerDto.MobileNumber;


                    _transaction.CreatePasswordHash(trainerDto.Password, out byte[] PasswordHash, out byte[] PasswordSalt);
                    trainer.PasswordHash = PasswordHash;
                    trainer.PasswordSalt = PasswordSalt;

                    _context.Trainer.Update(trainer);
                    _context.SaveChanges();
                    return Task.FromResult(trainer.ID);
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
