namespace Domain.Entities.Users
{
    public class Manager : IUser
    {
        public Guid Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;

        public List<Client> Clients { get; set; } = new List<Client>();
    }
}
