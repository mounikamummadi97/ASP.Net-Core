// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
//String Word = "Hackerrank";

//HashSet<char> letter = new HashSet<char>();
//int index = 0;
//char firstNonRepeating = 'e';
//for (int i = 0; i < Word.Length; i++)
//{
//    if (letter.Contains(Word[i]))
//        continue;
//    if (Word.IndexOf(Word[i], i + 1) == -1)
//    {
//        index = i;
//        firstNonRepeating = Word[i];
//        //break;
//    }
//    letter.Add(Word[i]);
//    Console.WriteLine("First non-repeating letter: " + firstNonRepeating);
//    Console.WriteLine("Index of non-repeating letter: " + index);
//}
string word = "HackerHacks";
int[] count = new int[256];
char str = ' ';
foreach (char letter in word)
{
    count[letter]++;
}
//char str = '0';
foreach (char nonrepeatingletter in word)
{
    if (count[nonrepeatingletter] == 1)
    {
        str = nonrepeatingletter;
        break;

    }
}
    Console.WriteLine("nonrepeating first occurance letter = " +str);
    int index = word.IndexOf(str);
    Console.WriteLine("index of nonrepeating first occurance letter = "+index);
