var newTweetsCallback;

var tweets = {
    addChangeListener: function (callback) {
        newTweetsCallback = callback;
    },

    updateTweetsList: function (newTweets) {
        newTweetsCallback(newTweets);
    }
};

module.exports = tweets;