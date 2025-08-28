using Acapra.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Acapra.Domain.Enums;

namespace Acapra.Infra.Mappings
{
    public class FormularioPerguntaMap : IEntityTypeConfiguration<FormularioPerguntaModel>
    {
        public void Configure(EntityTypeBuilder<FormularioPerguntaModel> builder)
        {
            builder.ToTable("formulario_perguntas");
            builder.HasKey(x => x.id);
            builder.HasIndex(x => x.formulario_adocao_id);
            builder.HasOne<FormularioAdocaoModel>().WithMany().HasForeignKey(x => x.id);

            builder.Property(x => x.id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(x => x.formulario_adocao_id).HasColumnName("formulario_adocao_id").HasColumnType("int").IsRequired();
            builder.Property(x => x.pergunta).HasColumnName("pergunta").HasColumnType("varchar(500)").IsRequired();
            builder.Property(x => x.obrigatorio).HasColumnName("obrigatorio").HasColumnType("tinyint(1)").IsRequired();
            builder.Property(x => x.tipo_resposta)
            .HasConversion(
                v => v.ToString().ToLower(),
                v => (TipoResposta)Enum.Parse(typeof(TipoResposta), v, true)

            )
            .HasColumnType("enum('Texto','Múltipla Escolha','Selecionar','Booleano')").IsRequired();
        }       
    } 
} 
