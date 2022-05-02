using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.VVG.model
{
    [Table("material")]
    public class Material : BaseEntity
    {
        [JsonPropertyName("code")]
        [Column("code")]
        public DateOnly Code { get; set; }

        [JsonPropertyName("name")]
        [Column("name")]
        public DateOnly Name { get; set; }

        [JsonPropertyName("unit_of_measure")]
        [Column("unit_of_measure")]
        public DateOnly UnitOfMeasure { get; set; }

    }
}
