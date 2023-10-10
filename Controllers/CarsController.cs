using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services;

namespace server.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
private readonly CarsService _carsService;

    public CarsController(CarsService carsService)
    {
        _carsService = carsService;
    }

    [HttpGet]
    public ActionResult<List<Car>> GetAllCars(){
      try
      {
        List<Car> cars = _carsService.GetAllCars();
        return Ok(cars);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{carId}")]
    public ActionResult<Car> GetCarById(int carId){
      try
      {
        Car car = _carsService.GetCarById(carId);
        return Ok(car);
      }
     catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  [HttpPost]
  public ActionResult<Car> CreateCar([FromBody] Car carData){
    try
    {
      Car car = _carsService.CreateCar(carData);
      return Ok(car);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{carId}")]
  public ActionResult<Car> UpdateCar( [FromBody]Car updateData, int carId){
    try
    {
      updateData.Id = carId;
      Car car = _carsService.UpdateCar(updateData);
      return Ok(car);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{carId}")]
  public ActionResult<string> RemoveCar(int carId){
    try
    {
      string message = _carsService.RemoveCar(carId);
      return Ok(message);
    }
     catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

}
