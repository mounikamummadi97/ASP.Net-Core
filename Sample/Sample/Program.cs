// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;

public struct PersonStruct
{
    public string FName { get; set; }
    public string LName { get; set; }
    public PersonStruct(string fName, string lName)
    {
        FName = fName;
        LName = lName;
    }

    void Dosomething(person person)
    {
        person.FName = "ansari";
        person.LName = "shabbir";
    }



    public static void Main(string[] args)
    {



        var shabbir = new person("shabbir", "ansari");
        Dosomething(shabbir);
        Console.WriteLine(shabbir.FName);
        Console.WriteLine(shabbir.LName);

    }
}
