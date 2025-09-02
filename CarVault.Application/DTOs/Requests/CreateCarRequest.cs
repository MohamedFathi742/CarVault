using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Application.DTOs.Requests;
public record class CreateCarRequest
(
  string Model ,
 string Brand ,
 decimal Price ,
 int CategoryId,
 List<string>? CarImages 

);
