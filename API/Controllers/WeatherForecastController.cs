using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Value>>> Get()
        {
            var values=await __context.Values.ToListAsync();
            return Ok(values);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<string>> Get(int id)
        {
            var value=await __context.Values.FindAsync(id);
            return Ok(value);
        }

        private readonly DataContext __context;

        public WeatherForecastController(DataContext context)
        {
            __context = context;

        }


    }
}
