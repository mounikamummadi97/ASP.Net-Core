// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using SyncProgram_Example;
using System.Diagnostics;

Stopwatch   s =new Stopwatch();
s.Start();
SyncProgram.Method2();
SyncProgram.Method1();
s.Stop();
Console.WriteLine("Time taking :"+s.ElapsedMilliseconds);



