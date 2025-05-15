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
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Options;

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
builder.Services.AddScoped<IRegistrationRepository, RegistrationRepository>();
builder.Services.AddScoped<IHomeRepository, HomeRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<IMediaRepository, MediaRepository>();
builder.Services.AddScoped<ISessionRepository, SessionRepository>();
builder.Services.AddScoped<ITargetRepository, TargetRepository>();
builder.Services.AddScoped<IThemeRepository, ThemeRepository>();
builder.Services.AddScoped<IWitnessRepository, WitnessRepository>();

//scoped services
builder.Services.AddScoped<IRegistrationQueueService, RegistrationQueueService>();
builder.Services.AddScoped<ISeminaireQueueService, SeminaireQueueService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<ISeminaireService, SeminaireService>();
builder.Services.AddScoped<IRegistrationService, RegistrationService>();
builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IMediaService, MediaService>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddScoped<ITargetService, TargetService>();
builder.Services.AddScoped<IThemeService, ThemeService>();
builder.Services.AddScoped<IWitnessService, WitnessService>();

//scoped builders
builder.Services.AddScoped<IRegistrationQueueViewModelBuilder, RegistrationQueueViewModelBuilder>();
builder.Services.AddScoped<ISeminaireQueueViewModelBuilder, SeminaireQueueViewModelBuilder>();
builder.Services.AddScoped<IPaymentViewModelBuilder, PaymentViewModelBuilder>();
builder.Services.AddScoped<ISeminaireViewModelBuilder, SeminaireViewModelBuilder>();
builder.Services.AddScoped<IMailViewModelBuilder, MailViewModelBuilder>();
builder.Services.AddScoped<IRegistrationViewModelBuilder, RegistrationViewModelBuilder>();
builder.Services.AddScoped<IHomeViewModelBuilder, HomeViewModelBuilder>();
builder.Services.AddScoped<IImageViewModelBuilder, ImageViewModelBuilder>();
builder.Services.AddScoped<IMediaViewModelBuilder, MediaViewModelBuilder>();
builder.Services.AddScoped<ISessionViewModelBuilder, SessionViewModelBuilder>();
builder.Services.AddScoped<ITargetViewModelBuilder, TargetViewModelBuilder>();
builder.Services.AddScoped<IThemeViewModelBuilder, ThemeViewModelBuilder>();
builder.Services.AddScoped<IWitnessViewModelBuilder, WitnessViewModelBuilder>();





builder.Services.AddHttpClient();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://192.168.1.94:3000", "http://localhost:3000", "http://localhost:7161", "http://localhost:5161")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title = "Mon API", Version = "v1" });

    // Affiche les noms d'enum en Swagger
    options.UseInlineDefinitionsForEnums();
});



builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 1024 * 1024 * 900; // 900 Mo
});



var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mon API V1");
    });
}




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseStaticFiles();
app.UseCors("AllowFrontend");
app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

//app.UseMvc();

app.Run();
