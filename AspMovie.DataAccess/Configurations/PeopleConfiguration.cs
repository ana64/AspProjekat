using AspMovie.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AspMovie.DataAccess.Configurations
{
    public abstract class PeopleConfiguration : EntityConfiguration<People>
    {
        protected override void ConfigureRules(EntityTypeBuilder<People> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(40).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();
        }
    }
}
