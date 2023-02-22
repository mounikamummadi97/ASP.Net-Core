using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutePrinciple_SolidPrinciple
{
    public abstract class Fruit
    {
        public abstract string GetColor();
    }
    public class Apple1 : Fruit
    {
        public override string GetColor()
        {
            return "Red";
        }
    }
    public class Orange1: Fruit
    {
        public override string GetColor()
        {
            return "Orange";
        }
    }
}
