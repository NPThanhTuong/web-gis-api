using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using WebApiGIS.Data;
using WebApiGIS.Dtos.Request;
using WebApiGIS.Dtos.Response;
using WebApiGIS.Models;
using WebApiGIS.Utils;
using WebApiGIS.Validators;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiGIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotelsController(WebGisDbContext db, IMapper mapper) : ControllerBase
    {
        private readonly WebGisDbContext _db = db;
        private readonly IMapper _mapper = mapper;

        // GET: api/<MotelsController>
        [HttpGet]
        public async Task<ActionResult<List<MotelRes>>> GetMotels([FromQuery] string? search)
        {
            IQueryable<Motel> query = _db.Motels
                .Include(m => m.MotelImages);

            if (!string.IsNullOrEmpty(search))
            {
                query = query
                    .Where(m =>
                        m.Name.ToLower().Contains(search.ToLower().Trim()) ||
                        m.Description.Contains(search.Trim()));
            }

            var motels = await query
                .ToListAsync();

            var result = _mapper.Map<List<MotelRes>>(motels);

            return Ok(result);
        }

        // GET api/<MotelsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MotelRes>> GetMotel(int id)
        {
            if (id <= 0)
                return BadRequest(new { message = "Id is invalid!" });

            var motel = await _db.Motels
               .Include(m => m.MotelImages)
               .FirstOrDefaultAsync(m => m.Id == id);

            if (motel is null)
                return NotFound(new { message = "Motel is not found" });

            var result = _mapper.Map<MotelRes>(motel);

            return Ok(result);
        }

        // POST api/<MotelsController>
        [HttpPost]
        public async Task<ActionResult> CreateNewMotel([FromBody] CreateMotelReq motelReq)
        {
            var validator = new CreateMotelValidator();
            try
            {
                var validationResult = await validator.ValidateAsync(motelReq);
                if (!validationResult.IsValid)
                    return BadRequest(validationResult.ToDictionary());

                if (GeometryHelper.IsValidGeoJson(motelReq.Geom))
                    return BadRequest(new { message = "GeoJSON is not valid" });

                var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == motelReq.UserId);
                if (user is null)
                    return NotFound(new { message = "User is not found" });

                var motel = _mapper.Map<Motel>(motelReq);

                await _db.Motels.AddAsync(motel);
                await _db.SaveChangesAsync();

                var result = _mapper.Map<MotelRes>(motel);

                return Created("Motels/" + motel.Id, result);
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { message = "Something went wrong" });
            }
        }

        // PUT api/<MotelsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMotel(int id, [FromBody] UpdateMotelReq updateMotelReq)
        {
            if (id <= 0)
                return BadRequest(new { message = "Id is invalid!" });

            var validator = new UpdateMotelValidator();
            try
            {
                var validationResult = await validator.ValidateAsync(updateMotelReq);
                if (!validationResult.IsValid)
                    return BadRequest(validationResult.ToDictionary());

                var motel = await _db.Motels
                    .Include(e => e.MotelImages)
                    .FirstOrDefaultAsync(e => e.Id == id);

                if (motel is null)
                    return NotFound(new { message = "Motel is not found!" });

                if (updateMotelReq.UserId is not null)
                {
                    var user = await _db.Users
                    .FirstOrDefaultAsync(u => u.Id == updateMotelReq.UserId);
                    if (user is null)
                        return NotFound(new { message = "Motel type is not found" });
                }

                _mapper.Map(updateMotelReq, motel);
                await _db.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { message = "Something went wrong!" });
            }
        }

        // DELETE api/<MotelsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMotel(int id)
        {
            if (id <= 0)
                return BadRequest(new { message = "Id is invalid!" });

            try
            {
                var motel = await _db.Motels
                    .Include(e => e.MotelImages)
                    .FirstOrDefaultAsync(e => e.Id == id);

                if (motel is null)
                    return NotFound(new { message = "Motel is not found!" });

                _db.Motels.Remove(motel);
                await _db.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { message = "Something went wrong!" });
            }
        }

        [HttpPost("{motelId}/images")]
        public async Task<ActionResult> AddMotelImage(int motelId, List<MotelImageReq> motelImageReqs)
        {
            if (motelId <= 0)
                return BadRequest(new { message = "Id is invalid" });

            try
            {
                var validator = new MotelImageValidator();

                for (int i = 0; i < motelImageReqs.Count; i++)
                {
                    var validationResult = validator.Validate(motelImageReqs.ElementAt(i));
                    if (!validationResult.IsValid)
                        return BadRequest(validationResult.ToDictionary());
                }

                var motel = await _db.Motels
                    .Include(e => e.MotelImages)
                    .FirstOrDefaultAsync(e => e.Id == motelId);

                if (motel is null)
                    return NotFound(new { message = "Motel is not found!" });

                var motelImages = _mapper.Map<List<MotelImage>>(motelImageReqs);

                motel.MotelImages.AddRange(motelImages);
                await _db.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { message = "Something went wrong!" });
            }
        }

        [HttpDelete("images/{imageId}")]
        public async Task<ActionResult> DeleteImage(int imageId)
        {
            if (imageId <= 0)
                return BadRequest(new { message = "Id is invalid" });

            try
            {
                var motelImage = await _db.MotelImages
                    .FirstOrDefaultAsync(e => e.Id == imageId);

                if (motelImage is null)
                    return NotFound(new { message = "Motel iamge is not found!" });

                _db.MotelImages.Remove(motelImage);
                await _db.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { message = "Something went wrong!" });
            }
        }

        [HttpGet("{id}/rooms")]
        public async Task<ActionResult<List<RoomRes>>> GetRoomOfMotel(int id)
        {
            if (id <= 0)
                return BadRequest(new { message = "Id is invalid!" });

            var rooms = await _db.Rooms
                .Where(r => r.MotelId == id)
                .ToListAsync();

            var result = _mapper.Map<List<RoomRes>>(rooms);

            return Ok(result);
        }
    }
}
