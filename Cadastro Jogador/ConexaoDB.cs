namespace Cadastro_Jogador
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ConexaoDB : DbContext
    {
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Documento> Documentos { get; set; }

        public ConexaoDB()
            : base("name=CadastroJogador")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
