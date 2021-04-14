using System;
using System.IO;
using System.Linq;
using Utility_Library;

namespace Day_01
{
    class Program
    {
        static void Main(string[] args)
        {
            // initialize Global Variables & get variable info
            Globals globalVariables = new Globals();
            globalVariables = globalVariables.GetGlobalVariables();

            // check environment and global variables initialized ok
            if (globalVariables.Failed)
            {
                Console.WriteLine($"Environment not found - Initialization Failed");
                Console.ReadLine();
                return;
            }

            //read data file
            string directionsData = File.ReadAllText($"{globalVariables.DataPath}151201 Input.txt");

            //Part One

            var upFloor = directionsData.Count(d=> d == '(');
            var downFloor = directionsData.Count(d => d == ')');

            var destinationFloor = upFloor - downFloor;

            Console.WriteLine($"Santa's destination floor : {destinationFloor}");
            Console.ReadLine();

            //Part Two

            var floorNumber = 0;
            var InstructionCount = 1;

            foreach(char direction in directionsData)
            {
                if (direction == '(') floorNumber++;
                if (direction == ')') floorNumber--;

                if (floorNumber < 0)
                {
                    Console.WriteLine($"Arrive in basement on instruction number : {InstructionCount}");
                    Console.ReadLine();
                    Environment.Exit(0);
                }

                InstructionCount++;
            }

        }
    }
}
