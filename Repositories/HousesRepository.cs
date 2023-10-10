using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;

namespace server.Repositories
{
    public class HousesRepository
    {

        private readonly IDbConnection _db;

        public HousesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal House CreateHouse(House houseData)
        {
            string sql = @"
                INSERT INTO houses
                (id, sqft, bedrooms, bathrooms, imgUrl, description, price)
                VALUES
                (@id, @sqft, @bedrooms, @bathrooms, @imgUrl, @description, @price);
                SELECT * FROM houses WHERE id = LAST_INSERT_ID();
            ";

            House house = _db.Query<House>(sql, houseData).FirstOrDefault();
            return house;
        }

        internal List<House> GetHouses()
        {
            string sql = "SELECT * FROM houses;";
            List<House> houses = _db.Query<House>(sql).ToList();
            return houses;
        }

    }
}