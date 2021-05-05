using System;
using System.Threading.Tasks;
using Virtualmind.Financial.Common.Enums;
using Virtualmind.Financial.Domain;

namespace Virtualmind.Financial.Service.IServices
{
    public interface IRate
    {
        Task<Rate> CalculareExchangeRate();
    }
}
