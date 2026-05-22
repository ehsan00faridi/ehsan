using Domain.BaseEntity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Extenstion
{
    public static class MediatRExtenstion
    {
        public static async Task DisPuchDomainEvent(this IMediator mediator,DbContext db ) { 



         var DomainEntities = db.ChangeTracker.Entries<BaseEntity<int>>()
                .Where(x=>x.Entity.DomainEvents !=null && x.Entity.DomainEvents.Any());
        
        var DomainEvents=DomainEntities.SelectMany(x=>x.Entity.DomainEvents).ToList();

            DomainEntities.ToList().ForEach(entity => entity.Entity.CleardomainEvents());

            foreach (var domain in DomainEvents) { 
            
            await mediator.Publish(domain);
            
            }

        
        
        
        }
    }
}
