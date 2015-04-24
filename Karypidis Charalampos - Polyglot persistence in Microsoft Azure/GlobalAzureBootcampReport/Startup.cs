using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Mvc;
using GlobalAzureBootcampReport.Twitter;
using Microsoft.Owin;
using Owin;
using Tweetinvi;

[assembly: OwinStartup(typeof(GlobalAzureBootcampReport.Startup))]

namespace GlobalAzureBootcampReport
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureIoC(app);
            ConfigureAuth(app);
            app.MapSignalR();

            ConnectToTwitter();
            InitializeCache();
        }

        private static void ConnectToTwitter()
        {
            var userAccessToken = ConfigurationManager.AppSettings["UserAccessToken"];
            var userAccessSecret = ConfigurationManager.AppSettings["UserAccessSecret"];
            var consumerKey = ConfigurationManager.AppSettings["ConsumerKey"];
            var consumerSecret = ConfigurationManager.AppSettings["ConsumerSecret"];
            TwitterCredentials.SetCredentials(userAccessToken, userAccessSecret, consumerKey, consumerSecret);
        }

        private static void InitializeCache()
        {
            var twitterManager = DependencyResolver.Current.GetService<ITwitterManager>();
            Task.WhenAll(twitterManager.CalculateStats());
        }
    }
}
