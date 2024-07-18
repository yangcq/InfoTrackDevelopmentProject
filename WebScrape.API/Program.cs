using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WebScrape.Data.Repository;
using WebScrape.Data;
using WebScrape.Data.Model;
using WebScrape.Service;
using WebScrape.Service.Pipeline;
using WebScrape.Service.Abstraction;
using WebScrape.Business;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<WebScrapeDB>(
    options => options.UseLazyLoadingProxies()
    .UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped(typeof(IRepository<Search>), typeof(SearchRepository));
builder.Services.AddScoped(typeof(IRepository<Ranking>), typeof(RankingRepository));
builder.Services.AddScoped(typeof(IRankValueRetrieve), typeof(WebScrapeRankRetrieve));
builder.Services.AddScoped(typeof(IWebScrapeSearchLogic), typeof(SearchThenStoreRankLogic));

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(MediatREntryPoint).Assembly);
    cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
    cfg.AddOpenBehavior(typeof(ExceptionBehavior<,>));
    cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(typeof(MediatREntryPoint).Assembly);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(options => options
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.Run();
