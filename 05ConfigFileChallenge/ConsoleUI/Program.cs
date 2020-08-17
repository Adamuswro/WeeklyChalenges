using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1. task
            var connString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            var appSetting = ConfigurationManager.AppSettings["TempFilePath"];
            Console.WriteLine($"Connection string: {connString}{Environment.NewLine}App setting: {appSetting}");
            #endregion
            #region 2 & 3. task
            AddValue("User role", "Admin");
            StringBuilder result = new StringBuilder();
            foreach (ConnectionStringSettings connectionString in ConfigurationManager.ConnectionStrings)
            {
                result.Append($"{connectionString.Name}: {connectionString.ConnectionString}");
                result.Append(Environment.NewLine);
            }
            foreach (var key in ConfigurationManager.AppSettings.AllKeys)
            {
                result.Append($"{key}: {ConfigurationManager.AppSettings[key]}");
                result.Append(Environment.NewLine);
            }
            Console.WriteLine(result);
            #endregion
            Console.ReadLine();
        }

        static void AddValue (string key, string value)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Add(key, value);
            config.Save(ConfigurationSaveMode.Minimal);
        }
    }
}
