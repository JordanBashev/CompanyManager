using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CompanyManager.Database.Entities
{
    [Index(nameof(username), IsUnique = true)]
    public class Manager : BaseEntity
    {
        [MaxLength(18)]
        public string? username { get; set; }
        [MaxLength(18)]
        public string? password { get; set; }
        public int yearsOfExperience { get; set; }
        [Precision(18, 2)]
        public decimal salary { get; set; }
    }
}
