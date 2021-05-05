using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Virtualmind.Financial.Repository;
using Virtualmind.Financial.Repository.DataContext;
using Virtualmind.Financial.Repository.IRepositories;
using Virtualmind.Financial.Service;
using Virtualmind.Financial.Service.IServices;
using Microsoft.EntityFrameworkCore;


namespace Virtualmind.Financial.IoC
{
    public class DependencyInjection
    {
        private readonly IConfiguration Configuration;
        public DependencyInjection(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void InjectDependencies(IServiceCollection services)
        {
            services.AddDbContext<FinancialContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("sqlConnectionString"));
            });
            
            services.AddTransient<IPurchaseRepository, PurchaseRepository>();
            services.AddTransient<IExchangeService, ExchangeService>();   
        }
    }
}
