using System.Numerics;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Xml;

static class Program
{
    static void Main()
    {
        string line;
        int length = 0;
        char[,] matrix = new char[140, 140];
        int l = 0;
        int matchCount = 0;
        StreamReader sr = new StreamReader(@"..\..\..\input4.txt");
        int crossFound = 0;

        while ((line = sr.ReadLine()) != null)
        {
            if (length == 0)
                length = line.Length;
            for (int x = 0; x < line.Length; x++)
            {
                matrix[l, x] = Convert.ToChar(line.Substring(x, 1));
                /* Console.Write(matrix[x, y]); */
            }
            l++;
        }
        sr.Close();

        for (int y = 0; y < length; y++)
        {
            //hor
            line = "";
            for (int x = 0; x < length; x++)
                line += matrix[y, x];

            Console.WriteLine(line);
            matchCount += CountMatches(line);

            crossFound += FindX(line, y, matrix);

            //ver
            /*             line = "";
                        for (int x = 0; x < length; x++)
                            line += matrix[x, y];

                        matchCount += CountMatches(line); */
            /* Console.WriteLine(line); */

            //ascend 1/2
            line = "";
            for (int x = 0; x <= y; x++)
                line += matrix[y - x, x];



            matchCount += CountMatches(line);
            /* Console.WriteLine(line); */


            /* crossFound += FindX(y, line, matrix, 0); */


            //descend 1/2
            /*             line = "";
                        for (int x = y; x >= 0; x--)
                            line += matrix[length - 1 - x, y - x];

                        matchCount += CountMatches(line); */
            /* Console.WriteLine(line); */

        }

        for (int y = length - 2; y >= 0; y--)
        {
            //ascend 2/2
            line = "";
            for (int x = 0; x <= y; x++)
                line += matrix[length - 1 - x, x + length - 1 - y];

            matchCount += CountMatches(line);
            /* Console.WriteLine(line); */


            /* crossFound += FindX(y, line, matrix, Math.Abs(length - 1 - y)); */



            //descend 2/2
            /*             line = "";
                        for (int x = 0; x <= y; x++)
                            line += matrix[x, length - 1 - y + x];

                        matchCount += CountMatches(line); */
            /* Console.WriteLine(line); */
        }
        /* Console.WriteLine(matchCount); */
        Console.WriteLine(crossFound);
    }




    /*     static public int FindXDiag(int y, string line, char[,] matrix, int extra)
        {
            int found = 0;
            string pattern1 = "MAS";
            string pattern2 = "SAM";
            string patt = "MAS|SAM";

            foreach (Match match in Regex.Matches(line, patt))
            {
                string crossLine = "";

                for (int j = -1; j < 2; j++)
                {
                    crossLine += matrix[extra + y - match.Index - 1 + j, extra + match.Index + 1 + j];
                }

                if (crossLine == pattern1 || crossLine == pattern2)
                    found++;
            }

            return found;
        } */


    static public int FindX(string line, int y, char[,] matrix)
    {
        int count = 0;
        string[] crossLine = new string[2];

        foreach (Match match in Regex.Matches(line, "A"))
        {
            if (y > 0 && y < line.Length -1 && match.Index > 0 && match.Index < line.Length - 1)
            {
                crossLine[0] = "";
                crossLine[1] = "";
                for (int i = -1; i < 2; i++)
                {
                    crossLine[0] += matrix[y + i, match.Index + i];
                    crossLine[1] += matrix[y - i, match.Index + i];
                }

                if ((crossLine[0] == "SAM" || crossLine[0] == "MAS") && (crossLine[1] == "SAM" || crossLine[1] == "MAS"))
                    count++;
            }
        }

        return count;

    }


    static public int CountMatches(string l)
    {
        string pattern1 = "XMAS";
        string pattern2 = "SAMX";
        int count = 0;

        foreach (Match match in Regex.Matches(l, pattern1))
            count++;
        foreach (Match match in Regex.Matches(l, pattern2))
            count++;

        return count;
    }

}