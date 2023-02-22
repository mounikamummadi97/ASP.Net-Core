// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Linq;

public class FiscalCode
{
    //{
    //    private static string[] vowels = { "A", "E", "I", "O", "U" };
    //    private static string[] consonants = { "B", "C", "D", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "V", "W", "X", "Y", "Z" };
    //    private static string[] monthConversion = { "A", "B", "C", "D", "E", "H", "L", "M", "P", "R", "S", "T" };

    //    public static string fiscalCode(Person person)
    //    {
    //        string surname = GetSurnameCode(person.surname);
    //        string name = GetNameCode(person.name);
    //        string dob = GetDOBCode(person.dob, person.gender);

    //        return surname + name + dob;
    //    }

    //    private static string GetSurnameCode(string surname)
    //    {
    //        string code = "";
    //        int consonantCount = 0;
    //        for (int i = 0; i < surname.Length; i++)
    //        {
    //            if (consonants.Contains(surname[i].ToString().ToUpper()))
    //            {
    //                code += surname[i].ToString().ToUpper();
    //                consonantCount++;
    //                if (consonantCount == 3) break;
    //            }
    //            else if (vowels.Contains(surname[i].ToString().ToUpper()))
    //            {
    //                if (code.Length < 3)
    //                {
    //                    code += surname[i].ToString().ToUpper();
    //                }
    //            }
    //        }

    //        while (code.Length < 3)
    //        {
    //            code += "X";
    //        }

    //        return code;
    //    }

    //    private static string GetNameCode(string name)
    //    {
    //        string code = "";
    //        int consonantCount = 0;
    //        for (int i = 0; i < name.Length; i++)
    //        {
    //            if (consonants.Contains(name[i].ToString().ToUpper()))
    //            {
    //                consonantCount++;
    //                if (consonantCount == 1 || consonantCount == 3 || consonantCount == 4)
    //                {
    //                    code += name[i].ToString().ToUpper();
    //                }
    //                if (code.Length == 3) break;
    //            }
    //            else if (vowels.Contains(name[i].ToString().ToUpper()))
    //            {
    //                if (code.Length < 3)
    //                {
    //                    code += name[i].ToString().ToUpper();
    //                }
    //            }
    //        }

    //        while (code.Length < 3)
    //        {
    //            code += "X";
    //        }

    //        return code;
    //    }

    //    private static string GetDOBCode(string dob, string gender)
    //    {
    //        string[] parts = dob.Split('/');
    //        int day = int.Parse(parts[0]);
    //        int month = int.Parse(parts[1]);

    //    }
    //    person = new {
    //        name = "Helen",
    //        surname = "Yu",
    //        gender = "F",
    //        dob = new DateTime(1950, 12, 1)
    //    };
    //Console.WriteLine(FiscalCode(person));

    //person = new
    //{
    //    name = "Mickey",
    //    surname = "Mouse",
    //    gender = "M",
    //    dob = new DateTime(1928, 1, 16)
    //};
    //Console.WriteLine(FiscalCode(person));
    public string GenerateFiscalCode(string name, string surname, string gender, DateTime dateOfBirth)
    {
        // Initialize variables to store the characters of the Fiscal Code
        string surnameCode = "";
        string nameCode = "";

        // Get the first 3 consonants of the surname
        var surnameConsonants = new string(surname.Where(c => !Char.IsVowel(c)).Take(3).ToArray());
        if (surnameConsonants.Length >= 3)
        {
            surnameCode = surnameConsonants.Substring(0, 3);
        }
        else
        {
            // Get the first (3 - surnameConsonants.Length) vowels of the surname
            var surnameVowels = new string(surname.Where(c => Char.IsVowel(c)).Take(3 - surnameConsonants.Length).ToArray());
            surnameCode = surnameConsonants + surnameVowels;

            // If the surname has less than 3 letters, add "X" to the end
            if (surnameCode.Length < 3)
            {
                surnameCode += "X";
            }
        }

        // Get the first, third and fourth consonants of the name
        var nameConsonants = new string(name.Where(c => !Char.IsVowel(c)).ToArray());
        if (nameConsonants.Length >= 4)
        {
            nameCode = nameConsonants[0] + nameConsonants[2] + nameConsonants[3];
        }
        else if (nameConsonants.Length >= 3)
        {
            nameCode = nameConsonants.Substring(0, 3);
        }
        else
        {
            // Get the first (3 - nameConsonants.Length) vowels of the name
            var nameVowels = new string(name.Where(c => Char.IsVowel(c)).Take(3 - nameConsonants.Length).ToArray());
            nameCode = nameConsonants + nameVowels;

            // If the name has less than 3 letters, add "X" to the end
            if (nameCode.Length < 3)
            {
                nameCode += "X";
            }
        }

        // Add the remaining characters of the Fiscal Code (date of birth and control code)
        string fiscalCode = surnameCode + nameCode + dateOfBirth.ToString("ddMMyy") + gender;

        // Calculate the control code
        int controlCode = GetControlCode(fiscalCode);
        fiscalCode += controlCode.ToString();

        return fiscalCode;
    }
        public string GenerateDOBAndGenderCode(DateTime dateOfBirth, string gender)
        {
            // Get the last two digits of the year of birth
            string yearCode = dateOfBirth.Year.ToString().Substring(2, 2);

            // Get the letter corresponding to the month of birth
            string monthCode = "";
            switch (dateOfBirth.Month)
            {
                case 1:
                    monthCode = "A";
                    break;
                case 2:
                    monthCode = "B";
                    break;
                // and so on for all the months
                case 12:
                    monthCode = "T";
                    break;
            }

            // Get the day of birth code
            string dayCode = "";
            if (gender == "M")
            {
                dayCode = dateOfBirth.Day.ToString("D2");
            }
            else if (gender == "F")
            {
                dayCode = (dateOfBirth.Day + 40).ToString();
            }

            return yearCode + monthCode + dayCode;
        }

    }
}