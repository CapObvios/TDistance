using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TravelDistance.GDST
{
    public class Values
    {
        [JsonProperty("distance")]
        public Numbers distance { get; set; }

        [JsonProperty("duration")]
        public Numbers duration { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }
    }
}
