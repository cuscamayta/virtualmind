using System;
using System.Threading.Tasks;
using Virtualmind.Financial.Common.Enums;
using Virtualmind.Financial.Domain;
using Virtualmind.Financial.Service.IServices;

namespace Virtualmind.Financial.Service
{
    public class ExchangeRateBRL:IRate
    {
        private IRate usdRate;
        public ExchangeRateBRL(IRate usdRate)
        {
            this.usdRate = usdRate;
        }

        public async Task<Rate> CalculareExchangeRate()
        {
            var usdRate = await this.usdRate.CalculareExchangeRate();

            var brazilianrate = float.Parse(usdRate.Purchase) / 4;

            return new Rate(brazilianrate.ToString(), brazilianrate.ToString(), $"Actualizada al {DateTime.Today.ToShortDateString()}");
        }
    }
}
