using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelDistance.LD
{
    public class LocationData
    {
        //[JsonProperty("lat")]
        //public double lat { get; set; }
        //[JsonProperty("lon")]
        //public double lon { get; set; }
        //[JsonProperty("country")]
        public string country { get; set; }
        [JsonProperty("city")]
        public string city { get; set; }

        [JsonProperty("zip")]
        public int zip { get; set; }

        [JsonProperty("regionname")]
        public string reg { get; set; }

    //    "status": "success",
    //"country": "COUNTRY",
    //"countryCode": "COUNTRY CODE",
    //"region": "REGION CODE",
    //"regionName": "REGION NAME",
    //"city": "CITY",
    //"zip": "ZIP CODE",
    //"lat": LATITUDE,
    //"lon": LONGITUDE,
    //"timezone": "TIME ZONE",
    //"isp": "ISP NAME",
    //"org": "ORGANIZATION NAME",
    //"as": "AS NUMBER / NAME",
    //"query": "IP ADDRESS USED FOR QUERY"
    }
}
