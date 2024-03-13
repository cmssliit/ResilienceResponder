namespace CrisisManagementSystem.API.DataLayer
{
    public class IncidentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsActive { get; set; }

        public virtual Workflow Workflow { get; set; }
    }
}
