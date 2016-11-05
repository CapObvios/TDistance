using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TravelDistance.GDST
{
    public class Elements
    {
        [JsonProperty("elements")]
        public List<Values> elements { get; set; }
    }
}
