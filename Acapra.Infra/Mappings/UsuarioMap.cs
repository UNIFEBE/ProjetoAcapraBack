using Acapra.Domain.Entities;
using Acapra.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Acapra.Infra.Mappings
{
       public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
       {
              public void Configure(EntityTypeBuilder<UsuarioModel> builder)
              {
                     builder.ToTable("usuario");

                     builder.HasKey(x => x.id);

                     builder.Property(x => x.id)
                            .HasColumnName("id")
                            .HasColumnType("int")
                            .IsRequired();

                     builder.Property(x => x.nome)
                            .HasColumnName("nome")
                            .HasColumnType("varchar(100)")
                            .IsRequired();

                     builder.Property(x => x.email)
                            .HasColumnName("email")
                            .HasColumnType("varchar(100)")
                            .IsRequired();

                     builder.Property(x => x.cpf)
                            .HasColumnName("cpf")
                            .HasColumnType("varchar(20)")
                            .IsRequired();

                     builder.Property(x => x.celular)
                            .HasColumnName("celular")
                            .HasColumnType("varchar(20)");

                     builder.Property(x => x.telefone)
                            .HasColumnName("telefone")
                            .HasColumnType("varchar(20)");

                     builder.Property(x => x.senha)
                            .HasColumnName("senha")
                            .HasColumnType("varchar(255)")
                            .IsRequired();

                     builder.Property(x => x.tipo_usuario)
                            .HasConversion(
                            v => v.ToString().ToLower(),
                            v => (TipoUsuario)Enum.Parse(typeof(TipoUsuario), v, true)
                            )
                            .HasColumnName("tipo_usuario")
                            .HasColumnType("enum('administrador','voluntario','adotante')")
                            .IsRequired();

                     builder.Property(x => x.ativo)
                            .HasColumnName("ativo")
                            .HasColumnType("tinyint(1)")
                            .IsRequired();

                     builder.Property(x => x.cep)
                            .HasColumnName("cep")
                            .HasColumnType("varchar(9)");

                     builder.Property(x => x.cidade)
                            .HasColumnName("cidade")
                            .HasColumnType("varchar(70)");

                     builder.Property(x => x.estado)
                            .HasColumnName("estado")
                            .HasColumnType("varchar(2)");

                     builder.Property(x => x.bairro)
                            .HasColumnName("bairro")
                            .HasColumnType("varchar(70)");

                     builder.Property(x => x.endereco)
                            .HasColumnName("endereco")
                            .HasColumnType("varchar(150)");

                     builder.Property(x => x.complemento)
                            .HasColumnName("complemento")
                            .HasColumnType("varchar(100)");

                     builder.Property(x => x.numero)
                            .HasColumnName("numero")
                            .HasColumnType("varchar(45)");
              }
       }
}
