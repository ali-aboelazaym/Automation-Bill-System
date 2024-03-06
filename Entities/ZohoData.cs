using System.ComponentModel.DataAnnotations.Schema;

namespace Automation_System.Entities
{
    public class ZohoData
    {
        //public CustomerDefaultBillingAddress[] arr1 { get; set; }
        public int Id { get; set; }
        [Column("invoice_number")]
        public string InvoiceNumber { get; set; }
        [Column("customer_default_billing_address")]
        public CustomerDefaultBillingAddress CustomerDefaultBillingAddress { get; set; }
        [Column("currency_code")]
        public string CurrencyCode { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("customer_name")]
        public string CustomerName { get; set; }
        [Column("customer_id")]
        public int CustomerId { get; set; }
        [Column("invoice_id")]
        public int InvoiceId { get; set; }
        [Column("total")]
        public decimal Total { get; set; }
        [Column("created_date")]
        public DateTime CreatedDate { get; set; }
        [Column("invoice_url")]
        public string InvoiceUrl { get; set; }

        public string amount { get; set; }
        
        public string lang { get; set; }
    }
}
