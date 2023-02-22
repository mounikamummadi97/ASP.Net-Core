// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
//int flightTime = 120;
//int[] movies = new int[] { 20, 70, 50, 70, 30 };
//List<string> suggestedMovies = new List<string>();
//string[] movieTitles = new string[] { "A", "B", "C", "D", "E" };

//for (int i = 0; i < Math.Pow(2, movies.Length); i++)
//{
//    int currentTime = flightTime;
//    string currentSuggestion = "";
//    for (int j = 0; j < movies.Length; j++)
//    {
//        if ((i & (1 << j)) > 0)
//        {
//            currentTime -= movies[j];
//            currentSuggestion += movieTitles[j] + " ";
//        }
//    }
//    if (currentTime >= 0)
//    {
//        suggestedMovies.Add(currentSuggestion);
//    }
//}
//Console.WriteLine(suggestedMovies.Count);
//foreach (string movie in suggestedMovies)
//{

//    Console.WriteLine(movie);
//}
int flightTime = 110;
List<string> suggestedMovies = new List<string>();
string[] movieData = File.ReadAllLines("C:\\Users\\vinee\\OneDrive\\Desktop\\Mounika\\Mounika\\movieData.txt");
List<string> movieTitles = new List<string>();
List<int> movieDurations = new List<int>();

foreach (string line in movieData)
{
    string[] parts = line.Split('=');
    movieTitles.Add(parts[0]);
    movieDurations.Add(int.Parse(parts[1]));
}

int[] movies = movieDurations.ToArray();

for (int i = 0; i < Math.Pow(2, movies.Length); i++)
{
    int currentTime = flightTime;
    string currentSuggestion = "";
    for (int j = 0; j < movies.Length; j++)
    {
        if ((i & (1 << j)) > 0)
        {
            currentTime -= movies[j];
            currentSuggestion += movieTitles[j] + " ";
        }
    }
    if (currentTime == 0)
    {
        suggestedMovies.Add(currentSuggestion);
    }
    
}
foreach (string movie in suggestedMovies)
{

    Console.WriteLine(movie);
}