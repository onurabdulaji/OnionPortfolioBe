using OnionPortfolioBe.Application.Extensions;
using OnionPortfolioBe.Persistence.Extensions;
using OnionPortfolioBe.WebApi.Endpoints.AboutEndpoint;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistenceLayer(builder.Configuration);
builder.Services.AddApplicationLayer();
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

var aboutEndpoints = new AboutEndpoints();
aboutEndpoints.AddRoutes(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
