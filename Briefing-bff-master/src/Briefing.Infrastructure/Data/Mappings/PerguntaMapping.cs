using Briefing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Briefing.Infrastructure.Data.Mappings
{
    public class PerguntaMapping: IEntityTypeConfiguration<Pergunta>
    {
        public void Configure(EntityTypeBuilder<Pergunta> builder)
        {

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Display).HasColumnType("Varchar(100)").IsRequired();

            builder.ToTable("Pergunta");
        }
    }
}
