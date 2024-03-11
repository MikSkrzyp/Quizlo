using AplikacjaDemo.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AplikacjaDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrzykladowyController : ControllerBase
    {
        private readonly PrzykladoweDbContext dbContext;

        public PrzykladowyController(PrzykladoweDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public  async Task<IActionResult> Get() { 
            var dane =  await dbContext.Przykladowy.ToListAsync();
            return Ok(dane);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PrzykladowyModel model)
        {
            await dbContext.Przykladowy.AddAsync(model);
            await dbContext.SaveChangesAsync();

            return Ok("utworzono");

        }
    }
}
