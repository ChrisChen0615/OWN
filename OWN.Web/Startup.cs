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
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

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
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddControllersWithViews();

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.RegisterAssemblyPublicNonGenericClasses(Assembly.GetAssembly(typeof(IBaseService)))
                .Where(x => x.Name.EndsWith("Service"))  //optional
                .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);

            //�q�պAŪ���n�J�O�ɳ]�w
            double LoginExpireMinute = this.Configuration.GetValue<double>("LoginExpireMinute");
            //���U CookieAuthentication�AScheme����
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
            {
                //�γ\�n�q�պA��Ū���A�ۤv�r�u�M�w
                option.LoginPath = new PathString("/Home/Login");//�n�J��
                option.LogoutPath = new PathString("/Home/Logout");//�n�XAction
                //�Τ᭶�����d�Ӥ[�A�n�J�O���A��Controller���Τ�n�J�ɾ��I�]�i�H�]�w��
                option.ExpireTimeSpan = TimeSpan.FromMinutes(LoginExpireMinute);//�S���w�]14��
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

            //�d�N����������...
            app.UseAuthentication();
            app.UseAuthorization();//Controller�BAction�~��[�W [Authorize] �ݩ�

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
