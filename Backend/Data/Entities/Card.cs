using System.ComponentModel.DataAnnotations;

namespace Backend.Data.Entities
{
    public class Card : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string FrontCard { get; set; }
        public string BackCard { get; set; }
        public int DeckId { get; set; }
        public Deck Deck { get; set; }
    }
}
