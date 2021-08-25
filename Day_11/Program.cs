using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_11
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            //var input = "vzbxkghb";
            var input = "ghijklmn";
            char[] inputArray;

            inputArray = input.ToCharArray(0, input.Length);

            //PART ONE

            Console.WriteLine("---PART ONE---\n\r");
            stopwatch.Start();

            var answer = CharIteration(inputArray);

            stopwatch.Stop();
            Console.Write("part 1 : ");
            Console.Write(inputArray);
            Console.WriteLine();
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

        public static char[] CharIteration(char[] inputArray)
        {
            Console.WriteLine(inputArray);
            Console.WriteLine();
            while (inputArray[0] < '{')
            {
                while (inputArray[1] < '{')
                {
                    while (inputArray[2] < '{')
                    {
                        while (inputArray[3] < '{')
                        {
                            while (inputArray[4] < '{')
                            {
                                while (inputArray[5] < '{')
                                {
                                    while (inputArray[6] < '{')
                                    {
                                        while (inputArray[7] < '{')
                                        {
                                            //Console.WriteLine(inputArray);

                                            if (!HasForbiddenletters(inputArray))
                                            {
                                                if (HasThreeInARow(inputArray))
                                                {
                                                    //        Console.WriteLine(inputArray);
                                                    if (HasDuplicateDoubles(inputArray))
                                                    {
                                                        return inputArray;

                                                        //Console.WriteLine(inputArray);
                                                    }
                                                }
                                            }

                                            inputArray[7]++;
                                            }
                                        inputArray[7] = 'a';
                                        inputArray[6]++;
                                    }
                                    inputArray[6] = 'a';
                                    inputArray[5]++;
                                }
                                inputArray[5] = 'a';
                                inputArray[4]++;
                            }
                            inputArray[4] = 'a';
                            inputArray[3]++;
                        }
                        inputArray[3] = 'a';
                        inputArray[2]++;
                    }
                    inputArray[2] = 'a';
                    inputArray[1]++;
                }
                inputArray[1] = 'a';
                inputArray[0]++;
            }

            return inputArray;
        }

        public static bool HasForbiddenletters(char[] testArray)
        {
            foreach (char letter in testArray)
            {
                if (letter == 'i' || letter == 'l' || letter == 'o') return true;
            }
            return false;
        }

        public static bool HasThreeInARow(char[] testArray)
        {
            char letter2;
            char letter3;

            for (int i = 0; i < testArray.Length - 2; i++)
            {
                letter2 = testArray[i];
                letter2++;
                letter3 = letter2;
                letter3++;

                if (testArray[i + 1] == letter2 && testArray[i + 2] == letter3) return true;
            }
            return false;
        }

        private static bool HasDuplicateDoubles(char[] testArray)
        {
            Console.WriteLine(testArray);
            char charToCheck;
            int duplicateCount = 0;
            for (int testChar = 97; testChar < 123; testChar++)
            {
                charToCheck = Convert.ToChar(testChar);
                for (int i = 0; i < testArray.Length - 2; i++)
                {
                    Console.Write(testArray[i]);
                    Console.Write(" ");
                    Console.Write(testArray[i+1]);
                    Console.Write(duplicateCount);
                    Console.WriteLine();
                    if (testArray[i] == charToCheck && testArray[i + 1] == charToCheck) duplicateCount++;
                }
            }

            //Console.Write(duplicateCount);
            //Console.WriteLine(testArray);
            if (duplicateCount > 1) return true;
            //Console.ReadLine();
            return false;
        }
    }

}
