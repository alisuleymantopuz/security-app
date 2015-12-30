namespace AuthorizationFramework.UI.Web
{
    using System.Configuration;

    public class WebSiteConfiguration
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            }
        }

        public static int SessionTimeoutMinutes
        {
            get
            {
                return int.Parse(ConfigurationManager.ConnectionStrings["SessionTimeoutMinutes"].ConnectionString);
            }
        }
    }
}