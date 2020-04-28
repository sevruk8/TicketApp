using System;
using System.Collections.Generic;
using System.Text;

namespace TicketApp.Service.TicketService.Abstractions.Models
{
    public class TicketModel
    {
        public Guid Id { get; set; }

        /// <summary>
        /// ID владельца билета
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        /// Время отправления
        /// </summary>

        public DateTime Departure { get; set; }

        /// <summary>
        /// ID пользователя делающий запрос
        /// </summary>
        public Guid UserId { get; }
    }
}
