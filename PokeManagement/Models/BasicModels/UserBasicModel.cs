namespace PokeManagement.Models.BasicModels
{
    public class UserBasicModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string? Role { get; set; }
        public bool IsDeleted { get; set; }
    }
}
