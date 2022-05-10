using JwtAuthentication.Helpers;
using JwtAuthentication.IServices;
using JwtAuthentication.Models;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthentication.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController :  ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        /// <summary>
        /// Get all data 
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await Task.Run(() => _userService.GetAllData());
            return Ok(data);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(UserModel model)
        {
            var data = await Task.Run(() => _userService.Post(model));

            return Ok(data);
        }
        
        [Authorize]
        [HttpPatch]
        public async Task<IActionResult> Patch(int id,UserModel model)
        {
            var data = await Task.Run(() => _userService.Update(id,model));

            return Ok(data);
        }
        
        [Authorize]
        [Route("/GetById")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await Task.Run(() => _userService.GetById(id));

            return Ok(data);
        }
        
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await Task.Run(() => _userService.Delete(id));

            return Ok(data);
        }


    }
}
