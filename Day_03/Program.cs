using System;
using System.Collections.Generic;
using System.Linq;
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
            //directionsData = "^>v<";

            // PART 1

            Console.WriteLine("Part 1\n\r");

            var houseaddressList = new List<string>();
            var houseCoOrdinates = new HouseCoOrdinates();

            houseaddressList = houseCoOrdinates.GetHouseAddresses(directionsData);

            int distinctAddresses = (from x in houseaddressList select x).Distinct().Count();

            Console.WriteLine($"Number of distinct delivery addresses: {distinctAddresses}\n\r");
            Console.ReadLine();

            // PART 2

            string santaDirections = "";
            string roboDirections = "";
            var santaHouseaddress = new List<string>();
            var roboHouseaddress = new List<string>();

            for (int index=0; index < directionsData.Length; index++)
            {
                if (index % 2 == 0)
                {
                    santaDirections += directionsData[index];
                }
                else
                {
                    roboDirections += directionsData[index];
                }
            }

            santaHouseaddress = houseCoOrdinates.GetHouseAddresses(santaDirections);
            roboHouseaddress = houseCoOrdinates.GetHouseAddresses(roboDirections);

            var duoHouseaddress = santaHouseaddress.Concat(roboHouseaddress).ToList();

            distinctAddresses = (from x in duoHouseaddress select x).Distinct().Count();

            Console.WriteLine($"Number of distinct delivery addresses for duel rounds: {distinctAddresses}\n\r");
            Console.ReadLine();
        }

    }
}
