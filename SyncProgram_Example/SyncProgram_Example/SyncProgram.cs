using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncProgram_Example
{
    public class SyncProgram
    {
        public static void Method1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("First Method" + i);
                Task.Delay(2000).Wait();
            }
        }
        public static void Method2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Second Method" + i);
                Task.Delay(1000).Wait();
            }
        }
    }
}
