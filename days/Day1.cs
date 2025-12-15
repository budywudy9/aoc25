using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc25.days
{
    internal class Day1
    {
        private int startValue = 50;
        private List<int> rotation;

        public Day1(string filePath)
        {
            rotation = new List<int>();

            ReadFile(filePath);
            Console.WriteLine("PART ONE:");
            PartOne();
            Console.WriteLine();
            Console.WriteLine("PART TWO:");
            PartTwo();
        }

        private void ReadFile(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                int value;
                while ((line = sr.ReadLine()) != null)
                {
                    value = Int32.Parse(line.Substring(1, line.Length - 1));
                    //rotation.Add(line.Substring(0, 1) == "L" ? -value : value);
                    rotation.Add(value);
                }
            }

        }

        private int PartOne()
        {
            int dialValue = startValue;
            int zeroCount = 0;
            for (int i = 0; i < rotation.Count; i++)
            {
                dialValue = (dialValue + rotation[i]) % 100;
                if (dialValue == 0)
                    zeroCount++;
            }

            Console.WriteLine(zeroCount);
            return zeroCount;
        }

        //private int PartTwo()
        //{
        //    // start at 50
        //    // L150 -> total value = 200; dialValue = 0
        //    // clicks twice, then ends at 0
        //    // so count is 3

        //    int dialValue = startValue;
        //    int zeroCount = 0;
        //    int zeroPasses = 0;
        //    for (int i = 0; i < rotation.Count; i++)
        //    {
        //        zeroPasses = Math.Abs(rotation[i]) / 100;
        //        // adds no of times it will pass 0 without considering dialValue
        //        zeroCount += zeroPasses;
        //        // adds another rotation if considering dialValue causes another pass
        //        zeroCount += (dialValue + Math.Abs(rotation[i]) / 100) > zeroPasses ? 1 : 0;
        //        dialValue = (dialValue + rotation[i]) % 100;
        //        if (dialValue < 0)
        //            dialValue = 100 + dialValue;
        //        else
        //            dialValue = 100 - dialValue;
        //        Console.WriteLine("dialValue: " + dialValue);
        //        // final case: it ends on 0. This will not be caught by the previous check so no issue of duplication.
        //        if (dialValue == 0)
        //            zeroCount++;

        //    }

        //    Console.WriteLine(zeroCount);
        //    return zeroCount;
        //}

        private int PartTwo()
        {
            List<string> dir = new List<string>();
            int zeroCount = 0;
            int dialValue = startValue;
            int prevValue = 0;
            using (StreamReader sr = new StreamReader(@"..\..\..\docs\Day1Input.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                    dir.Add(line.Substring(0, 1));
            }

            for (int i = 0; i < dir.Count; i++)
            {
                prevValue = dialValue;
                //rotations  not considering dialValue
                zeroCount += rotation[i] / 100;
                if (dir[i] == "L")
                {
                    dialValue = (dialValue - rotation[i]) % 100;
                    if (dialValue < 0)
                    {
                        dialValue = 100 + dialValue;
                    }
                    if (prevValue != 0 && dialValue > prevValue || dialValue == 0)
                    {
                        zeroCount++;
                    }
                }
                else
                {
                    dialValue = (dialValue + rotation[i] % 100);
                    if (dialValue > 99)
                    {
                        dialValue = dialValue - 100;
                    }
                    if (prevValue != 0 && dialValue < prevValue || dialValue == 0)
                    {
                        zeroCount++;
                    }
                }
                Console.WriteLine(zeroCount);
            }
            return zeroCount;
        }
    }
}

//7099