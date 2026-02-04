namespace Common.Contracts;

// Typical API contracts / DTOs
public sealed record CreateOrderRequest(List<CreateOrderLine> Lines);
public sealed record CreateOrderLine(string Sku, int Quantity, decimal Price);

public sealed record OrderDto(Guid Id, DateTimeOffset CreatedAt, decimal Total, string Currency);

// Example “event” contract (message bus, outbox, etc.)
public sealed record OrderCreated(Guid Id, DateTimeOffset CreatedAt);
