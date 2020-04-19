using System;
using System.Collections.Generic;
using System.Text;

namespace TicketApp.Service.UserService.Abstractions.Models
{
    /// <summary>
    /// Модель авторизации
    /// </summary>
    public class AuthorizationModel
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
    }
}
