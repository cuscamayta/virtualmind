using System;
using Virtualmind.Financial.Repository.DataContext;
using Virtualmind.Financial.Repository.IRepositories;
using Virtualmind.Financial.Domain;

namespace Virtualmind.Financial.Repository
{
    public class PurchaseRepository: RepositoryBase<UserPurchase>, IPurchaseRepository
    {
        private readonly FinancialContext financialContext;
        public PurchaseRepository(FinancialContext context): base(context)
        {
            financialContext = context;
        }
    }
}
