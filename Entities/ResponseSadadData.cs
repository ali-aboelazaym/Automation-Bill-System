namespace Automation_System.Entities
{
    public class ResponseSadadData
    {
        public int id { get; set; }
        //public int vendor_Id { get; set; }
        //public string code { get; set; }
        //public string type { get; set; }
        //public string status { get; set; }
        public int amount { get; set; }
        //public int alt_Amount { get; set; }
        public int total { get; set; }
        //public int subtotal { get; set; }
        //public int refunded_Amount { get; set; }
        //public string sendType { get; set; }
        public string lang { get; set; }
        public string customer_Name { get; set; }
        public string customer_Mobile { get; set; }
        //public string customer_Email { get; set; }
        public string ref_Number { get; set; }
        public string currency_Code { get; set; }
        //public string discount_Type { get; set; }
        //public int discount_Amount { get; set; }
        //public int discount_Amount_Total { get; set; }
        //public string expiry_Date { get; set; }
        //public string attachment { get; set; }
        //public int remind_After { get; set; }
        //public string comment { get; set; }
        //public bool terms_Condition_Enabled { get; set; }
        //public string terms_Condition { get; set; }
        //public string key { get; set; }       
        public string url { get; set; }
        

        //{"transactionID":null,"paymentGateway":null,"paymentGatewayCode":null,"deleted":false,"url":"https://sandbox.sadadpay.net/pay/127525342358","qr":"https://sandbox.sadadpay.net/qr/127525342358/download","orderStatus":"","success_ReturnURL":null,"fail_ReturnURL":null,"orderSession_Id":0}
    }
}
