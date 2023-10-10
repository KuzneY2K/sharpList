using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;
using server.Repositories;

namespace server.Services;

public class CarsService
{
  private readonly CarsRepository _repo;

    public CarsService(CarsRepository repo)
    {
        _repo = repo;
    }

    internal Car CreateCar(Car carData)
    {
      Car car = _repo.CreateCar(carData);
      return car;
    }

    internal List<Car> GetAllCars()
    {
      List<Car> cars = _repo.GetAllCars();
      return cars;
    }

    internal Car GetCarById(int carId)
    {
      Car car = _repo.GetCarById(carId);
      if(car == null) throw new Exception($"no car with id: {carId}");
      return car;
    }

    internal string RemoveCar(int carId)
    {
      Car car = this.GetCarById(carId);
      // THIS IS where WOULD check for ownership next

      _repo.RemoveCar(carId);
      return $"{car.Make} {car.Model} was removed from the database.";
    }

    internal Car UpdateCar(Car updateData)
    {
      Car original = this.GetCarById(updateData.Id);
      // THIS IS where WOULD check for ownership next
      original.Make = updateData.Make != null ? updateData.Make : original.Make;
      original.Model = updateData.Model != null ? updateData.Model : original.Model;
      original.Year = updateData.Year != 0 ? updateData.Year : original.Year;
      original.Price = updateData.Price != null ? updateData.Price : original.Price;
      original.ImgUrl = updateData.ImgUrl ?? original.ImgUrl;
      original.Description = updateData.Description ?? original.Description;
      Car car = _repo.UpdateCar(original);
      return car;
    }
}
