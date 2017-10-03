using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XmlApiEndpoint.Data;
using XmlApiEndpoint.Models;

namespace XmlApiEndpoint.Controllers
{
    [Route("api/[controller]")]
    public class TrafficController : Controller
    {
        private readonly TrafficContext _context;

        public TrafficController(TrafficContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return  Ok(_context.GetAllAsync());
        }

        [HttpGet("{regionCode}")]
        public async Task<IActionResult> Get(string regionCode)
        {
            var regionTraffic = await _context.GetByRegionCodeAsync(regionCode);

            if (regionTraffic == null)
            {
                return NotFound($"Invalid region code [{regionCode}]");
            }

            return Ok(regionTraffic);
        }
    }
}
