using System;
using System.Collections.Generic;
using GlobalAzureBootcampReport.Models;
using Microsoft.AspNet.SignalR;

namespace GlobalAzureBootcampReport.Hubs
{
    public class BootcampReportHub : Hub
    {
        public void UpdateUsersStats(IEnumerable<UserStat> usersStats)
        {
            Clients.All.updateUsersStats(usersStats);
        }


        public void AddTweetsToList(IEnumerable<Tweet> newTweets)
        {
            Clients.All.addTweetsToList(newTweets);
        }
    }
}