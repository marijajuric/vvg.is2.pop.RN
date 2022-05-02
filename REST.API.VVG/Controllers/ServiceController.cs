using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model.VVG.model;
using REST.API.VVG.Database;

namespace REST.API.VVG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly RnDbContext _db;

        public ServiceController(RnDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Service>? Get()
        {
            List<Service> services = new List<Service>();
            if (_db.Service != null)
                services = _db.Service.ToList();
            // ************************************************ //
            services = _db.Service.OrderBy(p => p.Id).ToList();
            return services;
        }

        [HttpGet("{id}")]
        public IEnumerable<Service>? GetById(int? id)
        {
            List<Service> services = new();
            Service? service = _db.Service.Find(id);
            if (service != null)
            {
                services.Add(service);
            }
            return services;
        }

        [HttpPut("{id}")]
        public IEnumerable<Service>? Update([FromBody] Service service)
        {
            List<Service> services = new List<Service>();
            EntityEntry<Service>? storedResource;
            if (_db.Service != null)
            {
                if (service.Id < 1)
                {
                    storedResource = _db.Service.Add(service);
                }
                else
                {
                    storedResource = _db.Service.Update(service);
                }

                _db.SaveChanges();
                services.Add(storedResource.Entity);
            }
            return services;
        }

        
    }
}
