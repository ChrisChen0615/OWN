using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCore.AutoRegisterDi;
using OWN.Repository;
using OWN.Repository.Tables;
using OWN.Service;
using System;
using System.Reflection;

namespace OWN.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public IConfiguration _Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<OWNDbContext>(options =>
                options.UseSqlServer(
                    _Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<OWNUser, OWNRole>(options =>
            {
                //options.SignIn.RequireConfirmedAccount = true;
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            })
                .AddEntityFrameworkStores<OWNDbContext>()
                .AddDefaultTokenProviders();

            services.AddControllersWithViews();

            //DI
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.RegisterAssemblyPublicNonGenericClasses(Assembly.GetAssembly(typeof(IBaseService)))
                .Where(x => x.Name.EndsWith("Service"))  //optional
                .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);

            //註冊 CookieAuthentication，Scheme必填
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(options =>
            //    {
            //        //從組態讀取設定
            //        options.Cookie.Name = _Configuration.GetValue<string>("WebSite:Cookie:Name") + "Auth";
            //        options.LoginPath = _Configuration.GetValue<string>("WebSite:Cookie:LoginPath");
            //        //用戶頁面停留太久，登入逾期，或Controller中用戶登入時機點也可以設定↓,//沒給預設14天
            //        options.ExpireTimeSpan = TimeSpan.FromMinutes(_Configuration.GetValue<double>("WebSite:Cookie:ExpireTimeMinute"));
            //        options.SlidingExpiration = true;
            //        //options.Cookie.Expiration = TimeSpan.FromMinutes(_Configuration.GetValue("WebSite:Cookie:ExpireTimeMinute", 180));
            //    });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.Name = _Configuration.GetValue<string>("WebSite:Cookie:Name");
                // Setting the HttpOnly value to true, makes
                // this cookie accessible only to ASP.NET.
                options.Cookie.HttpOnly = true;

                options.LoginPath = _Configuration.GetValue<string>("WebSite:Cookie:LoginPath");
                options.ExpireTimeSpan = TimeSpan.FromMinutes(_Configuration.GetValue<double>("WebSite:Cookie:ExpireTimeMinute"));
                options.SlidingExpiration = _Configuration.GetValue<bool>("WebSite:Cookie:SlidingExpiration");
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //留意先執行驗證...
            app.UseAuthentication();
            app.UseAuthorization();//Controller、Action才能加上 [Authorize] 屬性

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
