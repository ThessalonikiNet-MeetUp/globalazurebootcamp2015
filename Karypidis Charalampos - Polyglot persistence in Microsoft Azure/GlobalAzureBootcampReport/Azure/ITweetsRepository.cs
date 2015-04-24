using System;
using System.Collections.Generic;
using GlobalAzureBootcampReport.Models;

namespace GlobalAzureBootcampReport.Azure
{
    /// <summary>
    /// Repository responsible for data access code of <see cref="Tweet"/>
    /// </summary>
    public interface ITweetsRepository
    {
        /// <summary>
        /// Returns a collection with the users stats
        /// </summary>
        IEnumerable<UserStat> GetUserStats();

        IEnumerable<Tweet> GetLatestTweets();

        /// <summary>
        /// Stores asynchronously the supplied <paramref name="tweet"/>
        /// </summary>
        void SaveTweet(Tweet tweet);

    }
}