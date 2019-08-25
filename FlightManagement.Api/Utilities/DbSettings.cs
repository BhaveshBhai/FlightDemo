using System;
using System.Configuration;

namespace FlightManagement.Api.Utilities
{
    public class DbSettings
    {
        public const string ErrorLogPath = "ErrorLogs/";

        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ConnFlightCenter"].ConnectionString;
        }

        public static string GetAppSetting(string key)
        {
            return Convert.ToString(ConfigurationManager.AppSettings[key]);
        }
    }
}