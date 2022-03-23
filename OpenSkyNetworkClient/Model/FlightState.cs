using Newtonsoft.Json;
using OpenSkyNetworkClient.Converters;
using OpenSkyNetworkClient.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSkyNetworkClient.Model
{
    [JsonConverter(typeof(FlightStateConverter))]
    public class FlightState : IFlightState
    {
        public FlightState(string icao)
        {
            Icao24 = icao;
        }
        public string Icao24 { get; set; } 
        public string CallSign { get; set; }
        public string OriginCountry { get; set; }
        public DateTime? TimePosition { get; set; }
        public int LastContact { get; set; }
        public float? Longitude { get; set; }
        public float? Latitude { get; set; }
        public float? GeoAltitude { get; set; }
        public bool OnGround { get; set; }
        public float? Velocity { get; set; }
        public float? Heading { get; set; }
        public float? VerticalRate { get; set; }
        public int[] Sensors { get; set; }
        public float? BaroAltitude { get; set; }
        public string Squawk { get; set; }
        public bool Spi { get; set; }
        public int PositionSource { get; set; }
        public float? TrueTrack { get; set; }
        public IFlightRoute? FlightRoute { get; set; }
        public void Update(IFlightState flightState)
        {
            Icao24 = flightState.Icao24;
            CallSign = flightState.CallSign;
            OriginCountry = flightState.OriginCountry;
            TimePosition = flightState.TimePosition;
            LastContact = flightState.LastContact;
            Longitude = flightState.Longitude;
            Latitude = flightState.Latitude;
            GeoAltitude = flightState.GeoAltitude;
            OnGround = flightState.OnGround;
            Velocity = flightState.Velocity;
            Heading = flightState.Heading;
            VerticalRate = flightState.VerticalRate;
            Sensors = flightState.Sensors;
            BaroAltitude = flightState.BaroAltitude;
            Squawk = flightState.Squawk;
            Spi = flightState.Spi;
            PositionSource = flightState.PositionSource;
            TrueTrack = flightState.TrueTrack;
            Console.WriteLine("UPDATED");
        }

        public void AddRoute(IFlightRoute route)
        {
            FlightRoute = route;
            Console.WriteLine($"ROUTE FOUND: Callsign {route.Callsign}, Route from: {route.Route[0]}, Route to: {route.Route[1]}, OperatorIata: {route.OperatorIata}, FlightNumber: {route.FlightNumber}");
        }
    }
}
