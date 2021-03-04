using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using OWN.Repository;
using OWN.Repository.Tables;
using OWN.Web;

namespace OWN.NUnitTest.Infrastructure
{
    //ref:https://blog.darkthread.net/blog/aspnetcore-efcore-unitest/
    public static class WebHostTest
    {
        public static IWebHost _webHost = null;

        public static OWNDbContext ctx;
        public static T GetService<T>()
        {
            var scope = _webHost.Services.CreateScope();
            return scope.ServiceProvider.GetRequiredService<T>();
        }

        public static Mock<IRepositoryBase<Address>> _addressRepo;

        public static void Setup()
        {
            _webHost = WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .Build();
        }

        public static void SetupRepository()
        {
            ctx = GetService<OWNDbContext>();

            _addressRepo = new Mock<IRepositoryBase<Address>>();
        }
    }
}
