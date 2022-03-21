// See https://aka.ms/new-console-template for more information
using OpenSkyNetworkClient;

OpenSkyNetClient client = new OpenSkyNetClient();


var flights = await client.GetAllStatesAsync();

Console.WriteLine(flights.States[0].CallSign);
