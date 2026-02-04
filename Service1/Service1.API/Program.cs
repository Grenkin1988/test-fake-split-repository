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

app.MapPost("/orders", (CreateOrderRequest req) =>
{
    var order = new Order(OrderId.New());
    foreach (var line in req.Lines)
        order.AddLine(line.Sku, line.Quantity, line.Price);

    var dto = new OrderCreated(order.Id.Value, order.CreatedAt);
    return Results.Ok(dto);
});

app.Run();
