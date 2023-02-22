using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples_OpenClosedPrinciple
{
    public class SeniorDevSalaryCalculator : BaseSalaryCalculator
    {
        public SeniorDevSalaryCalculator(DeveloperReport developerReport) : base(developerReport)
        {
        }
        public override double CalculateSalary()
        {
           return DeveloperReport.HourlyRate* DeveloperReport.WorkingHours * 3.2;
        }
    }
}

