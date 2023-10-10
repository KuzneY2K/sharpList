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
            Guid UHID = Guid.NewGuid();
            houseData.Id = UHID;
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

        internal House UpdateHouse(House updateData)
        {
            string sql = @"
            UPDATE
            houses
            SET
            sqft = @sqft,
            bedrooms = @bedrooms,
            imgUrl = @imgUrl,
            description = @description,
            price = @price
            WHERE id = @id
            SELECT * FROM houses WHERE
            id = @id;
            ";
            House house = _db.Query<House>(sql, updateData).FirstOrDefault();
            return house;
        }

        internal List<House> GetHouses()
        {
            string sql = "SELECT * FROM houses;";
            List<House> houses = _db.Query<House>(sql).ToList();
            return houses;
        }

        internal House GetHouse(Guid houseId)
        {
            string sql = "SELECT * FROM houses WHERE id=@houseId";
            House house = _db.Query<House>(sql, new { houseId }).FirstOrDefault();
            return house;
        }

        internal void RemoveHouse(Guid houseId)
        {
            string sql = "DELETE FROM houses WHERE id=@houseId;";
            int rowsAffected = _db.Execute(sql, new { houseId });
            if (rowsAffected > 1) throw new Exception("Ok, you just wiped the whole DB...");
            if (rowsAffected < 1) throw new Exception("Ok, you didn't wipe the DB which is good.");
        }
    }
}