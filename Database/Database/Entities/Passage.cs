using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Database.Entities
{
    public class Passage
    {
        /// <summary>
        /// ID рейсов
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// От куда
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Куда
        /// </summary>
        public string To { get; set; }
        /// <summary>
        /// Максимальное количество билетов
        /// </summary>
        public int MaxTickets { get; set; }
        /// <summary>
        /// Время отбытия
        /// </summary>
        public DateTime Departure { get; set; }
        /// <summary>
        /// ID юзера
        /// </summary>
        public Guid UserId { get; }
        
    }
}
