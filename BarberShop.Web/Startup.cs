using System;
using BarberShop.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BarberShop.Bll.Interfaces;
using BarberShop.Bll.Services;
using BarberShop.Data.Entities;
using Microsoft.AspNetCore.Identity;
using BarberShop.Web.Settings;
//using Microsoft.AspNetCore.Identity.UI.Services;
using BarberShop.Web.Services;
// using BarberShop.Data.Seed.Interfaces;
// using BarberShop.Data.Seed.Services;
using Microsoft.AspNetCore.Http.Features;
using BarberShop.Web.Interfaces;
using BarberShop.Data.Seed.Settings;

namespace BarberShop.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BarberShopDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddIdentity<AppUser, IdentityRole<int>>()
            //    .AddEntityFrameworkStores<DrPetDbContext>()
            //    .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options => {
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = false;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                options.Lockout.MaxFailedAccessAttempts = 5;

                options.User.RequireUniqueEmail = true;

                options.SignIn.RequireConfirmedAccount = true;
            });

            services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 256 * 1024 * 1024;
            });

            services.Configure<IISServerOptions>(options =>
            {
                options.MaxRequestBodySize = 50 * 1024 * 1024;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            //services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            //services.AddTransient<IEmailSender, EmailSender>();

            //services.AddScoped<IRoleSeedService, RoleSeedService>();

            services.Configure<AdminSettings>(Configuration.GetSection("AdminSettings"));
            //services.AddScoped<IUserSeedService, UserSeedService>();

            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IBarberService, BarberService>();
            services.AddScoped<IServiceTypeService, ServiceTypeService>();
            services.AddScoped<IFileOperationService, FileOperationService>();

            //services.AddAuthentication().AddGoogle(options => {
            //    options.ClientId = Configuration["Authentication:Google:ClientId"];
            //    options.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
            //});

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdministratorRole", policy => policy.RequireRole("Administrators"));
            });

            services.AddRazorPages(options => {
                options.Conventions.AuthorizeFolder("/Admin", "RequireAdministratorRole");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
