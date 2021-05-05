using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Virtualmind.Financial.Common.Enums;
using Virtualmind.Financial.Domain;
using Virtualmind.Financial.Service.IServices;

namespace Virtualmind.Financial.Service
{
    public class ExchangeRateUSD : IRate
    {
        public ExchangeRateUSD()
        {
        }

        private readonly string baseUrl = "http://www.bancoprovincia.com.ar/Principal/Dolar";

        public async Task<Rate> CalculareExchangeRate()
        {
            using (var client = new HttpClient())
            {
                var httpResponse = await client.GetAsync(baseUrl);

                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception("Cannot retrieve rate");
                }

                var content = await httpResponse.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<string>>(content);
                if (values.Count > 0)
                {
                    return new Rate(values[0], values[1], values[2]);
                }

                return new Rate();
            }
        }
    }
}
