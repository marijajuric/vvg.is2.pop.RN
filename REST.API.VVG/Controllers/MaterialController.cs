using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model.VVG.model;
using REST.API.VVG.Database;

namespace REST.API.VVG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaterialController : ControllerBase
    {
        private readonly RnDbContext _db;

        public MaterialController(RnDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Material>? Get()
        {
            List<Material> materials = new List<Material>();
            if (_db.Material != null)
                materials = _db.Material.ToList();
            // ************************************************ //
            materials = _db.Material.OrderBy(p => p.Id).ToList();
            return materials;
        }

        [HttpGet("{id}")]
        public IEnumerable<Material>? GetById(int? id)
        {
            List<Material> materials = new ();
            Material? material = _db.Material.Find(id);
            if (material != null)
            {
                materials.Add(material);
            }
            return materials;
        }

        [HttpPut("{id}")]
        public IEnumerable<Material>? Update([FromBody] Material material)
        {
            List<Material> materials = new List<Material>();
            EntityEntry<Material>? storedResource;
            if(_db.Material != null)
            {
                if(material.Id < 1)
                {
                    storedResource = _db.Material.Add(material);
                }else
                {
                    storedResource = _db.Material.Update(material);
                }

                _db.SaveChanges();
                materials.Add(storedResource.Entity);
            }
            return materials;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Material? material = _db.Material.Find(id);
            if(material != null)
            {
                _db.Material.Remove(material);
                _db.SaveChanges();
                return new OkResult();
            }
            return NotFound();
        }
    }
}
