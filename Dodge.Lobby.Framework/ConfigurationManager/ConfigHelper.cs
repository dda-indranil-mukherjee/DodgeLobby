using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodge.Lobby.Framework.Configuration
{
    public class ConfigHelper
    {
        public static string CookieDomain { get { return GetAppSettings("COOKIE-DOMAIN"); } }
        public static double FormsAuthenticationTimeout { get { return double.Parse(GetAppSettings("FORMS-AUTHENTICATION-TIMEOUT")); } }
        public static double FormsAuthenticationRememberMeTimeout { get { return double.Parse(GetAppSettings("FORMS-AUTHENTICATION-REMEMBER-ME-TIMEOUT")); } }

        public static string GetAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
