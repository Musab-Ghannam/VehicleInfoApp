using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VehicleInfoApp.Models;
using VehicleService.Abstraction;

namespace VehicleInfoApp.Controllers
{
    public class HomeController(ILogger<HomeController> logger, IVehicleService vehicleService) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly IVehicleService _vehicleService = vehicleService;

        #region Index
        public async Task<IActionResult> Index(int makeId = 449, int year = 2023, string? makeName = null)
        {
            var carMakeResponse = await _vehicleService.GetCarMakeResponse();
            var carMake = CarMakeResponseModel.ToModel(carMakeResponse);
            var carModelsForMakeIdYear = await GetModelsForMakeIdYear(makeId,year);
            var tupleModel = new Tuple<CarMakeResponseModel, CarMakeIdYearresponsModel>(carMake, carModelsForMakeIdYear);
            ViewBag.VehicleTypes = await _vehicleService.GetVehicleType(makeId);
            ViewBag.MakeName = carMake.Results.FirstOrDefault(x => x.ID == makeId)?.MakeName;
            ViewBag.Year = year;
            return View(tupleModel);
        }
        #endregion

        #region GetModelsForMakeIdYear
        private async Task<CarMakeIdYearresponsModel> GetModelsForMakeIdYear(int makeId,int year)
        {
            var carResponse = await _vehicleService.CarForMakeIdYear(makeId, year);
            var carModel = CarMakeIdYearresponsModel.ToModel(carResponse);
            return carModel;
        }

        #endregion
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
