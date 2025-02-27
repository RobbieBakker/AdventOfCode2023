
using System.Numerics;

string path = "C:\\Users\\Robin\\Documents\\GitHub\\AdventOfCode2023\\5 dec\\test.txt";
string input;
Dictionary<BigInteger, BigInteger?> seeds = new Dictionary<BigInteger, BigInteger?>();
Dictionary<BigInteger, BigInteger?> seedsToSoil = new Dictionary<BigInteger, BigInteger?>();
Dictionary<BigInteger, BigInteger> soilToFert = new Dictionary<BigInteger, BigInteger>();
Dictionary<BigInteger, BigInteger> fertToWater = new Dictionary<BigInteger, BigInteger>();
Dictionary<BigInteger, BigInteger> waterToLight = new Dictionary<BigInteger, BigInteger>();
Dictionary<BigInteger, BigInteger> lightToTemp = new Dictionary<BigInteger, BigInteger>();
Dictionary<BigInteger, BigInteger> tempToHum = new Dictionary<BigInteger, BigInteger>();
Dictionary<BigInteger, BigInteger> humToLoc = new Dictionary<BigInteger, BigInteger>();


using (StreamReader sr = new StreamReader(path))
{
    input = sr.ReadToEnd();
}

string[] split = input.Split(new[] { "seeds: " }, StringSplitOptions.None);
string seedString = split[1].Split(new[] { "seed-to-soil map:" }, StringSplitOptions.None)[0];
input = split[1].Split(new[] { "seed-to-soil map:" }, StringSplitOptions.None)[1];

string soilString = input.Split(new[] { "soil-to-fertilizer map:" }, StringSplitOptions.None)[0];
input = split[1].Split(new[] { "soil-to-fertilizer map:" }, StringSplitOptions.None)[1];


foreach (string number in seedString.Split(" ", StringSplitOptions.RemoveEmptyEntries))
{
    seeds.Add(BigInteger.Parse(number), null);
}

foreach (string line in soilString.Split("\r\n", StringSplitOptions.RemoveEmptyEntries)){
    Console.WriteLine(line.Split(' ')[0], StringSplitOptions.RemoveEmptyEntries);
    BigInteger destination = BigInteger.Parse(line.Split(' ')[0]);
    BigInteger source = BigInteger.Parse((line.Split(' ')[1]).Split(' ')[0]);
    Console.WriteLine(destination);
    seedsToSoil.Add(destination, null);
}

Console.WriteLine(seedsToSoil.Count);
