namespace LiskovSubstitutePrinciple_SolidPrinciple
{
    public class Apple
    {
        public virtual string GetColor()
        {
            return "Red";
        }

    }
    public class Orange : Apple
    {
        public override string GetColor()
        {
            return "Orange";
        }
    }
}
