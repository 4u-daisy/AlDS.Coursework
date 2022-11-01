using System.ComponentModel.DataAnnotations;

namespace AlDS.Coursework.Board.BoardModel
{
    /// <summary>
    /// CardId - primary key
    /// BoardId - foreign key
    /// Board - for the one-to-many connection (Board-to-Card)
    /// ICollection<Note> Notes - for the one-to-many connection (Card-to-Notes)
    /// </summary>
    public class Card
    {
        [Required]
        public int CardId { get; set; }
        [Required]
        public int CreatorId { get; set; }
        [Required]
        public int BoardId { get; set; }

        public ICollection<Note> Notes { get; set; } = new List<Note>();

        public Board? Board { get; set; }

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
