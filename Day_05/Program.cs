using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Utility_Library;
using static Day_05.ValidTests;

namespace Day_05
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            //read data file
            var data = DataRepository.ReadToArray("151205 Input.txt"); //("C&C.txt");
            //string[] data = new string[] { "qjhvhtzxzqqjkmpb" };
            //string[] data = new string[] { "xilodxfuxphuiiii" };
            //string[] data = new string[] { "xxyxx" };
            //string[] data = new string[] { "uurcxstgmygtbstg" };
            //string[] data = new string[] { "ieodomkazucvgmuy" };
            //string[] data = new string[] { "aaa" };

            //PART ONE
            var datacount = data.Length;
            Console.WriteLine("---PART ONE---\n\r");
            stopwatch.Start();

            var niceCount = 0;

            foreach (string line in data)
            {
                if (!ContainsDisallowedLetterSet(line))
                {
                    if (ContainsVowel(line))
                    {
                        if (ContainsDoubleLetter(line)) niceCount++;
                    }
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"Part one nice list count: {niceCount}");
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();

            //PART TWO
            Console.WriteLine("---PART TWO---\n\r");
            stopwatch.Start();

            niceCount = 0;


            foreach (string line in data)
            {
                //Console.WriteLine($"{line} - {datacount}");
                if (ContainsDuplicateDoubles(line)) //niceCount++;
                {
                    Console.WriteLine($"{line} - passed doubles");
                    if (ContainsRepeatedSeperatedLetter(line))
                    {
                        Console.WriteLine($"{line} - repeats passed");
                        niceCount++;
                        //Console.ReadLine();
                    }
                }
                //Console.ReadLine();
                //datacount--;
            }
            //Console.WriteLine(datacount);

            stopwatch.Stop();
            Console.WriteLine($"Part two nice list count: {niceCount}");
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();

        }
    }
}
