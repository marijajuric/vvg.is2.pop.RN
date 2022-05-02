using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model.VVG.model;
using REST.API.VVG.Database;

namespace REST.API.VVG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkOrderController : ControllerBase
    {
        private readonly RnDbContext _db;

        public WorkOrderController(RnDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<WorkOrder>? Get()
        {
            List<WorkOrder> workorders = new List<WorkOrder>();
            if (_db.WorkOrder != null)
                workorders = _db.WorkOrder.ToList();
            // ************************************************ //
            workorders = _db.WorkOrder.OrderBy(p => p.Id).ToList();
            return workorders;
        }

        [HttpGet("{id}")]
        public IEnumerable<WorkOrder>? GetById(int? id)
        {
            List<WorkOrder> workorders = new();
            WorkOrder? workorder = _db.WorkOrder.Find(id);
            if (workorder != null)
            {
                workorders.Add(workorder);
            }
            return workorders;
        }

        [HttpPut("{id}")]
        public IEnumerable<WorkOrder>? Update([FromBody] WorkOrder workorder)
        {
            List<WorkOrder> workorders = new List<WorkOrder>();
            EntityEntry<WorkOrder>? storedResource;
            if (_db.WorkOrder != null)
            {
                if (workorder.Id < 1)
                {
                    storedResource = _db.WorkOrder.Add(workorder);
                }
                else
                {
                    storedResource = _db.WorkOrder.Update(workorder);
                }

                _db.SaveChanges();
                workorders.Add(storedResource.Entity);
            }
            return workorders;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            WorkOrder? workorder = _db.WorkOrder.Find(id);
            if (workorder != null)
            {
                _db.WorkOrder.Remove(workorder);
                _db.SaveChanges();
                return new OkResult();
            }
            return NotFound();
        }

    }
}
