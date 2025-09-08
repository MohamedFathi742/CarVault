using System.Linq;

namespace CarVault.Application.DTOs.Responses;
public static class PaginationResponseEx
{
    public static PaginationResponse<Tout> Map<Tin, Tout>(this PaginationResponse<Tin> src, Func<Tin, Tout> map)
    {
        return new PaginationResponse<Tout>
        {

            Items = src.Items.Select(map).ToList(),
            TotalCount =src.TotalCount,
            PageNumber=src.PageNumber,
            PageSize=src.PageSize,  

        };
    
    
    
    }
}
