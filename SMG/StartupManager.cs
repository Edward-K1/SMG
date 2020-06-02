using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace SMG
{
    class StartupManager
    {
        public StartupManager() { }

        public List<StartupObject> GetRegistryEntries()
        {
            List<StartupObject> regEntries = new List<StartupObject>();
            regEntries.AddRange(GetRootHiveEntries(Registry.CurrentUser, StartupKind.HKCUKey));
            regEntries.AddRange(GetRootHiveEntries(Registry.LocalMachine, StartupKind.HKLMKey));

            return regEntries;
        }

        public List<StartupObject> GetRootHiveEntries(RegistryKey rootHiveKey, StartupKind keyType)
        {
            var regEntries = new List<StartupObject>();
            var defaultSubKey = @"Software\Microsoft\Windows\CurrentVersion\Run";
            using (RegistryKey rootkey = rootHiveKey.OpenSubKey(defaultSubKey))
            {

                foreach (var key in rootkey.GetValueNames())
                {

                    string keyValue = $"{rootkey.GetValue(key)}";
                    Tuple<string, string> cleanValues = GetCleanRegValues(keyValue);

                    string filepath = cleanValues.Item1;
                    string launchCommand = cleanValues.Item2;

                    var regObject = new StartupObject(key, filepath, keyType, launchCommand);
                    regEntries.Add(regObject);
                }

            }

            return regEntries;

        }

        public Tuple<string, string> GetCleanRegValues(string regKeyValue)
        {
            //currently assuming file ends with .exe but that might not always be the case
            Regex filepathRegEx = new Regex("[^\"]+.exe|.EXE$");
            Regex launchCmdRegEx = new Regex(@"[/-]+\w+");
            string cleanPath = filepathRegEx.Match(regKeyValue).Value;
            string lauchCommand = launchCmdRegEx.Match(regKeyValue, cleanPath.Length).Value;

            return Tuple.Create(cleanPath, lauchCommand);

        }

    }
}
