using Database.Database.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketApp.Service.PassageService.Abstractions.Models
{
    public class PassageInfo
    {
        /// <summary>
        /// От куда
        /// </summary>
     
        public string From { get; set; }
        /// <summary>
        /// Куда
        /// </summary>
        public string To { get; set; }
        /// <summary>
        /// Время отправления
        /// </summary>
        public DateTime Departure { get; set; }
        /// <summary>
        /// Максимальное количество билетов
        /// </summary>
        public int MaxTickets { get; set; }
        /// <summary>
        /// Пользователь делающий запрос
        /// </summary>
        public Guid RequestUserId { get; } 
    }
}
