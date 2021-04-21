using System.IO;

namespace Utility_Library
{
    public class DataRepository
    {
        public static string[] ReadToArray(string dataPath)
        {
            string[] returnData = File.ReadAllLines(dataPath);
            return returnData;
        }

        public static string ReadToString(string dataPath)
        {
            string returnData = File.ReadAllText(dataPath);
            return returnData;
        }
    }
}
