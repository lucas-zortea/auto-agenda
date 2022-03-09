using AgendaCec.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaCec.Data.Mappings
{
    public class InstrutorMap : IEntityTypeConfiguration<Instrutor>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Instrutor> builder)
        {
            // tabela
            builder.ToTable("Instrutor");

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

            builder.Property(x => x.Apelido)
                .IsRequired()
                .HasColumnName("Apelido")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Disponivel)
                .IsRequired()
                .HasColumnName("Disponivel")
                .HasColumnType("TINYINT");

            // indíces
            builder.HasIndex(x => x.Slug, "IX_Instrutor_Slug")
                .IsUnique();

            // relacionamentos
            builder.HasOne(x => x.Pilar)
                .WithMany(x => x.Instrutores)
                .HasConstraintName("FK_Instrutor_Pilar")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Disciplinas)
                .WithMany(x => x.Instrutores)
                .UsingEntity<Dictionary<string, object>>(
                    "InstrutorDisciplina",
                    instrutor => instrutor.HasOne<Disciplina>()
                        .WithMany()
                        .HasForeignKey("InstrutorId")
                        .HasConstraintName("FK_InstrutorDisciplina_InstrutorId")
                        .OnDelete(DeleteBehavior.Cascade),
                    disciplina => disciplina.HasOne<Instrutor>()
                        .WithMany()
                        .HasForeignKey("DisciplinaId")
                        .HasConstraintName("FK_InstrutorDisciplina_DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                );
        }
    }
}