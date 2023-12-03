// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

string path = "C:\\Users\\Robin\\Documents\\GitHub\\AdventOfCode2023\\3 dec\\input2.txt";

part1(path);

static void part1(string path)
{
    char[,] array = buildArray(path);
    List<int> parts = new List<int>();
    parts.Add(0);
    
    for (int i = 0; i < array.GetLength(0); i++)
    {//each line

        for(int j = 0; j < array.GetLength(1); j++)
        {//each character
            string number = "";
            char[] specialChars = { '@', '#', '$', '%', '&', '*', '-', '=', '+', '/'};
            if (array[i, j].ToString().Any(char.IsDigit))
            {//if there is a number
                
                if(
                    specialChars.Contains(array[i-1, j-1]) || specialChars.Contains(array[i-1, j]) || specialChars.Contains(array[i-1, j+1]) || 
                    specialChars.Contains(array[i, j-1]) || specialChars.Contains(array[i, j+1]) || 
                    specialChars.Contains(array[i+1, j-1]) || specialChars.Contains(array[i+1, j]) || specialChars.Contains(array[i+1, j + 1]))
                {// if aangrenzend bevat speciaal teken ga naar begin van getal en add ze toe tot number string

                    int k = 0;
                    while (array[i, j + k].ToString().Any(char.IsDigit))
                    {
                        k--;
                    }
                    k += 1; // index kwam 1 te laag uit
                    while (array[i, j + k].ToString().Any(char.IsDigit))
                    {
                        number += array[i, j + k];
                        k++;
                    }
                    if(!number.Equals(""))
                    {
                        if (!parts.Last().Equals(int.Parse(number)))
                        {
                            parts.Add(int.Parse(number));
                            //Console.WriteLine(number);
                        }
                        number = "";
                    }
                }
            }
        }
    }

    Console.WriteLine(parts.Sum());
}

static char[,] buildArray(string path)
{
    using (StreamReader sr = new StreamReader(path))
    {
        char[,] array = new char[142, 143];
        string line;

        int lineNumber = 0;
        // looping through the lines
        while ((line = sr.ReadLine()) != null)
        {
            // looping through the characters
            for (int i = 0; i < line.Length; i++)
            {
                array[lineNumber, i] = line[i];
            }

            lineNumber++;
        }
        return array;
    }
}