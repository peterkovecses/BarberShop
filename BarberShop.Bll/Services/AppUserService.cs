using BarberShop.Bll.DTOs;
using BarberShop.Bll.Interfaces;
using BarberShop.Data;
using BarberShop.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BarberShop.Bll.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        public BarberShopDbContext DbContext { get; }

        public AppUserService(UserManager<AppUser> userManager, BarberShopDbContext dbContext)
        {
            _userManager = userManager;
            DbContext = dbContext;
        }

        public async Task AddBarberUserAsync(BarberUserDTO barberUserDTO)
        {
            var appUser = new AppUser
            {               
                UserName = barberUserDTO.Email,
                Email = barberUserDTO.Email,
                Name = barberUserDTO.Name,
                PhoneNumber = barberUserDTO.PhoneNumber,
                BarberId = barberUserDTO.BarberId,                
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var createResult = await _userManager.CreateAsync(appUser, barberUserDTO.Password);

            // if the registration needs to be confirmed
            if (_userManager.Options.SignIn.RequireConfirmedAccount)
            {
                // confirm the registration
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
                var result = await _userManager.ConfirmEmailAsync(appUser, code);
            }

            // set the user's permissions
            var addToRoleResult = await _userManager.AddToRoleAsync(appUser, "Barbers");

            if (!createResult.Succeeded || !addToRoleResult.Succeeded)
            {
                throw new ApplicationException("Nem sikerült létrehozni az borbély felhasználót: " +
                    string.Join(", ", createResult.Errors.Concat(addToRoleResult.Errors).Select(e => e.Description)));
            }
        }

        public async Task<BarberUserDTO> GetBarberUserAsync(int id)
        {
            return await DbContext.AppUsers
                .Where(au => au.BarberId == id)
                .Include(au => au.Barber)
                .Select(au => new BarberUserDTO
                {
                    Id = au.Id,
                    Name = au.Name,
                    PublicDescription = au.Barber.PublicDescription,
                    Email = au.Email,
                    PhoneNumber = au.PhoneNumber,
                    PhotoPath = au.Barber.PhotoPath,
                    BarberId = au.BarberId
                })
                .SingleOrDefaultAsync();
        }
    }
}
