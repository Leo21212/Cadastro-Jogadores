using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Cadastro_Jogador
{
    public class Documento
    {
        [Key]
        public string IDJogador { get; set; }
        public string Caminho { get; set; }
        public string Tipo { get; set; }
    }
}