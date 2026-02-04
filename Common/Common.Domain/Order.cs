namespace Common.Domain;

public sealed class Order
{
    private readonly List<Line> _lines = new();

    public OrderId Id { get; }
    public DateTimeOffset CreatedAt { get; } = DateTimeOffset.UtcNow;

    public IReadOnlyList<Line> Lines => _lines;
    public decimal Total => _lines.Sum(x => x.Price * x.Quantity);

    public Order(OrderId id) => Id = id;

    public void AddLine(string sku, int quantity, decimal price)
    {
        if (string.IsNullOrWhiteSpace(sku)) throw new ArgumentException("SKU is required.", nameof(sku));
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));
        if (price < 0) throw new ArgumentOutOfRangeException(nameof(price));

        _lines.Add(new Line(sku, quantity, price));
    }

    public readonly record struct Line(string Sku, int Quantity, decimal Price);
}
