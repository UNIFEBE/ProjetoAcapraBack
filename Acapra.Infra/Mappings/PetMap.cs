using Acapra.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Acapra.Domain.Enums;

namespace Acapra.Infra.Mappings
{
    public class PetMap : IEntityTypeConfiguration<PetModel>
    {
        public void Configure(EntityTypeBuilder<PetModel> builder)
        {
            builder.ToTable("pet");

            builder.HasKey(x => x.id);

            builder.Property(x => x.id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(x => x.nome).HasColumnName("nome").HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.descricao).HasColumnName("descricao").HasColumnType("varchar(45)").IsRequired();
            builder.Property(x => x.sexo).HasColumnName("sexo").HasColumnType("varchar(32)").IsRequired();
            builder.Property(x => x.raca).HasColumnName("raca").HasColumnType("varchar(70)").IsRequired();
            builder.Property(x => x.data_nascimento).HasColumnName("data_nascimento").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.pelagem).HasColumnName("pelagem").HasColumnType("varchar(45)").IsRequired();
            builder.Property(x => x.castrado).HasColumnName("castrado").HasColumnType("tinyint(1)").IsRequired();
            builder.Property(x => x.vacinado).HasColumnName("vacinado").HasColumnType("tinyint(1)").IsRequired();
            builder.Property(x => x.status)
                   .HasConversion(
                       v => v.ToString().ToLower(),
                       v => (StatusPet)Enum.Parse(typeof(StatusPet), v, true)
                   )
                   .HasColumnType("enum('disponivel','adotado','resgatado')")
                   .IsRequired();
        }       
    } 
} 
