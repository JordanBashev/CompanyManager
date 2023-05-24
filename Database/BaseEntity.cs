using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CompanyManager.Database
{
    public class BaseEntity
    {
        public int id { get; set; }
        [MaxLength(18)]
        public string name { get; set; }
        public DateTime createdOn { get; set; }
        public DateTime? removedOn { get; set; }
    }
}
