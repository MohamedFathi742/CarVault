namespace CarVault.Application.DTOs.Requests;
public class PaginationAndSearchRequest
{
    public int PageSize { get; set; } = 10;
    public int PageNumber { get; set; } = 1;
    public string? Search { get; set; }
   

 }
    

