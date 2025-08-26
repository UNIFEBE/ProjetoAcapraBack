using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Acapra.Infra.Context
{
    public class AcapraDbContext : DbContext
    {
        public AcapraDbContext(DbContextOptions<AcapraDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AcapraDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
