using AspMovie.DataAccess.Configurations;
using AspMovie.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AspMovie.DataAccess.Specifications
{
    public class ActorConfiguration : EntityConfiguration<Actor>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(x=>x.Born).IsRequired(false);
            builder.Property(x=>x.Biography).HasMaxLength(250).IsRequired(false);

            builder.HasMany(x=>x.ActorMovies)
                   .WithOne(x => x.Actor)
                   .HasForeignKey(x=>x.ActorId)
                   .OnDelete(DeleteBehavior.Restrict); 
            
        }
    }

    
}
