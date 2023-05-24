using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyManager.Database.Entities
{
    public class TeamToProject
    {
        public int id { get; set; }
        public int? projectId { get; set; }
        public int? teamId { get; set; }

        [ForeignKey(nameof(projectId))]
        public Project? employee { get; set; }

        [ForeignKey(nameof(teamId))]
        public Team? team { get; set; }
    }
}
