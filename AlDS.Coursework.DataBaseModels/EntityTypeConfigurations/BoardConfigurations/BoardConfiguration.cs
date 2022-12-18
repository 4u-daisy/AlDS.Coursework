using AlDS.Coursework.Board.BoardModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlDS.Coursework.DataBaseModels.EntityTypeConfigurations.BoardConfigurations
{
    public class BoardConfiguration : IEntityTypeConfiguration<AlDS.Coursework.Board.BoardModel.Board>
    {
        public void Configure(EntityTypeBuilder<AlDS.Coursework.Board.BoardModel.Board> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.BoardId);
            entityTypeBuilder
                .HasMany(x => x.Cards)
                .WithOne(x => x.Board)
                .HasForeignKey(x => x.BoardId);
            entityTypeBuilder
                .Property(x => x.BoardId)
                .IsRequired();
            entityTypeBuilder
                .Property(x => x.Title)
                .HasMaxLength(63);
            entityTypeBuilder
                .Property(x => x.Description)
                .HasMaxLength(127);
            entityTypeBuilder
                .Property(x => x.Space)
                .HasMaxLength(63);
            entityTypeBuilder
                .Property(x => x.DateCreated)
                .IsRequired();
        }
    }
}
