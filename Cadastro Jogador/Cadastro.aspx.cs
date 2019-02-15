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
        //DataTable DOCtable = new DataTable();
        //List<Documento> newDoc = new List<Documento>();
        Jogador jogador = new Jogador();
        protected void Page_Load(object sender, EventArgs e)
        {
            //DataTable dtb = new DataTable();
            //List<Documento> DocList = new List<Documento>();

            //dtb = CriaDataTable();
            //if (Session["mDatatable"] == null)
            //    Session["mDatatable"] = dtb;
            //else
            //    dtb = (DataTable)Session["mDatatable"];

            //if (Session["mDocs"] == null)
            //    Session["mDocs"] = DocList;
            //else
            //    DocList = (List<Documento>)Session["mDocs"];

            //this.GridDOC.DataSource = ((DataTable)Session["mDatatable"]).DefaultView;
            //this.GridDOC.DataBind();


            RangeValidatorData.MaximumValue = (System.DateTime.Today.AddYears(-18).ToString("d"));
            RangeValidatorData.MinimumValue = System.DateTime.Today.AddYears(-60).ToString("d");

            using (var db = new ConexaoDB())
            {
                var q = db.Jogadores.Any(x => x.CPF == null);

                if (q == false)
                {
                    jogador.ID = Guid.NewGuid().ToString();
                    db.Jogadores.Add(jogador);
                }

                else
                {
                    foreach (Jogador j in db.Jogadores.Where(x => x.CPF == null).ToList())
                        jogador.ID = j.ID;
                }
                db.SaveChanges();
                GridDOC.DataSource = db.Documentos.Where(x => x.IDJogador == jogador.ID).ToList();
                GridDOC.DataBind();
            }
        }

        //private DataTable CriaDataTable()

        //{
        //    DataTable mDataTable = new DataTable();
        //    DataColumn mDataColumn = new DataColumn();
        //    mDataColumn.DataType = Type.GetType("System.String");
        //    mDataColumn.ColumnName = "NOME";
        //    mDataTable.Columns.Add(mDataColumn);
        //    mDataColumn = new DataColumn();
        //    mDataColumn.DataType = Type.GetType("System.String");
        //    mDataColumn.ColumnName = "Tipo do Arquivo";
        //    mDataTable.Columns.Add(mDataColumn);
        //    return mDataTable;

        //}

        private bool UploadArquivo()
        {
            if (FileUploadDoc.FileName != "")
            {
                using (var db = new ConexaoDB())
                {


                    if (!Directory.Exists(@"C:\Users\lcosta\Documents\ArquivosImportados\" + jogador.ID))
                        Directory.CreateDirectory(@"C:\Users\lcosta\Documents\ArquivosImportados\" + jogador.ID);

                    FileUploadDoc.SaveAs((@"C:\Users\lcosta\Documents\ArquivosImportados\" +
                      jogador.ID + @"\" + FileUploadDoc.FileName).ToString());

                    //List<Documento> newDoc = (List<Documento>)Session["mDocs"];
                    Documento doc = new Documento();
                    doc.IDDocumento = Guid.NewGuid().ToString();
                    doc.Caminho = @"C:\Users\lcosta\Documents\ArquivosImportados\" +
                      jogador.ID + @"\" + FileUploadDoc.FileName;
                    doc.Tipo = Tipos_de_arquivo.SelectedItem.ToString();
                    doc.IDJogador = jogador.ID;
                    //newDoc.Add(doc);
                    //Session["mDocs"] = newDoc;
                    //DataTable dtb = (DataTable)Session["mDatatable"];
                    //DataRow row = dtb.NewRow();
                    //row["NOME"] = FileUploadDoc.FileName;
                    //row["Tipo do Arquivo"] = Tipos_de_arquivo.SelectedItem.ToString();
                    //dtb.Rows.Add(row);
                    //Session["mDatatable"] = dtb;


                    db.Documentos.Add(doc);
                    db.SaveChanges();
                    GridDOC.DataSource = db.Documentos.Where(x => x.IDJogador == jogador.ID).ToList();
                    GridDOC.DataBind();
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

        protected void Voltar_Click(object sender, EventArgs e)
        {
            //Session["mDatatable"] = null;
            //Session["mDocs"] = null;
            using (var db = new ConexaoDB())
            {
                foreach(var joga in db.Jogadores.Where(x => x.CPF == null))
                {
                    System.IO.File.Delete(@"C:\Users\lcosta\Documents\ArquivosImportados\"+joga.ID);
                }
                db.Jogadores.RemoveRange(db.Jogadores.Where(x => x.CPF == null));
                foreach (var documento in db.Documentos.Where(x => x.IDJogador == jogador.ID))
                {
                    System.IO.File.Delete(documento.Caminho);
                }
                db.Jogadores.RemoveRange(db.Jogadores.Where(x => x.CPF == null));
                db.Documentos.RemoveRange(db.Documentos.Where(x => x.IDJogador == jogador.ID));
                db.SaveChanges();
            }
            Response.Redirect("Tela_Inicial.aspx");
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
                using (var db = new ConexaoDB())
                {
                    jogador.Nome = TxTNome.Text;
                    jogador.Nascimento = TxTData.Text;
                    jogador.Endereco = TxTEndereco.Text;
                    jogador.CPF = TxTCPF.Text;
                    jogador.Posicao = DropDownListPosicao.SelectedItem.Text;
                    jogador.Time = TxTTime.Text;
                    //List<Documento> newDoc2 = (List<Documento>)Session["mDocs"];
                    foreach (Documento d in db.Documentos.Where(x => x.IDJogador == null).ToList())
                    {
                        d.IDJogador = jogador.ID;

                    }

                    foreach (Jogador d in db.Jogadores.Where(x => x.CPF == null).ToList())
                    {
                        d.Nome = TxTNome.Text;
                        d.Nascimento = TxTData.Text;
                        d.Endereco = TxTEndereco.Text;
                        d.CPF = TxTCPF.Text;
                        d.Posicao = DropDownListPosicao.SelectedItem.Text;
                        d.Time = TxTTime.Text;
                    }


                    db.SaveChanges();

                    //Session["mDatatable"] = null;
                    //Session["mDocs"] = null;
                    Response.Redirect("Tela_Inicial.aspx");
                }
            }
        }

        protected void GridDOC_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var l = GridDOC.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
            using (var db = new ConexaoDB())
            {
                var d = db.Documentos.Find(l);
                System.IO.File.Delete(d.Caminho);
                db.Documentos.Remove(d);
                db.SaveChanges();
                GridDOC.DataSource = db.Documentos.Where(x => x.IDJogador == jogador.ID).ToList();
                GridDOC.DataBind();
            }
            
        }
    }
}