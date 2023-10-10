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

        internal House UpdateHouse(House updateData)
        {
            House original = this.GetHouse(updateData.Id);
            original.Sqft = updateData.Sqft != null ? updateData.Sqft : original.Sqft;
            original.Bedrooms = updateData.Bedrooms != null ? updateData.Bedrooms : original.Bedrooms;
            original.Bathrooms = updateData.Bathrooms != null ? updateData.Bathrooms : original.Bathrooms;
            original.ImgUrl = updateData.ImgUrl != null ? updateData.ImgUrl : original.ImgUrl;
            original.Description = updateData.Description != null ? updateData.Description : original.Description;
            original.Price = updateData.Price != null ? updateData.Price : original.Price;
            House house = _housesRepo.UpdateHouse(original);
            return house;

        }

        internal House GetHouse(Guid houseId)
        {
            House house = _housesRepo.GetHouse(houseId);
            return house;
        }

        internal List<House> GetHouses()
        {
            List<House> houses = _housesRepo.GetHouses();
            return houses;
        }

        internal string RemoveHouse(Guid houseId)
        {
            House house = this.GetHouse(houseId);
            _housesRepo.RemoveHouse(houseId);
            return $"House {house.Id} was removed.";
        }

    }
}