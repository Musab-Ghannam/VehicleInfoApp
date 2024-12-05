using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using VehicleInfoApp.Abstraction;
using VehicleInfoApp.DTO;
using VehicleInfoApp.IntegrationUtilities;
using VehicleService.Abstraction;
using VehicleService.DTO;

namespace VehicleService.Services
{
    public class VehicleServices : IVehicleService
    {
        private readonly IOptions<VehicleSetting> _option;
        private readonly ILogger<VehicleServices> _logger;


        public VehicleServices(
         IOptions<VehicleSetting> option,
         ILogger<VehicleServices> logger)
        {
            _option = option;
            _logger = logger;
        }


        public async Task<VehicleMakeResponse> GetCarMakeResponse()
        {
            var client = new HttpClientCallers<VehicleMakeResponse>(_logger, _option.Value.AllMakesURL);
            var allCar = await client.GetRequest();
            return allCar;
        }

        public async Task<VehicleMakeIdYearResponse> CarForMakeIdYear(int makeId, int year)
        {
            var client = new HttpClientCallers<VehicleMakeIdYearResponse>(_logger, _option.Value.MakeIdYearURL);
            var relativeURL = $"/%20{makeId}/modelyear/{year}?format=json";
            var carForMakeIdYear = await client.GetRequest(relativeURL);
            return carForMakeIdYear;
        }

        public async Task<VehicleTypeResponse> GetVehicleType(int makeId)
        {
            var client = new HttpClientCallers<VehicleTypeResponse>(_logger, _option.Value.MakeIdURL);
            var relativeURL = $"/{makeId}?format=json";
            var VehicleType = await client.GetRequest(relativeURL);
            return VehicleType;
        }

    }


}
