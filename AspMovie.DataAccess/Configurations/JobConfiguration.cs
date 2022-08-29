using AspMovie.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AspMovie.DataAccess.Configurations
{
    public class JobConfiguration : EntityConfiguration<Job>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Job> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(40).IsRequired();
            builder.HasIndex(x=>x.Name).IsUnique();

            builder.HasData(
                 new Job { Id=1,Name ="director",CreatedAt=System.DateTime.UtcNow},
                 new Job { Id=2,Name = "producer", CreatedAt = System.DateTime.UtcNow },
                 new Job {Id=3, Name = "screenplay" , CreatedAt = System.DateTime.UtcNow },
                 new Job {Id = 4, Name = "script",CreatedAt = System.DateTime.UtcNow }
                );
        }
    }
}
