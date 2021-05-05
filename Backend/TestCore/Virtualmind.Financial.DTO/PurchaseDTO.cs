using System;
namespace Virtualmind.Financial.DTO
{
    public class PurchaseDTO
    {
        public int UserId { get; set; }
        public string CurrencyCode { get; set; }
        public float Amount { get; set; }
    }
}
