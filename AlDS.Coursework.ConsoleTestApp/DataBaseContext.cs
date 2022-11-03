using AlDS.Coursework.Board;
using AlDS.Coursework.DataBaseModels.EntityTypeConfigurations.BoardConfigurations;
using AlDS.Coursework.DataBaseModels.EntityTypeConfigurations.UserConfigurations;
using AlDS.Coursework.DataBaseModels.EntityTypeConfigurations.RelatedTablesConfigurations;
using Microsoft.EntityFrameworkCore;
using AlDS.Coursework.Board.BoardModel;
using AlDS.Coursework.Board.UserModel;
using AlDS.Coursework.Board.RelatedTablesModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace AlDS.Coursework.Test
{
    public class DataBaseContext : IdentityDbContext<User, IdentityRole, string>
    {
        public DbSet<Board.BoardModel.Board> Board { get; set; }
        public DbSet<Card> Card { get; set; }
        public DbSet<Note> Note { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserBoard> UserBoard { get; set; }


        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options) { }

        public DataBaseContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Database=TestProject_AlDStwo; Persist Security Info=false; User ID='sa'; Password='sa'; MultipleActiveResultSets=True; Trusted_Connection=False;";
            optionsBuilder.UseSqlServer(connectionString);
        }
        
            //Alds_TestProject
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
/*
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder
        .Entity<BlogPostsCount>(
            eb =>
            {
                eb.HasNoKey();
                eb.ToView("View_BlogPostCounts");
                eb.Property(v => v.BlogName).HasColumnName("Name");
            });
}
 */