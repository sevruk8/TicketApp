using Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketApp.Service.UserService;
using TicketApp.Service.UserService.Abstractions.Models;

namespace TicketApp.Controllers
{
    [Route("Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public ActionResult<List<UserShortModel>> GetUsers()
        {
            return _userService.GetAllUsers();
        }

        [HttpGet("{id}")]
        public ActionResult<UserModel> GetUser([FromRoute]Guid id)
        {
            return _userService.GetUser(id);
        }

        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="registrationModel"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Registration")]
        public async Task Registration([FromQuery]RegistrationModel registrationModel)
        {
            await _userService.Registration(registrationModel);
        }

        [HttpPost]
        public ActionResult<Guid> CreateUser([FromBody]UserInfo user)
        {
            return _userService.CreateUser(user);
        }
        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="authorizationModel"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("Authorize")]
        [ProducesResponseType(typeof(Token), 200)]
        public async Task<Token> Authorize(AuthorizationModel authorizationModel)
        {
            var token = await _userService.Authorization(authorizationModel);
            return token;
        }

        [Authorize]
        [HttpGet]
        [Route("Test")]
        public async Task<int[]> Registration()
        {
            return new int[] { 1, 2, 3, 4, 5 };
        }

        [HttpDelete]
        public void DeleteUser([FromQuery] Guid id)
        {
            _userService.DeleteUser(id);
        }

        [HttpPut("{userId}")]
        public void UpdateUser([FromBody] UserInfo user, [FromRoute]Guid userId)
        {
            _userService.UpdateUser(userId, user);
        }
    }
}
