using CatalogAPI.Products.GetProduct;

var builder = WebApplication.CreateBuilder(args);

//added for ILogger Error 
//var serviceProvider = builder.Services.BuildServiceProvider();
//var logger = serviceProvider.GetService<ILogger<GetProductQueryHanlder>>();
//builder.Services.AddSingleton(typeof(ILogger), logger);


//Add services to container
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("DataBase")!);
}).UseLightweightSessions();

var app = builder.Build();

//Configure the Http request Pipeline
app.MapCarter();

app.Run();
