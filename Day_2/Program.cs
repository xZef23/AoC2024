
static class Program
{

    static void Main()

    {
        string fileInput;
        string[] report;
        int[] levels = new int[10];
        List<int> dampLevels = new List<int>();
        bool safecheck;
        bool safe;
        int safeCount = 0;
        StreamReader sr = new StreamReader(@"..\..\..\input2.txt");

        while ((fileInput = sr.ReadLine()) != null)
        {
            report = fileInput.Split();
            for (int i = 0; i < report.Length; i++)
            {
                Array.Resize<int>(ref levels, report.Length);
                levels[i] = Convert.ToInt32(report[i]);
            }

            safecheck = false;

            for (int i = 0; i < levels.Length; i++)
            {
                int lastSign = 0;
                safe = true;
                dampLevels.Clear();

                for (int j = 0; j < levels.Length; j++)
                {
                    if (i != j)
                    {
                        dampLevels.Add(levels[j]);
                    }
                }

                for (int j = 1; j < dampLevels.Count(); j++)
                {
                    int diff = Math.Abs(dampLevels[j - 1] - dampLevels[j]);
                    int sign = Math.Sign(dampLevels[j - 1] - dampLevels[j]);
                    if (diff > 3 || diff < 1 || sign + lastSign == 0)
                    {
                        safe = false;
                    }
                    lastSign = sign;
                }

                if (safe)
                    safecheck = true;


            }

            if (safecheck)
                safeCount++;

        }

        sr.Close();
        Console.WriteLine(safeCount);
    }

}