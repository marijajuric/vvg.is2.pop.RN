using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Model.VVG.model
{
    [Table("service")]
    public class Service : BaseEntity
    {
        [JsonPropertyName("service_name")]
        [Column("service_name")]
        public string? ServiceName { get; set; }

        [JsonPropertyName("service_price")]
        [Column("service_price")]
        public string? ServicePrice { get; set; }

        [JsonPropertyName("hours_spent")]
        [Column("hours_spent")]
        public string? HoursSpent { get; set; }
    }
}
