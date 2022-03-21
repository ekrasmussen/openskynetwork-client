// See https://aka.ms/new-console-template for more information
using OpenSkyNetworkClient;
using OpenSkyNetworkClient.Model;

OpenSkyNetClient client = new OpenSkyNetClient();

BoundingBox bbox = new BoundingBox(57.049321f, 9.687195f, 57.150023f, 10.005798f);

client.StartProximityTracking(bbox);
client.StartTracking("40775c");

var custom = client.GetCustomList();
var proximity = client.GetProximityList();

for(int i = 0; i < 100; i++)
{
    foreach(var p in proximity)
    {
        Console.WriteLine($"Proximity ICAO: {p.Icao24} - Coords: {p.Latitude} , {p.Longitude}");
    }

    foreach(var p in custom)
    {
        Console.WriteLine($"Custom ICAO: {p.Icao24} - Coords: {p.Latitude} , {p.Longitude}");
    }
    await Task.Delay(10000);
}

Console.ReadKey();
