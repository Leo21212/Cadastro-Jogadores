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
        public string Endereco { get; set; }
        public string CPF { get; set; }
        public string Posicao { get; set; }
        public string Time { get; set; }
        public List<Documento> Documentos { get => documentos; set => documentos = value; }
        private List<Documento> documentos = new List<Documento>();
    }
}