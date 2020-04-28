using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketApp.Services.PassageService.Models.Enums;

namespace TicketApp.Services.PassageService.Models
{
    public class GetAllPassagesParameters
    {
        
        public SortedField SortedField{ get; set; }
        public string UserCity { get; set; }
        public bool From { get; set; }

    }
}
