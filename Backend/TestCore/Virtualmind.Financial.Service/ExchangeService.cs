using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Virtualmind.Financial.Common.Enums;
using Virtualmind.Financial.Domain;
using Virtualmind.Financial.DTO;
using Virtualmind.Financial.Repository.IRepositories;
using Virtualmind.Financial.Service.IServices;

namespace Virtualmind.Financial.Service
{
    public class ExchangeService : IExchangeService
    {        
        private readonly IPurchaseRepository _purchaseRepository;
        public ExchangeService(IPurchaseRepository purchaseRepository)
        {
            this._purchaseRepository = purchaseRepository;
        }

        //public async Task<Rate> GetRate(CurrencyCode currencyCode)
        //{
        //    switch (currencyCode)
        //    {
        //        case CurrencyCode.USD:
        //            return await GetUSDRate();
        //        case CurrencyCode.Real:
        //            return await GetBrazilianRate();
        //        default:
        //            throw new Exception("Cannot exchange the currency");
        //    }

        //}

        public async Task<float> Purchase(PurchaseDTO purchaseModel, IRate rateService)
        {
            var usdRate = await rateService.CalculareExchangeRate();
            var userPurchaseTx = CreateExchangePurchase(purchaseModel, float.Parse(usdRate.Purchase));
            var result = await _purchaseRepository.Add(userPurchaseTx);

            return result.ExchangeValue;
        }

        private UserPurchase CreateExchangePurchase(PurchaseDTO purchaseModel, float USDExchange)
        {
            return new UserPurchase()
            {
                Id = Guid.NewGuid(),
                UserId = purchaseModel.UserId,
                CurrencyCode = purchaseModel.CurrencyCode,
                Amount = purchaseModel.Amount,
                ExchangeValue = purchaseModel.Amount / USDExchange
            };
        }

        //public async Task<Rate> GetUSDRate()
        //{
        //    using (var client = new HttpClient())
        //    {
        //        var httpResponse = await client.GetAsync("http://www.bancoprovincia.com.ar/Principal/Dolar");

        //        if (!httpResponse.IsSuccessStatusCode)
        //        {
        //            throw new Exception("Cannot retrieve rate");
        //        }

        //        var content = await httpResponse.Content.ReadAsStringAsync();
        //        var values = JsonConvert.DeserializeObject<List<string>>(content);
        //        if (values.Count > 0)
        //        {
        //            return new Rate(values[0], values[1], values[2]);
        //        }

        //        return new Rate();
        //    }
        //}

        //private async Task<Rate> GetBrazilianRate()
        //{
        //    var usdRate = await GetUSDRate();

        //    var brazilianrate = float.Parse(usdRate.Purchase) / 4;

        //    return new Rate(brazilianrate.ToString(), brazilianrate.ToString(), $"Actualizada al {DateTime.Today.ToShortDateString()}");
        //}

        public async Task<Rate> GetRate(IRate rateService)
        {
            return await rateService.CalculareExchangeRate();
        }
    }
}
