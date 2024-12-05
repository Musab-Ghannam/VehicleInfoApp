using VehicleInfoApp.DTO;
using VehicleService.DTO;

namespace VehicleInfoApp.Models
{
    public class CarMakeIdYearresponsModel
    {
        public int Count { get; set; }
        public string Message { get; set; }
        public string SearchCriteria { get; set; }
        public List<VehicleForMakeIdYearDTO> Results { get; set; }

        public static CarMakeIdYearresponsModel ToModel(VehicleMakeIdYearResponse model)
        {
            return new CarMakeIdYearresponsModel()
            {
                Count = model.Count,
                Message = model.Message,
                SearchCriteria = model.SearchCriteria,
                Results = model.Results
            };
        }
    }
}
