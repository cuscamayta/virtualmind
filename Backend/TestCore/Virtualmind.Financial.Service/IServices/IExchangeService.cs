using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Virtualmind.Financial.Common.Enums;
using Virtualmind.Financial.Domain;
using Virtualmind.Financial.DTO;

namespace Virtualmind.Financial.Service.IServices
{
    public interface IExchangeService
    {
        Task<Rate> GetRate(IRate rateService);
        Task<float> Purchase(PurchaseDTO purchaseModel, IRate rateService);        
    }
}
