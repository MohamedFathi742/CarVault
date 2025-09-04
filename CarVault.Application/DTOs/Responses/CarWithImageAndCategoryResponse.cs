using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
 List<string>? CarImages


);
