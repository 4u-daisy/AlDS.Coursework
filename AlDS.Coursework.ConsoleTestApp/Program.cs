using AlDS.Coursework.Board.UserModel;
using AlDS.Coursework.Test;

//using AlDS.Coursework.RelatedTables;
//using Microsoft.EntityFrameworkCore.Design;


using (DataBaseContext db = new DataBaseContext())
{
    var user = new User();
    user.Password = "126653";
    user.Email = "Dasha6163@email.ru";

    db.Users.Add(user);

    db.SaveChangesAsync();

}

Console.WriteLine("Hello.");