﻿namespace SeminarHub.Models
{
    public class DetailSeminarViewModel
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string DateAndTime { get; set; }
        public string Lecturer { get; set; }
        public int? Duration { get; set; }
        public string Details { get; set; }
        public string Organizer { get; set; }
        public string Category { get; set; }
    }
}
