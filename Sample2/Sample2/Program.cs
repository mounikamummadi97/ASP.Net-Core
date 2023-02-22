// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
//var input = new int[] { 2, 5, 6, 3, 9, -2, 8, 17,1,11,-4,0,7 };


//List<(int, int)> pairs = new List<(int, int)>();

//for (int i = 0; i < input.Length; i++)
//{
//    for (int j = i + 1; j < input.Length - 1; j++)
//    {
//        //if (input[i] + input[j] == 7)
//        //{
//        //    pairs.Add((input[i], input[j]));

//        if ((i & (1 << j)) > 0)
//        {
//        } 
//    }
//}

//foreach ((int x, int y) in pairs)
//{
//    Console.WriteLine("(" + x + ", " + y + ")");
//}
//using System;
//using System.Collections.Generic;

namespace CombinationSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = new int[] { 2, 5, 6, 3, 9, -2, 8, 17, 1, 11, -4, 0, 7 };
            int target = 7;
            List<List<int>> result = new List<List<int>>();

            FindCombinationSum(input, target, new List<int>(), result, 0);

            Console.WriteLine("All possible combinations of numbers in the input array that equal to 7 are:");
            foreach (var list in result)
            {
                Console.WriteLine(string.Join(" ", list));
            }
        }

        private static void FindCombinationSum(int[] input, int target, List<int> current, List<List<int>> result, int start)
        {
            if (target == 0)
            {
                result.Add(new List<int>(current));
                return;
            }

            for (int i = start; i < input.Length; i++)
            {
                if (input[i] > target)
                {
                    continue;
                }
                current.Add(input[i]);
                FindCombinationSum(input, target - input[i], current, result, i + 1);
                current.RemoveAt(current.Count - 1);
            }
        }
    }
}







