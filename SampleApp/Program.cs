// See https://aka.ms/new-console-template for more information
using OpenSkyNetworkClient;

OpenSkyNetClient client = new OpenSkyNetClient();

client.StartTracking("a6fe0e");
client.StartTracking("ab6fdd");

await Task.Delay(10000);
Console.WriteLine("Stopped Tracking the first");
client.StopTracking("a6fe0e");
Console.ReadKey();
