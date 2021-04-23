using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_03
{
    public class HouseCoOrdinates
    {
        public int XAxis { get; set; }

        public int YAxis { get; set; }

        public HouseCoOrdinates GetHouseCoOrdinates(HouseCoOrdinates previousCoOrdinates, char direction)
        {
            var newCoOrdinates = previousCoOrdinates;

            switch (direction)
            {
                case '^':
                    newCoOrdinates.YAxis += 1;
                    break;
                case 'v':
                    newCoOrdinates.YAxis -= 1;
                    break;
                case '>':
                    newCoOrdinates.XAxis += 1;
                    break;
                case '<':
                    newCoOrdinates.XAxis -= 1;
                    break;
            }

            return newCoOrdinates;
        }
    }
}
