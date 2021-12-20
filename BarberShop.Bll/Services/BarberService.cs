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
            // ide jön majd még az email
        };

        public async Task<IList<BarberDTO>> GetBarbersAsync()
        {
            return (await DbContext.Barbers.Where(b => b.IsDeleted == false)
                .Select(BarberSelector)
                .ToListAsync())
                .OrderBy(b => b.Name)
                .ToList();
        }

        public async Task<BarberDTO> GetBarberAsync(int id)
        {
            return (await DbContext.Barbers.Where(b => b.Id == id)
                .Select(BarberSelector)
                .SingleOrDefaultAsync());
        }

        public async Task AddOrUpdateBarberAsync(BarberDTO barberDTO)
        {
            EntityEntry<Barber> entry;

            // update
            if (barberDTO.Id != 0)
            {
                var barber = await DbContext.Barbers.FindAsync(barberDTO.Id);
                entry = DbContext.Entry(barber);
            }

            // create
            else
                entry = DbContext.Add(new Barber());

            entry.CurrentValues.SetValues(barberDTO);

            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteBarberAsync(int id)
        {
            var barber = await DbContext.Barbers.FindAsync(id);

            if (barber != null)
                barber.IsDeleted = true;

            DbContext.SaveChanges();
        }
    }
}
