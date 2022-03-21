// See https://aka.ms/new-console-template for more information
using OpenSkyNetworkClient;

OpenSkyNetClient client = new OpenSkyNetClient();

client.StartTracking("a46e70");
client.StartTracking("aa56da");

await Task.Delay(10000);
Console.WriteLine("Stopped Tracking the first");
client.StopTracking("a46e70");
Console.ReadKey();
