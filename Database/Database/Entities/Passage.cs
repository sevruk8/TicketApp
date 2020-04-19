using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Database.Entities
{
    public class Passage
    {
        public Guid Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int MaxTickets { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public Guid UserId { get; }

    }
}
