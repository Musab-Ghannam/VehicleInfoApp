using VehicleInfoApp.DTO;
using VehicleService.DTO;

namespace VehicleInfoApp.Models
{
    public class CarMakeResponseModel
    {
        public int Count { get; set; }
        public string Message { get; set; }
        public string SearchCriteria { get; set; }
        public List<VehicleMakeDTO> Results { get; set; }

        public static CarMakeResponseModel ToModel(VehicleMakeResponse model)
        {
            return new CarMakeResponseModel()
            {
                Count = model.Count,
                Message = model.Message,
                SearchCriteria = model.SearchCriteria,
                Results = model.Results
            };
        }
    }
}
