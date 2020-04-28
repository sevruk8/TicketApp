using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketApp.Services.TicketService.Models.Enums;

namespace TicketApp.Services.TicketService.Abstractions.Models
{
    public class TicketShortModel
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
        public string From { get; set; }

        public SortedField SortedField { get; set; }
    }
}
