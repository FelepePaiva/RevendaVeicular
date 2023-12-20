using RevendaVeicular.ViewModel;

namespace RevendaVeicular.Model
{
    public interface IVehicleRepository
    {
        void Add(VehicleModel vehicleModel);

        List<VehicleModel> Get();
        public VehicleModel GetById (int id);
        void UpdateById(int id, VehicleViewModel vehicleViewModel);

        bool DeleteById(int id);
    }
}
