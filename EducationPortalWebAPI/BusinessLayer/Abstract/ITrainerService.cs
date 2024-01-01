using Entity_Layer.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITrainerService
    {
        Task<int> Insert(TrainerDto trainerDto);
        Task<int> Update(TrainerDto trainerDto);
        Task<int> GetByEmail(string email);

    }
}
