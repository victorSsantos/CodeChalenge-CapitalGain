using CapitalGains.UI.DTOs.Converters;
using Newtonsoft.Json;

namespace CapitalGains.UI.DTOs
{
    public class OperationOutput(double tax)
    {
        [JsonProperty("tax")]
        [JsonConverter(typeof(DoubleWithTwoDecimalsConverter))]
        public double tax = tax;
    }
}
