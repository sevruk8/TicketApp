using System;
using System.Collections.Generic;
using System.Text;
using TicketApp.Service.TicketService.Abstractions.Models;

namespace TicketApp.Service.TicketService.Abstractions
{
    public interface ITicketService
    {
        TicketModel GetTicket(Guid Id);

        List<TicketModel> GetAllTickets();

        void UpdateTicket(Guid Id, TicketModel ticket);

        Guid CreateTicket(TicketModel ticket);

        void DeleteTicket(Guid id);
    }
}
