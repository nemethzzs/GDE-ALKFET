using Microsoft.AspNetCore.Mvc;
using backend.Services;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly HotelService _service;

        public HotelController(HotelService service)
        {
            _service = service;
        }

        [HttpGet("szobak")]
        public async Task<IActionResult> GetSzobak()
        {
            return Ok(await _service.GetSzobak());
        }

        [HttpGet("foglalasok")]
        public async Task<IActionResult> GetFoglalasok()
        {
            return Ok(await _service.GetFoglalasok());
        }

        [HttpPost("foglal")]
        public async Task<IActionResult> Foglal([FromBody] FoglalRequest req)
        {
            await _service.Foglal(req.Szobaszam, req.Datum);
            return Ok();
        }

        [HttpDelete("torles")]
        public async Task<IActionResult> Torles(int szobaszam, DateTime datum)
        {
            await _service.Torles(szobaszam, datum);
            return Ok();
        }
    }

    public class FoglalRequest
    {
        public int Szobaszam { get; set; }
        public DateTime Datum { get; set; }
    }
}