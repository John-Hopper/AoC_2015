using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility_Library;

namespace Day_08
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            //read data file
            var data = DataRepository.ReadToArray("151208 Input.txt");

            //PART ONE

            Console.WriteLine("---PART ONE---\n\r");
            stopwatch.Start();

            string output="";
            string singleChar;
            string hexToConvert;
            int decimalValue;
            int stringCode = 0;
            int stringValues = 0;
            int stringVariance;

            foreach (string item in data)
            {
                stringCode += item.Length;

                for (int index = 1; index < item.Length-1; index++)
                {
                    singleChar = item.Substring(index, 1);
                    if(singleChar==@"\")
                    {
                        index++;
                        singleChar = item.Substring(index, 1);
                        if (singleChar == "x")
                        {
                            index++;
                            hexToConvert = item.Substring(index, 1);
                            index++;
                            hexToConvert += item.Substring(index, 1);
                            decimalValue = Convert.ToInt32(hexToConvert, 16);
                            singleChar =Convert.ToChar(decimalValue).ToString();
                        }
                    }
                    output += singleChar;
                }
                stringValues += output.Length;
                output = "";
            }
            stringVariance = stringCode - stringValues;
            stopwatch.Stop();
            Console.WriteLine($"part 1 : {stringVariance} ");
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();

            //PART TWO

            Console.WriteLine("\n\r---PART TWO---\n\r");
            stopwatch.Start();


            stopwatch.Stop();
            Console.WriteLine($"Part 2 : {0}");
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();
        }
    }
}
