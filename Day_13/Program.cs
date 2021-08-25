using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility_Library;

namespace Day_13
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<KeyValuePair<string, string>, int> seatingPair = new Dictionary<KeyValuePair<string, string>, int>();
            List<string> guestList = new List<string>();

            Stopwatch stopwatch = new Stopwatch();

            //read data file
            var data = DataRepository.ReadToArray("151213 Input.txt");

            //PART ONE

            Console.WriteLine("---PART ONE---\n\r");
            stopwatch.Start();

            for (int x = 0; x < data.Length; x++)
            {
                int happiness;
                string[] line = data[x].Trim(new Char[] { '.' }).Split(' ');
                var person = line[0];
                var nextTo = line[10];
                if (line[2] == "gain") happiness = Int32.Parse(line[3]);
                else happiness = 0 - Int32.Parse(line[3]);

                if (!guestList.Contains(person)) guestList.Add(person);

                seatingPair.Add(new KeyValuePair<string, string>(person, nextTo), happiness);
            }

            var temp = guestList.Permute();
        }
    }

    public static class listextensions 
    { 
        public static IEnumerable<IEnumerable<T>> Permute<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null)
            {
                yield break;
            }

            var list = sequence.ToList();

            if (!list.Any())
            {
                yield return Enumerable.Empty<T>();
            }
            else
            {
                var startingElementIndex = 0;

                foreach (var startingElement in list)
                {
                    var index = startingElementIndex;
                    var remainingItems = list.Where((e, i) => i != index);

                    foreach (var permutationOfRemainder in remainingItems.Permute())
                    {
                        yield return permutationOfRemainder.Prepend(startingElement);
                    }

                    startingElementIndex++;
                }
            }
        }
    }
}
