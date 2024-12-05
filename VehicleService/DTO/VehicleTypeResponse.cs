
namespace VehicleService.DTO
{
    public class VehicleTypeResponse
    {
        public int Count {  get; set; }
        public string Message { get; set; }
        public string SearchCriteria { get; set; }
        public List<VehicleTypeDTO> Results { get; set; }

    }
}
