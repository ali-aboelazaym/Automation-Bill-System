namespace Automation_System.Entities.WhatsappEntity
{
    public class WhatsappRequest
    {
        public string to { get; set; }
        public string from { get; set; }
        public string channel { get; set; }
        public Content content { get; set; }


        //public string messaging_product { get; set; } = "whatsapp";
        //public string reciptient_type { get; set; }= "individual";
        //public string to { get; set; }
        //public string type { get; set; } = "template";
        //public Template template { get; set; }
    }
}
