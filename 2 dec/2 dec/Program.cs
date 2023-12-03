// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;


string path = "C:\\Users\\Robin\\Documents\\GitHub\\AdventOfCode2023\\2 dec\\input.txt";

//part1(path);
part2(path);



static void part1(string path)
{
    int sum = 0;
    using (StreamReader sr = new StreamReader(path))
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            //Console.WriteLine("line:" + line);
            if (checkColor(line, "blue", 14) == true && checkColor(line, "green", 13) == true && checkColor(line, "red", 12) == true)
            {
                string pattern = @"\bGame\s(\d+)\b";
                var matches = Regex.Match(line, pattern);
                sum += int.Parse(matches.Groups[1].Value);
            }

        }
    }
    Console.WriteLine(sum);
}

static Boolean checkColor(string line, string color, int maxValue)
{
    string pattern = @"\b(\d+)\s" + color + "\\b";
    var matches = Regex.Matches(line, pattern);

    foreach (Match match in matches)
    {
        if (int.Parse(match.Groups[1].Value) > maxValue)
        {
            return false;
        }
    }
    return true;
}

static void part2(string path)
{
    int sum = 0;
    using (StreamReader sr = new StreamReader(path))
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            int maxBlue = 0;
            int maxGreen = 0;
            int maxRed = 0;


            //Console.WriteLine("line:" + line);
            // check maxvalue of blue
            maxBlue = getMinimumNeededCubes(line, "blue");
            maxGreen = getMinimumNeededCubes(line, "green");
            maxRed = getMinimumNeededCubes(line, "red");

            int power = maxBlue * maxGreen * maxRed;

            sum += power;
            //string pattern = @"\bGame\s(\d+)\b";

        }
    }
    Console.WriteLine(sum);
}

static int getMinimumNeededCubes(string line, string color)
{
    int maxValue = 0;

    string pattern = @"\b(\d+)\s"+color+"\\b";

    var matches = Regex.Matches(line, pattern);
    foreach (Match match in matches)
    {
        if (int.Parse(match.Groups[1].Value) > maxValue)
        {
            maxValue = int.Parse(match.Groups[1].Value);
        }
    }
    //Console.WriteLine("min " + color + " needed: " + maxValue);
    return maxValue;
}