using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Application.DTOs.Responses;
public record class OrderResponse
(
 int Id,
DateTime OrderDate,
string Status,
 string UserId,
string UserFullName,
int CarId,
string CarModel,
string CarBrand,
decimal CarPrice,
List<string>? CarImages
);
