// See https://aka.ms/new-console-template for more information
using OpenSkyNetworkClient;
using OpenSkyNetworkClient.Model;

OpenSkyNetClient client = new OpenSkyNetClient();

BoundingBox bbox = new BoundingBox(57.049321f, 9.687195f, 57.150023f, 10.005798f);

client.StartProximityTracking(bbox);

Console.ReadKey();
