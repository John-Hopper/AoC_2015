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

            data = "^>v<";

            //PART ONE

            var addressDictionary = new Dictionary<(int, int), int>();

            addressDictionary.Add((0,0),1);

            Console.WriteLine("---PART ONE---\n\r");
            stopwatch.Start();

            //var houseaddressList = new List<string>();
            //var houseCoOrdinates = new HouseCoOrdinates();

            //houseaddressList = houseCoOrdinates.GetHouseAddresses(data);

            //int distinctAddresses = (from x in houseaddressList select x).Distinct().Count();

            stopwatch.Stop();
            Console.WriteLine($"Number of distinct delivery addresses: ");
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();

            //PART TWO

            Console.WriteLine("\n\r---PART TWO---\n\r");

            //string santaDirections = "";
            //string roboDirections = "";
            //var santaHouseaddress = new List<string>();
            //var roboHouseaddress = new List<string>();

            //for (int index=0; index < directionsData.Length; index++)
            //{
            //    if (index % 2 == 0)
            //    {
            //        santaDirections += directionsData[index];
            //    }
            //    else
            //    {
            //        roboDirections += directionsData[index];
            //    }
            //}

            //santaHouseaddress = houseCoOrdinates.GetHouseAddresses(santaDirections);
            //roboHouseaddress = houseCoOrdinates.GetHouseAddresses(roboDirections);

            //var duoHouseaddress = santaHouseaddress.Concat(roboHouseaddress).ToList();

            //distinctAddresses = (from x in duoHouseaddress select x).Distinct().Count();
            stopwatch.Stop();
            Console.WriteLine($"Number of distinct delivery addresses for duel rounds: ");
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();
        }

    }
}
