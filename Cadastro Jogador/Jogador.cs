using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cadastro_Jogador
{
    public class Jogador
    {
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public string endereco { get; set; }
        public string CPF { get; set; }
        public string posicao { get; set; }
        public string time { get; set; }
        public List<string> documentos = new List<string>();
    }
}