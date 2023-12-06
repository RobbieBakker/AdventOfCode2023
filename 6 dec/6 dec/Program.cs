// See https://aka.ms/new-console-template for more information
using Microsoft.VisualBasic;
using System.Numerics;


//part1();
part2();

static void part1()
{
    List<(int, int)> games = new List<(int, int)>();
    string path = "C:\\Users\\Robin\\Documents\\GitHub\\AdventOfCode2023\\6 dec\\input.txt";
    string input;
    int output = 1;
    using (StreamReader sr = new StreamReader(path))
    {
        input = sr.ReadToEnd();
    }
    input = input.Split("Time:")[1].ToString();
    string[] times = input.Split("\r\nDistance:", StringSplitOptions.RemoveEmptyEntries)[0].ToString().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string[] distances = input.Split("Distance:", StringSplitOptions.RemoveEmptyEntries)[1].ToString().Split(" ", StringSplitOptions.RemoveEmptyEntries);

    for (int i = 0; i < times.Length; i++)
    {
        games.Add((int.Parse(times[i]), int.Parse(distances[i])));
    }

    for (int i = 0; i < games.Count; i++)
    {
        int gameTime = games[i].Item1;
        int distToBeat = games[i].Item2;
        output *= getWinnings(gameTime, distToBeat);
    }
    Console.WriteLine(output);
}

static void part2()
{
    List<(int, int)> games = new List<(int, int)>();
    string path = "C:\\Users\\Robin\\Documents\\GitHub\\AdventOfCode2023\\6 dec\\input.txt";
    string input;
    int output = 1;
    using (StreamReader sr = new StreamReader(path))
    {
        input = sr.ReadToEnd();
    }
    input = input.Split("Time:")[1].Replace(" ", "").ToString();
    string times = input.Split("\r\nDistance:")[0];
    string distances = input.Split("Distance:")[1];

    int gameTime = int.Parse(times);
    long distToBeat = long.Parse(distances);
    Console.WriteLine(getWinnings(gameTime, distToBeat));
}

static int getWinnings(int gameTime, long distToBeat)
{
    int wins = 0;
    for(int i = 0; i < gameTime; i++)
    {
        int timeLeft = gameTime - i;
        long travelDist = (long) timeLeft * i;
        if (travelDist > distToBeat)
        {
            wins++;
        }
    }
    return wins;
}