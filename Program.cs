using Automation_System.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestSharp;
using Automation_System.Interfaces;
using Automation_System.Services;
using Microsoft.Extensions.Caching.Memory;
using Automation_System.Entities.WhatsappEntity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();
builder.Services.AddScoped<ISadadServices, SADADPaymentService>();
builder.Services.AddMemoryCache();
builder.Services.Configure<WhatsappSettings>(builder.Configuration.GetSection(nameof(WhatsappSettings)));

//Configurer DB

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// configure sadad payment getway

var options = new RestClientOptions("https://apisandbox.sadadpay.net/api/Invoice/createpaymentlinkinvoice");
var client = new RestClient(options);
var request = new RestRequest("");
request.AddHeader("content-type", "application/*+json");
var response = await client.PostAsync(request);

// end of configure sadad payment getway

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
