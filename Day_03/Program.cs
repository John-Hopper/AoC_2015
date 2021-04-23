using System;
using Utility_Library;

namespace Day_03
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
            var directionsData = DataRepository.ReadToString($"{globalVariables.DataPath}151203 Input.txt");

            Console.WriteLine(directionsData);
            Console.ReadLine();
        }
    }
}
