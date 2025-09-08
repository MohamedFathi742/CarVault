namespace CarVault.Domain.Entities;
public sealed class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public string Status { get; set; } = "Pending";
    public string UserId { get; set; }
    public ApplicationUser  User { get; set; }

    public int CarId { get; set; }
    public Car Car { get; set; }




}
