using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Utility_Library;

namespace Day_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            //read data file
            var data = DataRepository.ReadToString("151203 Input.txt");

            //PART ONE

            Console.WriteLine("---PART ONE---\n\r");
            stopwatch.Start();

            var addressDictionary = Address.GetAddresses(data);

            stopwatch.Stop();
            Console.WriteLine($"Number of distinct delivery addresses: {addressDictionary.Count} ");
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();

            //PART TWO

            Console.WriteLine("\n\r---PART TWO---\n\r");
            stopwatch.Start();

            string santaDirections = "";
            string roboDirections = "";

            for (int index = 0; index < data.Length; index++)
            {
                if (index % 2 == 0)
                {
                    santaDirections += data[index];
                }
                else
                {
                    roboDirections += data[index];
                }
            }

            var duelAddressDictionary = Address.GetAddresses(santaDirections, roboDirections);

            stopwatch.Stop();
            Console.WriteLine($"Number of delivery's made by Santa & Robo-Santa combined: {duelAddressDictionary.Count}");
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();
        }

    }
}
