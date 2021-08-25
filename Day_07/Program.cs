using System;
using System.Collections.Generic;
using System.Diagnostics;
using Utility_Library;

namespace Day_07
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            string[] Data = DataRepository.ReadToArray("151207 Input.txt");

            Dictionary<string, int> WiresDictionary = new Dictionary<string, int>();
            List<Instruction> InstructionList = new List<Instruction>();
            Instruction Instruction = new Instruction();

            //PART ONE
            Console.WriteLine("---PART ONE---\n\r");
            stopwatch.Start();

            foreach (string line in Data)
            {
                InstructionList.Add(Instruction.BuildInstruction(line));
            }

            while (InstructionList.Count != 0)
            {
                foreach (Instruction instruction in InstructionList)
                {
                    string outputKey = instruction.Output;
                    string input1Key = instruction.Input1;
                    string input2Key = instruction.Input2;

                    switch (instruction.Operator)
                    {
                        case "EQUALS":
                            if (instruction.Input1.IsNumeric())
                            {
                                int input = int.Parse(instruction.Input1);
                                if (WiresDictionary.ContainsKey(outputKey))
                                {
                                    WiresDictionary[outputKey] = input;
                                    instruction.IsComplete = true;
                                    break;
                                }
                                else
                                {
                                    WiresDictionary.Add(outputKey, input);
                                    instruction.IsComplete = true;
                                    break;
                                }
                            }
                            if (!WiresDictionary.ContainsKey(input1Key)) break;
                            if (WiresDictionary.ContainsKey(outputKey))
                            {
                                WiresDictionary[outputKey] = WiresDictionary[input1Key];
                                instruction.IsComplete = true;
                                break;
                            }
                            else
                            {
                                WiresDictionary.Add(outputKey, WiresDictionary[input1Key]);
                                instruction.IsComplete = true;
                                break;
                            }

                        case "AND":
                            if (instruction.Input1.IsNumeric())
                            {
                                int input1 = int.Parse(instruction.Input1);
                                if (!WiresDictionary.ContainsKey(input2Key)) break;
                                if (WiresDictionary.ContainsKey(outputKey))
                                {
                                    WiresDictionary[outputKey] = input1 & WiresDictionary[input2Key];
                                    instruction.IsComplete = true;
                                    break;
                                }
                                else
                                {
                                    WiresDictionary.Add(outputKey, input1 & WiresDictionary[input2Key]);
                                    instruction.IsComplete = true;
                                    break;
                                }
                            }
                            else
                            {
                                if (!WiresDictionary.ContainsKey(input1Key) || !WiresDictionary.ContainsKey(input2Key)) break;
                                if (WiresDictionary.ContainsKey(outputKey))
                                {
                                    WiresDictionary[instruction.Output] = WiresDictionary[input1Key] & WiresDictionary[input2Key];
                                    instruction.IsComplete = true;
                                    break;
                                }
                                {
                                    int result = WiresDictionary[instruction.Input1] & WiresDictionary[instruction.Input2];
                                    WiresDictionary.Add(outputKey, WiresDictionary[input1Key] & WiresDictionary[input2Key]);
                                    instruction.IsComplete = true;
                                    break;
                                }
                            }

                        case "OR":
                            if (!WiresDictionary.ContainsKey(input1Key) || !WiresDictionary.ContainsKey(input2Key)) break;
                            if (WiresDictionary.ContainsKey(outputKey))
                            {
                                WiresDictionary[outputKey] = WiresDictionary[input1Key] | WiresDictionary[input2Key];
                                instruction.IsComplete = true;
                                break;
                            }
                            else
                            {
                                WiresDictionary.Add(outputKey, WiresDictionary[input1Key] | WiresDictionary[input2Key]);
                                instruction.IsComplete = true;
                                break;
                            }

                        case "NOT":
                            if (!WiresDictionary.ContainsKey(input2Key)) break;
                            if (WiresDictionary.ContainsKey(outputKey))
                            {
                                WiresDictionary[outputKey] = ~WiresDictionary[input2Key];
                                instruction.IsComplete = true;
                                break;
                            }
                            else
                            {
                                WiresDictionary.Add(outputKey, ~WiresDictionary[input2Key]);
                                instruction.IsComplete = true;
                                break;
                            }

                        case "LSHIFT":
                            if (!WiresDictionary.ContainsKey(input1Key)) break;
                            int lShift = int.Parse(instruction.Input2);
                            if (WiresDictionary.ContainsKey(instruction.Output))
                            {
                                WiresDictionary[instruction.Output] = WiresDictionary[input1Key] << lShift;
                                instruction.IsComplete = true;
                                break;
                            }
                            else
                            {
                                WiresDictionary.Add(outputKey, WiresDictionary[input1Key] << lShift);
                                instruction.IsComplete = true;
                                break;
                            }

                        case "RSHIFT":
                            if (!WiresDictionary.ContainsKey(input1Key)) break;
                            int rShift = int.Parse(instruction.Input2);
                            if (WiresDictionary.ContainsKey(instruction.Output))
                            {
                                WiresDictionary[instruction.Output] = WiresDictionary[input1Key] >> rShift;
                                instruction.IsComplete = true;
                                break;
                            }
                            else
                            {
                                WiresDictionary.Add(outputKey, WiresDictionary[input1Key] >> rShift);
                                instruction.IsComplete = true;
                                break;
                            }
                    }
                }
                InstructionList.RemoveAll(r => r.IsComplete == true);
            }

            stopwatch.Stop();
            Console.WriteLine($"Wire 'a' = {WiresDictionary["a"]}");
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();

            int keyATransfer = WiresDictionary["a"];
            InstructionList.Clear();
            WiresDictionary.Clear();
            Data[334] = $"{keyATransfer} -> b";

            //PART TWO
            Console.WriteLine("---PART TWO---\n\r");
            stopwatch.Start();

            foreach (string line in Data)
            {
                InstructionList.Add(Instruction.BuildInstruction(line));
            }

            while (InstructionList.Count != 0)
            {
                foreach (Instruction instruction in InstructionList)
                {
                    string outputKey = instruction.Output;
                    string input1Key = instruction.Input1;
                    string input2Key = instruction.Input2;

                    switch (instruction.Operator)
                    {
                        case "EQUALS":
                            if (instruction.Input1.IsNumeric())
                            {
                                int input = int.Parse(instruction.Input1);
                                if (WiresDictionary.ContainsKey(outputKey))
                                {
                                    WiresDictionary[outputKey] = input;
                                    instruction.IsComplete = true;
                                    break;
                                }
                                else
                                {
                                    WiresDictionary.Add(outputKey, input);
                                    instruction.IsComplete = true;
                                    break;
                                }
                            }
                            if (!WiresDictionary.ContainsKey(input1Key)) break;
                            if (WiresDictionary.ContainsKey(outputKey))
                            {
                                WiresDictionary[outputKey] = WiresDictionary[input1Key];
                                instruction.IsComplete = true;
                                break;
                            }
                            else
                            {
                                WiresDictionary.Add(outputKey, WiresDictionary[input1Key]);
                                instruction.IsComplete = true;
                                break;
                            }

                        case "AND":
                            if (instruction.Input1.IsNumeric())
                            {
                                int input1 = int.Parse(instruction.Input1);
                                if (!WiresDictionary.ContainsKey(input2Key)) break;
                                if (WiresDictionary.ContainsKey(outputKey))
                                {
                                    WiresDictionary[outputKey] = input1 & WiresDictionary[input2Key];
                                    instruction.IsComplete = true;
                                    break;
                                }
                                else
                                {
                                    WiresDictionary.Add(outputKey, input1 & WiresDictionary[input2Key]);
                                    instruction.IsComplete = true;
                                    break;
                                }
                            }
                            else
                            {
                                if (!WiresDictionary.ContainsKey(input1Key) || !WiresDictionary.ContainsKey(input2Key)) break;
                                if (WiresDictionary.ContainsKey(outputKey))
                                {
                                    WiresDictionary[instruction.Output] = WiresDictionary[input1Key] & WiresDictionary[input2Key];
                                    instruction.IsComplete = true;
                                    break;
                                }
                                {
                                    int result = WiresDictionary[instruction.Input1] & WiresDictionary[instruction.Input2];
                                    WiresDictionary.Add(outputKey, WiresDictionary[input1Key] & WiresDictionary[input2Key]);
                                    instruction.IsComplete = true;
                                    break;
                                }
                            }

                        case "OR":
                            if (!WiresDictionary.ContainsKey(input1Key) || !WiresDictionary.ContainsKey(input2Key)) break;
                            if (WiresDictionary.ContainsKey(outputKey))
                            {
                                WiresDictionary[outputKey] = WiresDictionary[input1Key] | WiresDictionary[input2Key];
                                instruction.IsComplete = true;
                                break;
                            }
                            else
                            {
                                WiresDictionary.Add(outputKey, WiresDictionary[input1Key] | WiresDictionary[input2Key]);
                                instruction.IsComplete = true;
                                break;
                            }

                        case "NOT":
                            if (!WiresDictionary.ContainsKey(input2Key)) break;
                            if (WiresDictionary.ContainsKey(outputKey))
                            {
                                WiresDictionary[outputKey] = ~WiresDictionary[input2Key];
                                instruction.IsComplete = true;
                                break;
                            }
                            else
                            {
                                WiresDictionary.Add(outputKey, ~WiresDictionary[input2Key]);
                                instruction.IsComplete = true;
                                break;
                            }

                        case "LSHIFT":
                            if (!WiresDictionary.ContainsKey(input1Key)) break;
                            int lShift = int.Parse(instruction.Input2);
                            if (WiresDictionary.ContainsKey(instruction.Output))
                            {
                                WiresDictionary[instruction.Output] = WiresDictionary[input1Key] << lShift;
                                instruction.IsComplete = true;
                                break;
                            }
                            else
                            {
                                WiresDictionary.Add(outputKey, WiresDictionary[input1Key] << lShift);
                                instruction.IsComplete = true;
                                break;
                            }

                        case "RSHIFT":
                            if (!WiresDictionary.ContainsKey(input1Key)) break;
                            int rShift = int.Parse(instruction.Input2);
                            if (WiresDictionary.ContainsKey(instruction.Output))
                            {
                                WiresDictionary[instruction.Output] = WiresDictionary[input1Key] >> rShift;
                                instruction.IsComplete = true;
                                break;
                            }
                            else
                            {
                                WiresDictionary.Add(outputKey, WiresDictionary[input1Key] >> rShift);
                                instruction.IsComplete = true;
                                break;
                            }
                    }
                }
                InstructionList.RemoveAll(r => r.IsComplete == true);
            }

            stopwatch.Stop();
            Console.WriteLine($"Wire 'a' = {WiresDictionary["a"]}");
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();
        }
    }
}
