using System;
using System.Collections.Generic;
using System.Text;

namespace TicketApp.Service.TicketService.Abstractions.Models
{
    public class TicketModel
    {
        public Guid Id { get; set; }

        public Guid ClientId { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateClosed { get; set; }
    }
}
