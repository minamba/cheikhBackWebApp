using ApplicationCheikh.Api.Builder.impl;
using ApplicationCheikh.Api.Builder;
using ApplicationCheikh.Api.Builders.impl;
using ApplicationCheikh.Api.Builders;
using ApplicationCheikh.Dal.Respositories;
using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Repositories;
using ApplicationCheikh.Domain.Services.imp;
using ApplicationCheikh.Domain.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);



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
builder.Services.AddScoped<ICloseRegistrationRepository, CloseRegistrationRepository>();
builder.Services.AddScoped<IPaymentPageRepository, PaymentPageRepository>();
builder.Services.AddScoped<IMediaRepository, MediaRepository>();


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
builder.Services.AddScoped<ICloseRegistrationService, CloseRegistrationService>();
builder.Services.AddScoped<IPaymentPageService, PaymentPageService>();
builder.Services.AddScoped<IMediaService, MediaService>();


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
builder.Services.AddScoped<ICloseRegistrationViewModelBuilder, CloseRegistrationViewModelBuilder>();
builder.Services.AddScoped<IPaymentPageViewModelBuilder, PaymentPageViewModelBuilder>();
builder.Services.AddScoped<IMediaViewModelBuilder, MediaViewModelBuilder>();





// Services
builder.Services.AddControllers();
builder.Services.AddHttpClient();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins("https://www.hatimalmaliki.com")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 1024 * 1024 * 900;
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ... tes services scoped (repositories, services, builders) ici ...

var app = builder.Build();

// Middleware
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseRouting();

app.UseAuthorization();

app.UseDefaultFiles();   // sert index.html par défaut
app.UseStaticFiles();    // permet d'accéder aux fichiers dans wwwroot

app.MapControllers();

// Si aucune route API ne correspond, sert index.html (SPA fallback)
app.MapFallbackToFile("index.html");

app.Run();
