using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RevendaVeicular.Infra;
using RevendaVeicular.Model;
using RevendaVeicular.ViewModel;

namespace RevendaVeicular.Controllers
{
    [ApiController]
    [Route("api/v1/vehicle")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        [Authorize(Policy = "ManagerPolicy")]
        [HttpPost]
        public IActionResult AddVehicle(VehicleViewModel vehicleViewModel)
        {
            var vehicle = new VehicleModel(vehicleViewModel.Id, vehicleViewModel.Model, vehicleViewModel.Color, vehicleViewModel.Year,
                vehicleViewModel.Price);
            _vehicleRepository.Add(vehicle);
            return Ok(vehicle);
        }
        
        [HttpGet]
        public IActionResult GetVehicle() {
            var vehicles = _vehicleRepository.Get();
            return Ok(vehicles);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var vehicle = _vehicleRepository.GetById(id);
            if (vehicle != null)
            {
                return Ok(vehicle);
            }
            return NotFound();
        }
        [Authorize(Policy = "ManagerPolicy")]
        [HttpPut("{id}")]
        public IActionResult UpdateVehicleById(int id, VehicleViewModel vehicleViewModel) {
            _vehicleRepository.UpdateById(id, vehicleViewModel);
            return Ok();
        }
        [Authorize(Policy = "ManagerPolicy")]
        [HttpDelete("{id}")]
        public IActionResult DeleteVehicleById(int id) {
            bool vehicle = _vehicleRepository.DeleteById(id);
            if (vehicle == true) {
                return NoContent();
            }
            return NotFound();
                    
        }

    }
}
