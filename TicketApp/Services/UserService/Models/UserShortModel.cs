using Database.Database.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketApp.Service.UserService.Abstractions.Models
{
    public class UserShortModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserType Type { get; set; }
    }
}
