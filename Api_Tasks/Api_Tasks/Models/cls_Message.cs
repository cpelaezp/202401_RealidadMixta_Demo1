﻿namespace Api_Tasks.Models
{
    public class cls_Message
    {
        public int Id { get; set; }
        public string From { get; set; }
        public int Type {  get; set; }
        public DateTime DateSend { get; set; }
        public DateTime DateRead { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

    }
}
