using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Application.DTOs.Responses;
public record class CategoryResponse
(
   int Id ,
 string Name ,
 List<CarResponse>? Cars 

 );
