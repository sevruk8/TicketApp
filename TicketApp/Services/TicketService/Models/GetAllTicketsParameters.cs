using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketApp.Services.TicketService.Models.Enums;

namespace TicketApp.Services.TicketService.Models
{
    public class GetAllTicketsParameters
    {
        public SortedField SortedField { get; set; }
        public string UserCity { get; set; }
        public bool From { get; set; }
    }
}
