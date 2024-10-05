using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Users;

namespace Domain.Entities
{
    public class Lesson
    {
        public int TeacherId {  get; set; }
        public Teacher? Teacher { get; set; }

        public bool IsCompleted { get; set; }

        public Guid ClientId { get; set; }
        public Client? Client { get; set; }

        public DateTime LessonDate { get; set; } = DateTime.Now;
    }
}
