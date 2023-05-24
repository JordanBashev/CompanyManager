using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyManager.Database.Entities
{
    public class Project : BaseEntity
    {
        public int? managerId { get; set; }
        [Precision(18, 2)]
        public decimal cost { get; set; }
        public DateTime FinishedOn { get; set; }

        [ForeignKey(nameof(managerId))]
        public Manager? manager { get; set; }
    }
}
