namespace Backend.Data.Entities
{
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Deck>? Decks { get; set; }
    }
}
