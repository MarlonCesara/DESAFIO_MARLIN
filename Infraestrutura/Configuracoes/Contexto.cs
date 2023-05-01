using Entidades.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Configuracoes
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes){}

        public DbSet<Turma> Turma { get; set; }
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<AlunoTurma> AlunoTurma { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
        }
        
        public string ObterStringConexao()
        {
            string strcon = "Data Source=DESKTOP-91PALS4;Initial Catalog=DESAFIO_MARLIN;Integrated Security=False;User ID=sa;Password=1234;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
            return strcon;
        }
    }
}
