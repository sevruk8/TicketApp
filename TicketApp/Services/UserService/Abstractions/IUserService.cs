using Identity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketApp.Service.UserService.Abstractions.Models;

namespace TicketApp.Service.UserService.Abstractions
{
    interface IUserService
    {

        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="registrationModel"></param>
        /// <returns></returns>
        Task Registration(RegistrationModel registrationModel);

        /// <summary>
        /// Авторизация 
        /// </summary>
        /// <param name="authorizationModel"></param>
        /// <returns></returns>
        Task<Token> Authorization(AuthorizationModel authorizationModel);

        // CRUD - Create Read Update Delete
        UserModel GetUser(Guid Id);

        List<UserShortModel> GetAllUsers();

        void UpdateUser(Guid Id, UserInfo user);

        Guid CreateUser(UserInfo user);

        void DeleteUser(Guid Id);

    }
}

