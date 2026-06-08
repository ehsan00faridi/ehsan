using Domain.UnitOfWork;
using Domain.Models.Customers;
using Domain.Models.Ordera;
using Domain.Models.Products;
using Microsoft.EntityFrameworkCore;
using Domain.BaseEntity;
using MediatR;
using Infrastrucure.Extenstion;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Domain.Models.User;
using Domain.Models.Roles;

namespace Infrastrucure
{
    public class ApplicationDbContext : IdentityDbContext<User,Role,int>,IUnitOfWork
    {
        private readonly IMediator _mediator;
        public ApplicationDbContext(DbContextOptions options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public async Task<int> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {


      
            await _mediator.DisPuchDomainEvent(this);



            var date= DateTime.Now;
            var entries = ChangeTracker.Entries<IBaseEntity<int>>();
            foreach (var entry in entries)
            {
                if (entry.State==EntityState.Added)
                {
                    entry.Entity.Created = date;
                    entry.Entity.ModifiedBy = 0;
                }
                if (entry.State==EntityState.Added||entry.State==EntityState.Modified)
                {
                    entry.Entity.Modified = date;
                    entry.Entity.ModifiedBy = 0;
                }

            }
           return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
