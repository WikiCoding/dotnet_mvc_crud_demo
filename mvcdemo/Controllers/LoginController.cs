using Microsoft.AspNetCore.Mvc;
using mvcdemo.Contracts;
using mvcdemo.Repository;

namespace mvcdemo.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IMembersRepository _membersRepository;

        public LoginController(ILogger<LoginController> logger, IMembersRepository membersRepository)
        {
            _logger = logger;
            _membersRepository = membersRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            _logger.LogInformation(loginRequest.Username);
            var user = await _membersRepository.GetByUsername(loginRequest.Username);

            if (user is null) return Redirect("Home"); // could also show error page instead

            return Redirect("Dashboard");
        }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }
    }
}