using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Model.VVG.model
{
    [Table("work_order_service;")]
    public class WorkOrderService : BaseEntity
    {
        [JsonPropertyName("work_order_id ")]
        [Column("work_order_id ")]
        public string? WorkOrderId { get; set; }

        [JsonPropertyName("service_id ")]
        [Column("service_id ")]
        public int ServiceId { get; set; }

    }
}
