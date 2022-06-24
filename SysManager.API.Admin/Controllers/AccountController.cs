using Microsoft.AspNetCore.Mvc;
using SysManager.Application.Contracts.Users.Request;
using SysManager.Application.Helpers;
using SysManager.Application.Services;
using System;
using System.Threading.Tasks;

namespace SysManager.API.Admin.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AccountController
    { 
        private readonly UserService _userService;
        public AccountController(UserService service)
        {
        this._userService = service;
        }
        [HttpPost("create-account")]
        public async Task<IActionResult> Post([FromBody] UserPostRequest request)
        {
            Console.WriteLine("Inicio do processo");
            var response = await _userService.PostAsync(request);
            return Utils.Convert(response);
        }
        [HttpPost("login")]
        public async Task<IActionResult> PostLogin([FromBody] UserPostRequest request)
        {
            Console.WriteLine("Inicio do processo 2");
            return Utils.Convert(new ResultData(false));

        }

    }
}
