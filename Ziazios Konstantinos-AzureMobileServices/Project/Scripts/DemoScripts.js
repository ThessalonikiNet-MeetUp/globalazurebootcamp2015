function read(query, user, request) {

    //query.where(Complete:success);
    //var table = tables.getTable('lecture')
    //notification.read(function, function)
    //mssql.query
    request.execute({
    		success:function(results) {
    			results.forEach(function(result) {
    				result.Timestamp = new Date();
    			});
    			request.respond(statusCode.OK, results);
    		}
    		error:function(error) {
    			console.error(error);
    			request.respond(statusCode.BAD_REQUEST);
    		}
    });
}


function insert(item, user, request) {
// Define a simple payload for a GCM notification.
var payload = {
    "data": {
        "message": item.text
    }
};      
request.execute({
    success: function() {
        // If the insert succeeds, send a notification.
        push.gcm.send(null, payload, {
            success: function(pushResponse) {
                console.log("Sent push:", pushResponse, payload);
                request.respond();
                },              
            error: function (pushResponse) {
                console.log("Error Sending push:", pushResponse);
                request.respond(500, { error: pushResponse });
                }
            });
        },
    error: function(err) {
        console.log("request.execute error", err)
        request.respond();
    }
  });
}

    function insert(item, user, request) {
        var todoItemTable = tables.getTable('TodoItem');
        // Check the supplied custom parameter to see if
        // we should allow duplicate text items to be inserted.        
        if (request.parameters.duplicateText === 'false') {
            // Find all existing items with the same text
            // and that are not marked 'complete'. 
            todoItemTable.where({
                text: item.text,
                complete: false
            }).read({
                success: insertItemIfNotComplete
            });
        } else {
            request.execute();
        }

        function insertItemIfNotComplete(existingItems) {
            if (existingItems.length > 0) {
                request.respond(statusCodes.CONFLICT, 
                    "Duplicate items are not allowed.");
            } else {
                // Insert the item as normal. 
                request.execute();
            }
        }
    }


    //---------------------------
    var updatesTable = tables.getTable('Updates');
var request = require('request');
var twitterUrl = "https://api.twitter.com/1.1/search/tweets.json?q=%23globalazure&result_type=recent";

// Get the service configuration module.
var config = require('mobileservice-config');

// Get the stored Twitter consumer key and secret. 
var consumerKey = config.twitterConsumerKey,
    consumerSecret = config.twitterConsumerSecret
// Get the Twitter access token from app settings.    
var accessToken= config.appSettings.TWITTER_ACCESS_TOKEN,
    accessTokenSecret = config.appSettings.TWITTER_ACCESS_TOKEN_SECRET;

function getUpdates() {   
    // Check what is the last tweet we stored when the job last ran
    // and ask Twitter to only give us more recent tweets
    appendLastTweetId(
        twitterUrl, 
        function twitterUrlReady(url){            
            // Create a new request with OAuth credentials.
            request.get({
                url: url,                
                oauth: {
                    consumer_key: consumerKey,
                    consumer_secret: consumerSecret,
                    token: accessToken,
                    token_secret: accessTokenSecret
                }},
                function (error, response, body) {
                if (!error && response.statusCode == 200) {
                    var results = JSON.parse(body).statuses;
                    if(results){
                        console.log('Fetched ' + results.length + ' new results from Twitter');                       
                        results.forEach(function (tweet){
                            if(!filterOutTweet(tweet)){
                                var update = {
                                    twitterId: tweet.id,
                                    text: tweet.text,
                                    author: tweet.user.screen_name,
                                    date: tweet.created_at
                                };
                                updatesTable.insert(update);
                            }
                        });
                    }            
                } else { 
                    console.error('Could not contact Twitter');
                }
            });

        });
 }
// Find the largest (most recent) tweet ID we have already stored
// (if we have stored any) and ask Twitter to only return more
// recent ones
function appendLastTweetId(url, callback){
    updatesTable
    .orderByDescending('twitterId')
    .read({success: function readUpdates(updates){
        if(updates.length){
            callback(url + '&since_id=' + (updates[0].twitterId + 1));           
        } else {
            callback(url);
        }
    }});
}

function filterOutTweet(tweet){
    // Remove retweets and replies
    return (tweet.text.indexOf('RT') === 0 || tweet.to_user_id);
}


function processOrder() { 
 
    serviceBusService.createQueueIfNotExists('orders', function(error) {  
        if (!error) { 
            serviceBusService.receiveQueueMessage('orders', receiveMessageCallback); 
        } 
        else { 
            console.error(error); 
        }  
    }); 
} 
 
var azure = require('azure');  
var serviceBusService = azure.createServiceBusService('<namespace name>', '<namespace key>');  
var receivedMessageCount = 0; 
var notificationSent = false; 
 
function receiveMessageCallback(error, receivedMessage) { 
 
    if (!error){ 
        receivedMessageCount++; 
 
        var order = JSON.parse(receivedMessage.body); 
 
        var deliveryOrderTable = tables.getTable('DeliveryOrder'); 
        deliveryOrderTable.insert({  
            product: order.product, 
            quantity: order.quantity, 
            customer: order.customer, 
            delivered: false                     
        }, { 
            success: function() { 
                if (!notificationSent) { 
                    sendPushNotification('/Images/Logo.png', 'New orders', 'One or more orders have been placed'); 
                    notificationSent = true; 
                } 
 
                if (receivedMessageCount < 10) { 
                    // continue receiving messages until we process a batch of 10 messages 
                    serviceBusService.receiveQueueMessage('orders', receiveMessageCallback); 
                } 
            }, 
            error: errorHandler 
        }); 
    } 
} 
 
function sendPushNotification(imagesrc, title, line1) { 
    var channelTable = tables.getTable('channels'); 
    channelTable.read({ 
        success: function(channels) { 
            channels.forEach(function (channel) { 
               push.wns.sendToastImageAndText02(channel.channelUri, { 
                    image1src: imagesrc, 
                    text1: title, 
                    text2: line1 
                }); 
            }); 
        } 
    }); 
} 
 
function errorHandler(error){ 
     console.error(error); 
}