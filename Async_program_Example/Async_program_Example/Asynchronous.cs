using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async_program_Example
{
    public class Asynchronous
    {
        static async Task PrepareCoffeeAsync()
        {
            Console.WriteLine("Grinding coffee beans...");
          
            Console.WriteLine("Coffee beans are ground.");
            await Task.Delay(2000);
            Console.WriteLine("Coffee prepared");
            Console.ReadLine();
        }
        static async Task PrepareIdlyAsync()
        {
            // var T1=new TaskCompletionSource<int>();

            Console.WriteLine("Idly batter mixed");
            //await Task.Delay(3000);
            Console.WriteLine("Idly batter put in plates ");
           // await Task.Delay(5000);
            Console.WriteLine("Idly cooked");


        }
        static async Task PrepareBoiledEggsAsync()
        {
            Console.WriteLine("Boiling eggs...");
            //await Task.Delay(4000);
            Console.WriteLine("Eggs are Boiled.");


        }


        public static async Task Main()
        {
            Console.WriteLine("Starting to make breakfast...");
            Task PrepareCoffeeTask = PrepareCoffeeAsync();
            Task PrepareIdlyTask = PrepareIdlyAsync();
            Task PrepareBoiledEggsTask = PrepareBoiledEggsAsync();
            await Task.WhenAll(PrepareCoffeeTask, PrepareIdlyTask, PrepareBoiledEggsTask);



            Console.WriteLine("Breakfast is ready!");
        }
    }
}

