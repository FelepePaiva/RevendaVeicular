using Microsoft.AspNetCore.Http.HttpResults;
using RevendaVeicular.Model;
using RevendaVeicular.ViewModel;

namespace RevendaVeicular.Infra
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ConnectionContext _connectionContext = new ConnectionContext();

        public void Add(VehicleModel vehicleModel)
        {
            _connectionContext.vehicleModels.Add(vehicleModel);
            _connectionContext.SaveChanges();
        }

        public bool DeleteById(int id)
        {
            var vehicle = _connectionContext.vehicleModels.Find(id);
            if (vehicle != null)
            {
                _connectionContext.Remove(vehicle);
                _connectionContext.SaveChanges();
                return true;
            }         
            return false;
        }

        public List<VehicleModel> Get()
        {
            return _connectionContext.vehicleModels.ToList();
        }

        public VehicleModel GetById(int id)
        {
            var vehicle = _connectionContext.vehicleModels.Find(id);
            if (vehicle != null) { 
                return vehicle;
            }
            return null;
        }

        public void UpdateById(int id, VehicleViewModel vehicleViewModel)
        {
            var vehicle = _connectionContext.vehicleModels.Find(id);
            if (vehicle != null)
            {
                vehicle.Model = vehicleViewModel.Model;
                vehicle.Color = vehicleViewModel.Color;
                vehicle.Year = vehicleViewModel.Year;
                vehicle.Price = vehicleViewModel.Price;
                _connectionContext.SaveChanges();
            }
        }
    }
}

