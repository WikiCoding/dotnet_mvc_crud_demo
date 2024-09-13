using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvcdemo.Contracts;
using mvcdemo.Repository;
using mvcdemo.Services;

namespace mvcdemo.Controllers
{
    [Route("[controller]")]
    public class RegisterController : Controller
    {
        private readonly ILogger<RegisterController> _logger;
        private readonly MembersService _membersService;

        public RegisterController(ILogger<RegisterController> logger, MembersService membersService)
        {
            _logger = logger;
            _membersService = membersService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(LoginRequest loginRequest)
        {
            var user = await _membersService.GetMemberByUsername(loginRequest.Username);

            if (user is not null) return Redirect("Home");

            await _membersService.SaveMember(loginRequest.Username, loginRequest.Password);

            return Redirect("Login");
        }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }
    }
}