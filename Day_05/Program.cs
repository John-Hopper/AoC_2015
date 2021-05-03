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
            var data = DataRepository.ReadToArray("151205 Input.txt");

            //PART ONE

            Console.WriteLine("---PART ONE---\n\r");
            stopwatch.Start();

            var niceCount = 0;

            foreach (string line in data)
            {
                if (!ContainsDisallowedLetterSet(line)) 
                {
                    if (ContainsVowel(line))
                    {
                        if(ContainsDoubleLetter(line)) niceCount++;
                    }
                }
            }           

            stopwatch.Stop();
            Console.WriteLine($"secret number with giving five zeros: {niceCount}");
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();

            //PART TWO
            Console.WriteLine("---PART TWO---\n\r");
            stopwatch.Start();

            

            stopwatch.Stop();
            Console.WriteLine($"secret number with giving six zeros: {1}");
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();

        }
    }
}
