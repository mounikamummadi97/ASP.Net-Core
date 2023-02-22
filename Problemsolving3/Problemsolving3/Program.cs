// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System.Security.Cryptography.X509Certificates;

using System;

public class Time
{
 
    static string AdjustTime(string timestamp, int hrs, int min, int sec)
    {
        DateTime currentTime = DateTime.Now;
        DateTime newTime = currentTime.AddHours(hrs).AddMinutes(min).AddSeconds(sec);
        return newTime.ToString("HH:mm:ss");
        //string timestamp;
        //string format = "HH:mm:ss";
        //DateTime currentTime = DateTime.ParseExact(timestamp,format,null);
        //// DateTime currentTime = DateTime.Parse(timestamp, "HH:mm:ss", null);
        //DateTime newTime = currentTime.AddHours(hrs).AddMinutes(min).AddSeconds(sec);
        //return newTime.ToString("HH:mm:ss");
    }

    static void Main(string[] args)
    {
        string currentTimestamp = " ";
        int hrs = 02, min = 05, sec = 30;
        string newTimestamp = AdjustTime(currentTimestamp, hrs, min, sec);
        Console.WriteLine("Current timestamp: {0}", currentTimestamp);
        Console.WriteLine("New timestamp: {0}", newTimestamp);
    }
}



