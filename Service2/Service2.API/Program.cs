using Common.Contracts;
using Common.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/health/common", () =>
{
    var sample = new Order(OrderId.New());
    sample.AddLine("SKU-1", 2, 10m);

    var dto = new OrderDto(sample.Id.Value, sample.CreatedAt, sample.Total);
    return Results.Ok(new { ok = true, sample });
});

app.Run();
