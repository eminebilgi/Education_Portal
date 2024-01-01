using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer.Concrete
{
    public class MembersEducation : BaseEntity
    {
        public int MemberID { get; set; }
        public int EducationID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? TransactionType { get; set; }

    }
}
