namespace Automation_System.Entities.WhatsappEntity
{
    public class MessageResponse
    {
        public string Id { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime SendTime { get; set; }
        public DateTime ReceiveTime { get; set; }
        public DateTime ReadingTime { get; set; }
    }
}
