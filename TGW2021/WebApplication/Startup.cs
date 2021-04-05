using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication.Data;
using WebApplication.Data.DataModels;
using WebApplication.Services;
using WebApplication.Services.MessagingService;
using WebApplication.Services.UserSession;

namespace WebApplication
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
            // DB
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            // Identity (not using it, but could be very easily added with [Authorize] on backoffice
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            // Transient services per domain, to enforce single action per request (better for EF stability)
            services.AddTransient<ICustomerDataDomain>(s => s.GetRequiredService<ApplicationDbContext>());
            services.AddTransient<IOrderDataDomain>(s => s.GetRequiredService<ApplicationDbContext>());
            services.AddTransient<IProductDataDomain>(s => s.GetRequiredService<ApplicationDbContext>());

            // CQRS processors
            services.AddCQRSProcessors();


            // Messaging system
            services.AddTransient<MessagingService>();
            services.AddSingleton<MessageQueue>();
            services.AddHostedService<QueueProcessorHostedService>();
            services.AddSingleton<MessageProcessorFactory>();
            services.AddMessageProcessors();


            // User services
            services.AddScoped<ScopedUserSessionProvider>();


            // Packages
            services.AddAutoMapper(typeof(ServicesAutomapperProfile));


            // MVC stuff
            services.AddHttpContextAccessor();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext dataContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
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
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                  );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            // migrate any database changes on startup (includes initial db creation)
            dataContext.Database.Migrate();
        }
    }
}
