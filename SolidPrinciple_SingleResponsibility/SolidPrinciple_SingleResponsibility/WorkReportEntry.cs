﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciple_SingleResponsibility
{
    public class WorkReportEntry
    {
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public int SpentHours { get; set; }
    }
}
