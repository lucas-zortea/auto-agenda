using AgendaCec.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaCec.Data.Mappings
{
    public class LocalMap : IEntityTypeConfiguration<Local>
    {
        public void Configure(EntityTypeBuilder<Local> builder)
        {
            // tabela
            builder.ToTable("Local");

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

            builder.Property(x => x.Slug)
                .IsRequired()
                .HasColumnName("Slug")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Informatizada)
                .IsRequired()
                .HasColumnName("Informatizada")
                .HasColumnType("TINYINT");

            builder.Property(x => x.Capacidade)
                .IsRequired()
                .HasColumnName("Capacidade")
                .HasColumnType("INT");

            // índices
            builder.HasIndex(x => x.Slug, "IX_Local_Slug")
                .IsUnique();
        }
    }
}