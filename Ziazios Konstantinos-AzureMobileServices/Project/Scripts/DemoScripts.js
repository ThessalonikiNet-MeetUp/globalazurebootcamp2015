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