using AlDS.Coursework.Board.UserModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlDS.Coursework.DataBaseModels.EntityTypeConfigurations.UserConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.UserId);
            entityTypeBuilder.HasIndex(x => x.UserId);
            entityTypeBuilder
                .Property(x => x.UserId)
                .IsRequired()
                .ValueGeneratedOnAdd();
            entityTypeBuilder
                .Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(63);
            entityTypeBuilder
                .Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(63);
            entityTypeBuilder
                .Property(x => x.Nickname)
                .HasMaxLength(63);
            entityTypeBuilder
                .Property(x => x.Address)
                .HasMaxLength(127);
            entityTypeBuilder
                .Property(x => x.Name)
                .HasMaxLength(63);
            entityTypeBuilder
                .Property(x => x.Firstname)
                .HasMaxLength(63);
            entityTypeBuilder
                .Property(x => x.Middlename)
                .HasMaxLength(63);
            entityTypeBuilder
                .Property(x => x.Information)
                .HasMaxLength(253);
        }
    }
}
