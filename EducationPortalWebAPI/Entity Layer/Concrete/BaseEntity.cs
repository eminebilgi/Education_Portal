using Entity_Layer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer.Concrete
{
    public class BaseEntity : IBaseEntity
    {
        public int ID { get; set; }
    }
}
