function sendnotifications() {
    var azure = require("azure");
    var hub = azure.createNotificationHubService('skgazuredemo','Endpoint=sb://skgazure2015hub-ns.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=JJIDK7zfBlX2nnjP9t8J5zTJIMeUoIqGxWMuxx+aKrY=' );
    
    var message = {text1: "Notification Hub", text2:"From azure mobile", text3:"test"};
    
    hub.send(null, JSON.stringify(message), function (error) {
      if(error) {
          console.error(error);
      }  
    });
            
}