using Microsoft.EntityFrameworkCore;
using Virtualmind.Financial.Domain;
using System;

namespace Virtualmind.Financial.Repository.DataContext
{
    public class FinancialContext:DbContext
    {

        public FinancialContext(DbContextOptions<FinancialContext> options) : base(options) { }

        public DbSet<UserPurchase> UserPurchase { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPurchase>().HasData(
                 new UserPurchase
                 {
                     Id = Guid.NewGuid(),
                     UserId = 1,
                     Amount= 20,
                     CurrencyCode="USD"
                 }
             );
        }
    }
}
