using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cadastro_Jogador
{
    public partial class Edit : System.Web.UI.Page
    {
        Jogador jog;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var db = new Model1())
                {
                    jog = db.Jogadores.Find(Request.QueryString["id"]);
                }
            }

            using (var db = new Model1())
            {
                var q = Request.QueryString["id"];
                GridView1.DataSource = db.Documentos.Where(x => x.IDJogador == q).ToList();
                GridView1.DataBind();
            }

            TxTNome.Text = jog.Nome;
            TxTData.Text = jog.Nascimento;
            TxTEndereco.Text = jog.Endereco;
            TxTTime.Text = jog.Time;
            DropDownListPosicao.SelectedItem.Text = jog.Posicao;
            TxTTime.Text = jog.Time;
            TxTCPF.Text = jog.CPF;
            RangeValidatorData.MaximumValue = (System.DateTime.Today.AddYears(-18).ToString("d"));
            RangeValidatorData.MinimumValue = System.DateTime.Today.AddYears(-60).ToString("d");
        }


        private bool UploadArquivo()
        {
            if (FileUploadDoc.FileName != "")
            {
                FileUploadDoc.SaveAs((@"C:\Users\lcosta\Desktop\Cadastro Jogador\"
                    + FileUploadDoc.FileName).ToString());

                Documento doc = new Documento();
                doc.Caminho = @"C:\Users\lcosta\Desktop\Cadastro Jogador\" + FileUploadDoc.FileName;
                doc.Tipo = Tipos_de_arquivo.SelectedItem.ToString();

                using (var db = new Model1())
                {
                    var q = Request.QueryString["id"];
                    GridView1.DataSource = db.Documentos.Where(x => x.IDJogador == q).ToList();
                    GridView1.DataBind();
                }

                return true;
            }
            return false;
        }

        protected void BUpload(object sender, EventArgs e)
        {
            try
            {
                if (UploadArquivo())
                {
                    Status.Text = "Importação Realizada";
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