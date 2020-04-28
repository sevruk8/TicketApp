using System;

namespace TicketApp.Services.TicketService.Abstractions.Models
{
    public class TicketInfo
    {
        /// <summary>
        /// ID владельца билета
        /// </summary>
        public Guid ClientId { get; set; }
        /// <summary>
        /// Время отправления
        /// </summary>
        public DateTime Departure { get; set; }
        /// <summary>
        /// Время прибытия
        /// </summary>
        public DateTime Arrival { get; set; }
        /// <summary>
        /// ID пользователя делающий запрос
        /// </summary>
        public Guid UserId { get; }

    }
}
