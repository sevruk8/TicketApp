

using Database.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class DatabaseContext : DbContext 
    {
        /// <summary>
        /// Конструктор DbContext
        /// </summary>
        /// <param name="options">Опции для создания контекста</param>
        /// <returns>Новый экземпляр этого контекста</returns>
        public DatabaseContext(DbContextOptions options) : base(options)
        { }

        /// <summary>
        /// Пользователи
        /// </summary>
        public virtual DbSet<User> Users { get; set; }

        /// <summary>
        /// Рейсы
        /// </summary>
        public virtual DbSet<Passage> Passages { get; set; }

        /// <summary>
        /// Билеты
        /// </summary>
        public virtual DbSet<Ticket> Tickets { get; set; }


    }
}
