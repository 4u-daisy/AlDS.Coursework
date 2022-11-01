using AlDS.Coursework.Board;
using AlDS.Coursework.DataBaseModels.EntityTypeConfigurations.BoardConfigurations;
using AlDS.Coursework.DataBaseModels.EntityTypeConfigurations.UserConfigurations;
using AlDS.Coursework.DataBaseModels.EntityTypeConfigurations.RelatedTablesConfigurations;
using Microsoft.EntityFrameworkCore;
using AlDS.Coursework.Board.BoardModel;
using AlDS.Coursework.Board.UserModel;
using AlDS.Coursework.Board.RelatedTablesModel;

namespace AlDS.Coursework.Test
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Board.BoardModel.Board> Boards { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserBoard> UserBoards { get; set; }


        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options) { }

        public DataBaseContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Database=Alds_TestProject; Persist Security Info=false; User ID='sa'; Password='sa'; MultipleActiveResultSets=True; Trusted_Connection=False;";
            optionsBuilder.UseSqlServer(connectionString);
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
