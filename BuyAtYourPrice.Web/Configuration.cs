using System.Configuration;

namespace BuyAtYourPrice.Web
{
    public static class Configuration
    {
        public static string MembershipApplicationName
        {
            get { return ConfigurationManager.AppSettings.Get("MembershipApplicationName"); }
        }
    }
}