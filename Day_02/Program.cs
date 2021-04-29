using System;
using System.Collections.Generic;
using System.Diagnostics;
using Utility_Library;

namespace Day_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            //read data file
            var data = DataRepository.ReadToArray("151202 Input.txt");

            //PART ONE

            Console.WriteLine("---PART ONE---\n\r");

            stopwatch.Start();
            //dimensionData to list of presents
            var presentsList = new List<Present>();

            //populate list of presents
            foreach(string dimensionData in data)
            {
                // split line of password data into individual parts
                string[] dimension = dimensionData.Split('x');
                presentsList.Add(new Present() 
                {
                    Length=int.Parse(dimension[0]), 
                    Width=int.Parse(dimension[1]), 
                    Height=int.Parse(dimension[2]) 
                });
            }

            int wrappingToOrder = 0;

            foreach(Present present in presentsList)
            {
                wrappingToOrder += present.TotalWrapping;
            }

            stopwatch.Stop();

            Console.WriteLine($"Total wrapping to order for presents = {wrappingToOrder}");
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();

            //PART TWO

            Console.WriteLine("\n\r---PART TWO---\n\r");

            stopwatch.Start();
            int ribbonToOrder = 0;

            foreach (Present present in presentsList)
            {
                ribbonToOrder += present.TotalRibbon;
            }

            stopwatch.Stop();

            Console.WriteLine($"Total ribbon to order for presents = {ribbonToOrder}");
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();
        }
    }
}

