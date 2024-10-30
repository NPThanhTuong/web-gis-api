using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiGIS.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiGIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotelLocationsController : ControllerBase
    {
        private readonly WebGisDbContext _db;
        private readonly IMapper _mapper;


        public MotelLocationsController(WebGisDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        // GET: api/<MotelLocationsController>
        //[HttpGet]
        //public async Task<ActionResult<List<MotelLocationResDto>>> GetMotelLocations()
        //{
        //    var motelLocations = await _db.MotelLocations.ToListAsync();

        //    var result = _mapper.Map<List<MotelLocationResDto>>(motelLocations);

        //    return Ok(result);
        //}

        // GET api/<MotelLocationsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //// POST api/<MotelLocationsController>
        //[HttpPost]
        //public async Task<ActionResult<Location>> PostLocation([FromBody] MotelLocation location)
        //{
        //    _db.MotelLocations.Add(location);
        //    await _db.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetMotelLocations), new { id = location.Id }, location);
        //}

        // PUT api/<MotelLocationsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<MotelLocationsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
