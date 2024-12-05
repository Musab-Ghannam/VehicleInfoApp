
namespace VehicleService.DTO
{
    public class VehicleMakeIdYearResponse
    {
        public int Count { get; set; }  
        public string Message { get; set; }
        public string SearchCriteria { get; set; }
        public List<VehicleForMakeIdYearDTO> Results { get; set; }
    }
}
