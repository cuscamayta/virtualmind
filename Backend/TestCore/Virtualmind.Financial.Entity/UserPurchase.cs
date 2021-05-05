using System;
namespace Virtualmind.Financial.Domain
{
    public class UserPurchase : BaseEntity
    {
        public int  UserId { get; set; }
        public string CurrencyCode { get; set; }
        public float Amount { get; set; }
        public float ExchangeValue { get; set; }
    }
}
