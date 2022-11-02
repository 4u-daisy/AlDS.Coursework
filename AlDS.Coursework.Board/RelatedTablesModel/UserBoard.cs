using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AlDS.Coursework.Board.RelatedTablesModel
{
    /// <summary>
    /// for many-to-many connecction User-to-Board
    /// </summary>
    public class UserBoard
    {
        [Key]
        public string Key { get; set; }

        public string UserId { get; set; }
        public UserModel.User User { get; set; }

        public string BoardId { get; set; }
        public BoardModel.Board Board { get; set; }

        public UserBoard()
        {
            Key = UserId + BoardId;
        }

    }
}
