using CarVault.Application.DTOs.Requests;
using CarVault.Application.DTOs.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Infrastructure.Common;
public static class PagenationAndSearchGeneric
{

    public static async Task<PaginationResponse<T>> ToPagedResultAsync<T>
        (this IQueryable<T> query,
        PaginationAndSearchRequest parameters,
        Expression<Func<T, bool>>? searchPredicate = null)


    {

        if (!string.IsNullOrWhiteSpace(parameters.Search)&&searchPredicate!=null)
       query = query.Where(searchPredicate);


        var total= await query.CountAsync();

        var items= query 
            .Skip((parameters.PageNumber-1)*parameters.PageSize)
            .Take(parameters.PageSize)
            .ToListAsync();
        return new PaginationResponse<T> 
        {
            Items =await items,
            TotalCount = total,
   PageSize = parameters.PageSize,
   PageNumber = parameters.PageNumber

        
        
        
        };

       



    }
}
