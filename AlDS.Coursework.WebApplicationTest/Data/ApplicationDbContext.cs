using AlDS.Coursework.Board.BoardModel;
using AlDS.Coursework.Board.RelatedTablesModel;
using AlDS.Coursework.Board.UserModel;
using AlDS.Coursework.DataBaseModels.EntityTypeConfigurations.BoardConfigurations;
using AlDS.Coursework.DataBaseModels.EntityTypeConfigurations.RelatedTablesConfigurations;
using AlDS.Coursework.DataBaseModels.EntityTypeConfigurations.UserConfigurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlDS.Coursework.WebApplicationTest.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public DbSet<Board.BoardModel.Board> Board { get; set; }
        public DbSet<Card> Card { get; set; }
        public DbSet<Note> Note { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserBoard> UserBoard { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BoardConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CardConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NoteConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserBoardConfiguration).Assembly);
        }
    }
}