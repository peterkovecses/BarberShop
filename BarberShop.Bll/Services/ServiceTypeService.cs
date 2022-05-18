using BarberShop.Bll.DTOs;
using BarberShop.Bll.Interfaces;
using BarberShop.Data;
using BarberShop.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Bll.Services
{
    public class ServiceTypeService : IServiceTypeService
    {
        public BarberShopDbContext DbContext { get; }
        public ServiceTypeService(BarberShopDbContext dbContext)
        {
            DbContext = dbContext;
        }

        private Expression<Func<ServiceType, ServiceTypeDTO>> ServiceTypeSelector = st => new ServiceTypeDTO
        {
            Id = st.Id,
            Name = st.Name,
            Price = st.Price
        };

        public async Task<IList<ServiceTypeDTO>> GetServiceTypesAsync()
        {
            return (await DbContext.ServiceTypes
                .Select(ServiceTypeSelector)
                .ToListAsync())
                .OrderBy(st => st.Name)
                .ToList();
        }

        public async Task<ServiceTypeDTO> GetServiceTypeAsync(int id)
        {
            return await DbContext.ServiceTypes.Where(st => st.Id == id)
                .Select(ServiceTypeSelector)
                .SingleOrDefaultAsync();
        }

        public async Task AddOrUpdateServiceTypeAsync(ServiceTypeDTO serviceTypeDTO)
        {
            EntityEntry<ServiceType> entry;

            // update
            if (serviceTypeDTO.Id != 0)
            {
                var serviceType = await DbContext.ServiceTypes.FindAsync(serviceTypeDTO.Id);
                entry = DbContext.Entry(serviceType);
            }

            // create
            else
                entry = DbContext.Add(new ServiceType());

            entry.CurrentValues.SetValues(serviceTypeDTO);

            await DbContext.SaveChangesAsync();
        }

        public void DeleteServiceType(int id)
        {
            DbContext.ServiceTypes.Remove(new ServiceType { Id = id });
            DbContext.SaveChanges();
        }
    }
}
