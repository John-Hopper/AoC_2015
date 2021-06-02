using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Day_04
{
    public static class Crypto
    {
        public static string GetHash(string input)
        {
            var returnHash = "";

            var hash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(input.ToCharArray()));
            foreach (byte h in hash)
            {
                returnHash += (h.ToString("x2"));
            }
            return returnHash;
        }

        public static int GetSecretNumber(string key, int leadingZeros)
        {
            // Get string of zeros to check
            string firstFiveCheck = "";
            for(int index=0; index<leadingZeros; index++)
            {
                firstFiveCheck += "0";
            }

            // get hash number
            var keyNumber = 1;
            var secretNumber=GetHash(key + keyNumber.ToString());

            // grab first five characters
            string firstFivChar = new string(secretNumber.Take(leadingZeros).ToArray());

            // compare first five character string to zero check string and loop until it matches
            while (firstFivChar != firstFiveCheck)
            {
                keyNumber++;
                secretNumber = GetHash(key + keyNumber.ToString());
                firstFivChar = new string(secretNumber.Take(leadingZeros).ToArray());
            } 

            return keyNumber;
        }
    }
}
