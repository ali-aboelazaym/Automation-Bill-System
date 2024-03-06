namespace Automation_System.Entities
{
    public class InvoiceInsertResponse
    {
        
        public bool isValid { get; set; }
        public string errorKey { get; set; }
        public SadadResponse response { get; set; }
    }
}
