using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_14
{
    public class ReindeerStats
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public int FlyTime { get; set; }
        public int RestTime { get; set; }

        public int DistanceTraveled { get; set; }

        public int Points { get; set; }
        public List<FlightPlan> FlightPlan { get; set; }
    }
}
