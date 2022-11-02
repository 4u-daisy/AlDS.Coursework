using AlDS.Coursework.Board.RelatedTablesModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlDS.Coursework.DataBaseModels.EntityTypeConfigurations.RelatedTablesConfigurations
{
    public class UserBoardConfiguration : IEntityTypeConfiguration<UserBoard>
    {
        public void Configure(EntityTypeBuilder<UserBoard> entityTypeBuilder)
        {
            entityTypeBuilder
                .HasKey(x => x.Key)
                .HasName("PRIMARY KEY");

            entityTypeBuilder
                .HasOne(x => x.User)
                .WithMany(x => x.UserBoards)
                .HasForeignKey(x => x.UserId);

            entityTypeBuilder
                .HasOne(x => x.Board)
                .WithMany(x => x.UserBoards)
                .HasForeignKey(x => x.BoardId);
        }
    }
}
