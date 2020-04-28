using Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketApp.Service.TicketService;
using TicketApp.Service.TicketService.Abstractions;
using TicketApp.Service.TicketService.Abstractions.Models;
using TicketApp.Services.TicketService.Abstractions.Models;

namespace TicketApp.Controllers
{
    [Route("Tickets")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }


        [HttpGet]
        public async Task<List<TicketShortModel>> GetTickets([FromQuery] TicketShortModel ticketShortModel)
        {
            return _ticketService.GetAllTickets(ticketShortModel);
        }

        [HttpGet("{id}")]
        public ActionResult<TicketModel> GetTicket([FromRoute]Guid Id)
        {
            return _ticketService.GetTicket(Id);
        }

        [HttpPost]
        public ActionResult<Guid> CreateTicket([FromBody]TicketInfo ticketInfo)
        {
            return _ticketService.CreateTicket(ticketInfo);
        }
        
        [HttpDelete]
        public void DeleteTicket([FromQuery] Guid Id, [FromBody]TicketModel ticketModel)
        {
            _ticketService.DeleteTicket(Id, ticketModel);
        }

        [HttpPut("{ticketId}")]
        public void UpdateTicket([FromBody] TicketModel ticket, [FromRoute]Guid Id)
        {
            _ticketService.UpdateTicket(Id, ticket);
        }
    }
}
