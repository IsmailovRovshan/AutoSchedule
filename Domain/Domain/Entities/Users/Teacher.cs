namespace Domain.Entities.Users
{
    public class Teacher : IUser
    {
        public Guid Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;

        public DateTime StartWork { get; set; } = DateTime.Now;
        public DateTime EndWork { get; set; } = DateTime.Now;

        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
