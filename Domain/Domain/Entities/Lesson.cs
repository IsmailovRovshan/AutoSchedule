﻿using Domain.Entities.Users;
using Domain.Enum;

namespace Domain.Entities
{
    public class Lesson
    {
        public int TeacherId {  get; set; }
        public Teacher? Teacher { get; set; }

        public Status Status { get; set; } = Status.Scheduled;

        public Guid ClientId { get; set; }
        public Client? Client { get; set; }

        public DateTime LessonDate { get; set; } = DateTime.Now;
    }

    
}
