namespace MzansiBuilds.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Stage { get; set; }
        public string Support { get; set; }
        public string Status { get; set; } = "ongoing";

        public List<string> Comments { get; set; } = new List<string>();
        public List<string> Milestones { get; set; } = new List<string>();
    }
}
