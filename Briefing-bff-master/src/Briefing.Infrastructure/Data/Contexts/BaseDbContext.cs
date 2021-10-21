using Briefing.Domain.Interfaces.Repositories;
using Briefing.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Briefing.Infrastructure.Data.Contexts
{
    public class BaseDbContext : DbContext, IUnitOfWork
    {

        public BaseDbContext()
        {

        }
        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("socialmente");
            modelBuilder.ApplyAllConfigurations();
        }
    }
}
