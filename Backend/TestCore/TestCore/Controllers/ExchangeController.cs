using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Virtualmind.Financial.Common.Enums;
using Virtualmind.Financial.Domain;
using Virtualmind.Financial.DTO;
using Virtualmind.Financial.Service;
using Virtualmind.Financial.Service.IServices;

namespace Virtualmind.Financial.Api.Controllers
{
    [EnableCors("CorsApi")]
    [Route("api/[controller]")]
    public class ExchangeController : Controller
    {
        private readonly IExchangeService _exchangeService;
        private readonly IRate usdService;
        private readonly IRate brlService;
        private List<string> allowedCurrencies = new List<string>() { "USD", "BRL" };


        //TODO needs to inject a service locator in order to get the service for USD, BRL exchange rate
        public ExchangeController(IExchangeService exchangeService)
        {
            this._exchangeService = exchangeService;
            this.usdService = new ExchangeRateUSD();
            this.brlService = new ExchangeRateBRL(this.usdService);
        }

        [HttpGet("rate/{currency}")]
        public async Task<IActionResult> GetRate(string currency)
        {
            if (allowedCurrencies.Contains(currency.ToUpper()))
            {
                switch (EnumUtility.ParseEnum<CurrencyCode>(currency))
                {

                    case CurrencyCode.USD:
                        return Ok(ResponseDTO<Rate>.Success200(await _exchangeService.GetRate(usdService)));
                    case CurrencyCode.BRL:
                        return Ok(ResponseDTO<Rate>.Success200(await _exchangeService.GetRate(brlService)));
                    default:
                        return Ok(ResponseDTO<Rate>.Success200(await _exchangeService.GetRate(usdService)));
                }

            }
            else
            {
                throw new System.Exception($"Currency {currency} not supported");                
            }
        }


        [HttpPost("purchase")]
        public async Task<IActionResult> Post([FromBody] PurchaseDTO model)
        {
            //TODO add another validations
            if (allowedCurrencies.Contains(model.CurrencyCode.ToUpper()))
            {
                var rateUsd = await _exchangeService.Purchase(model,new ExchangeRateUSD());

                return Ok(rateUsd);
            }
            else
            {
                throw new System.Exception($"Currency {model.CurrencyCode} not supported");
            }
        }

    }
}
