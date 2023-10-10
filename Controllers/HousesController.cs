using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HousesController : ControllerBase
    {

        private readonly HousesService _housesService;

        public HousesController(HousesService housesService)
        {
            _housesService = housesService;
        }

        [HttpGet]
        public ActionResult<List<House>> GetHouses()
        {
            try
            {
                List<House> houses = _housesService.GetHouses();
                return Ok(houses);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{houseId}")]
        public ActionResult<House> GetHouse(Guid houseId)
        {
            try
            {
                House house = _housesService.GetHouse(houseId);
                return Ok(house);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<House> CreateHouse([FromBody] House houseData)
        {
            try
            {
                House house = _housesService.CreateHouse(houseData);
                return Ok(house);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{houseId}")]
        public ActionResult<string> RemoveHouse(Guid houseId)
        {
            try
            {
                string message = _housesService.RemoveHouse(houseId);
                return Ok(message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{houseId}")]
        public ActionResult<House> UpdateHouse([FromBody] House updateData, Guid houseId)
        {
            try
            {
                updateData.Id = houseId;
                House house = _housesService.UpdateHouse(updateData);
                return Ok(house);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}