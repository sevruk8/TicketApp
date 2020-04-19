using Database.Database.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketApp.Service.UserService.Abstractions.Models
{
    /// <summary>
    /// Модель регистрации
    /// </summary>
    public class RegistrationModel
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Почта
        /// </summary>
        public string Email { get; set; }


        /// <summary>
        /// Имя 
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия 
        /// </summary>
        public string LastName { get; set; }


    }
}
