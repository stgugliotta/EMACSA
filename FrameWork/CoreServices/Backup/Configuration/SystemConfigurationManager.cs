using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web.Configuration;

namespace ar.com.telecom.eva.CoreServices.Configuration
{
    internal static class SystemConfigurationManager
    {
        private static bool useWebManager = true;

        public static System.Configuration.Configuration OpenExeConfiguration(string exePath)
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = exePath;
            
            return System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
        }

        public static object GetSection(string sectionName)
        {
            if(useWebManager)
            {
                try
                {
                    return WebConfigurationManager.GetSection(sectionName);
                }
                catch
                {
                    useWebManager = false;
                    return System.Configuration.ConfigurationManager.GetSection(sectionName);
                }
            }
            else 
            {
                return System.Configuration.ConfigurationManager.GetSection(sectionName);
            }
        }
    }
}
