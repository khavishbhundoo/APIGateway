using APIGateway.Utils;
using System.ComponentModel.DataAnnotations;

namespace APIGateway.Contracts
{
    public class PaymentRequest
    {
        [Required]
        [CreditCard]
        public string cardNo { get; set; }

        [Required]
        [RegularExpression(@"(0[1-9]|10|11|12)/[0-9]{2}$", ErrorMessage = "The expiry date should be in mm/yy format")]
        public string expiry { get; set; }

        [Required]
        [Range(1,int.MaxValue)]
        public int amount { get; set; }

        [Required]
        [CurrencySymbol (ErrorMessage = "A three-letter ISO currency code representing the currency of the payment must be used (ISO 4217)")]
        public string currency { get; set; }

        [Required]
        [RegularExpression(@"([0-9]{3}|[0-9]{4})$", ErrorMessage = "CVV code should be 3 digits long (4 digits if you are using American Express)")]
        public int cvv { get; set; }
    }
}
