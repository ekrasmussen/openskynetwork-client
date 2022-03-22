// See https://aka.ms/new-console-template for more information
using OpenSkyNetworkClient;
using OpenSkyNetworkClient.Model;

OpenSkyNetClient client = new OpenSkyNetClient();

BoundingBox bbox = new BoundingBox(55.474184, 12.403564, 55.736389, 12.878723);

client.StartProximityTracking(bbox);

var route = await client.GetRouteAsync("FIN1CW");

Console.WriteLine($"callsign {route.Callsign}, Route from: {route.Route[0]}, Route to: {route.Route[1]}, OperatorIata: {route.OperatorIata}, FlightNumber: {route.FlightNumber}");
Console.ReadKey();
