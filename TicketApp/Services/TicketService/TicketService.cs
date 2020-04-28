using AutoMapper;
using Database;
using Database.Database.Entities;
using Database.Database.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using TicketApp.Service.TicketService.Abstractions;
using TicketApp.Service.TicketService.Abstractions.Models;
using TicketApp.Services.TicketService.Abstractions.Models;
using TicketApp.Services.TicketService.Models;
using TicketApp.Services.TicketService.Models.Enums;

namespace TicketApp.Service.TicketService
{
    /// <summary>
    /// Класс реализующий интерфейс Билетов
    /// </summary>
    public class TicketService : ITicketService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public TicketService(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        
        public Guid CreateTicket(TicketInfo ticketInfo)
        {
            
                var ticket = new Ticket()
                {
                    Id = Guid.NewGuid(),
                    ClientId = ticketInfo.ClientId,
                    Departure = ticketInfo.Departure
                };
                _dbContext.Tickets.Add(ticket);
                _dbContext.SaveChanges();
                return ticket.Id;
           

        }

        public void DeleteTicket(Guid Id, TicketModel ticketModel)
        {
            var isAdminOrCashier = _dbContext.Users.First(e => e.Id == ticketModel.UserId).Type != UserType.User;
            var isOwnerAndValidTime = (ticketModel.ClientId == ticketModel.UserId) && (ticketModel.Departure - DateTime.Now > TimeSpan.FromMinutes(15));

            if (isAdminOrCashier || isOwnerAndValidTime)
            {
                var ticket = _dbContext.Tickets.First(e => e.Id == Id);
                _dbContext.Tickets.Remove(ticket);
                _dbContext.SaveChanges();
            }

            else {throw new Exception("У вас нет прав доступа");}
        }

        

        public List<TicketShortModel> GetAllTickets(TicketShortModel ticketShortModel, GetAllTicketsParameters parameters)
        {
            var tickets = _dbContext.Tickets;

            var resultTickets = new List<TicketShortModel>();
            
            resultTickets.AddRange(tickets.Select(e => _mapper.Map<TicketShortModel>(e)));

            var isAdminOrCashier = _dbContext.Users.First(e => e.Id == ticketShortModel.UserId).Type != UserType.User;
            if (!isAdminOrCashier)
            {
                resultTickets = resultTickets.Where(e => e.ClientId == ticketShortModel.UserId).ToList();
                if (!string.IsNullOrEmpty(parameters.UserCity))
                {
                    resultTickets = resultTickets.Where(e => e.From.Contains(parameters.UserCity)).ToList();
                }
                if (parameters.SortedField != SortedField.None)
                {
                    resultTickets = resultTickets.Where(e => e.SortedField == parameters.SortedField).ToList();
                }
            }

            return resultTickets;
        }

        
        public TicketModel GetTicket(Guid Id)
        {

            var ticket = _dbContext.Tickets.First(e => e.Id == Id);

            return _mapper.Map<TicketModel>(ticket);
        }


        
        public void UpdateTicket(Guid Id, TicketModel ticketModel)
        {
            if((_dbContext.Users.First(e => e.Id == ticketModel.UserId).Type != UserType.User)||(
                ticketModel.ClientId == ticketModel.UserId))
            {
                var ticket = _dbContext.Tickets.First(e => e.Id == Id);

                _dbContext.SaveChanges();
            }
        }
    }
}
