using Acapra.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acapra.Infra.Mappings
{
    public class FormularioRespostasMap : IEntityTypeConfiguration<FormularioRespostasModel>
    {
        public void Configure(EntityTypeBuilder<FormularioRespostasModel> builder)
        {
            builder.ToTable("formulario_respostas");
            builder.HasKey(x => x.id);

            builder.HasIndex(x => x.usuarioId);
            builder.HasOne<UsuarioModel>().WithMany().HasForeignKey(x => x.usuarioId);

            builder.HasIndex(x => x.formularioPerguntaId);
            builder.HasOne<FormularioPerguntaModel>().WithMany().HasForeignKey(x => x.formularioPerguntaId);

            builder.Property(x => x.id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(x => x.usuarioId).HasColumnName("usuario_id").HasColumnType("int").IsRequired();
            builder.Property(x => x.formularioPerguntaId).HasColumnName("formulario_perguntas_id").HasColumnType("int").IsRequired();
            builder.Property(x => x.resposta).HasColumnName("resposta").HasColumnType("varchar(500)").IsRequired();
            builder.Property(x => x.ultimaAlteracao).HasColumnName("ultima_alteracao").HasColumnType("datetime").IsRequired();
        }
    }
}
