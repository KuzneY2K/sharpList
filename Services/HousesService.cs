using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;
using server.Repositories;

namespace server.Services
{
    public class HousesService
    {

        private readonly HousesRepository _housesRepo;

        public HousesService(HousesRepository housesRepo)
        {
            _housesRepo = housesRepo;
        }

        internal House CreateHouse(House houseData)
        {
            House house = _housesRepo.CreateHouse(houseData);
            return house;
        }

        internal List<House> GetHouses()
        {
            List<House> houses = _housesRepo.GetHouses();
            return houses;
        }

    }
}