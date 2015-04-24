using System;
using System.Collections.Generic;
using System.Linq;
using GlobalAzureBootcampReport.Models;
using Microsoft.WindowsAzure.Storage.Table;
using Tweetinvi.Core.Extensions;

namespace GlobalAzureBootcampReport.Azure
{
    /// <summary>
    /// Implementation of <see cref="ITweetsRepository"/>
    /// </summary>
    internal class TweetsRepository : ITweetsRepository
    {
        const string TableName = "Tweets";
        private readonly CloudTable _table;

        public TweetsRepository()
        {
            _table = AzureHelper.GetTableReference(TableName);
        }

        public IEnumerable<UserStat> GetUserStats()
        {
            var tableQuery = _table.ExecuteQuery(new TableQuery<Tweet>()).ToList();
            var query = tableQuery
                .GroupBy(t => t.PartitionKey, (key, g) => new UserStat {UserId = key, TweetsNumber = g.Count()})
                .OrderByDescending(g => g.TweetsNumber).ToList();
            query.ForEach(us =>
            {
                var tweet = tableQuery.First(t => t.PartitionKey == us.UserId);
                us.Name = tweet.User;
                us.ProfileUrl = "https://www.twitter.com/" + tweet.ScreenName;
                us.ImageUrl = string.Format("{0}/profileimages/{1}",
                    AzureHelper.CloudStorageAccount.BlobStorageUri.PrimaryUri.ToString().TrimEnd(new[] {'/'}), us.UserId);
            });
            return query;
        }

        public IEnumerable<Tweet> GetLatestTweets()
        {
            var oneHourAgoTimestap = new DateTimeOffset(DateTime.UtcNow.AddMinutes(-60));
            var query =
                new TableQuery<Tweet>().Where(TableQuery.GenerateFilterConditionForDate("Timestamp",
                    QueryComparisons.GreaterThan, oneHourAgoTimestap));
            return _table.ExecuteQuery(query);
        }

        public void SaveTweet(Tweet tweet)
        {
            var insertOperation = TableOperation.Insert(tweet);
            _table.Execute(insertOperation);
        }

    }
}