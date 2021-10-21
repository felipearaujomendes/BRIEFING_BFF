using Briefing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Briefing.Infrastructure.Data.Mappings
{
    public class RespostaMapping : IEntityTypeConfiguration<Resposta>
    {
        public void Configure(EntityTypeBuilder<Resposta> builder)
        {

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Valor).HasColumnType("Varchar(100)").IsRequired();

        }
    }
}
