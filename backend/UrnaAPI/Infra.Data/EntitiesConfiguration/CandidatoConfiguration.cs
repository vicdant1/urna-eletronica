using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.EntitiesConfiguration
{
    public class CandidatoConfiguration : IEntityTypeConfiguration<Candidato>
    {
        public void Configure(EntityTypeBuilder<Candidato> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(c => c.NomeCompleto).HasMaxLength(100).IsRequired();
            builder.Property(c => c.NomeVice).HasMaxLength(100).IsRequired();
        }
    }
}
