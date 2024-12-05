using VehicleInfoApp.DTO;
using VehicleService.DTO;


namespace VehicleService.Abstraction
{
    public interface IVehicleService
    {
        Task<VehicleMakeResponse> GetCarMakeResponse();
        Task<VehicleMakeIdYearResponse> CarForMakeIdYear(int makeId, int year);
        Task<VehicleTypeResponse> GetVehicleType(int makeId);
    }
}
