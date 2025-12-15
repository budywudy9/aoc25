using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc25.days
{
    internal class Day3
    {

        List<string> numbers;

        public Day3(string filePath)
        {
            numbers = new List<string>();
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
                    numbers.Add(line);
            }
        }

        //private int PartOne()
        //{
        //    int largest = 0;
        //    int second = 0;
        //    int v = 0;
        //    int total = 0;

        //    for (int i = 0; i < numbers.Count; i++)
        //    {
        //        Console.WriteLine(numbers[i]);
        //        for (int j = 0; j < numbers[i].Length - 1; j++)
        //        {
        //            v = Int32.Parse(numbers[i][j].ToString());
        //            if (v > largest && i != numbers[i].Length - 1)
        //            {
        //                largest = v;
        //                second = Int32.Parse(numbers[i][j + 1].ToString());
        //            }
        //            else if (v > second)
        //            {
        //                second = v;
        //            }
        //        }
        //        Console.WriteLine((largest * 10) + second);
        //        Console.WriteLine();
        //        total += (largest * 10) + second;
        //        largest = 0;
        //        second = 0;
        //        v = 0;
        //    }

        //    Console.WriteLine(total);
        //    return total;
        //}
        private int PartOne()
        {
            int total = 0;
            int highInt;
            int lowInt;

            for (int i = 0; i < numbers.Count(); i++)
            {
                highInt = 9;
                lowInt = 0;
                List<int> digits = new List<int>();

                foreach (char digit in numbers[i])
                    digits.Add(Int32.Parse(digit.ToString()));

                while (digits.IndexOf(highInt) == -1 || digits.IndexOf(highInt) == digits.Count() - 1)
                    highInt--;

                digits.RemoveRange(0, digits.IndexOf(highInt) + 1);
                lowInt = digits.Max();
                total += (highInt * 10) + lowInt;

            }
            //Console.WriteLine(total);

            return 0;
        }

        private int PartTwo()
        {
            long total = 0;

            for (int i = 0; i < numbers.Count(); i++)
            {
                long curTot = 0;
                int count = 0;
                int prevIdx = 0;
                int highestIdx;
                int d = 0;
                List<int> digits = new List<int>();
                foreach (char digit in numbers[i])
                    digits.Add(Int32.Parse(digit.ToString()));

                while (count < 12)
                {
                    highestIdx = 11 - count;
                    d = digits.Take(digits.Count() - (11 - count)).Max();
                    digits.RemoveRange(0, prevIdx + 1);
                    curTot += d * (long)Math.Pow(10, 11 - count);
                    count++;
                }
                total += curTot;
            }

            Console.WriteLine(total);
            return 0;
        }
    }
}
