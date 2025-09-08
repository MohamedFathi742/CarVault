namespace CarVault.Application.DTOs.Requests;
public record class CreateCarImageRequest
(
 int CarId, 
List<string> ImageUrl 
    
 );
