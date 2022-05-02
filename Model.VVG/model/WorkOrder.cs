using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.VVG.model
{
    [Table("work_order")]
    public class WorkOrder : BaseEntity
    {
        [JsonPropertyName("order_number")]
        [Column("order_number")]
        public int OrderNumber { get; set; }

        [JsonPropertyName("date_of_receipt ")]
        [Column("date_of_receipt ")]
        public string? DateOfReceipt { get; set; }

        [JsonPropertyName("completion_date ")]
        [Column("completion_date ")]
        public int CompletionDate { get; set; }

        [JsonPropertyName("fault_description ")]
        [Column("fault_description ")]
        public decimal FaultDescription { get; set; }

        [JsonPropertyName("solution_description  ")]
        [Column("solution_description  ")]
        public decimal SolutionDescription { get; set; }

    }
}
