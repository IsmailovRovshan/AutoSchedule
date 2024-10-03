using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Lesson
    {
        public int TeacherId {  get; set; }
        public Teacher? Teacher { get; set; }

        public int ClientId { get; set; }
        public Client? Client { get; set; }

        public DateTime Data { get; set; } = DateTime.Now;
    }
}
