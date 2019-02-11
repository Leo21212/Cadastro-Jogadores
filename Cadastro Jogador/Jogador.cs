using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Cadastro_Jogador
{
    public class Jogador
    {
        public string ID { get; set; }
        public string Nome { get; set; }
        public string Nascimento { get; set; }
        public string Endereco { get; set; }
        public string CPF { get; set; }
        public string Posicao { get; set; }
        public string Time { get; set; }
    }

    public class CadastroContext : DbContext
    {
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Documento> Documentos { get; set; }
    }
}