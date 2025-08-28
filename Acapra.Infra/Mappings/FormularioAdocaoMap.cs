using Acapra.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Acapra.Domain.Enums;

namespace Acapra.Infra.Mappings
{
    public class FormularioAdocaoMap : IEntityTypeConfiguration<FormularioAdocaoModel>
    {
        public void Configure(EntityTypeBuilder<FormularioAdocaoModel> builder)
        {
            builder.ToTable("formulario_adocao");
            builder.HasKey(x => x.id);

            builder.Property(x => x.id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(x => x.titulo).HasColumnName("titulo").HasColumnType("varchar(255)").IsRequired();
            builder.Property(x => x.descricao).HasColumnName("descricao").HasColumnType("varchar(500)").IsRequired();
        }       
    } 
} 
