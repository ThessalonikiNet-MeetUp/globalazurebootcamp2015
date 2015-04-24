using System;
using System.Threading.Tasks;

namespace GlobalAzureBootcampReport.Twitter
{
    /// <summary>
    /// Contains the methods for interacting with Twitter api
    /// </summary>
    public interface ITwitterManager
    {
        /// <summary>
        /// Starts listening on Twitter stream.
        /// </summary>
        void StartListening();

        /// <summary>
        /// Stops listening on the Twitter stream
        /// </summary>
        void StopListening();

        /// <summary>
        /// Calculates the stats for the stored tweets in the table storage and initializes the redis cache 
        /// </summary>
        Task CalculateStats();
    }
}