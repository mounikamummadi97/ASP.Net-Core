using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples_OpenClosedPrinciple
{
    public abstract class BaseSalaryCalculator
    {
        public DeveloperReport DeveloperReport { get; set; }//property is a type of DeveloperReport
        public BaseSalaryCalculator(DeveloperReport developerReport)
        {
            DeveloperReport = developerReport;
        }
        public abstract double CalculateSalary();
    }
}
