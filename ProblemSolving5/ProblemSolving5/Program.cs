// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");



//namespace MealDurationCalculator
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            DateTime currentTime = DateTime.Now;
//            int[] duration = CalculateMealDuration(currentTime);

//            Console.WriteLine("Time to Eat: " + currentTime.ToString("h:mm tt"));
//            Console.WriteLine("Hours: " + duration[0]);
//            Console.WriteLine("Minutes: " + duration[1]);
//        }

//        static int[] CalculateMealDuration(DateTime currentTime)
//        {
//            int[] duration = new int[2];
//            int currentHour = currentTime.Hour;
//            int currentMinute = currentTime.Minute;

//            int[] nextMeal = NextMealTime(currentHour);
//            int hours = nextMeal[0] - currentHour;
//            int minutes = nextMeal[1] - currentMinute;

//            if (minutes < 0)
//            {
//                hours--;
//                minutes = 60 + minutes;
//            }

//            if (hours < 0)
//            {
//                hours = 24 + hours;
//            }

//            duration[0] = hours;
//            duration[1] = minutes;

//            return duration;
//        }

//        static int[] NextMealTime(int hour)
//        {
//            int[] mealTime = new int[2];
//            if (hour < 7)
//            {
//                mealTime[0] = 7;
//                mealTime[1] = 0;
//            }
//            else if (hour < 12)
//            {
//                mealTime[0] = 12;
//                mealTime[1] = 0;
//            }
//            else if (hour < 19)
//            {
//                mealTime[0] = 19;
//                mealTime[1] = 0;
//            }
//            else
//            {
//                mealTime[0] = 7;
//                mealTime[1] = 0;
//            }
//            return mealTime;
//        }
//    }
//}

//public class Meal
//{
//    public static void Main(string[] args)
//    {
//        DateTime currentTime = DateTime.Now;
//        int[] duration = CalculateMealDuration(currentTime);

//        Console.WriteLine("CurrentTime : " + currentTime.ToString("h:mm tt"));
//        Console.WriteLine("Next meal time to eat is:");
//        Console.WriteLine("Hours: " + duration[0] + ",  Minutes: " + duration[1]);
//        Console.WriteLine();
//        //Console.WriteLine(meal);
//    }
//    static int[] CalculateMealDuration(DateTime currentTime)
//    {
//        int currentHour = currentTime.Hour;
//        int currentMinute = currentTime.Minute;
//        //if (currentHour < 7)
//        //{
//        //    nextMealHour = 7;
//        //}
//        //else if (currentHour < 12)
//        //{
//        //    nextMealHour = 12;
//        //}
//        //else if (currentHour < 19)
//        //{
//        //    nextMealHour = 19;
//        //}
//        //else
//        //{
//        //    nextMealHour = 7;
//        //}
//        int nextMealHour = (currentHour < 7) ? 7 : (currentHour < 12) ? 12 : (currentHour < 19) ? 19 : 7;
//        int nextMealMinute = 0;
//        string meal = (currentHour < 7) ? "Breakfast" : (currentHour < 12) ? "Lunch" : (currentHour < 19) ? "Dinner" : "Breakfast";
//        Console.WriteLine(meal);

//        int hours = nextMealHour - currentHour;
//        int minutes = nextMealMinute - currentMinute;

//        if (minutes < 0)
//        {
//            hours--;
//            minutes = 60 + minutes;
//        }

//        if (hours < 0)
//        {
//            hours = 24 + hours;
//        }

//        return new int[] { hours, minutes };
//    }
//}

//1 hour and 10 minutes until the next meal, breakfast



string meal = "";

int[] duration = CalculateMealDuration( out  meal);
if (duration[0] > 0)
{
    Console.WriteLine("{0} hour and {1} minutes until the next meal, {2} ", duration[0], duration[1], meal);
}
else
{
    Console.WriteLine("{0} minutes until the next meal, {1} ", duration[1], meal);
}
static int[] CalculateMealDuration( out string meal)
{
    DateTime currentTime = DateTime.Now;
    int currentHour = currentTime.Hour;
    int currentMinute = currentTime.Minute;
    int nextMealHour = (currentHour < 7) ? 7 : (currentHour < 12) ? 12 : (currentHour < 19) ? 19 : 7;
    int nextMealMinute = 0;
    meal = (currentHour < 7) ? "Breakfast" : (currentHour < 12) ? "Lunch" : (currentHour < 19) ? "Dinner" : "Breakfast";
    int hours = nextMealHour - currentHour;
    int minutes = nextMealMinute - currentMinute;
    if (minutes < 0)
    {
        hours--;
        minutes = 60 + minutes;
    }
    if (hours < 0)
    {
        hours = 24 + hours;
    }
    return new int[] { hours, minutes };
}


