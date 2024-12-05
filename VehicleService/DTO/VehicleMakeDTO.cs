
using Newtonsoft.Json;

namespace VehicleService.DTO
{
    public class VehicleMakeDTO
    {
        [JsonProperty("Make_ID")]
        public int ID { get; set; }
        [JsonProperty("Make_Name")]
        public string? MakeName { get; set; }
    }
}
