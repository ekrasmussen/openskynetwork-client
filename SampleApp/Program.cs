// See https://aka.ms/new-console-template for more information
using OpenSkyNetworkClient;
using OpenSkyNetworkClient.Model;

OpenSkyNetClient client = new OpenSkyNetClient();

BoundingBox bbox = new BoundingBox(57.040730, 9.656982, 58.222811, 12.864990);

client.StartProximityTracking(bbox);

var route = await client.GetRouteAsync("FIN1CW");

Console.WriteLine($"callsign {route.Callsign}, Route from: {route.Route[0]}, Route to: {route.Route[1]}, OperatorIata: {route.OperatorIata}, FlightNumber: {route.FlightNumber}");
Console.ReadKey();
