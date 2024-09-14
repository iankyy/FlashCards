using System.ComponentModel.DataAnnotations;

namespace Backend.Data.Entities
{
    public class Deck : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Card> Cards { get; set; } = new List<Card>();
        
        public int CardsAmount { get { return Cards.Count; } }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
