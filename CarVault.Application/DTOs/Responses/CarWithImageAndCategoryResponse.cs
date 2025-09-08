namespace CarVault.Application.DTOs.Responses;
public record CarWithImageAndCategoryResponse

(
 int Id,
 string Model,
 string Brand,
 decimal Price,
 bool IsSold,
 int CategoryId,
 string CategoryName,
 List<CarImageResponse>? CarImages


);
