using System;

namespace Utility_Library
{
    public class WorkingEnvironment
    {
        public string OsVersion { get; set; }
        public string CurrentDirectory { get; set; }
        public string MachineName { get; set; }
        public string UserDomainName { get; set; }
        public string UserName { get; set; }

        /// <summary>
        /// Returns various properties for environment the application is running in.
        /// </summary>
        /// <returns>WorkingEnvironment class</returns>
        public WorkingEnvironment EnvironmentInfo()
        {
            WorkingEnvironment dataReturn = new WorkingEnvironment
            {
                OsVersion = Convert.ToString(Environment.OSVersion),
                CurrentDirectory = Convert.ToString(Environment.CurrentDirectory),
                MachineName = Convert.ToString(Environment.MachineName),
                UserDomainName = Convert.ToString(Environment.UserDomainName),
                UserName = Convert.ToString(Environment.UserName)
            };

            return dataReturn;
        }
    }
}
