// See https://aka.ms/new-console-template for more information
using OpenSkyNetworkClient;

OpenSkyNetClient client = new OpenSkyNetClient();


var flights = await client.GetAllStatesAsync();

string[] icaos = { "aae327", "ab5ce4" };

var customFlights = await client.GetCustomStatesAsync(icaos);

Console.WriteLine(flights.States[0].CallSign);
