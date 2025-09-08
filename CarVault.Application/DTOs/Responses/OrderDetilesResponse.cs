using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Application.DTOs.Responses;
public record OrderDetilesResponse
(int Id,
DateTime OrderDate,
string Status,
 string UserId,
string UserFullName,
//List<CarImageResponse>? CarImages,
List<CarResponse>? Cars

//int CarId,
//string CarModel,
//string CarBrand,
//decimal CarPrice,

    );

