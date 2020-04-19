using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Models
{
    /// <summary>
    /// Модель токена
    /// </summary>
    public class Token
    {
        /// <summary>
        /// Тип токена
        /// </summary>
        public string TokenType { get; set; }

        /// <summary>
        /// Токен
        /// </summary>
        public string AccessToken { get; set; }
    }
}
