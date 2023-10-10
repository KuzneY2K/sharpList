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
                return houses;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}