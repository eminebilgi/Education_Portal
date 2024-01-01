using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using Entity_Layer.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TrainerManager : ITrainerService
    {
        private ITrainerDal _trainerDal;
        public TrainerManager(ITrainerDal trainerDal)
        {
            _trainerDal = trainerDal;
        }
        public Task<int> GetByEmail(string email)
        {
            return _trainerDal.GetByEmail(email);
        }
        public Task<int> Insert(TrainerDto trainerDto)
        {
            return _trainerDal.Insert(trainerDto);
        }

        public Task<int> Update(TrainerDto trainerDto)
        {
            return _trainerDal.Update(trainerDto);
        }
    }
}
