using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility_Library;

namespace Day_06
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            //read data file
            var data = DataRepository.ReadToArray("151206 Input.txt");

            //PART ONE

            Console.WriteLine("---PART ONE---\n\r");
            stopwatch.Start();

            var instructionsList = new List<Instructions>();
            //var instructionsLine = new Instructions();

            foreach (string line in data)
            {
                var instructionsLine = new Instructions();
                string[] dataBreakdown = line.Split(',');

                string[] part1 = dataBreakdown[0].Split(' ');
                if (part1.Length == 2)
                {
                    instructionsLine.Instruction = part1[0];
                    instructionsLine.XStart = int.Parse(part1[1]);
                }
                else
                {
                    instructionsLine.Instruction = part1[1];
                    instructionsLine.XStart = int.Parse(part1[2]);
                }

                string[] part2 = dataBreakdown[1].Split(' ');
                instructionsLine.YStart = int.Parse(part2[0]);
                instructionsLine.XEnd = int.Parse(part2[2]);

                instructionsLine.YEnd = int.Parse(dataBreakdown[2]);

                instructionsList.Add(instructionsLine);
            }


            int[,] lightingRig = new int[1000, 1000];

            for (int x = 0; x < 1000; x++)
            {
                for (int y = 0; y < 1000; y++)
                {
                    lightingRig[x, y] = 0;
                }
            }

            foreach (Instructions lightingInstruction in instructionsList)
            {
                for (int y = lightingInstruction.YStart; y < lightingInstruction.YEnd + 1; y++)
                {
                    for (int x = lightingInstruction.XStart; x < lightingInstruction.XEnd + 1; x++)
                    {
                        if (lightingInstruction.Instruction == "on") lightingRig[x, y] = 1;
                        if (lightingInstruction.Instruction == "off") lightingRig[x, y] = 0;
                        if (lightingInstruction.Instruction == "toggle")
                        {
                            if (lightingRig[x, y] == 0)
                            {
                                lightingRig[x, y] = 1;
                            }
                            else
                            {
                                lightingRig[x, y] = 0;
                            }
                        }
                    }
                }
            }

            var lightsOnTotal = 0;

            for (int x = 0; x < 1000; x++)
            {
                for (int y = 0; y < 1000; y++)
                {
                    lightsOnTotal += lightingRig[x, y];
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"Total lights still on : {lightsOnTotal} ");
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();

            //PART TWO

            Console.WriteLine("\n\r---PART TWO---\n\r");
            stopwatch.Start();

            for (int x = 0; x < 1000; x++)
            {
                for (int y = 0; y < 1000; y++)
                {
                    lightingRig[x, y] = 0;
                }
            }

            foreach (Instructions lightingInstruction in instructionsList)
            {
                for (int y = lightingInstruction.YStart; y < lightingInstruction.YEnd + 1; y++)
                {
                    for (int x = lightingInstruction.XStart; x < lightingInstruction.XEnd + 1; x++)
                    {
                        if (lightingInstruction.Instruction == "on") lightingRig[x, y] += 1;
                        if (lightingInstruction.Instruction == "off")
                        {
                            if (lightingRig[x, y] > 0)
                            {
                                lightingRig[x, y] -= 1;
                            }
                        }
                        if (lightingInstruction.Instruction == "toggle") lightingRig[x, y] += 2;
                    }
                }
            }

            lightsOnTotal = 0;

            for (int x = 0; x < 1000; x++)
            {
                for (int y = 0; y < 1000; y++)
                {
                    lightsOnTotal += lightingRig[x, y];
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"Total lights still on : {lightsOnTotal}");
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();
        }

    }
}
