namespace CarVault.Domain.Entities;
public sealed class Car
{
    public int Id { get; set; }
    public string Model { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public bool IsSold { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public Order Order { get; set; }
    public ICollection<CarImage> CarImages { get; set; } = [];

}
