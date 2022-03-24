using AutoMapper;
using Chirag.BookReading.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Chirag.BookReading.Application.Interfaces;
using Chirag.BookReading.Application.Services;
using Chirag.BookReading.Core.IRepositories;
using Chirag.BookReading.Core.IRepositories.Base;
using Chirag.BookReading.Infrastructure.Repository;
using Chirag.BookReading.Infrastructure.Repository.Base;
using Chirag.BookReadingEvent.Web.Interfaces;
using Chirag.BookReadingEvent.Web.Services;
using Chirag.BookReadingEvent.Application.Interfaces;
using Chirag.BookReadingEvent.Core.Configuration;

namespace Chirag.BookReadingEvent.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called at runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureBookReadingEventServices(services);
            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
          
            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.UseRouting();  // this middleware is used to route
            app.UseAuthentication();    // this is used to use the identity i.e login,signup
            app.UseAuthorization();
            // this middleware is also used to route
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }

        //endpoints.MapControllerRoute(
        //    name: "default",
        //    pattern: "{controller=Home}/{action=Index}/{id?}");
        public void ConfigureBookReadingEventServices(IServiceCollection services)
        {

            //Core Layer DI
            services.Configure<ConfigurationSettings>(Configuration);

            //Infrastructure Layer DI
            ConfigureDatabases(services);
            // this is used for work with data for login,signup
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<EventContext>()  // name of dbcontext 
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
            });

            services.AddScoped<IUnitofwork, UnitOfWork>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();


            //Application Layer DI
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICommentService, CommentService>();

            //Web Layer DI
            services.AddAutoMapper(typeof(Startup)); // Add AutoMapper
            services.AddScoped<IIndexPageService, IndexPageService>();
            services.AddScoped<IEventPageService, EventPageService>();
            services.AddScoped<IAccountPageService, AccountPageService>();
            services.AddScoped<ICommentPageService, CommentPageService>();

           // this is used when it is in development environment
#if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation();

#endif
        }

        public void ConfigureDatabases(IServiceCollection services)
        {
            // in this we  use database from appsetting json file with help of key define in json file
            services.AddDbContext<EventContext>(c =>
                c.UseSqlServer(Configuration.GetConnectionString("EventDatabase")));
        }
    }
}
