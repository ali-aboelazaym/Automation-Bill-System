using Automation_System.Dtos;
using Automation_System.Entities;
using Automation_System.Entities.WhatsappEntity;
using Automation_System.Interfaces;
using Automation_System.Services;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using System;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text.Json;
using Automation_System.Entities.WhatsappEntity;
using System.Configuration;
using Automation_System.Migrations;
using static System.Net.Mime.MediaTypeNames;

namespace Automation_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly ISadadServices _paymentService;
        private readonly IConfiguration _configuration;
        //private readonly WhatsappSettings _settings;
        

        public InvoiceController(ApplicationDbContext context, ISadadServices paymentService, IConfiguration configuration)
        {
            _context = context;
            _paymentService = paymentService;

            _configuration = configuration;
            //IOptions<WhatsappSettings> settings

            //_settings = settings.Value;
            
            //, InvoiceResponseData data
        }

        [HttpPost("InvoiceData")]
        public async Task<ActionResult> PostInvoiceData([FromBody] ZohoData zohodata)
        {
            _context.ZohoDatas.Add(zohodata);
            _context.SaveChanges();

            var SadadRequest = new InvoiceInsertRequest();
            var InvoiceData = new Invoice();
            InvoiceData.ref_Number = zohodata.InvoiceNumber;
            InvoiceData.amount = zohodata.amount;
            InvoiceData.customer_Name = zohodata.CustomerName;
            InvoiceData.customer_Mobile = zohodata.CustomerDefaultBillingAddress.Phone;
            InvoiceData.customer_Email = zohodata.Email;
            InvoiceData.lang = zohodata.lang;
            InvoiceData.currency_Code = zohodata.CurrencyCode;

            SadadRequest.Invoices = new List<Invoice>();
            SadadRequest.Invoices.Add(InvoiceData);

            var invoiceInsertResponse = await _paymentService.InsertInvoice(SadadRequest);
            var InvoiceId = invoiceInsertResponse.response.invoiceId;

            //return Ok(new { InvoiceId = InvoiceId });

            var invoice = await _paymentService.GetInvoiceByIdAsync(InvoiceId);

            //var datasource = new ResponseSadadData();
            //var datasource = new Invoice();
            
            List<Header> header = new List<Header>
            {
                new Header { type = "text", text =invoice.response.ref_Number }
            };
            List<Body> body = new List<Body>
            {
                new Body { type = "text", text =invoice.response.customer_Name }
            };
            List<Button> button = new List<Button>
            {
                new Button { type = "url" , index = 0 , text = invoice.response.url },
                new Button { type = "url" , index = 1 , text = invoice.response.url }
            };

             
            

            
            var MessgeData = new WhatsappRequest();
            MessgeData.to = invoice.response.customer_Mobile;
            MessgeData.from = "156483521";
            MessgeData.channel = "whatsapp";
            //MessgeData.content.contentType = "template";
            MessgeData.content = new Content();
            MessgeData.content.contentType = "template";

            MessgeData.content.template = new Template();
            MessgeData.content.template.templateId = "invoice_e1_sedadpay_v1";
            MessgeData.content.template.templateLanguage = invoice.response.lang;
            MessgeData.content.template.components= new Component();
            MessgeData.content.template.components.header = header;
            MessgeData.content.template.components.body = body;
            MessgeData.content.template.components.button = button;


            var MessageResponse = await _paymentService.SendWhatsappMessage(MessgeData);

            return Ok(MessageResponse );


        }


        //[HttpPost("Send-Message")]
        //public async Task<IActionResult> PostWhatsappMessages()
        //{
        //    var ApiToken = _configuration["WhatsappSettings:Token"];
        //    var ApiUrl = _configuration["WhatsappSettings:ApiUrl"];
        //    //var language = Request.Headers["language"].ToString();
        //    using HttpClient httpClient = new HttpClient();
        //    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiToken);

        //    var datasource = new ResponseSadadData();

        //    List<Header> header = new List<Header>
        //    {              
        //        new Header { type = "text", text =datasource.currency_Code }
        //    };
        //    List<Body> body = new List<Body>
        //    {                
        //        new Body { type = "text", text =datasource.currency_Code }
        //    };
        //    List<Button> button = new List<Button>
        //    {                
        //        new Button { type = datasource.url , index = 0 , text = datasource.currency_Code },
        //        new Button { type = datasource.url , index = 1 , text = datasource.currency_Code }
        //    };

        //    WhatsappRequest body1 = new()
        //    {
        //        to = datasource.customer_Mobile,              
        //        from = "254684654",
        //        channel = "whatsapp",
        //        content = new Content
        //        {
        //            contentType = "tempalat",
        //            template = new Template
        //            {
        //                templateId = "invoice_e1_sedadpay_v1",
        //                templateLanguage = datasource.lang ,
        //                components = new Component
        //                {
        //                    header = header,
        //                    body = body,
        //                    button = button
        //                }
        //            }
        //        }
        //    };

        //    HttpResponseMessage response = await httpClient.PostAsJsonAsync(new Uri(ApiUrl), body1);
        //    if (!response.IsSuccessStatusCode)
        //    {
        //        return Ok(response);                
        //    }
        //    else
        //    {
        //        throw new Exception("Some Thing went wrong");
        //    }
        //}
    }
}
