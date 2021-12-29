using BarberShop.Bll.DTOs;
using BarberShop.Bll.Helpers;
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
    public class BarberService : IBarberService
    {
        public BarberShopDbContext DbContext { get; }
        public BarberService(BarberShopDbContext dbContext)
        {
            DbContext = dbContext;
        }

        private Expression<Func<Barber, BarberDTO>> BarberSelector = b => new BarberDTO
        {
            Id = b.Id,
            Name = b.Name,
            PublicDescription = b.PublicDescription,
            ShortPublicDescription = b.PublicDescription.Shorten(200),
            PhotoPath = b.PhotoPath            
        };

        public async Task<IList<BarberDTO>> GetBarbersAsync()
        {
            return (await DbContext.Barbers.Where(b => b.IsDeleted == false)
                .Select(BarberSelector)
                .ToListAsync())
                .ToList();
        }

        public async Task<BarberDTO> GetBarberAsync(int id)
        {
            return (await DbContext.Barbers.Where(b => b.Id == id)
                .Select(BarberSelector)
                .SingleOrDefaultAsync());
        }

        public async Task<int> AddBarberAsync(BarberUserDTO barberUserDTO)
        {
            var barber = new Barber
            {
                Name = barberUserDTO.Name,
                PublicDescription = barberUserDTO.PublicDescription,
                PhotoPath = barberUserDTO.PhotoPath
            };

            DbContext.Barbers.Add(barber);

            await DbContext.SaveChangesAsync();

            return barber.Id;
        }

        public async Task UpdateBarberAsync(BarberDTO barberDTO)
        {
            EntityEntry<Barber> entry;
            var barber = await DbContext.Barbers.FindAsync(barberDTO.Id);
            entry = DbContext.Entry(barber);
            entry.CurrentValues.SetValues(barberDTO);

            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteBarberAsync(int id)
        {
            var barber = await DbContext.AppUsers
                .Where(au => au.BarberId == id)
                .Include(au => au.Barber)
                .SingleOrDefaultAsync();

            if (barber != null)
                barber.Barber.IsDeleted = true;

            DbContext.AppUsers.Remove(barber);

            await DbContext.SaveChangesAsync();
        }        
    }
}
