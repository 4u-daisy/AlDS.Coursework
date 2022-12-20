using AlDS.Coursework.Board.UserModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlDS.Coursework.DataBaseModels.EntityTypeConfigurations.UserConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            //entityTypeBuilder.HasIndex(x => x.Id);
            entityTypeBuilder
                .Property(x => x.Id)
                .IsRequired();
            entityTypeBuilder
                .Property(x => x.PasswordHash)
                .IsRequired()
                .HasMaxLength(127);
            entityTypeBuilder
                .Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(63);
            entityTypeBuilder
                .Property(x => x.UserName)
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
