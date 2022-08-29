using AspMovie.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspMovie.DataAccess.Configurations
{
    public class CertificateConfiguration : IEntityTypeConfiguration<Certification>
    {
        public void Configure(EntityTypeBuilder<Certification> builder)
        {
            builder.Property(x => x.Certificate).IsRequired();
            builder.HasIndex(x=>x.Certificate).IsUnique();

            builder.HasData(
                    new Certification { CertificationId = 1, Certificate = "G" },
                    new Certification { CertificationId = 2, Certificate = "PG" },
                    new Certification { CertificationId = 3, Certificate = "PG-13" },
                    new Certification { CertificationId = 4, Certificate = "R" }
                );
        }
    }
}
