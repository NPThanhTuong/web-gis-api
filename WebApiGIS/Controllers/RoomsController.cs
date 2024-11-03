using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiGIS.Data;
using WebApiGIS.Dtos.Request;
using WebApiGIS.Dtos.Response;
using WebApiGIS.Models;
using WebApiGIS.Validators;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiGIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController(WebGisDbContext db, IMapper mapper) : ControllerBase
    {
        private readonly WebGisDbContext _db = db;
        private readonly IMapper _mapper = mapper;

        // GET: api/<RoomsController>
        [HttpGet]
        public async Task<ActionResult<List<RoomRes>>> GetRooms()
        {
            var rooms = await _db.Rooms
                .Include(r => r.Motel)
                    .ThenInclude(m => m.MotelImages)
                .ToListAsync();

            var result = _mapper.Map<List<RoomRes>>(rooms);

            return Ok(result);
        }

        // GET api/<RoomsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomRes>> GetRoom(int id)
        {
            if (id <= 0)
                return BadRequest(new { message = "Id is invalid" });

            var rooms = await _db.Rooms
                 .Include(r => r.Motel)
                     .ThenInclude(m => m.MotelImages)
                 .FirstOrDefaultAsync(r => r.Id == id);

            var result = _mapper.Map<RoomRes>(rooms);

            return Ok(result);
        }

        // POST api/<RoomsController>
        [HttpPost]
        public async Task<ActionResult> CreateNewRoom([FromBody] CreateRoomReq createRoomReq)
        {
            var validator = new CreateRoomValidator();
            try
            {
                var validationResult = await validator.ValidateAsync(createRoomReq);
                if (!validationResult.IsValid)
                    return BadRequest(validationResult.ToDictionary());

                var motel = await _db.Motels.FirstOrDefaultAsync(m => m.Id == createRoomReq.MotelId);
                if (motel is null)
                    return NotFound(new { message = "Motel is not found" });

                var room = _mapper.Map<Room>(createRoomReq);

                await _db.Rooms.AddAsync(room);
                await _db.SaveChangesAsync();

                return Created();
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { message = "Something went wrong" });
            }
        }

        // PUT api/<RoomsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRoom(int id, [FromBody] UpdateRoomReq updateRoomReq)
        {

            if (id <= 0)
                return BadRequest(new { message = "Id is invalid" });

            var validator = new UpdateRoomValidator();

            try
            {
                var validationResult = await validator.ValidateAsync(updateRoomReq);
                if (!validationResult.IsValid)
                    return BadRequest(validationResult.ToDictionary());

                var room = await _db.Rooms.FirstOrDefaultAsync(r => r.Id == id);
                if (room is null)
                    return NotFound(new { message = "Room is not found" });

                if (updateRoomReq.MotelId is not null && updateRoomReq.MotelId > 0)
                {
                    var motel = await _db.Motels.FirstOrDefaultAsync(m => m.Id == updateRoomReq.MotelId);
                    if (motel is null)
                        return NotFound(new { message = "Motel is not found" });
                }

                _mapper.Map(updateRoomReq, room);

                if (updateRoomReq.IsAvailable.HasValue)
                {
                    room.IsAvailable = updateRoomReq.IsAvailable.Value;
                }

                if (updateRoomReq.IsMezzanine.HasValue)
                {
                    room.IsMezzanine = updateRoomReq.IsMezzanine.Value;
                }

                await _db.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { message = "Something went wrong" });
            }
        }

        // DELETE api/<RoomsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRoom(int id)
        {
            if (id <= 0)
                return BadRequest(new { message = "Id is invalid" });

            try
            {
                var room = await _db.Rooms.FirstOrDefaultAsync(r => r.Id == id);
                if (room is null)
                    return NotFound(new { message = "Room is not found" });

                _db.Rooms.Remove(room);
                await _db.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { message = "Something went wrong" });
            }
        }
    }
}
