using AgendaCec.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaCec.Data
{
    public class AgendaCecDataContext : DbContext
    {
        public DbSet<Area> Areas { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Instrutor> Instrutores { get; set; }
        public DbSet<Local> Locais { get; set; }
        public DbSet<Pilar> Pilares { get; set; }
        public DbSet<Turma> Turmas { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder options)
            => options.UseMySql("server=localhost;user=root;password=Dreadmin;database=agenda-cec",
            new MySqlServerVersion(new Version(8, 0, 27)));
    }
}