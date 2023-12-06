// See https://aka.ms/new-console-template for more information



//part1();
using Microsoft.VisualBasic;
using System.Numerics;

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
        output *= getPossibilities(gameTime, distToBeat);
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
    BigInteger distToBeat = BigInteger.Parse(distances);
    BigInteger int1 = 51699833;
    BigInteger int2 = 46;
    Console.WriteLine(int1 * int2);
    output = getWinnings(gameTime, distToBeat);
    
    

    Console.WriteLine(output);

}

static int getWinnings(int gameTime, BigInteger distToBeat)
{
    int timeLeft = gameTime;
    BigInteger travelDist = 0;
    int wins = 0;
    for(int i = 0; i < gameTime; i++)
    {
        timeLeft = gameTime - i;
        travelDist = BigInteger.Parse(timeLeft.ToString()) * i;
        if (travelDist > distToBeat)
        {
            wins++;
        }
    }

    return wins;
}


static int getPossibilities(int gameLength, int distToBeat)
{
    int pressTime = 0;
    int timeLeft = gameLength;
    int travelDist = 0;
    int possibilities = 0;
    for(int i = 0; i < gameLength; i++)
    {
        pressTime = i;
        timeLeft = gameLength - pressTime;
        travelDist = timeLeft * i;
        if(travelDist > distToBeat)
        {
            possibilities++;
        }
    }
    return possibilities;
}
