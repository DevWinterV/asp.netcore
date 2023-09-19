using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace WEB_API.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options) { 

        }
        public DbSet<Contacts> Contacts {  get; set; }
    }

}
