using Microsoft.EntityFrameworkCore;
using RevendaVeicular.Model;

namespace RevendaVeicular.Infra
{
    public class EmployerRepository : IEmployerRepository
    {
        private readonly ConnectionContext _connectionContext = new ConnectionContext();

        public void AddEmployer(EmployerModel employerModel)
        {
            _connectionContext.employerModels.Add(employerModel);
            _connectionContext.SaveChanges();
        }

        public bool DeleteEmployerById(int id)
        {
            var employer = _connectionContext.employerModels.Find(id);
            if (employer != null) 
            {
                _connectionContext.employerModels.Remove(employer);
                _connectionContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<EmployerModel> GetAll()
        {
            return _connectionContext.employerModels.ToList();
        }

        public EmployerModel GetById(int id)
        {
            var employer = _connectionContext.employerModels.Find(id);
            if (employer != null) 
            {
                return employer;
            }
            return null;
        }

        public void UpdateEmployerById(int id)
        {
            throw new NotImplementedException();
        }

        public EmployerModel Authenticate(string name, string password)
        {
            var authenticatedEmployer = _connectionContext.employerModels
                .FirstOrDefault(e => e.Name == name && e.Password == password);

            return authenticatedEmployer;
        }

    }



}
