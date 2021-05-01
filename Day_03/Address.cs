using System;
using System.Collections.Generic;

namespace Day_03
{
    public static class Address
    {
        public static string NewAddress(string currentAddress, char direction)
        {
            string[] CoOrdinates = currentAddress.Split(':');

            int xAxis = Int32.Parse(CoOrdinates[0]);
            int yAxis = Int32.Parse(CoOrdinates[1]);

            switch (direction)
            {
                case '^':
                    yAxis++;
                    break;
                case 'v':
                    yAxis--;
                    break;
                case '>':
                    xAxis++;
                    break;
                case '<':
                    xAxis--;
                    break;
            }

            return xAxis.ToString()+":"+yAxis.ToString();
        }

        public static Dictionary<string, int> GetAddresses(string data)
        {
            var addressDictionary = new Dictionary<string, int>();
            var address = "0:0";

            addressDictionary.Add(address, 1);

            foreach (char direction in data)
            {
                address = NewAddress(address, direction);
                if (addressDictionary.TryGetValue(address, out int presents))
                {
                    addressDictionary[address] += 1;
                }
                else
                {
                    addressDictionary.Add(address, 1);
                }
            }

            return addressDictionary;
        }

        public static Dictionary<string, int> GetAddresses(string data1, string data2)
        {
            var addressDictionary = new Dictionary<string, int>();
            var address = "0:0";

            addressDictionary.Add(address, 1);

            foreach (char direction in data1)
            {
                address = NewAddress(address, direction);
                if (addressDictionary.TryGetValue(address, out int presents))
                {
                    addressDictionary[address] += 1;
                }
                else
                {
                    addressDictionary.Add(address, 1);
                }
            }

            address = "0:0";
            addressDictionary[address] += 1;

            foreach (char direction in data2)
            {
                address = NewAddress(address, direction);
                if (addressDictionary.TryGetValue(address, out int presents))
                {
                    addressDictionary[address] += 1;
                }
                else
                {
                    addressDictionary.Add(address, 1);
                }
            }

            return addressDictionary;
        }
    }
}
