using System;
using System.Collections.Generic;
using System.IO;

namespace TestAlgoritmoTT
{
    public class Similitud
    {
        public List<int> solicitante { get; set; }
        public Dictionary<string, float> results = new Dictionary<string, float>();

        public void func()
        {
            using (var reader = new StreamReader(@"../../../testMenores.csv"))
            {
                int lineCount = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (lineCount > 0)
                    {
                        List<int> ls = new List<int>();
                        string[] values = line.Split(',');
                        int columnCount = 0;
                        foreach (string value in values)
                        {
                            if (columnCount > 0)
                            {
                                ls.Add(Int32.Parse(value));
                            }
                            columnCount++;
                        }
                        int ab = 0;
                        int a = 0;
                        int b = 0;
                        for (int i = 0; i < 14; i++)
                        {
                            ab += this.solicitante[i] * ls[i];
                            a += (int)Math.Pow(this.solicitante[i], 2);
                            b += (int)Math.Pow(ls[i], 2);
                        }
                        float score = (float)(ab / (Math.Sqrt(a) * Math.Sqrt(b)));
                        this.results.Add(values[0], score);
                    }
                    lineCount ++;
                }
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Similitud sim = new Similitud();
            sim.solicitante = new List<int>() { 7, 6, 4, 9, 2, 6, 6, 1, 3, 8, 7, 7, 9, 2 };
            sim.func();
            foreach (KeyValuePair<string, float> kvp in sim.results)
            {
                Console.WriteLine(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value));
            }
        }
    }
}
