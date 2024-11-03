using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class EquipmentsController(WebGisDbContext db, IMapper mapper) : ControllerBase
    {
        private readonly WebGisDbContext _db = db;
        private readonly IMapper _mapper = mapper;

        // GET: api/<EquipmentsController>
        [Authorize(Roles = ConstConfig.UserRoleName)]
        [HttpGet]
        public async Task<ActionResult<List<EquipmentRes>>> GetEquipments()
        {
            var equipments = await _db.Equipments
                .Include(e => e.EquipmentType)
                .ToListAsync();

            var result = _mapper.Map<List<EquipmentRes>>(equipments);

            return Ok(result);
        }


        // GET api/<EquipmentsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<EquipmentRes>>> GetEquipment(int id)
        {
            var equipment = await _db.Equipments
                .Include(e => e.EquipmentType)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (equipment is null)
                return NotFound(new { message = "Equipment is not found!" });

            var result = _mapper.Map<EquipmentRes>(equipment);

            return Ok(result);
        }

        // POST api/<EquipmentsController>
        [HttpPost]
        public async Task<ActionResult> CreateEquipment([FromBody] CreateEquipmentReq createEquipmentReq)
        {
            var validator = new CreateEquipmentValidator();
            try
            {
                var validationResult = await validator.ValidateAsync(createEquipmentReq);
                if (!validationResult.IsValid)
                    return BadRequest(validationResult.ToDictionary());

                var equipmentType = await _db.EquipmentTypes
                    .FirstOrDefaultAsync(et => et.Id == createEquipmentReq.EquipmentTypeId);
                if (equipmentType is null)
                    return NotFound(new { message = "Equipment type is not found" });

                var room = await _db.Rooms
                    .FirstOrDefaultAsync(r => r.Id == createEquipmentReq.RoomId);
                if (room is null)
                    return NotFound(new { message = "Room type is not found" });

                var equipment = _mapper.Map<Equipment>(createEquipmentReq);

                await _db.Equipments.AddAsync(equipment);
                await _db.SaveChangesAsync();

                return Created();
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { message = "Something went wrong!" });
            }
        }

        // PUT api/<EquipmentsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEquipment(int id, [FromBody] UpdateEquipmentReq updateEquipmentReq)
        {
            var validator = new UpdateEquipmentValidator();
            try
            {
                var validationResult = await validator.ValidateAsync(updateEquipmentReq);
                if (!validationResult.IsValid)
                    return BadRequest(validationResult.ToDictionary());

                var equipment = await _db.Equipments
                    .Include(e => e.EquipmentType)
                    .FirstOrDefaultAsync(e => e.Id == id);

                if (equipment is null)
                    return NotFound(new { message = "Equipment is not found!" });

                if (updateEquipmentReq.EquipmentTypeId is not null)
                {
                    var equipmentType = await _db.EquipmentTypes
                    .FirstOrDefaultAsync(et => et.Id == updateEquipmentReq.EquipmentTypeId);
                    if (equipmentType is null)
                        return NotFound(new { message = "Equipment type is not found" });
                }

                if (updateEquipmentReq.RoomId is not null)
                {
                    var room = await _db.Rooms
                        .FirstOrDefaultAsync(r => r.Id == updateEquipmentReq.RoomId);
                    if (room is null)
                        return NotFound(new { message = "Room type is not found" });
                }

                _mapper.Map(updateEquipmentReq, equipment);
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

        // DELETE api/<EquipmentsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEquipment(int id)
        {
            try
            {
                var equipment = await _db.Equipments
                    .Include(e => e.EquipmentType)
                    .FirstOrDefaultAsync(e => e.Id == id);

                if (equipment is null)
                    return NotFound(new { message = "Equipment is not found!" });

                _db.Equipments.Remove(equipment);
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
    }
}
