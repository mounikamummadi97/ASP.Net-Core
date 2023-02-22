//// See https://aka.ms/new-console-template for more information
////Console.WriteLine("Hello, World!");

//class Program



List<int[]> inputs = new List<int[]> {
 new int[] {4, 8, 3, 2, 1, 2},
 new int[] {4, 4, 5, 4, 3, 2, 1, 8, 3, 2, 1},
 new int[] {4, 3, 2, 1, 3, 2, 1, 1},
 new int[] {1, 1, 2, 1},
 new int[] {}
 };

foreach (int[] input in inputs)
{
    List<int[]> result = FinalCountdown(input);
    Console.WriteLine($"\nCountdown sequences count: {result.Count()}");
    //Console.WriteLine("Sequences:");

    //foreach (int[] seq in result[1])
    //{
    //    Console.WriteLine("[ " + string.Join(", ", seq) + " ]");
    //}
    //Console.WriteLine(); foreach (int[] seq in result[1])             Console.Write("[ ");


    if (result.Count > 0)
    {
        Console.Write("[ " + result.Count().ToString() + ", "); if (result.Count > 1)
            Console.Write("[");
        foreach (int[] number in result)
        {
            Console.Write("[ " + string.Join(", ", number) + " ] ");
        }
        if (result.Count > 1)
            Console.Write("]"); Console.Write("]");
    }
    else
    {
        Console.Write("[ 0, []]");
    }
}


static List<int[]> FinalCountdown(int[] arr)
{
    List<int[]> sequences = new List<int[]>();

   
    int[] sequence;
    int i = 0;
    while (i < arr.Length)
    {
        int j = i + 1;
        if (j < arr.Length && arr[i] == arr[j] && arr[i] == 1)
        {
            for (int p = 0; p < 2; p++)
            {
                sequence = new int[1];
                sequence[0] = 1;
                sequences.Add(sequence);
                i++;
                j++;
            }
        }
        else
        {
            while (j < arr.Length && arr[j] == arr[j - 1] - 1)
            {
                j++;
            }
            if (j - i >= 2)
            {
                sequence = new int[j - i];
                for (int k = i; k < j; k++)
                {
                    sequence[k - i] = arr[k];
                }
                sequences.Add(sequence);
            }
            i = j;
            if (j < arr.Length && arr[i] == arr[j] && arr[i] == 1)
            {
                sequence = new int[1];
                sequence[0] = 1;
                sequences.Add(sequence);
                i++;
                j++;
            }
        }
    }
    return (sequences);
}
