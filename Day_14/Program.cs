using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Utility_Library;

namespace Day_14
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ReindeerStats> Reindeers = new List<ReindeerStats>();

            Stopwatch stopwatch = new Stopwatch();

            //read data file
            var data = DataRepository.ReadToArray("151214 Input.txt");

            //prepare data
            for (int x = 0; x < data.Length; x++)
            {
                ReindeerStats stats = new ReindeerStats();
                string[] line = data[x].Split(' ');

                stats.Name = line[0];
                stats.Speed = Int32.Parse(line[3]);
                stats.FlyTime = Int32.Parse(line[6]);
                stats.RestTime = Int32.Parse(line[13]);

                Reindeers.Add(stats);
            }

            //PART ONE

            Console.WriteLine("---PART ONE---\n\r");
            stopwatch.Start();

            for(int index=0; index<Reindeers.Count; index++)
            {
                int FlightTime = 2503;

                while (FlightTime>0)
                {
                    if (Reindeers[index].FlyTime < FlightTime)
                    {
                        Reindeers[index].DistanceTraveled += (Reindeers[index].FlyTime * Reindeers[index].Speed);
                        FlightTime -= Reindeers[index].FlyTime;
                    }
                    else
                    {
                        Reindeers[index].DistanceTraveled += (FlightTime * Reindeers[index].Speed);
                        FlightTime = 0;
                    }

                    if (Reindeers[index].RestTime < FlightTime && FlightTime != 0) FlightTime -= Reindeers[index].RestTime;
                    else FlightTime = 0;
                }
                
            }
            
            int maxDistance = Reindeers.Max(x => x.DistanceTraveled);

            stopwatch.Stop();
            Console.WriteLine($"Max Distance reached : {maxDistance} ");
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();

            Console.WriteLine("---PART TWO---\n\r");
            stopwatch.Start();

            foreach(ReindeerStats reindeer in Reindeers)
            {
                List<FlightPlan> flightplan = new List<FlightPlan>();
                int secondCount = 2503;
                int distance = 0;

                while (secondCount>0)
                {
                    for(int x=0; x<reindeer.FlyTime; x++)
                    {
                        if (secondCount > 0)
                        {
                            distance += reindeer.Speed;
                            flightplan.Add(new FlightPlan { DistanceAtInterval = distance });
                            secondCount--;
                        }
                    }

                    for (int x = 0; x < reindeer.RestTime; x++)
                    {
                        if (secondCount > 0)
                        {
                            flightplan.Add(new FlightPlan { DistanceAtInterval = distance });
                            secondCount--;
                        }
                    }
                }
                reindeer.FlightPlan = flightplan;
            }

            maxDistance = 0;

            for(int index=0; index < 2503; index++)
            {
                maxDistance = Reindeers.Max(x => x.FlightPlan[index].DistanceAtInterval);

                foreach(ReindeerStats reindeer in Reindeers)
                {
                    if (reindeer.FlightPlan[index].DistanceAtInterval == maxDistance) reindeer.Points++;
                }
            }

            int maxPoints = Reindeers.Max(x => x.Points);

            stopwatch.Stop();
            Console.WriteLine($"Max points reached : {maxPoints} ");
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();
        }
    }
}
