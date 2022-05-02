using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model.VVG.model;
using REST.API.VVG.Database;

namespace REST.API.VVG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkOrderServiceController : ControllerBase
    {
        private readonly RnDbContext _db;

        public WorkOrderServiceController(RnDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<WorkOrderService>? Get()
        {
            List<WorkOrderService> workOrderServices = new List<WorkOrderService>();
            if (_db.WorkOrderService != null)
                workOrderServices = _db.WorkOrderService.ToList();
            // ************************************************ //
            workOrderServices = _db.WorkOrderService.OrderBy(p => p.Id).ToList();
            return workOrderServices;
        }

        [HttpGet("{id}")]
        public IEnumerable<WorkOrderService>? GetById(int? id)
        {
            List<WorkOrderService> workOrderServices = new();
            WorkOrderService? workOrderService = _db.WorkOrderService.Find(id);
            if (workOrderService != null)
            {
                workOrderServices.Add(workOrderService);
            }
            return workOrderServices;
        }

        [HttpPut("{id}")]
        public IEnumerable<WorkOrderService>? Update([FromBody] WorkOrderService workOrderService)
        {
            List<WorkOrderService> workOrderServices = new List<WorkOrderService>();
            EntityEntry<WorkOrderService>? storedResource;
            if (_db.WorkOrderService != null)
            {
                if (workOrderService.Id < 1)
                {
                    storedResource = _db.WorkOrderService.Add(workOrderService);
                }
                else
                {
                    storedResource = _db.WorkOrderService.Update(workOrderService);
                }

                _db.SaveChanges();
                workOrderServices.Add(storedResource.Entity);
            }
            return workOrderServices;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            WorkOrderService? workOrderService = _db.WorkOrderService.Find(id);
            if (workOrderService != null)
            {
                _db.WorkOrderService.Remove(workOrderService);
                _db.SaveChanges();
                return new OkResult();
            }
            return NotFound();
        }
    }
}
