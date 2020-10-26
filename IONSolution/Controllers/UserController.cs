using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IONSolution.Domain.Model;
using IONSolution.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IONSolution.Controllers
{    
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiVersion("1")]
    [ApiController]
    public class UserController : ControllerBase
    {
      
        private readonly ILogger<UserController> _logger ;

        private readonly IUserRepository _repository;

      

        public UserController(ILogger<UserController> logger, IUserRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Login(User model)
        {
            
            var user=_repository.Get(model.UserName);
           if (user==null)
                return Ok(new { success=false, errorMessage = "User does not exist." });

            if (user.Password != model.Password)
                return Ok(new { success = false, errorMessage = "Password is incorrect." });
            else
            {
                _repository.GenerateToken(model.UserName);
                return Ok(new { success = true, errorMessage = "User login successfully." });
            }

        }

        [HttpPost]
        public async Task<IActionResult> Logout(User model)
        {

            var user = _repository.Get(model.UserName);
            if (user == null)
                return Ok(new { success = false, errorMessage = "User does not exist." });

            _repository.DisposeToken(model.UserName);            
            return Ok(new { success = true, errorMessage = "User logout successfully." });

        }

    }
}
