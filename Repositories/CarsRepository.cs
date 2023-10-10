using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;

namespace server.Repositories;

public class CarsRepository
{
    private readonly IDbConnection _db;

    public CarsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Car CreateCar(Car carData)
    {
      string sql = @"
      INSERT INTO cars
      (make, model, year, price, description, imgUrl, isNew)
      VALUES
      (@make, @model, @year, @price, @description, @imgUrl, @isNew);
      SELECT * FROM cars WHERE id = LAST_INSERT_ID();
      ";
      Car car = _db.Query<Car>(sql, carData).FirstOrDefault();
      return car;
    }

    internal List<Car> GetAllCars()
    {
      string sql = "SELECT * FROM cars;";
      List<Car> cars = _db.Query<Car>(sql).ToList();
      return cars;
    }

    internal Car GetCarById(int carId)
    {
      string sql = "SELECT * FROM cars WHERE id = @carId;";
      // NOTE to avoid, SLQ injection attacks (like bobby drop tables)
      // pass a {key:value} into the Query to match and pull values from
      // example {carId: 2} matches @carId and reads as "...WHERE id = 2";
      Car car = _db.Query<Car>(sql, new {carId}).FirstOrDefault();
      return car;
    }

    internal void RemoveCar(int carId)
    {
      string sql = "DELETE FROM cars WHERE id = @carId";
      // string sql = "DELETE FROM cars WHERE id = @carId LIMIT 1";
      int rowsAffected = _db.Execute(sql, new {carId});

      // NOTE checks for paranoid people. Which most devs become after they delete something from a production environment.
      if(rowsAffected > 1) throw new Exception("Get the Senior dev, i just delted it all.");
      if(rowsAffected < 1) throw new Exception("somehow nothing was deleted?");
    }

    internal Car UpdateCar(Car carData)
    {
      string sql = @"
      UPDATE cars
      SET
      make = @make,
      model = @model,
      year = @year,
      price = @price,
      imgUrl = @imgUrl,
      description = @description,
      isNew = @isNew
      WHERE id = @id;
      SELECT * FROM cars WHERE id = @id;
      ";
      Car car = _db.Query<Car>(sql, carData).FirstOrDefault();
      return car;
    }
}
