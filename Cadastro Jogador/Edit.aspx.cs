using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
                using (var db = new ConexaoDB())
                {
                    jog = db.Jogadores.Find(Request.QueryString["id"]);
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
        }


        private bool UploadArquivo()
        {
            var q = Request.QueryString["id"];
            if (FileUploadDoc.FileName != "")
            {
                if (!Directory.Exists(@"C:\Users\lcosta\Documents\ArquivosImportados\" + q))
                    Directory.CreateDirectory(@"C:\Users\lcosta\Documents\ArquivosImportados\" + q);

                FileUploadDoc.SaveAs((@"C:\Users\lcosta\Documents\ArquivosImportados\" +
                     q + @"\" + FileUploadDoc.FileName).ToString());

                Documento doc = new Documento();
                doc.Caminho = @"C:\Users\lcosta\Documents\ArquivosImportados\" +
                  q + @"\" + FileUploadDoc.FileName;
                doc.Tipo = Tipos_de_arquivo.SelectedItem.ToString();
                doc.IDJogador = Request.QueryString["id"];
                doc.IDDocumento = Guid.NewGuid().ToString();

                using (var db = new ConexaoDB())
                {
                    db.Documentos.Add(doc);
                    db.SaveChanges();
                    q = Request.QueryString["id"];
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var l = GridView1.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
            using (var db = new ConexaoDB())
            {
                var d = db.Documentos.Find(l);
                db.Documentos.Remove(d);
                db.SaveChanges();
                System.IO.File.Delete(d.Caminho);
                var q = Request.QueryString["id"];
                GridView1.DataSource = db.Documentos.Where(x => x.IDJogador == q).ToList();
                GridView1.DataBind();

            }
        }

        protected void Voltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Listagem.aspx");
        }

        protected void Salvar_Click(object sender, EventArgs e)
        {
            using (var db = new ConexaoDB())
            {
                var q = Request.QueryString["id"];
                foreach (Jogador d in db.Jogadores.Where(x => x.ID == q).ToList())
                {
                    d.Nome = TxTNome.Text;
                    d.Nascimento = TxTData.Text;
                    d.Endereco = TxTEndereco.Text;
                    d.CPF = TxTCPF.Text;
                    d.Posicao = DropDownListPosicao.SelectedItem.Text;
                    d.Time = TxTTime.Text;
                }
                db.SaveChanges();
                Response.Redirect("Listagem.aspx");
            }
        }

        protected void Deletar_Click(object sender, EventArgs e)
        {
            using (var db = new ConexaoDB())
            {
                var q = Request.QueryString["id"];
                db.Documentos.RemoveRange(db.Documentos.Where(x => x.IDJogador==q));
                db.Jogadores.RemoveRange(db.Jogadores.Where(x => x.ID == q));
                System.IO.File.Delete(@"C:\Users\lcosta\Documents\ArquivosImportados\" +
                      q);
                db.SaveChanges();
                Response.Redirect("Listagem.aspx");
            }
        }
    }
}