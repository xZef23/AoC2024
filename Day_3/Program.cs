using System.Security;
using System.Text.RegularExpressions;

static class Program
{

    static void Main()
    {
        string pattern = @"mul\(\d{1,3},\d{1,3}\)";
        string input;
        string[] part;
        string[] values = new string[2];
        int result = 0;

        StreamReader sr = new StreamReader(@"..\..\..\input3.txt");
        input = sr.ReadToEnd();
        sr.Close();

        part = input.Split("do");
        for (int i = 0; i < part.Length; i++)
        {
            if (i == 0 || part[i].StartsWith("()"))
                foreach (Match match in Regex.Matches(part[i], pattern))
                {
                    values = Sanitize(match.Value).Split(',');
                    result = result + (Convert.ToInt32(values[0]) * Convert.ToInt32(values[1]));
                }
        }

        Console.WriteLine(result);
    }

    static public string Sanitize(string value)
    {
        value = value.Substring(4);
        value = value.Trim(')');
        return value;
    }

}