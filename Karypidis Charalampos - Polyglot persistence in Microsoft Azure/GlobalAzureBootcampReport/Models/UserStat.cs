using System;
using System.Collections.Generic;

namespace GlobalAzureBootcampReport.Models
{
    public class UserStat
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string ProfileUrl { get; set; }
        public int TweetsNumber { get; set; }
        public string Country { get; set; }
        public string ImageUrl { get; set; }
    }

    public class UserStatComparer : IEqualityComparer<UserStat>
    {
        public bool Equals(UserStat x, UserStat y)
        {
            //Check whether the compared objects reference the same data.
            if (ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
            return false;

            if (ReferenceEquals(x.UserId, null) || ReferenceEquals(y.UserId, null))
                return false;

            return x.UserId == y.UserId;
        }

        public int GetHashCode(UserStat obj)
        {
            if (ReferenceEquals(obj, null)) return 0;
            if (ReferenceEquals(obj.UserId, null)) return 0;
            return obj.UserId.GetHashCode();
        }
    }

}