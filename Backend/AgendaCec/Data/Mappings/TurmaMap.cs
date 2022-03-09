using AgendaCec.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaCec.Data.Mappings
{
    public class TurmaMap : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            // tabela
            builder.ToTable("Turma");

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

            builder.Property(x => x.DataInicio)
                .IsRequired()
                .HasColumnName("DataInicio")
                .HasColumnType("DATETIME")
                // .HasDefaultValueSql("NOW()");
                .HasDefaultValue(DateTime.Now.ToUniversalTime());

            builder.Property(x => x.DataFim)
                .IsRequired()
                .HasColumnName("DataFim")
                .HasColumnType("DATETIME")
                // .HasDefaultValueSql("NOW()");
                .HasDefaultValue(DateTime.Now.ToUniversalTime());

            builder.Property(x => x.NumeroAlunos)
                .IsRequired()
                .HasColumnName("NumeroAlunos")
                .HasColumnType("INT");

            // relacionamentos
            builder.HasMany(x => x.Disciplinas)
                .WithMany(x => x.Turmas)
                .UsingEntity<Dictionary<string, object>>(
                    "TurmaDisciplina",
                    turma => turma.HasOne<Disciplina>()
                        .WithMany()
                        .HasForeignKey("TurmaId")
                        .HasConstraintName("FK_TurmaDisciplina_TurmaId")
                        .OnDelete(DeleteBehavior.Cascade),
                    disciplina => disciplina.HasOne<Turma>()
                        .WithMany()
                        .HasForeignKey("DisciplinaId")
                        .HasConstraintName("FK_TurmaDisciplina_DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                );
        }
    }
}