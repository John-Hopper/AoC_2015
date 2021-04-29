using System;
using System.Diagnostics;
using System.Linq;
using Utility_Library;

namespace Day_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            //read data file
            var data = DataRepository.ReadToString("151201 Input.txt");

            //PART ONE

            Console.WriteLine("---PART ONE---\n\r");
            stopwatch.Start();

            var upFloor = data.Count(d=> d == '(');
            var downFloor = data.Count(d => d == ')');

            var destinationFloor = upFloor - downFloor;

            stopwatch.Stop();

            Console.WriteLine($"Santa's destination floor : {destinationFloor}");
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();

            //PART TWO

            Console.WriteLine("\n\r---PART TWO---\n\r");

            stopwatch.Start();
            var floorNumber = 0;
            var InstructionCount = 1;

            foreach(char direction in data)
            {
                if (direction == '(') floorNumber++;
                if (direction == ')') floorNumber--;

                if (floorNumber < 0)
                {
                    stopwatch.Stop();
                    Console.WriteLine($"Arrive in basement on instruction number : {InstructionCount}");
                    Console.WriteLine(stopwatch.Elapsed);
                    Console.ReadLine();
                    Environment.Exit(0);
                }

                InstructionCount++;
            }

        }
    }
}
