using CarVault.Application.DTOs.Requests;
using CarVault.Application.DTOs.Responses;
using CarVault.Domain.Entities;
using Mapster;

namespace CarVault.Application.Mapping;
public static class MappingConfiguration
{

    public static void RegisterMappings() 
    {
        TypeAdapterConfig<CreateCarRequest, Car>.NewConfig();
            //.Map(dest=>dest.CarImages,src=>src.CarImages);
        TypeAdapterConfig<UpdateCarRequest, Car>.NewConfig();
        TypeAdapterConfig<Car, CarResponse>.NewConfig();
        TypeAdapterConfig<Car, CarWithImageAndCategoryResponse>.NewConfig();
    

        TypeAdapterConfig<CreateOrderRequest, Order>.NewConfig();
        TypeAdapterConfig<UpdateOrderRequest, Order>.NewConfig();
        TypeAdapterConfig<Order, OrderResponse>.NewConfig();
        TypeAdapterConfig<Order, OrderDetilesResponse>.NewConfig();
    

        TypeAdapterConfig<CreateCategoryRequest, Category>.NewConfig();
        TypeAdapterConfig<UpdateCategoryRequest, Category>.NewConfig();
        TypeAdapterConfig<Category, CategoryResponse>.NewConfig();
        TypeAdapterConfig<Category, CategoryWithCarResponse>.NewConfig();
    

        TypeAdapterConfig<CreateCarImageRequest, CarImage>.NewConfig()
            .Map(dest=>dest.ImageUrl,src=>src.ImageUrl)
            .Ignore(dest=>dest.Car);
        TypeAdapterConfig<CarImage, CarImageResponse>.NewConfig();
    

        TypeAdapterConfig<RegisterUserRequest, AuthResponse>.NewConfig();
        TypeAdapterConfig<UpdateUserRequest, ApplicationUser>.NewConfig();
        TypeAdapterConfig<ApplicationUser, UserResponse>.NewConfig();
    
    
    
    }


}
