namespace Eventures.Web
{
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Eventures.Data;
    using Eventures.Models;
    using Services.Interfaces;
    using Eventures.Services;
    using AutoMapper;
    using Eventures.Web.Mapper;
    using Middlewares.Extensions;
    using Microsoft.Extensions.Logging;
    using Eventures.Web.Filters;

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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Services for Database
            services.AddDbContext<EventuresDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        
            // Configuring auto mapper
            var mapperConfig = new MapperConfiguration(m => m.AddProfile(new MapperProfile()));
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.Configure<IdentityOptions>(optinons =>
            {
                optinons.SignIn.RequireConfirmedEmail = false;
                optinons.Password.RequiredLength = 3;
                optinons.Password.RequireLowercase = false;
                optinons.Password.RequireNonAlphanumeric = false;
                optinons.Password.RequireLowercase = false;
                optinons.Password.RequireUppercase = false;
                optinons.Password.RequiredUniqueChars = 0;
            });

            services.AddIdentity<User, IdentityRole>()
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<EventuresDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<IEventsService, EventService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddScoped<LogUserActivityActionFilter>();
         
            services.AddLogging();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggingFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            loggingFactory.AddConsole(Configuration.GetSection("Logging"));
            loggingFactory.AddDebug();
            loggingFactory.AddFile($"Logs/{Configuration.GetSection("ApplicationName")}-{DateTime.UtcNow.ToString("dd/MM/yyyy")}.txt");

            // Middleware for seeding roles
            app.UseSeedRoles();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}