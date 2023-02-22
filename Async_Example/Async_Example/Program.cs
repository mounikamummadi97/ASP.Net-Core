// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Diagnostics;
using System.Threading.Tasks;
namespace Async_Example
{
    public class breakfast
    {
        public static void Main(string[] args)
        { Stopwatch s = new Stopwatch();
            s.Start();
            breakfast objAsync = new breakfast();
            objAsync.BreakFastItems();
            s.Stop();
            Console.WriteLine("time taking :"+s.ElapsedMilliseconds);
            Console.ReadLine();
        }
        // breakfast items = new breakfast();
        public Task  BreakFastItems()  
        {
            
            var T1 = PrepareTea();
            var T2 = PrepareIdly();
            var T3 = PrepareBoiledEggs();
            //items.Add(T1);
            //BreakfastTa.Add(T2);
            //BreakfastTask.Add(T3)
            var bf = Task.WhenAll(T2,T1,T3);
            return bf;
           

        }
        
       
        public static async Task PrepareTea()
        {
            //Console.WriteLine("Tea prepared");
            //await Task.Delay(10000);
            //Console.WriteLine("Tea prepared");


            await Task.Run(() =>
            {
                Task.Delay(500000);
                Console.WriteLine("tea prepared");
                 Task.Delay(500000);

            });
        }
        public static async Task PrepareIdly()
        {
            // var T1=new TaskCompletionSource<int>();
           
            await Task.Run(() =>
            {
                Console.WriteLine("Idly prepared");

            });
        }
        public static async Task PrepareBoiledEggs()
        { 
            await Task.Run(() =>
        {
            Console.WriteLine("Boiled eggs prepared");
        });

        }
      
    }
}