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
            string firstFiveCheck = "";
            for(int index=0; index<leadingZeros; index++)
            {
                firstFiveCheck += "0";
            }
            var keyNumber = 1;
            var secretNumber=GetHash(key + keyNumber.ToString());
            string firstFivChar = new string(secretNumber.Take(leadingZeros).ToArray());

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
