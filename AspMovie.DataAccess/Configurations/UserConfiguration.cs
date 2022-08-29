using AspMovie.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AspMovie.DataAccess.Configurations
{
    public class UserConfiguration : EntityConfiguration<User>
    {

        protected override void ConfigureRules(EntityTypeBuilder<User> builder)
        {

            builder.Property(x => x.Email).HasMaxLength(50).IsRequired();

            builder.HasIndex(x => x.Email).IsUnique();

            builder.HasMany(x => x.UseCases).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        }
    }
}
