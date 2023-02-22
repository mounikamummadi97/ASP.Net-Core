// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");



using System.ComponentModel;

class Program
{
    //static bool cFuge(int n, int k)
    //{
    //    return n % 2 == 0 && k % 2 == 0;
    //}
    //static void Main(string[] args)
    //{
    //    Console.WriteLine(cFuge(6, 4));
    //    Console.WriteLine(cFuge(2, 1));
    //    Console.WriteLine(cFuge(3, 3));
    //}
    public static  bool IsBalanced(int n, int k)
    {
        int sum = 0;
        for (int i = 1; i <= k; i++)
        {
            sum += i;
            if (sum == n)
            {
                return true;
            }
            if (sum > n)
            {
                return false;
            }
        }
        return false;
    }
    static void Main(string[] args)
    {
        Console.WriteLine(IsBalanced(6, 4));
        Console.WriteLine(IsBalanced(2, 1));
        Console.WriteLine(IsBalanced(3, 3));


        The prompt is asking to write a function finalCountdown that takes an array of integers as an argument and returns an array of two values. The first value is the number of countdown sequences(a descending sequence of integers from k down to 1) that exist in the input array and the second value is the array of those countdown sequences in the order in which they appear in the input array.If there are no countdown sequences in the input array, the function should return [0, []].
    }
}

      
          
          




