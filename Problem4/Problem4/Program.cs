// See https://aka.ms/new-console-template for more information
//public string GenerateDOBAndGenderCode(DateTime dateOfBirth, string gender)
using System.Reflection;
//class program 
//{
//    public string GenerateSurnameCode(string surname)
//    {
//        string surnameCode = "";
//        int count = 0;
//        for (int i = 0; i < surname.Length; i++)
//        {
//            if (IsConsonant(surname[i]))
//            {
//                surnameCode += surname[i];
//                count++;
//                if (count == 3)
//                {
//                    break;
//                }
//            }
//        }

//        if (count < 3)
//        {
//            for (int i = 0; i < surname.Length; i++)
//            {
//                if (IsVowel(surname[i]))
//                {
//                    surnameCode += surname[i];
//                    count++;
//                    if (count == 3)
//                    {
//                        break;
//                    }
//                }
//            }
//        }

//        if (count < 3)
//        {
//            for (int i = count; i < 3; i++)
//            {
//                surnameCode += "X";
//            }
//        }

//        return surnameCode;
//    }

//    private bool IsConsonant(char c)
//    {
//        return !IsVowel(c);
//    }

//    private bool IsVowel(char c)
//    {
//        return "AEIOU".IndexOf(c) != -1;
//    }

//}
//public class name{
//    public string GenerateNameCode(string name)
//    {
//        string nameCode = "";
//        int count = 0;
//        for (int i = 0; i < name.Length; i++)
//        {
//            if (IsConsonant(name[i]))
//            {
//                nameCode += name[i];
//                count++;
//                if (count == 3)
//                {
//                    break;
//                }
//            }
//        }

//        if (count == 3)
//        {
//            return nameCode;
//        }
//        else if (count > 3)
//        {
//            nameCode = "";
//            nameCode += name[0];
//            nameCode += name[2];
//            nameCode += name[3];
//            return nameCode;
//        }

//        for (int i = 0; i < name.Length; i++)
//        {
//            if (IsVowel(name[i]))
//            {
//                nameCode += name[i];
//                count++;
//                if (count == 3)
//                {
//                    break;
//                }
//            }
//        }

//        if (count < 3)
//        {
//            for (int i = count; i < 3; i++)
//            {
//                nameCode += "X";
//            }
//        }

//        return nameCode;
//    }

//    private bool IsConsonant(char c)
//    {
//        return !IsVowel(c);
//    }

//    private bool IsVowel(char c)
//    {
//        return "AEIOU".IndexOf(c) != -1;
//    }


//}
//public class gender
//{
//    string GenerateCodeFromDate(DateTime birthdate, string gender)
//    {
//        //Take the last two digits of the year of birth
//        string year = birthdate.Year.ToString().Substring(2);

//        //Generate a letter corresponding to the month of birth
//        string month = "";
//        switch (birthdate.Month)
//        {
//            case 1: month = "A"; break;
//            case 2: month = "B"; break;
//            //...
//            case 12: month = "T"; break;
//        }

//        //For males take the day of birth adding one zero at the start if is less than 10
//        //For females take the day of birth and sum 40 to it
//        string day = "";
//        if (gender == "M")
//        {
//            day = birthdate.Day < 10 ? "0" + birthdate.Day : birthdate.Day.ToString();
//        }
//        else
//        {
//            day = (birthdate.Day + 40).ToString();
//        }

//        return year + month + day;
//    }

//}
class Person
{
    public string name;
    public string surname;
    public string gender;
    public DateTime dob;
}

class FiscalCode
{
    private static readonly string[] monthCodes = new string[] { "A", "B", "C", "D", "E", "H", "L", "M", "P", "R", "S", "T" };
    //char[] vowels = { 'A', 'E', 'I', 'O', 'U', 'a', 'e', 'i', 'o', 'u' };
    //char[] consonants = { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z', 'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Y', 'Z' };
    public static string fiscalCode(Person person)
    {
        string surnameCode = generateSurnameCode(person.surname);
        string nameCode = generateNameCode(person.name);
        string dobCode = generateDOBCode(person.dob, person.gender);

        return surnameCode + nameCode+ dobCode;
    }

    private static string generateSurnameCode(string surname)
    {
        string consonants = "";
        string vowels = "";
        foreach (char c in surname)
        {
            if (c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U' ||c=='a' ||c=='e' ||c=='i'||c=='o'||c=='u')
            {
                vowels += c;
            }
            else
            {
                consonants += c;
            }
        }
        //return (const+vowels + "XXX")substring(0, 3)
        if (consonants.Length >= 3)
        {
            return consonants.Substring(0, 3);
        }
        else
        {
            string code = "";
            int i = 0;
            while (code.Length < 3)
            {
                //(const+vowels + "XXX")substring(0, 3)
                if (i < consonants.Length)
                {
                    code += consonants[i];
                }
                else if (i - consonants.Length < vowels.Length)
                {
                    code += vowels[i - consonants.Length];
                }
                else
                {
                    code += "X";
                }
                i++;
            }
            return code;
        }
    }

    private static string generateNameCode(string name)
    {
        string consonants = "";
        string vowels = "";
        foreach (char c in name)
        {
            if (c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U' || c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
            {
                //c = char.ToUpper(c);
                vowels += c;
            }
            else
            {
                consonants += c;
            }
        }

        if (consonants.Length == 3)
        {
            return consonants;
        }
        else if (consonants.Length > 3)
        {
            return "" + consonants[0] + consonants[2] + consonants[3];
        }
        else
        {
            string code = "";
            int i = 0;
            while (code.Length < 3)
            {
                if (i < consonants.Length)
                {
                    code += consonants[i];
                }
                else if (i - consonants.Length < vowels.Length)
                {
                    code += vowels[i - consonants.Length];
                }
                else
                {
                    code += "X";
                }
                i++;
            }
            return code;
        }
    }


    private static string generateDOBCode(DateTime dob, string gender)
    {
        string yearCode = dob.Year.ToString().Substring(2);
        string monthCode = monthCodes[dob.Month - 1];
        string dayCode = dob.Day.ToString("D2");
        if (gender.ToUpper() == "F")
        {
            int femaleDay = dob.Day + 40;
            dayCode = femaleDay.ToString();
        }
        return yearCode + monthCode + dayCode;
    }

    public static void Main(string[] args)
    {
        var person = new { name = "Meet", surname = "AA", gender = "M", dob = new DateTime(1900, 1, 1) };
        string nameCode = generateNameCode(person.name);
        string surnameCode = generateSurnameCode(person.surname);
        string dobCode = generateDOBCode(person.dob, person.gender);
        string fiscalCode = surnameCode +  nameCode + dobCode;
        Console.WriteLine(fiscalCode.ToUpper());
    }
}