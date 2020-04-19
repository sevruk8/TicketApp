using Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketApp.Service.TicketService;
using TicketApp.Service.TicketService.Abstractions.Models;

namespace TicketApp.Controllers
{
    [Route("Tickets")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly TicketService _ticketService;

        public TicketController(TicketService ticketService)
        {
            _ticketService = ticketService;
        }


        [HttpGet]
        public ActionResult<List<TicketModel>> GetTickets()
        {
            return _ticketService.GetAllTickets();
        }

        [HttpGet("{id}")]
        public ActionResult<TicketModel> GetTicket([FromRoute]Guid Id)
        {
            return _ticketService.GetTicket(Id);
        }

        

        [HttpPost]
        public ActionResult<Guid> CreateTicket([FromBody]TicketModel ticket)
        {
            return _ticketService.CreateTicket(ticket);
        }
        
        [HttpDelete]
        public void DeleteTicket([FromQuery] Guid Id)
        {
            _ticketService.DeleteTicket(Id);
        }

        [HttpPut("{ticketId}")]
        public void UpdateTicket([FromBody] TicketModel ticket, [FromRoute]Guid Id)
        {
            _ticketService.UpdateTicket(Id, ticket);
        }
    }
}
