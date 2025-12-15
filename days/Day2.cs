using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc25.days
{
    internal class Day2
    {
        string[] ranges;
        public Day2(string filePath)
        {
            ReadFile(filePath);
            PartOne();
            PartTwo();
        }

        private void ReadFile(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    ranges = line.Split(',');
                }
            }
        }

        private long PartOne()
        {
            long total = 0;
            long firstHalf = 0;
            long secondHalf = 0;
            for (int i = 0; i < ranges.Length; i++)
            {
                for (long j = Int64.Parse(ranges[i].Split('-')[0]); j <= Int64.Parse(ranges[i].Split('-')[1]); j++)
                {
                    // guard case: if number is a single digit, it cannot repeat digits and so is valid
                    if (j < 10)
                        continue;
                    int digits = (int)Math.Floor(Math.Log10(j)) + 1;
                    // number cannot be made of two pairs of repeating digits if the number of digits is not an even number
                    if (digits % 2 != 0)
                        continue;
                    firstHalf = j / (long)Math.Pow(10, digits / 2);
                    secondHalf = j - (firstHalf * (long)Math.Pow(10, digits / 2));
                    if (firstHalf == secondHalf)
                    {
                        //Console.WriteLine(j);
                        total += j;
                    }
                }
            }

            Console.WriteLine(total);
            return total;
        }

        private void PartTwo()
        {
            Console.WriteLine();
            long total = 0;
            for (int i = 0; i < ranges.Length; i++)
            {
                for (long j = Int64.Parse(ranges[i].Split('-')[0]); j <= Int64.Parse(ranges[i].Split('-')[1]); j++)
                {
                    // guard case: if number is a single digit, it cannot repeat digits and so is valid
                    if (j < 10)
                        continue;

                    int digits = (int)Math.Floor(Math.Log10(j)) + 1;

                    List<int> factors = divisors(digits);
                    foreach (int f in factors)
                    {
                        IEnumerable<string> split = Split(j.ToString(), f);
                        if (split.All(x => x == split.First()))
                        {
                            total += j;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(total);
        }

        private List<int> divisors(long inp)
        {
            HashSet<int> factors = new HashSet<int>();

            for (int i = 1; i <= inp/2; i++)
            {
                if (inp % i == 0)
                    factors.Add(i);
            }

            return factors.ToList();
        }

        //ty stack overflow im too lazy to write this myself
        static IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }
    }
}
