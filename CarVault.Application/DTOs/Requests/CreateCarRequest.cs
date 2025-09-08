namespace CarVault.Application.DTOs.Requests;
public record class CreateCarRequest
(
  string Model ,
 string Brand ,
 decimal Price ,
 int CategoryId
// List<CreateCarImageRequest>? CarImages 

);
