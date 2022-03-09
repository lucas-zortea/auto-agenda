using AgendaCec.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaCec.Data.Mappings
{
    public class EventoMap : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            // tabela
            builder.ToTable("Evento");

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

            // relacionamentos
            builder.HasOne(x => x.Instrutor)
                .WithMany(x => x.Eventos)
                .HasConstraintName("FK_Evento_Instrutor")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Turma)
                .WithMany(x => x.Eventos)
                .HasConstraintName("FK_Evento_Turma")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Local)
                .WithMany(x => x.Eventos)
                .HasConstraintName("FK_Evento_Local")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Disciplina)
                .WithMany(x => x.Eventos)
                .HasConstraintName("FK_Evento_Disciplina")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}