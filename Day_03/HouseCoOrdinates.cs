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

        private string _address;

        public string Address
        {
            get { return Convert.ToString(XAxis) + Convert.ToString(YAxis); }
        }


        public HouseCoOrdinates GetHouseCoOrdinates(HouseCoOrdinates previousCoOrdinates, char direction)
        {
            var newCoOrdinates = new HouseCoOrdinates();

            switch (direction)
            {
                case '^':
                    newCoOrdinates.YAxis = previousCoOrdinates.YAxis + 1;
                    break;
                case 'v':
                    newCoOrdinates.YAxis = previousCoOrdinates.YAxis - 1;
                    break;
                case '>':
                    newCoOrdinates.XAxis = previousCoOrdinates.XAxis + 1;
                    break;
                case '<':
                    newCoOrdinates.XAxis = previousCoOrdinates.XAxis - 1;
                    break;
            }

            return newCoOrdinates;
        }

        public List<string> GetHouseAddresses(string directionData)
        {
            var returnedHouseAddresses = new List<string>();
            var coOrdinateList = new List<HouseCoOrdinates>();
            //var previousCoOrdinates = new HouseCoOrdinates()
            //{
            //    XAxis = 0,
            //    YAxis = 0
            //};
            var newCordinates = new HouseCoOrdinates();
            //var houseaddress = new List<string>();
            var previousCoOrdinateIndex = 0;

            coOrdinateList.Add(new HouseCoOrdinates()
            {
                XAxis = 0,
                YAxis = 0
            });

            //coOrdinateList.Add(previousCoOrdinates);

            foreach (char direction in directionData)
            {
                //newCordinates = newCordinates.GetHouseCoOrdinates(previousCoOrdinates, direction);
                //coOrdinateList.Add(new HouseCoOrdinates() 
                //{ 
                //    XAxis = newCordinates.XAxis, 
                //    YAxis = newCordinates.YAxis 
                //});
                coOrdinateList.Add(newCordinates.GetHouseCoOrdinates(coOrdinateList[previousCoOrdinateIndex], direction));
                previousCoOrdinateIndex++;
            }

            foreach (HouseCoOrdinates house in coOrdinateList)
            {
                returnedHouseAddresses.Add(house.Address);
            }

            return returnedHouseAddresses;
        }


    }
}
