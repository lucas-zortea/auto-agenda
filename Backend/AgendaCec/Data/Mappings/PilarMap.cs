using AgendaCec.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaCec.Data.Mappings
{
    public class PilarMap : IEntityTypeConfiguration<Pilar>
    {
        public void Configure(EntityTypeBuilder<Pilar> builder)
        {
            // tabela
            builder.ToTable("Pilar");

            // chave primária
            builder.HasKey(x => x.Id);

            // identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseMySqlIdentityColumn();

            // propriedades
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Cor)
                .IsRequired()
                .HasColumnName("Cor")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Slug)
                .IsRequired()
                .HasColumnName("Slug")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            // índices
            builder.HasIndex(x => x.Slug, "IX_Pilar_Slug")
                .IsUnique();

            // relacionamentos
            builder.HasMany(x => x.Areas)
                .WithOne(x => x.Pilar)
                .HasConstraintName("FK_Area_Pilar")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}