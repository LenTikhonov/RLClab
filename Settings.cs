using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLClab
{
    public class Settings
    {
        [JsonProperty("percent")]
        public double percent { get; set; }
        [JsonProperty("minSumm")]
        public int minSumm { get; set; }
    }
}
