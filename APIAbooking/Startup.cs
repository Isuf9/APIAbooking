using APIAbooking.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation.AspNetCore;
using APIAbooking.Services;
using APIAbooking.Logic.Client;
using Microsoft.AspNetCore.Mvc.Razor;
using ReflectionIT.Mvc.Paging;
using APIAbooking.Services.OwnerService;
using APIAbooking.Logic.OwnerLogic;
using APIAbooking.Services.RoomService;
using APIAbooking.Logic.RoomLogic;

namespace APIAbooking
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
            services.AddMvc().AddFluentValidation(mvcConfiguration => mvcConfiguration.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddTransient<IService, ClientServices>();
            services.AddTransient<IClientService, ClientServices>();
            services.AddTransient<IOwnerService, OwnerService>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddHttpContextAccessor();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddDbContext<APIAbookingContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddPaging();
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddMvc();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Clients}/{action=Login}/{id?}");
            });
        }

    }
}
