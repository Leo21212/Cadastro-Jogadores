using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;
using System.Data;

namespace Cadastro_Jogador
{
    public partial class Cadastro : System.Web.UI.Page
    {
        Jogador jogador = new Jogador();

        protected void Page_Load(object sender, EventArgs e)
        {
            RangeValidator1.MaximumValue= (System.DateTime.Today.AddYears(-18).ToString("d"));
            RangeValidator1.MinimumValue = System.DateTime.Today.AddYears(-60).ToString("d");

           
        }

        private bool UploadArquivo()
        {
            if (FileUpload1.FileName !="") {
                FileUpload1.SaveAs((@"C:\Users\lcosta\Desktop\Cadastro Jogador\"
                    + FileUpload1.FileName).ToString());

                var nome = FileUpload1.FileName;
                jogador.documentos.Add(nome);
                return true;
            }
            return false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (UploadArquivo())
                {
                    Status.Text = "Importação realizada";
                }
                else
                {
                    Status.Text = "Não foi possível realizar a importação do arquivo";
                }
            }

            catch (Exception)
            {

                throw;
            }
        }
    }
}