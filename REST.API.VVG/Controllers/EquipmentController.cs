using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model.VVG.model;
using REST.API.VVG.Database;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace REST.API.VVG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EquipmentController : ControllerBase
    {
        private readonly RnDbContext _db;

        public EquipmentController(RnDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Equipment>? Get()
        {
            List<Equipment> equipments = new List<Equipment>();
            if (_db.Equipment != null)
                equipments = _db.Equipment.ToList();
            // ************************************************ //
            equipments = _db.Equipment.OrderBy(p => p.Id).ToList();
            return equipments;
        }

        [HttpGet("{id}")]
        public IEnumerable<Equipment>? GetById(int? id)
        {
            List<Equipment> equipments = new();
            Equipment? equipment = _db.Equipment.Find(id);
            if (equipment != null)
            {
                equipments.Add(equipment);
            }
            return equipments;
        }

        [HttpPut("{id}")]
        public IEnumerable<Equipment>? Update([FromBody] Equipment equipment)
        {
            List<Equipment> equipments = new List<Equipment>();
            EntityEntry<Equipment>? storedResource;
            if (_db.Equipment != null)
            {
                if (equipment.Id < 1)
                {
                    storedResource = _db.Equipment.Add(equipment);
                }
                else
                {
                    storedResource = _db.Equipment.Update(equipment);
                }

                _db.SaveChanges();
                equipments.Add(storedResource.Entity);
            }
            return equipments;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Equipment? equipment = _db.Equipment.Find(id);
            if (equipment != null)
            {
                _db.Equipment.Remove(equipment);
                _db.SaveChanges();
                return new OkResult();
            }
            return NotFound();
        }
    }
}
