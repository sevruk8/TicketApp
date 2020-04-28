using AutoMapper;
using Database.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketApp.Service.PassageService.Abstractions.Models;
using TicketApp.Service.TicketService.Abstractions.Models;
using TicketApp.Service.UserService.Abstractions.Models;
using TicketApp.Services.TicketService.Abstractions.Models;

namespace TicketApp.Services
{
    /// <summary>
    /// Профиль преобразования AutoMapper для Services
    /// </summary>


    public class DomainMappingProfile : Profile 
    {
        public DomainMappingProfile()
        {
            CreateMap<Passage, PassageInfo>();
            CreateMap<Passage, PassageModel>();
            CreateMap<Passage, PassageShortModel>();
            CreateMap<Ticket, TicketInfo>();
            CreateMap<Ticket, TicketModel>();
            CreateMap<Ticket, TicketShortModel>();
            CreateMap<User, UserInfo>();
            CreateMap<User, UserModel>();
            CreateMap<User, UserShortModel>();
            CreateMap<User, RegistrationModel>();
            CreateMap<User, AuthorizationModel>();

        }
    }
}
