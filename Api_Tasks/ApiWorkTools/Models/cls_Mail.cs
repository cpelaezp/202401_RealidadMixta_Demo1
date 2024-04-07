namespace ApiWorkTools.Models
{
    public class cls_Mail
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime DateSend { get; set; }
        public DateTime DateRead { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }

    }
}
