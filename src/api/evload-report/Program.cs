using AutoMapper;
using Coravel;
using evload_report.Core;
using evload_report.Detector;
using evload_report.Models;
using loadsession_detector;
using Microsoft.EntityFrameworkCore;
using persistence;
using shelly_connector;
using shelly_connector.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi()
    .AddShellyConnector(builder.Configuration)
    .AddMemoryCache(options =>
    {
        options.TrackStatistics = true;
        options.SizeLimit = 2048; // 2KB
    })
    .AddAutoMapper(configAction =>
    {
        configAction.CreateMap<EmStatus, LiveData>()
            .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => DateTimeOffset.Now))
            .ForMember(dest => dest.ACurrent, opt => opt.MapFrom(src => src.ACurrent))
            .ForMember(dest => dest.AActPower, opt => opt.MapFrom(src => src.AActPower))
            .ForMember(dest => dest.BCurrent, opt => opt.MapFrom(src => src.BCurrent))
            .ForMember(dest => dest.BActPower, opt => opt.MapFrom(src => src.BActPower))
            .ForMember(dest => dest.CCurrent, opt => opt.MapFrom(src => src.CCurrent))
            .ForMember(dest => dest.CActPower, opt => opt.MapFrom(src => src.CActPower));

        configAction.CreateMap<EmData, CounterStatus>()
            .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => DateTimeOffset.Now))
            .ForMember(dest => dest.ATotalActEnergy, opt => opt.MapFrom(src => src.ATotalActEnergy))
            .ForMember(dest => dest.BTotalActEnergy, opt => opt.MapFrom(src => src.BTotalActEnergy))
            .ForMember(dest => dest.CTotalActEnergy, opt => opt.MapFrom(src => src.CTotalActEnergy))
            .ForMember(dest => dest.TotalAct, opt => opt.MapFrom(src => src.TotalAct));
    })
    .AddPersistence(builder.Configuration)
    .AddLoadSessionDetector(builder.Configuration)
    .AddEvents()
    .AddScoped<LoadSessionTracker>()
    .AddTransient<EnergyCounterProvider>()
    .AddSingleton<IEnergyTariffProvider, EnergyTariffProvider>();


var app = builder.Build();

await app.BootstrapPersistenceAsync(CancellationToken.None);

app.UseLoadSessionDetector();
app.Services.ConfigureEvents()
    .Register<LoadSessionDetectedEvent>()
    .Subscribe<LoadSessionTracker>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UsePathBase("/api");

app.MapGet("em/live", async (ShellyDataProvider dataProvider) =>
{
    var emStatus = await dataProvider.GetEmStatusAsync();
    var liveData = app.Services.GetRequiredService<IMapper>().Map<LiveData>(emStatus);

    return Results.Ok(liveData);
}).WithName("GetLiveData");

app.MapGet("em/counters", async (ShellyDataProvider dataProvider) =>
{
    var emStatus = await dataProvider.GetEmCountersAsync();
    var liveData = app.Services.GetRequiredService<IMapper>().Map<CounterStatus>(emStatus);

    return Results.Ok(liveData);
}).WithName("GetCounters");

await app.RunAsync(CancellationToken.None);