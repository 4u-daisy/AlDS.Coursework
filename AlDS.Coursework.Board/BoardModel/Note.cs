using System.ComponentModel.DataAnnotations;

namespace AlDS.Coursework.Board.BoardModel
{
    /// <summary>
    /// NoteId - primary key
    /// CardId - foreign key
    /// ICollection<Note> Notes - for the one-to-many connection (Card-to-Notes)
    /// </summary>
    public class Note
    {
        [Required]
        [Key]
        public string NoteId { get; set; } = new Guid().ToString();
        [Required]
        public string CreatorId { get; set; }
        [Required]
        public string CardId { get; set; }

        public Card? Card { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Text { get; set; }
        public string? Comment { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateUpdated { get; set; }

        public int? IdUserExecuted { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateExecuted { get; set; }

    }
}