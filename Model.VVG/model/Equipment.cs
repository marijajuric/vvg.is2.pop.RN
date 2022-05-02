using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Model.VVG.model
{
    [Table("equipment")]
    public class Equipment : BaseEntity
    {
        [JsonPropertyName("serial_number")]
        [Column("serial_number")]
        public string? SerialNumber { get; set; }

        [JsonPropertyName("name")]
        [Column("name")]
        public string? Name { get; set; }

        [JsonPropertyName("model")]
        [Column("model")]
        public string? Model { get; set; }

    }
}
