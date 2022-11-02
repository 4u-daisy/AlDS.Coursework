using AlDS.Coursework.Board.RelatedTablesModel;
using System.ComponentModel.DataAnnotations;

namespace AlDS.Coursework.Board.BoardModel
{
    /// <summary>
    /// BoardId - primary key
    /// UserId - foreign key
    /// ICollection<UserBoard> UserBoards - for the many-to-many connection
    /// ICollection<Card> Cards - for the one-to-mane connection (Board-to-Card)
    /// </summary>
    public class Board
    {
        // TODO переделать все под string's 
        [Required]
        [Key]
        public string BoardId { get; set; } = new Guid().ToString();
        [Required]
        public string UserId { get; set; }

        public ICollection<UserBoard> UserBoards { get; set; } = new List<UserBoard>();
        public ICollection<Card> Cards { get; set; } = new List<Card>();


        public string? Space { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateUpdated { get; set; }

    }
}