using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Database.Entities
{
    /// <summary>
    /// Билет пользователя
    /// </summary>
    public class Ticket
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        // <summary>
        /// ID кому принадлежит билет
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        /// ID рейса 
        /// </summary>
        public Guid PassageId { get; set; }

        /// <summary>
        /// Время отправления
        /// </summary>
        public DateTime Departure { get; set; }
        /// <summary>
        /// Время прибытия
        /// </summary>
        public DateTime Arrival { get; set; }

    }
}
