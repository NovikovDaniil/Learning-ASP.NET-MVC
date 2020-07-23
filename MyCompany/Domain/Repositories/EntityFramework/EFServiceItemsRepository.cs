using Microsoft.EntityFrameworkCore;
using MyCompany.Domain.Entities;
using MyCompany.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Domain.Repositories.EntityFramework
{
    public class EFServiceItemsRepository : IServiceItemsRepository
    {
        protected readonly AppDbContext context;

        public EFServiceItemsRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void DeleteServiceItem(Guid id)
        {
            context.ServiceItems.Remove(new ServiceItem() { Id = id });
            context.SaveChanges();
        }

        public ServiceItem GetServiceItemById(Guid id)
            => context.ServiceItems.FirstOrDefault(s => s.Id == id);

        public IQueryable<ServiceItem> GetServiceItems()
            => context.ServiceItems;

        public void SaveServiceItem(ServiceItem serviceItem)
        {
            if (serviceItem.Id == default)
                context.Entry(serviceItem).State = EntityState.Added;
            else
                context.Entry(serviceItem).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
