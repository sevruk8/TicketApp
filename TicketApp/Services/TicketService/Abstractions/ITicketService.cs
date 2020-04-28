using System;
using System.Collections.Generic;
using System.Text;
using TicketApp.Service.TicketService.Abstractions.Models;
using TicketApp.Services.TicketService.Abstractions.Models;
using TicketApp.Services.TicketService.Models;

namespace TicketApp.Service.TicketService.Abstractions
{
    public interface ITicketService
    {
        TicketModel GetTicket(Guid Id);

        List<TicketShortModel> GetAllTickets(TicketShortModel ticketShortModel, GetAllTicketsParameters parameters);

        void UpdateTicket(Guid Id, TicketModel ticket);

        Guid CreateTicket(TicketInfo ticketInfo);

        void DeleteTicket(Guid Id, TicketModel ticketModel);
    }
}
