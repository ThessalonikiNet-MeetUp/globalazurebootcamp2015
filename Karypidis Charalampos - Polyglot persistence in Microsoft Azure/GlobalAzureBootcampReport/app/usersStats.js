var updateUsersStatsCallback;

var usersStats = {
    addChangeListener: function (callback) {
        updateUsersStatsCallback = callback;
    },

    updateUserStats: function (newStats) {
        updateUsersStatsCallback(newStats);
    }
};

module.exports = usersStats;