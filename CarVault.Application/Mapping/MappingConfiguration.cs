using CarVault.Application.DTOs.Requests;
using CarVault.Application.DTOs.Responses;
using CarVault.Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Application.Mapping;
public static class MappingConfiguration
{

    public static void RegisterMappings() 
    {
        TypeAdapterConfig<CreateCarRequest, Car>.NewConfig();
        TypeAdapterConfig<UpdateCarRequest, Car>.NewConfig();
        TypeAdapterConfig<Car, CarResponse>.NewConfig();
    

        TypeAdapterConfig<CreateOrderRequest, Order>.NewConfig();
        TypeAdapterConfig<UpdateOrderRequest, Order>.NewConfig();
        TypeAdapterConfig<Order, OrderResponse>.NewConfig();
    

        TypeAdapterConfig<CreateCategoryRequest, Category>.NewConfig();
        TypeAdapterConfig<UpdateCategoryRequest, Category>.NewConfig();
        TypeAdapterConfig<Category, CategoryResponse>.NewConfig();
    

        TypeAdapterConfig<CreateCarImageRequest, CarImage>.NewConfig();
        TypeAdapterConfig<CarImage, CarImageResponse>.NewConfig();
    

        TypeAdapterConfig<RegisterUserRequest, ApplicationUser>.NewConfig();
        TypeAdapterConfig<UpdateUserRequest, ApplicationUser>.NewConfig();
        TypeAdapterConfig<ApplicationUser, UserResponse>.NewConfig();
    
    
    
    }


}
