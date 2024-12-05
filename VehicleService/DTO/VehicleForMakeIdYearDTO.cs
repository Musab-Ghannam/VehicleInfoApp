using Newtonsoft.Json;

namespace VehicleService.DTO
{
    public class VehicleForMakeIdYearDTO
    {
        [JsonProperty("Make_ID")]
        public int MakId {  get; set; }

        [JsonProperty("Make_Name")]
        public string MakName { get; set; }
        [JsonProperty("Model_ID")]
        public int ModelId {  get; set; }
        [JsonProperty("Model_Name")]
        public string ModelName { get; set; }

    }
}
