﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using hackhathonTarnow.Context;
using hackhathonTarnow.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hackhathonTarnow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        private MySqlContext _context { get; set; }
        public ParkingController(MySqlContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<HttpResponseMessage>> ParkingCreate([FromBody] Parking parking)
        {
            _context.Parkings.Add(parking);
            await _context.SaveChangesAsync();
            return Ok("Dodano Parking");
        }
        [HttpGet]
        public async Task<IEnumerable<Parking>> GetParking()
        {
            var parking = await _context.Parkings.ToListAsync();
            return parking;
        }
    }
}
}