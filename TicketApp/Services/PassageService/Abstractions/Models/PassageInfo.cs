using Database.Database.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketApp.Service.PassageService.Abstractions.Models
{
    public class PassageInfo
    {
        public Guid Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public int MaxTickets { get; set; }
        public Guid UserId { get; } 
    }
}
