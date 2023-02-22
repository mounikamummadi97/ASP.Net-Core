// See https://aka.ms/new-console-template for more information

using SolidPrinciple_SingleResponsibility;

var report = new WorkReport();
report.AddEntry(new WorkReportEntry 
{ ProjectCode = "123Ds", 
    ProjectName = "Project1",
    SpentHours = 5 }
);
report.AddEntry(new WorkReportEntry 
{ ProjectCode = "987Fc", 
    ProjectName = "Project2", 
    SpentHours = 3 }
);
report.AddEntry(new WorkReportEntry
{
    ProjectCode = "5467Fc",
    ProjectName = "Project3",
    SpentHours = 8
}
);
report.RemoveentryAt(0);
//report.RemoveentryAt(1);
Console.WriteLine(report.ToString());
var saver = new FileSaver();
saver.SaveToFile(@"Reports", "WorkReport.txt", report);