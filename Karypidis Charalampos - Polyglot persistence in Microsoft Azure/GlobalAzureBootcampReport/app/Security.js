var userAuthenticationCallback;

var security = {
    addChangeListener: function (callback) {
        userAuthenticationCallback = callback;
    },
    
    updateUserSecurity: function (status) {
        updateUsersStatsCallback(status);
    },

    register: function (registrationData) {
        $.post("api/Account/Register", registrationData, function (result) {
            if (result.isAuthenticated) {
                userAuthenticationCallback(result);
            }
        });
    },

    login:function(loginData) {
        $.post("api/Account/Login", loginData, function (result) {
            if (result.isAuthenticated) {
                userAuthenticationCallback(result);
            }
        });
    },

    logout: function() {
        $.post("api/Account/Logout", function (result) {
            if (result.isLoggedOut) {
                userAuthenticationCallback({ isAuthenticated: false });
            }
        });
    }
};

module.exports = security;