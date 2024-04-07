namespace Api_Tasks.Models
{
    public class cls_Task
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

    }
}
