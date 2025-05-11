using ApplicationCheikh.Api.Builder;
using ApplicationCheikh.Api.Builder.impl;
using ApplicationCheikh.Api.Builders;
using ApplicationCheikh.Api.Builders.impl;
using ApplicationCheikh.Dal.Respositories;
using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Repositories;
using ApplicationCheikh.Domain.Services;
using ApplicationCheikh.Domain.Services.imp;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MiaDatabaseContext>();
builder.Services.AddMvc();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//scoped repositories
builder.Services.AddScoped<IRegistrationQueueRepository, RegistrationQueueRepository>();
builder.Services.AddScoped<ISeminaireQueueRepository, SeminaireQueueRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<ISeminaireRepository, SeminaireRepository>();

//scoped services
builder.Services.AddScoped<IRegistrationQueueService, RegistrationQueueService>();
builder.Services.AddScoped<ISeminaireQueueService, SeminaireQueueService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<ISeminaireService, SeminaireService>();

//scoped builders
builder.Services.AddScoped<IRegistrationQueueViewModelBuilder, RegistrationQueueViewModelBuilder>();
builder.Services.AddScoped<ISeminaireQueueViewModelBuilder, SeminaireQueueViewModelBuilder>();
builder.Services.AddScoped<IPaymentViewModelBuilder, PaymentViewModelBuilder>();
builder.Services.AddScoped<ISeminaireViewModelBuilder, SeminaireViewModelBuilder>();
builder.Services.AddScoped<IMailViewModelBuilder, MailViewModelBuilder>();


builder.Services.AddHttpClient();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://192.168.1.94:3000", "http://localhost:3000")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseCors("AllowFrontend");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
//app.UseMvc();

app.Run();
