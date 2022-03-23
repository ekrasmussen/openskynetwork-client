// See https://aka.ms/new-console-template for more information
using OpenSkyNetworkClient;
using OpenSkyNetworkClient.Model;

OpenSkyNetClient client = new OpenSkyNetClient();

client.StartTracking("407797");
otherTask();

for(int i = 0; i < 1000; i++)
{
    await Task.Delay(5000);
    foreach(var flight in client.GetCustomList())
    {
        Console.WriteLine($"icao24: {flight.Icao24}");
    }
}

async Task otherTask()
{
    await Task.Delay(10000);
    client.StartTracking("4d2242");
    await Task.Delay(50000);
    client.StartTracking("c0816e");
}
Console.ReadKey();
