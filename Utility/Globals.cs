
using System;

namespace Utility_Library
{
    public class Globals
    {
        public string DataPath { get; set; }
        public bool Failed { get; set; }

        public Globals GetGlobalVariables()
        {
            // initialize
            Globals dataReturn = new Globals
            {
                Failed = false
            };

            // Get environment info
            WorkingEnvironment enviromentData = new WorkingEnvironment();
            enviromentData = enviromentData.EnvironmentInfo();

            // Pick input data path to return based on environment found
            switch (enviromentData.UserDomainName)
            {
                case "AT100440":
                    dataReturn.DataPath = @"C:\Users\dev1\Source\Repos\AoC_2015\Data Input\";
                    break;
                case "COLUMBUS":
                    dataReturn.DataPath = @"D:\Users\U.6076325\source\repos\AoC_2015\Data Input\";
                    break;
                default:
                    dataReturn.Failed = true;
                    break;
            }

            // check environment and global variables initialized ok
            if (dataReturn.Failed)
            {
                Console.WriteLine($"Environment not found - Initialization Failed");
                Console.ReadLine();
                Environment.Exit(0);
            }
            return dataReturn;
        }
    }
}
