using CarVault.Application.DTOs.Requests;
using CarVault.Application.DTOs.Responses;
using CarVault.Application.Interfaces;
using CarVault.Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVault.Application.Services;
public class CarService(ICarRepository repository):ICarService
{
    private readonly ICarRepository _repository = repository;

    public async Task<IEnumerable<CarWithImageAndCategoryResponse>> GetCarWithImageAndCategoryAsync()
    {
        var cars=await _repository.GetCarWithImageAndCategoryAsync();
        return cars;
    }

    public async Task<IEnumerable<CarResponse>> GetAllCarsAsync()
    {
      var cars= await _repository.GetAllAsync();
        return cars.Adapt<IEnumerable<CarResponse>>();
    }


    //public async Task<CarWithImageAndCategoryResponse?> GetCarWithImageAsync(int id)
    //{
    //  var car = await _repository.GetCarWithImageAsync(id);
    //    return car.Adapt<CarWithImageAndCategoryResponse>();
    //}


    public async Task<IEnumerable<CarWithImageAndCategoryResponse>> GetCarWithCategoryAsync(int categoryId)
    {
        
        var cars=await _repository.GetCarWithCategoryAsync(categoryId);
        return cars.Adapt<IEnumerable<CarWithImageAndCategoryResponse>>();
    }

    public async Task<CarResponse?> GetCarByIdAsync(int id)
    {
       var car= await _repository.GetByIdAsync(id) ?? throw new Exception("Not Found"); ;
        return car.Adapt<CarResponse>();
    }
    public async Task<CarResponse?> AddCarAsync(CreateCarRequest request)
    {
        var car = request.Adapt<Car>();
        await _repository.AddAsync(car);
        return car.Adapt<CarResponse>();
    }
    public async Task<CarResponse?> UpdateCarAsync(UpdateCarRequest request, int id)
    {
        var car = await _repository.GetByIdAsync(id) ?? throw new Exception("Not Found");
        car.Model= request.Model;
        car.Brand= request.Brand;
        car.Price= request.Price;
        car.IsSold= request.IsSold;
        //car.CategoryId= request.CategoryId;
        //car.CarImages= request.CarImages;
      
        
        await _repository.UpdateAsync(car);
       return car.Adapt<CarResponse>();
    }


    public async Task DeleteCarAsync(int id)           
    {
      
        var car = await _repository.GetByIdAsync(id) ?? throw new Exception("Not Found");
        await _repository.DeleteAsync(car);

    }

  
}
