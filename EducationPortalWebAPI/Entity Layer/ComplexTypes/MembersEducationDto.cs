using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer.ComplexTypes
{
    public class MembersEducationDto
    {
        public int ID { get; set; }
        public int MemberID { get; set; }
        public int EducationID { get; set; }
        public string? TransactionType { get; set; }
    }
}
