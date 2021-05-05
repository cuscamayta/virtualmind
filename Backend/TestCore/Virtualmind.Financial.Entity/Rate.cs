using System;
namespace Virtualmind.Financial.Domain
{
    public class Rate
    {

        public Rate() { }

        public Rate(string purchaseValue,string sellvalue,string lastModifiedDateValue)
        {
            this.Purchase = purchaseValue;
            this.Sell = sellvalue;
            this.LastModified = lastModifiedDateValue;
        }

        public string Purchase { get; set; }
        public string Sell { get; set; }
        public string LastModified { get; set; }
    }
}
        