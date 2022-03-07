using AgendaCec.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaCec.Data.Mappings
{
    public class DisciplinaMap : IEntityTypeConfiguration<Disciplina>
    {
        public void Configure(EntityTypeBuilder<Disciplina> builder)
        {
            // tabela
            builder.ToTable("Disciplina");

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

            // índices
            builder.HasIndex(x => x.Slug, "IX_Disciplina_Slug")
                .IsUnique();

            // relacionamentos
            builder.HasOne(x => x.Area)
                .WithMany(x => x.Disciplinas)
                .HasConstraintName("FK_Instrutor_Pilar")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}