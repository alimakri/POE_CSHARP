var http = require("http")

http.createServer(function(request, response){
  //response.writeHead(200, {'Content-Type':'text/plain'});
  response.end('<html><body><h2 style="color:red">Hello world</h2></body></html>');
}).listen(8081);

console.log('Server running at http://127.0.0.1:8081');