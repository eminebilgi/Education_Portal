using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer.Concrete
{
    public class Education : BaseEntity
    {
        public string? EducationName { get; set; }
        public string? Description { get; set; }
        public int CategoryID { get; set; }
        public int TrainerID { get; set; }
        public int Quota { get; set; }
        public string? Duration { get; set; }
        public decimal Price { get; set; }
        public string? Currency { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Source>? Sources{ get; set; }
        public ICollection<MembersEducation>? MembersEducations { get; set; }

    }
}
