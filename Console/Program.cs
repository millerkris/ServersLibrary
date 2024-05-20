
using ServersLibrary;



Servers servers = Servers.Instance;


Console.WriteLine(servers.AddServer("http://example.com"));  // true
Console.WriteLine(servers.AddServer("https://example.org")); // true
Console.WriteLine(servers.AddServer("ftp://example.net"));   // false


var httpServers = servers.GetHttpServers();
var httpsServers = servers.GetHttpsServers();

Console.WriteLine("HTTP servers:");
foreach (var server in httpServers)
{
    Console.WriteLine(server);
}

Console.WriteLine("HTTPS servers:");
foreach (var server in httpsServers)
{
    Console.WriteLine(server);
}
    
