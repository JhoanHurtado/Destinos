using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destinos.Data.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=DestinosContext")
        {
        }
        public DbSet<Place> Places { get; set; }

    }
}
