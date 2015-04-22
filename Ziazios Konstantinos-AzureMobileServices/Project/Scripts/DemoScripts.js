function read(query, user, request) {
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