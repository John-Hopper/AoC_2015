using System;
using System.Collections.Generic;
using Utility_Library;

namespace Day_02
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
            var dimensionsData = DataRepository.ReadToArray($"{globalVariables.DataPath}151202 Input.txt");

            //PART ONE

            //dimensionData to list of presents
            var presentsList = new List<Present>();

            //populate list of presents
            foreach(string dimensionData in dimensionsData)
            {
                // split line of password data into individual parts
                string[] data = dimensionData.Split('x');
                presentsList.Add(new Present() 
                {
                    Length=int.Parse(data[0]), 
                    Width=int.Parse(data[1]), 
                    Height=int.Parse(data[2]) 
                });
            }

            int wrappingToOrder = 0;

            foreach(Present present in presentsList)
            {
                wrappingToOrder += present.TotalWrapping;
            }

            Console.WriteLine("--PART ONE--\r\n");
            Console.WriteLine($"Total wrapping to order for presents = {wrappingToOrder}\r\n");
            Console.ReadLine();

            //PART TWO

            int ribbonToOrder = 0;

            foreach (Present present in presentsList)
            {
                ribbonToOrder += present.TotalRibbon;
            }

            Console.WriteLine("--PART TWO--\r\n");
            Console.WriteLine($"Total ribbon to order for presents = {ribbonToOrder}\r\n");
            Console.ReadLine();
        }
    }
}

