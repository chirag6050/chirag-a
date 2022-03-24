using Chirag.BookReading.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Chirag.BookReading.Infrastructure.Data
{
    public class EventContext : IdentityDbContext   
    {
        public EventContext(
            DbContextOptions<EventContext> options)
            : base(options)
        {
        }
        public DbSet<Event> Events { get; set; }

        public DbSet<Comment> Comment { get; set; }
    }
}
