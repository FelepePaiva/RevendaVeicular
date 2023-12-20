using Microsoft.AspNetCore.Mvc;
using RevendaVeicular.Model;
using RevendaVeicular.Services;
using RevendaVeicular.ViewModel;

namespace RevendaVeicular.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        private readonly IEmployerRepository _employerRepository;
        public AuthController(IEmployerRepository employerRepository) 
        {
            _employerRepository = employerRepository;
        }
        [HttpPost]
        public IActionResult Auth(EmployerViewModel employerViewModel) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var authenticateEmployer = _employerRepository.Authenticate(employerViewModel.Name, employerViewModel.Password);
            if (authenticateEmployer == null)
            {
                return BadRequest();
            }
            var token = TokenService.GenerateToken(authenticateEmployer);
            return Ok(token);
           
        }
    }
}
