using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer.ComplexTypes
{
    public class EducationListDto
    {
        public int EducationID { get; set; }
        public string? EducationName { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? TrainerName { get; set; }
        public int TrainerID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? TransactionType { get; set; }
    }
}
