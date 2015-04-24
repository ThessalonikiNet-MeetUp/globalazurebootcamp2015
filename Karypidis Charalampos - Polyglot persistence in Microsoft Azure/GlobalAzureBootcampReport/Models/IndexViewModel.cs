using System;
using System.Collections.Generic;

namespace GlobalAzureBootcampReport.Models
{
    public class IndexViewModel
    {
        public IEnumerable<UserStat> UsersStats { get; set; }
        public IEnumerable<Tweet> Tweets { get; set; }
        public ApplicationUser User { get; set; }
    }
}