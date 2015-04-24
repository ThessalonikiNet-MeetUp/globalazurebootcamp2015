using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using GlobalAzureBootcampReport.Azure;
using GlobalAzureBootcampReport.Hubs;
using GlobalAzureBootcampReport.Models;
using GlobalAzureBootcampReport.Redis;
using GlobalAzureBootcampReport.Twitter;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.SignalR;

namespace GlobalAzureBootcampReport.Controllers
{
    public class HomeController : AsyncController
    {
        private readonly ITwitterManager _twitterManager;
        private readonly ITweetsRepository _tweetsRepository;
        private readonly ICache _cache;

        private readonly Lazy<IHubContext> _context =
            new Lazy<IHubContext>(() => GlobalHost.ConnectionManager.GetHubContext<BootcampReportHub>());

        public HomeController(ITwitterManager twitterManager, ITweetsRepository tweetsRepository)
        {
            _twitterManager = twitterManager;
            _tweetsRepository = tweetsRepository;
            _cache = new Cache();
        }

        public async Task<ActionResult> Index()
        {
            var stats = await _cache.GetItemAsync<IEnumerable<UserStat>>(_cache.TopUsersStatsKey);
            stats = stats.OrderByDescending(us => us.TweetsNumber).Take(20);
            var tweets = _tweetsRepository.GetLatestTweets().OrderByDescending(t => t.CreatedAt).Take(250);
            ApplicationUser user = null;
            if (User.Identity.IsAuthenticated)
            {
                user = Request.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByName(User.Identity.Name);
            }
            return View(new IndexViewModel
            {
                UsersStats = stats,
                Tweets = tweets,
                User = user
            });
        }

        public ActionResult DummyUpdate()
        {
            var stats = _tweetsRepository.GetUserStats().Reverse();
            _context.Value.Clients.All.updateUsersStats(stats);
            return new EmptyResult();
        }

        public ActionResult StartListening()
        {
            _twitterManager.StartListening();
            return new EmptyResult();
        }

        public ActionResult StopListening()
        {
            _twitterManager.StopListening();
            return new EmptyResult();
        }

    }
}
