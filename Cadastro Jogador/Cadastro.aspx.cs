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
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dtb = new DataTable();
            List<Documento> DocList = new List<Documento>();

            dtb = CriaDataTable();
            if (Session["mDatatable"] == null)
                Session["mDatatable"] = dtb;
            else
                dtb = (DataTable)Session["mDatatable"];

            if (Session["mDocs"] == null)
                Session["mDocs"] = DocList;
            else
                DocList = (List<Documento>)Session["mDocs"];

            this.GridView1.DataSource = ((DataTable)Session["mDatatable"]).DefaultView;
            this.GridView1.DataBind();
            RangeValidatorData.MaximumValue = (System.DateTime.Today.AddYears(-18).ToString("d"));
            RangeValidatorData.MinimumValue = System.DateTime.Today.AddYears(-60).ToString("d");
        }

        private DataTable CriaDataTable()

        {
            DataTable mDataTable = new DataTable();
            DataColumn mDataColumn;
            mDataColumn = new DataColumn();
            mDataColumn.DataType = Type.GetType("System.String");
            mDataColumn.ColumnName = "Caminho do Arquivo";
            mDataTable.Columns.Add(mDataColumn);
            mDataColumn = new DataColumn();
            mDataColumn.DataType = Type.GetType("System.String");
            mDataColumn.ColumnName = "Tipo do Arquivo";
            mDataTable.Columns.Add(mDataColumn);
            return mDataTable;

        }

        private bool UploadArquivo()
        {
            if (FileUploadDoc.FileName != "")
            {
                FileUploadDoc.SaveAs((@"C:\Users\lcosta\Desktop\Cadastro Jogador\"
                    + FileUploadDoc.FileName).ToString());

                List<Documento> newDoc = (List<Documento>)Session["mDocs"];
                Documento doc = new Documento();
                doc.Caminho = @"C:\Users\lcosta\Desktop\Cadastro Jogador\" + FileUploadDoc.FileName;
                doc.Tipo = Tipos_de_arquivo.SelectedItem.ToString();
                newDoc.Add(doc);
                Session["mDocs"] = newDoc;
                DataTable dtb = (DataTable)Session["mDatatable"];
                DataRow row = dtb.NewRow();
                row["Caminho do Arquivo"] = FileUploadDoc.FileName;
                row["Tipo do Arquivo"] = Tipos_de_arquivo.SelectedItem.ToString();
                dtb.Rows.Add(row);
                Session["mDatatable"] = dtb;

                GridView1.DataSource = ((DataTable)Session["mDatatable"]).DefaultView;

                GridView1.DataBind();

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

        protected void Voltar_Click(object sender, EventArgs e)
        {
            Session["mDatatable"] = null;
            Session["mDocs"] = null;
            Response.Redirect("Tela Inicial.aspx");
        }

        protected void Salvar_Click(object sender, EventArgs e)
        {
            if (RangeValidatorData.IsValid &&
                    RegularExpressionValidatorCPF.IsValid &&
                    TxTNome.Text != "" &&
                    TxTData.Text != "" &&
                    TxTEndereco.Text != "" &&
                    TxTCPF.Text != "" &&
                    TxTTime.Text != "")
            {
                using (var db = new CadastroContext())
                {
                    var queryID = "";

                    queryID = "@SELECT NewID()";

                    Jogador jogador = new Jogador();
                    jogador.ID = queryID;
                    jogador.Nome = TxTNome.Text;
                    jogador.Nascimento = TxTData.Text;
                    jogador.Endereco = TxTEndereco.Text;
                    jogador.CPF = TxTCPF.Text;
                    jogador.Posicao = DropDownListPosicao.SelectedItem.Text;
                    jogador.Time = TxTTime.Text;
                    List<Documento> newDoc2 = (List<Documento>)Session["mDocs"];
                    foreach (Documento d in newDoc2)
                    {
                        d.IDJogador = jogador.ID;
                        db.Documentos.Add(d);
                    }
                    db.Jogadores.Add(jogador);

                    db.SaveChanges();

                    Session["mDatatable"] = null;
                    Session["mDocs"] = null;
                    Response.Redirect("Tela Inicial.aspx");



                }
            }
        }
    }
}