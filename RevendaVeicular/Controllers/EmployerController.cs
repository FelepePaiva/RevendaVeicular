using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RevendaVeicular.Model;
using RevendaVeicular.ViewModel;

namespace RevendaVeicular.Controllers
{
    [ApiController]
    [Route("api/v1/employer")]
    public class EmployerController : ControllerBase
    {
        private readonly IEmployerRepository _employerRepository;
        public EmployerController(IEmployerRepository employerRepository)
        {
            _employerRepository = employerRepository;
        }
        
        [HttpPost]
        public IActionResult AddEmployer(EmployerViewModel employerViewModel)
        {
            var employer = new EmployerModel(employerViewModel.Id, employerViewModel.Name,
                employerViewModel.Password, employerViewModel.Role);
            _employerRepository.AddEmployer(employer);
            return Ok(employer);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployer(int id) 
        {
            bool employer = _employerRepository.DeleteEmployerById(id);
            if (employer)
            {
                return NoContent();
            }
            return BadRequest();
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var employees = _employerRepository.GetAll();
            return Ok(employees);
        }
      
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var employer = _employerRepository.GetById(id);
            if (employer != null) 
            {
                return Ok(employer);
            }
            return BadRequest();
        }
    }
}
