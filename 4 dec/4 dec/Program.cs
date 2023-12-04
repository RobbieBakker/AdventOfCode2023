// See https://aka.ms/new-console-template for more information





using static System.Formats.Asn1.AsnWriter;

string path = "C:\\Users\\Robin\\Documents\\GitHub\\AdventOfCode2023\\4 dec\\input.txt";

part1(path);
part2(path);

static void part1(string path)
{
    string line;
    int sum = 0;

    using (StreamReader sr = new StreamReader(path))
    {
        while ((line = sr.ReadLine()) != null)
        {
            int matches = calculateMatches(line);
            sum += calculateScore(matches);
        }
        Console.WriteLine(sum);
    }
}

static void part2(string path)
{
    string line;
    string leftRight;
    int cards = 0;
    List<string> bigList = new List<string>();
    Dictionary<int,int> copyList = new Dictionary<int,int>();

    // Putting all the items in list bigList and putting occurrences in copyList
    using (StreamReader sr = new StreamReader(path))
    {
        int i = 0;
        while ((line = sr.ReadLine()) != null)
        {
            bigList.Add(line);
            copyList.Add(i, 1);
            i++;
        }
    }
    
    // Checking matches and adding the new won copycards to the copyList value
    for(int i = 0;  i < bigList.Count; i++)
    {
        int matches;
        matches = calculateMatches(bigList[i]);

        for(int j = i+1; j < (i + matches +1); j++)
        {
            copyList[j] += copyList[i];
        }
        
    }

    // Reading copyList value to calculate amount of cards
    foreach(KeyValuePair<int, int> card in copyList)
    {
        cards += card.Value;
    }
    Console.WriteLine(cards);
}

static int calculateMatches(string line)
{
    // remove the Card X:
    line = line.Substring(line.IndexOf(':') + 2);
    // split left and right list
    List<string> splittedList = line.Split('|').ToList();
    // convert them to ints and put each int into listitems
    List<int> leftList = splittedList[0].Split().Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToList();
    List<int> rightList = splittedList[1].Split().Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToList();
    int matches = 0;

    foreach (int value in rightList)
    {
        if (leftList.Contains(value))
        {
            matches += 1;
        }
    }
    return matches;
}

static int calculateScore(int matches)
{
    int score = 0;
    if (matches > 0)
    {
        score = ((int)Math.Pow(2, matches - 1));
    }
    return score;
}