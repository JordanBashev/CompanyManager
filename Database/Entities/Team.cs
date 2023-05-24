using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyManager.Database.Entities
{
    public class Team : BaseEntity
    {
        [MaxLength(36)]
        public string? task { get; set; }
        public double pointsPerPerson { get; set; }
    }
}
