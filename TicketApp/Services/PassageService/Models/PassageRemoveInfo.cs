using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketApp.Services.PassageService.Models
{
    public class PassageRemoveInfo
    {
        public Guid PassageId { get; set; }
        public Guid RequestUserId { get; set; }
    }
}
