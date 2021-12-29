using BarberShop.Data.Entities;
using BarberShop.Data.Seed.Interfaces;
using BarberShop.Data.Seed.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberShop.Data.Seed.Services
{
    public class UserSeedService : IUserSeedService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AdminSettings _adminSettings;

        public UserSeedService(UserManager<AppUser> userManager, IOptions<AdminSettings> adminSettings)
        {
            _userManager = userManager;
            _adminSettings = adminSettings.Value;
        }

        public async Task SeedUserAsync()
        {
            // if there is no user with this role
            if (!(await _userManager.GetUsersInRoleAsync("Barbers")).Any())
            {
                // Add doctor AppUsers
                var barberUsers = new List<AppUser>
            {
                new AppUser { UserName = "kobakkaroly@gmail.com", Email =  "kobakkaroly@gmail.com", PhoneNumber = "06202020201", Name = "Kobak Károly", BarberId = 1, SecurityStamp = Guid.NewGuid().ToString()},
                new AppUser { UserName = "bajuszbela@gmail.com", Email =  "bajuszbela@gmail.com", PhoneNumber = "06202020201", Name = "Bajusz Béla", BarberId = 2, SecurityStamp = Guid.NewGuid().ToString()},
                new AppUser { UserName = "szakallsandor@gmail.com", Email =  "szakallsandor@gmail.com", PhoneNumber = "06202020201", Name = "Szakáll Sándor", BarberId = 3, SecurityStamp = Guid.NewGuid().ToString()},
                new AppUser { UserName = "borbelybertalan@gmail.com", Email =  "borbelybertalan@gmail.com", PhoneNumber = "06202020201", Name = "Borbély Bertalan", BarberId = 4, SecurityStamp = Guid.NewGuid().ToString()}
            };

                foreach (var barberUser in barberUsers)
                {
                    var createResult = await _userManager.CreateAsync(barberUser, _adminSettings.Password);

                    // if the registration needs to be confirmed
                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        // confirm the registration
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(barberUser);
                        var result = await _userManager.ConfirmEmailAsync(barberUser, code);
                    }

                    // set the user's permissions
                    var addToRoleResult = await _userManager.AddToRoleAsync(barberUser, "Barbers");

                    if (!createResult.Succeeded || !addToRoleResult.Succeeded)
                    {
                        throw new ApplicationException("Nem sikerült létrehozni az borbély felhasználót: " +
                            string.Join(", ", createResult.Errors.Concat(addToRoleResult.Errors).Select(e => e.Description)));
                    }
                }
            }

            // if there is no user with this role
            if (!(await _userManager.GetUsersInRoleAsync("Administrators")).Any())
            {
                var appUser = new AppUser
                {
                    UserName = _adminSettings.UserName,
                    Email = _adminSettings.Email,
                    PhoneNumber = _adminSettings.PhoneNumber,
                    Name = _adminSettings.Name,                    
                    SecurityStamp = Guid.NewGuid().ToString() // random string
                };

                // create the user
                var createResult = await _userManager.CreateAsync(appUser, _adminSettings.Password);

                // if the registration needs to be confirmed
                if (_userManager.Options.SignIn.RequireConfirmedAccount)
                {
                    // confirm the registration
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
                    var result = await _userManager.ConfirmEmailAsync(appUser, code);
                }

                // set the user's permissions
                var addToRoleResult = await _userManager.AddToRoleAsync(appUser, "Administrators");

                if (!createResult.Succeeded || !addToRoleResult.Succeeded)
                {
                    throw new ApplicationException("Nem sikerült létrehozni az adminisztrátor felhasználót: " +
                        string.Join(", ", createResult.Errors.Concat(addToRoleResult.Errors).Select(e => e.Description)));
                }
            }
        }
    }
}
