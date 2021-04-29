using System.IO;

namespace Utility_Library
{
    public static class DataRepository
    {
        public static string[] ReadToArray(string fileName)
        {
            // initialize Global Variables
            Globals globalVariables = new Globals();
            globalVariables = globalVariables.GetGlobalVariables();

            string[] returnData = File.ReadAllLines(globalVariables.DataPath + fileName);
            return returnData;
        }

        public static string ReadToString(string fileName)
        {
            // initialize Global Variables
            Globals globalVariables = new Globals();
            globalVariables = globalVariables.GetGlobalVariables();

            string returnData = File.ReadAllText(globalVariables.DataPath + fileName);
            return returnData;
        }

    }
}
