namespace Automation_System.Entities
{
    public class Invoice
    {
        public string ref_Number { get; set; }
        public string amount { get; set; }
        public string customer_Name { get; set; }
        public string customer_Mobile { get; set; }
        public string customer_Email { get; set; }
        public string lang { get; set; }
        public string currency_Code { get; set; }
    }
}
