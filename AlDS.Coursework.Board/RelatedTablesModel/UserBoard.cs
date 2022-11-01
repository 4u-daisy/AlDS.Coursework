namespace AlDS.Coursework.Board.RelatedTablesModel
{
    /// <summary>
    /// for many-to-many connecction User-to-Board
    /// </summary>
    public class UserBoard
    {
        public int UserId { get; set; }
        public UserModel.User User { get; set; }

        public int BoardId { get; set; }
        public BoardModel.Board Board { get; set; }
    }
}
