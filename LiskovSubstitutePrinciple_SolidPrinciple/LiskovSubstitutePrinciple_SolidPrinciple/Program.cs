// See https://aka.ms/new-console-template for more information
using LiskovSubstitutePrinciple_SolidPrinciple;


    Apple apple = new Orange();
    Console.WriteLine(apple.GetColor());//store the child class object in the Parent Reference variable 
//LISKOV SUBSTITUTE PRINCIPLE
      Fruit fruit = new Orange1();
      Console.WriteLine(fruit.GetColor());
      fruit = new Apple1();
      Console.WriteLine(fruit.GetColor());
