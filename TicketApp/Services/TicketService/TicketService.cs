using Database;
using Database.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using TicketApp.Service.TicketService.Abstractions;
using TicketApp.Service.TicketService.Abstractions.Models;

namespace TicketApp.Service.TicketService
{
    public class TicketService : ITicketService
    {
        private readonly DatabaseContext _dbContext;

        public TicketService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Guid CreateTicket(TicketModel ticketModel)
        {
            var ticket = new Ticket()
            {
                Id = Guid.NewGuid(),
                ClientId = ticketModel.ClientId,
                DateAdded = ticketModel.DateAdded,
                DateClosed = ticketModel.DateClosed
            };

            _dbContext.Tickets.Add(ticket);
            _dbContext.SaveChanges();
            return ticket.Id;
        }

        public void DeleteTicket(Guid Id)
        {
            var ticket = _dbContext.Tickets.First(e => e.Id == Id);
            _dbContext.Tickets.Remove(ticket);
            _dbContext.SaveChanges();
        }

        public List<TicketModel> GetAllTickets()
        {
            var tickets = _dbContext.Tickets;

            var resultTickets = new List<TicketModel>();

            foreach (var dbTicket in tickets)
            {
                var ticket = new TicketModel()
                {
                    Id = dbTicket.Id,
                    ClientId = dbTicket.ClientId,
                    DateAdded = dbTicket.DateAdded,
                    DateClosed = dbTicket.DateClosed
                };
                resultTickets.Add(ticket);
            }

            return resultTickets;
        }

        public TicketModel GetTicket(Guid Id)
        {
            var dbTicket = _dbContext.Tickets.First(e => e.Id == Id);

            var ticket = new TicketModel()
            {
                Id = dbTicket.Id,
                ClientId = dbTicket.ClientId,
                DateAdded = dbTicket.DateAdded,
                DateClosed = dbTicket.DateClosed
            };

            return ticket;
        }

        public void UpdateTicket(Guid Id, TicketModel ticketModel)
        {
            var ticket = _dbContext.Tickets.First(e => e.Id == Id);

            ticket.DateAdded = ticketModel.DateAdded;
            ticket.DateClosed = ticketModel.DateClosed;

            _dbContext.SaveChanges();
        }
    }
}
