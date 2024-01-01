using Entity_Layer.ComplexTypes;
using Entity_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ITrainerDal
    {
        Task<int> Insert(TrainerDto trainerDto);
        Task<int> Update(TrainerDto trainerDto);
        Task<int> GetByEmail(string email);
    }
}
