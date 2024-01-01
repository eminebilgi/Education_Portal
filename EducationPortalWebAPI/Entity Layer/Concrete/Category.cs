using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer.Concrete
{
    public class Category:BaseEntity
    {
        public string? CategoryName { get; set; }
        public ICollection<Education> Educations { get; set; }

    }
}
