using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDKacha.Geolocation
{
    internal class RouteBuilder
    {
        
        public RouteBuilder GetGeolocation()
        {
                GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
                watcher.TryStart(false, TimeSpan.FromMilliseconds(10000));

                if (!watcher.Position.Location.IsUnknown)
                {
                    RouteBuilder res = new RouteBuilder();
                    res.Latitude = watcher.Position.Location.Latitude;
                    res.Longtitude = watcher.Position.Location.Longitude;
                    return res;
                }
                else
                {
                    return null;
                }
        }

        public double Latitude { get; private set; }
        public double Longtitude { get; private set; }
    }

}

