﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer.Concrete
{
    public class Source : BaseEntity
    {
        public int EducationID { get; set; }
        public string? SourcePath { get; set; }

    }
}
