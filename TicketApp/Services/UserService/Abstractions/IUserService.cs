using Identity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketApp.Service.UserService.Abstractions.Models;
using TicketApp.Services.UserService.Models;

namespace TicketApp.Service.UserService.Abstractions
{
    public interface IUserService
    {

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="registrationModel"></param>
        /// <returns></returns>
        Task Registration(RegistrationModel registrationModel);

        /// <summary>
        /// Регистрация администратора
        /// </summary>
        Task RegistrationAdmin(RegistrationAdminModel registrationAdminModel);

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

