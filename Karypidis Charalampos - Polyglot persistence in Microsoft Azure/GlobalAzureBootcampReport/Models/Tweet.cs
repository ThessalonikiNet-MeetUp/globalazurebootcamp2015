using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace GlobalAzureBootcampReport.Models
{
    public class Tweet : TableEntity
    {
        public Tweet() {}

        public Tweet(string partitionKey, string rowKey)
        {
            PartitionKey = partitionKey;
            RowKey = rowKey;
        }

        public string UserId { get { return PartitionKey; } }
        public string TweetId { get { return RowKey; } }

        public string User { get; set; }

        public string ScreenName { get; set; }

        public string Text { get; set; }

        public string Country { get; set; }

        public string CreatedAt { get { return Timestamp.DateTime.ToString("f"); } }
    }
}