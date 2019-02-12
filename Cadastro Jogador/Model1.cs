namespace Cadastro_Jogador
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Documento> Documentos { get; set; }

        public Model1()
            : base("name=CadastroJogador")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

    }
    }
}
