using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cadastro_Jogador
{
    public class Documento
    {
        [Key]
        public string IDDocumento { get; set; }
        [ForeignKey("Jogador")]
        public string  IDJogador { get; set; }
        public Jogador Jogador { get; set; }
        public string Caminho { get; set; }
        public string Tipo { get; set; }
    }
}