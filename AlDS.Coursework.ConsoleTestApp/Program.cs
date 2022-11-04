using AlDS.Coursework.Board.BoardModel;
using AlDS.Coursework.Board.RelatedTablesModel;
using AlDS.Coursework.Board.UserModel;
using AlDS.Coursework.Test;
//using AlDS.Coursework.RelatedTables;
//using Microsoft.EntityFrameworkCore.Design;

//TODO настроить каскадное удаление и удаление в прицнипе


using (DataBaseContext db = new DataBaseContext())
{
    //var userList = db.User.ToList();

    var elem = db.User.First(x => x.Email == "n_daisy1@mail.ru");

    db.Board.Remove(db.Board.First(x => x.UserId == elem.Id));
    db.UserBoard.Remove(db.UserBoard.First(x => x.UserId == elem.Id));

    db.Note.RemoveRange(db.Note.Where(x=>x.NoteId != String.Empty));
    db.Card.RemoveRange(db.Card.Where(x => x.CardId != String.Empty));
    
    db.SaveChanges();   

    var boards = db.UserBoard.First(x => x.UserId == elem.Id);
    var b = db.Board.First(x => x.BoardId == boards.BoardId);

    var card = new Card()
    {
        Board = b,
        BoardId = boards.BoardId,
        CreatorId = elem.Id,
        Title = "В планах",
    };
    var card2 = new Card()
    {
        Board = b,
        BoardId = boards.BoardId,
        CreatorId = elem.Id,
        Title = "Делаю",
    };
    var card3 = new Card()
    {
        Board = b,
        BoardId = boards.BoardId,
        CreatorId = elem.Id,
        Title = "Сделано",
    };

    var note = new Note()
    {
        CardId = card.CardId,
        Card = card,
        CreatorId = elem.Id,
        Title = "Важное дело номер 1",
        Text = "абоба абиба"
    };
    var note2 = new Note()
    {
        CardId = card2.CardId,
        Card = card2,
        CreatorId = elem.Id,
        Title = "Важное дело второй карты",
        Text = "абиба"
    };
    var note3 = new Note()
    {
        CardId = card3.CardId,
        Card = card3,
        CreatorId = elem.Id,
        Title = "Третье дело карты 3",
        Text = "абоба?"
    };
    var note4 = new Note()
    {
        CardId = card.CardId,
        Card = card,
        CreatorId = elem.Id,
        Title = "Дело секретное, в планах",
        Text = "пупа и лупа работали в бухгалтерии"
    };

    db.Card.Add(card);
    db.Card.Add(card2);
    db.Card.Add(card3);

    db.Note.Add(note);
    db.Note.Add(note2);
    db.Note.Add(note3);
    db.Note.Add(note4);

    db.SaveChanges();
}


Console.WriteLine("All okay :)");

//var board = new Board()
//{
//    Title = "Study",
//    Description = "This is my study list",
//    UserId = userList[1].Id
//};

//db.Board.Add(board);
//db.SaveChanges();

//var boards = db.Board.ToList();

//var userboard = new UserBoard()
//{
//    User = daisy,
//    Board = boards[0],

//    UserId = daisy.Id,
//    BoardId = boards[0].BoardId,

//    Key = new String(daisy.Id + boards[0].BoardId)
//};

//var userboard2 = new UserBoard()
//{
//    User = daisy,
//    Board = boards[1],

//    UserId = daisy.Id,
//    BoardId = boards[1].BoardId,

//    Key = new String(daisy.Id + boards[1].BoardId)
//};

//db.UserBoard.Add(userboard);
//db.UserBoard.Add(userboard2);
/*
    var user = new User()
    {
        PasswordHash = "126653",
        Email = "11111@email.ru"
    };

    db.Users.Add(user);
    db.SaveChanges();
 */


/*
using (DataBaseContext db = new DataBaseContext())
{
    //var user = new User()
    //{
    //    PasswordHash = "126653",
    //    Email = "11111@email.ru"
    //};

    //var user2 = new User()
    //{
    //    PasswordHash = "2852",
    //    Email = "2222@email.ru"
    //};

    //var user3 = new User()
    //{
    //    PasswordHash = "32862",
    //    Email = "3331@email.ru"
    //};

    //var board = new Board()
    //{
    //    UserId = 1,
    //    Title = "one",
    //    Description = "description one"
    //};

    //var board2 = new Board()
    //{
    //    UserId = 3,
    //    Title = "two",
    //    Description = "description one"
    //};

    ////userId = 1, boardId = 1
    //var userBoard = new UserBoard()
    //{
    //    User = user,
    //    Board = board,
    //    UserId = "1",
    //    BoardId = 1,
    //};
    //// userId = 1, boardId = 2
    //var userBoard2 = new UserBoard()
    //{
    //    User = user,
    //    Board = board2,
    //    UserId = "1",
    //    BoardId = 2,
    //};
    //// userId = 3, boardId = 2
    //var userBoard3 = new UserBoard()
    //{
    //    User = user3,
    //    Board = board2,
    //    UserId = "3",
    //    BoardId = 2,
    //};
    //// userId = 2, boardId = 1
    //var userBoard4 = new UserBoard()
    //{
    //    User = user2,
    //    Board = board,
    //    UserId = "2",
    //    BoardId = 1,
    //};


    //var card = new Card()
    //{
    //    CreatorId = 1,
    //    Board = board,
    //    BoardId = 1,
    //    Title = "one",
    //    Description = "first descr"
    //};
    //var card2 = new Card()
    //{
    //    CreatorId = 2,
    //    Board = board,
    //    BoardId = 1,
    //    Title = "two",
    //    Description = "second descr"
    //};
    //var card3 = new Card()
    //{
    //    CreatorId = 3,
    //    Board = board2,
    //    BoardId = 2,
    //    Title = "three",
    //    Description = "third descr"
    //};

    //var noteOne = new Note()
    //{
    //    CreatorId = 1,
    //    Card = card,
    //    CardId = 1,
    //    Title = "one",
    //    Description = "first description note",
    //    Text = "first text note"
    //};
    //var noteOne2 = new Note()
    //{
    //    CreatorId = 2,
    //    Card = card,
    //    CardId = 1,
    //    Title = "two",
    //    Description = "second description note",
    //    Text = "second text note"
    //};
    //var noteOne3 = new Note()
    //{
    //    CreatorId = 3,
    //    Card = card,
    //    CardId = 3,
    //    Title = "tree",
    //    Description = "third description note",
    //    Text = "third text note"
    //};
    //var noteOne4 = new Note()
    //{
    //    CreatorId = 1,
    //    Card = card,
    //    CardId = 3,
    //    Title = "four",
    //    Description = "fourth description note",
    //    Text = "fourth text note"
    //};
    //var noteOne5 = new Note()
    //{
    //    CreatorId = 2,
    //    Card = card,
    //    CardId = 2,
    //    Title = "five",
    //    Description = "fifth description note",
    //    Text = "fifth text note"
    //};

    //board.Cards.Add(card);
    //board.Cards.Add(card2);
    //board2.Cards.Add(card3);

    //card.Notes.Add(noteOne);
    //card.Notes.Add(noteOne2);
    //card3.Notes.Add(noteOne3);
    //card3.Notes.Add(noteOne4);
    //card2.Notes.Add(noteOne5);


    //db.Users.Add(user);
    //db.Users.Add(user2);
    //db.Users.Add(user3);

    //db.Boards.Add(board);
    //db.Boards.Add(board2);

    //db.UserBoards.Add(userBoard);
    //db.UserBoards.Add(userBoard2);
    //db.UserBoards.Add(userBoard3);
    //db.UserBoards.Add(userBoard4);

    ////db.Cards.Add(card);
    ////db.Cards.Add(card2);
    ////db.Cards.Add(card3);

    ////db.Notes.Add(noteOne);
    ////db.Notes.Add(noteOne2);
    ////db.Notes.Add(noteOne3);
    ////db.Notes.Add(noteOne4);
    ////db.Notes.Add(noteOne5);


    //db.SaveChanges();

}
 */


/*
    var user = new User()
    {
        Password = "126653",
        Email = "11111@email.ru"
    };

    var user2 = new User()
    {
        Password = "2852",
        Email = "2222@email.ru"
    };

    var user3 = new User()
    {
        Password = "32862",
        Email = "3331@email.ru"
    };

    var board = new Board()
    {
        UserId = 1,
        Title = "one",
        Description = "description one"
    };

    var board2 = new Board()
    {
        UserId = 3,
        Title = "two",
        Description = "description one"
    };

    //userId = 1, boardId = 1
    var userBoard = new UserBoard()
    {
        User = user,
        Board = board,
        UserId = 1,
        BoardId = 1,
    };
    // userId = 1, boardId = 2
    var userBoard2 = new UserBoard()
    {
        User = user,
        Board = board2,
        UserId = 1,
        BoardId = 2,
    };
    // userId = 3, boardId = 2
    var userBoard3 = new UserBoard()
    {
        User = user3,
        Board = board2,
        UserId = 3,
        BoardId = 2,
    };
    // userId = 2, boardId = 1
    var userBoard4 = new UserBoard()
    {
        User = user2,
        Board = board,
        UserId = 2,
        BoardId = 1,
    };


    var card = new Card()
    {
        CreatorId = 1,
        Board = board,
        BoardId = 1,
        Title = "one",
        Description = "first descr"
    };
    var card2 = new Card()
    {
        CreatorId = 2,
        Board = board,
        BoardId = 1,
        Title = "two",
        Description = "second descr"
    };
    var card3 = new Card()
    {
        CreatorId = 3,
        Board = board2,
        BoardId = 2,
        Title = "three",
        Description = "third descr"
    };

    var noteOne = new Note()
    {
        CreatorId = 1,
        Card = card,
        CardId = 1,
        Title = "one",
        Description = "first description note",
        Text = "first text note"
    };
    var noteOne2 = new Note()
    {
        CreatorId = 2,
        Card = card,
        CardId = 1,
        Title = "two",
        Description = "second description note",
        Text = "second text note"
    };
    var noteOne3 = new Note()
    {
        CreatorId = 3,
        Card = card,
        CardId = 3,
        Title = "tree",
        Description = "third description note",
        Text = "third text note"
    };
    var noteOne4 = new Note()
    {
        CreatorId = 1,
        Card = card,
        CardId = 3,
        Title = "four",
        Description = "fourth description note",
        Text = "fourth text note"
    };
    var noteOne5 = new Note()
    {
        CreatorId = 2,
        Card = card,
        CardId = 2,
        Title = "five",
        Description = "fifth description note",
        Text = "fifth text note"
    };

    board.Cards.Add(card);
    board.Cards.Add(card2);
    board2.Cards.Add(card3);

    card.Notes.Add(noteOne);
    card.Notes.Add(noteOne2);
    card3.Notes.Add(noteOne3);
    card3.Notes.Add(noteOne4);
    card2.Notes.Add(noteOne5);


    db.Users.Add(user);
    db.Users.Add(user2);
    db.Users.Add(user3);

    db.Boards.Add(board);
    db.Boards.Add(board2);

    db.UserBoards.Add(userBoard);
    db.UserBoards.Add(userBoard2);
    db.UserBoards.Add(userBoard3);
    db.UserBoards.Add(userBoard4);

    //db.Cards.Add(card);
    //db.Cards.Add(card2);
    //db.Cards.Add(card3);

    //db.Notes.Add(noteOne);
    //db.Notes.Add(noteOne2);
    //db.Notes.Add(noteOne3);
    //db.Notes.Add(noteOne4);
    //db.Notes.Add(noteOne5);


    db.SaveChanges();
 */