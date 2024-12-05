using VehicleService.DTO;

namespace VehicleInfoApp.DTO
{
    public class VehicleMakeResponse
    {
        public int Count { get; set; }
        public string Message { get; set; }
        public string SearchCriteria { get; set; }
        public List<VehicleMakeDTO> Results { get; set; }
    }
}
