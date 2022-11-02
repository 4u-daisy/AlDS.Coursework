using AlDS.Coursework.Board.BoardModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlDS.Coursework.DataBaseModels.EntityTypeConfigurations.BoardConfigurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.NoteId);
            //entityTypeBuilder.HasIndex(x => x.NoteId);
            entityTypeBuilder
                .Property(x => x.NoteId)
                .IsRequired();
            entityTypeBuilder
                .Property(x => x.Title)
                .HasMaxLength(63);
            entityTypeBuilder
                .Property(x => x.Description)
                .HasMaxLength(127);
            entityTypeBuilder
                .Property(x => x.Text)
                .HasMaxLength(1023);
            entityTypeBuilder
                .Property(x => x.Comment)
                .HasMaxLength(257);
            entityTypeBuilder
                .Property(x => x.DateCreated)
                .IsRequired();
        }
    }
}
