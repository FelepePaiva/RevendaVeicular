namespace RevendaVeicular.Model
{
    public interface IEmployerRepository
    {
        void AddEmployer(EmployerModel employerModel);
        List<EmployerModel> GetAll();
        EmployerModel GetById(int id);
        bool DeleteEmployerById(int id);
        void UpdateEmployerById(int id);
        EmployerModel Authenticate(string name, string password);
   



    }
}
