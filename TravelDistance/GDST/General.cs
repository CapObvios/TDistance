using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TravelDistance.GDST
{
    public class General
    {
        [JsonProperty("destination_addresses")]
        public List<string> dest { get; set; }
        //[JsonProperty("origin_addresses")]
        //public List<string> origin { get; set; }
        [JsonProperty("rows")]
        public List<Elements> rows { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }
    }
}
