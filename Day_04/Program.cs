using System;
using System.Diagnostics;

namespace Day_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            var key = "bgvyzdsv";

            //PART ONE
            Console.WriteLine("---PART ONE---\n\r");
            stopwatch.Start();

            var secretNumber = Crypto.GetSecretNumber(key, 5);

            stopwatch.Stop();
            Console.WriteLine($"secret number with giving five zeros: {secretNumber}");
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();

            //PART TWO
            Console.WriteLine("---PART TWO---\n\r");
            stopwatch.Start();

            secretNumber = Crypto.GetSecretNumber(key, 6);

            stopwatch.Stop();
            Console.WriteLine($"secret number with giving six zeros: {secretNumber}");
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();
        }
    }
}
