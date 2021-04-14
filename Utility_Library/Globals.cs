

namespace Utility_Library
{
    public class Globals
    {
        public string DataPath { get; set; }
        public bool Failed { get; set; }

        public Globals GetGlobalVariables()
        {
            // initialize
            Globals dataReturn = new Globals();
            dataReturn.Failed = false;
            WorkingEnvironment enviromentData = new WorkingEnvironment();

            // Get environment info
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
            return dataReturn;
        }
    }
}
