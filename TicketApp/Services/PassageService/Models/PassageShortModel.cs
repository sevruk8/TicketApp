using System;
using System.Collections.Generic;
using System.Text;
using TicketApp.Services.PassageService.Models.Enums;

namespace TicketApp.Service.PassageService.Abstractions.Models
{
    public class PassageShortModel
    {
        public Guid Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int MaxTickets { get; set; }
        public SortedField SortedField { get; set; }

    }
}
