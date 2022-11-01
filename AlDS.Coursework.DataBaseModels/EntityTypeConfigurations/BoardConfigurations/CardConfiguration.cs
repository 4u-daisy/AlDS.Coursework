using AlDS.Coursework.Board.BoardModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlDS.Coursework.DataBaseModels.EntityTypeConfigurations.BoardConfigurations
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.CardId);
            entityTypeBuilder.HasIndex(x => x.CardId);
            entityTypeBuilder
                .HasMany(x => x.Notes)
                .WithOne(x => x.Card)
                .HasForeignKey(x => x.CardId);
            entityTypeBuilder
                .Property(x => x.CardId)
                .IsRequired()
                .ValueGeneratedOnAdd();
            entityTypeBuilder
                .Property(x => x.Title)
                .HasMaxLength(63);
            entityTypeBuilder
                .Property(x => x.Description)
                .HasMaxLength(127);
            entityTypeBuilder
                .Property(x => x.DateCreated)
                .IsRequired();
        }
    }
}
