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
        /// ID прользователя, которому принадлежит билет
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        /// Дата добавления
        /// </summary>
        public DateTime DateAdded { get; set; }

        /// <summary>
        /// Дата завершения
        /// </summary>
        public DateTime DateClosed { get; set; }

        public int MaxTicket { get; set; }
    }
}
