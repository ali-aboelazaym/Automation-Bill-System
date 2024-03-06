using Automation_System.Entities;
using Automation_System.Entities.WhatsappEntity;

namespace Automation_System.Interfaces
{
    public interface ISadadServices
    {
        public Task<string> GenerateAccessToken();
        public Task<InvoiceInsertResponse> InsertInvoice(InvoiceInsertRequest request);
        public Task<InvoiceResponseData> GetInvoiceByIdAsync(string invoiceId);
        public Task<MessageResponse> SendWhatsappMessage(WhatsappRequest data);
    }
}
