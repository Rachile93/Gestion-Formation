using GestionFormation.Entity;
using GestionFormation.Models;
using GestionFormation.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GestionFormation.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<Formateur> formateurs{ get; set; }
        public DbSet<Formation> formations { get; set; }
    }
}