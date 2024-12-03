using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

static class Program
{
    static void Main()
    {
        string fileInput;
        string[] split = new string[2];
        List<int> locations1 = new List<int>();
        List<int> locations2 = new List<int>();
        int distance = 0;
        int similarity = 0;

        StreamReader sr = new StreamReader(@"..\..\..\input1.txt");

        while ((fileInput = sr.ReadLine()) != null)
        {
            split = fileInput.Split("   ");
            locations1.Add(int.Parse(split[0]));
            locations2.Add(int.Parse(split[1]));
        }

        sr.Close();
        locations1.Sort();
        locations2.Sort();

        for (int i = 0; i < locations1.Count(); i++)
        {
            distance += Math.Abs(locations1[i] - locations2[i]);
            // Console.WriteLine(distance);
        }

        // Result 1 
        Console.WriteLine(distance);

        for (int i = 0; i < locations1.Count(); i++)
        {
            int partialSimilarity = 0;
            for (int j = 0; j < locations2.Count(); j++)
            {
                if (locations1[i] == locations2[j])
                {
                    partialSimilarity++;
                }
            }
            partialSimilarity *= locations1[i];
            similarity += partialSimilarity;
        }

        //Result 2 
        Console.WriteLine("\n"+similarity);
    }
}


