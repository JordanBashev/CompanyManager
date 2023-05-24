using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyManager.Database.Entities
{
    [Index(nameof(username), IsUnique = true)]
    public class Employee : BaseEntity
    {
        [MaxLength(18)]
        public string? username { get; set; }
        [MaxLength(18)]
        public string? password { get; set; }
        public int yearsOfExperience { get; set; }
        public int? managerId { get; set; }
        public int? teamId { get; set; }
        [Precision(18,2)]
        public decimal salary { get; set; }

        [ForeignKey(nameof(managerId))]
        public Manager? manager { get; set; }

        [ForeignKey(nameof(teamId))]
        public Team? team { get; set; }
    }
}
