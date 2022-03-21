// See https://aka.ms/new-console-template for more information
using OpenSkyNetworkClient;

OpenSkyNetClient client = new OpenSkyNetClient();


var flights = client.GetAllStatesAsync().Result;

string[] icaos = { "aae327", "ab5ce4" };

var customFlights = client.GetCustomStatesAsync(icaos).Result;

await Task.Delay(5000);
Console.WriteLine($"{flights.States.Length}");
Console.WriteLine(customFlights.States.Length);

Console.ReadKey();
