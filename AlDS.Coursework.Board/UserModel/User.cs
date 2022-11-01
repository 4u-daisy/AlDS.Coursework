using AlDS.Coursework.Board.BoardModel;
using AlDS.Coursework.Board.RelatedTablesModel;
using System.ComponentModel.DataAnnotations;

namespace AlDS.Coursework.Board.UserModel
{
    /// <summary>
    ///  UserId - primary key
    ///  ICollection<UserBoard> UserBoards - for the many-to-many connection
    /// </summary>
    public class User
    {
        [Required]
        public int UserId { get; set; }
        public ICollection<UserBoard> UserBoards { get; set; } = new List<UserBoard>();

        [Required]
        public string Email { get; set; } = String.Empty;
        [Required]
        public string Password { get; set; } = String.Empty;

        public string? Nickname { get; set; } = new string("DefaultNick");

        public string? Name { get; set; }
        public string? Firstname { get; set; }
        public string? Middlename { get; set; }

        public string? Information { get; set; }
        public string? Address { get; set; }

        public DateTime DateRegistration { get; set; } = DateTime.UtcNow;
        public DateTime DateBirthday { get; set; }
    }
}
