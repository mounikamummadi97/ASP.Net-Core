// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using SolidPrinciples_OpenClosedPrinciple;

var developerCalculations = new List<BaseSalaryCalculator>
        {
            new SeniorDevSalaryCalculator(new DeveloperReport {Id = 1, Name = "Shravan", Level = "Senior developer", HourlyRate = 30.5, WorkingHours = 160 }),
            new JuniorDevSalaryCalculator(new DeveloperReport {Id = 2, Name = "Mounika", Level = "Junior developer", HourlyRate = 20, WorkingHours = 150 }),
            new SeniorDevSalaryCalculator(new DeveloperReport {Id = 3, Name = "Vinay", Level = "Senior developer", HourlyRate = 30.5, WorkingHours = 180 })
        };
var calculator = new SalaryCalculator(developerCalculations);
Console.WriteLine($"Sum of all the developer salaries is {calculator.CalculateTotalSalaries()} dollars");