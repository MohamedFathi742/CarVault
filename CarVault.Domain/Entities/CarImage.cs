namespace CarVault.Domain.Entities;
public sealed class CarImage
{

    public int Id { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public int CarId { get; set; }
    public Car Car { get; set; }
}

