using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Application.Models;
using static Microsoft.Azure.Documents.Trigger;
using EntityFrameworkCore.Triggers;

namespace Application.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Application.Models.Activity> Activities { get; set; }
        
        public override Task<int>SaveChangesAsync(CancellationToken cancellationToken= default(CancellationToken))
        {
            return this.SaveChangesWithTriggersAsync(base.SaveChangesAsync, acceptAllChangesOnSuccess:true, cancellationToken:cancellationToken);
        }
    }
}