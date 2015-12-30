using System.Web.Optimization;

[assembly: WebActivator.PostApplicationStartMethod(typeof(AuthorizationFramework.UI.Web.BundleConfigurationActivator), "Activate")]
namespace AuthorizationFramework.UI.Web
{
    public static class BundleConfigurationActivator
    {
        public static void Activate()
        {
            BundleTable.Bundles.RegisterConfigurationBundles();
        }
    }
}