using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Application.DTOs.Responses;
public class PaginationResponse<T>
{
    public List<T> Items { get; set; } = new List<T>();

    public int PageSize { get; set; } = 10;
    public int PageNumber { get; set; } = 1;
    public int TotalCount { get; set; }
    public int TotalPages=>(int)Math.Ceiling((double)TotalCount / PageSize);
  

}



 
 

