﻿using System;
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
            if (e.CommandName == "Click_Delete")
            {
                var l = GridView1.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text;
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
            else
            {
                var l = GridView1.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text;
                using (var db = new ConexaoDB())
                {
                    var d = db.Documentos.Find(l);
                    DownLoad(d.Caminho);

                }
            }
        }

        protected void Voltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Listagem.aspx");
        }

        protected void Salvar_Click(object sender, EventArgs e)
        {
            List<string> aux = new List<string>();
            var q = Request.QueryString["id"];
            using (var db = new ConexaoDB())
            {
                foreach (Jogador r in db.Jogadores)
                {
                    if(r.ID!=q)
                        aux.Add(r.CPF.ToString());
                }

                foreach (var n in aux)
                {
                    if (n != TxTCPF.Text)
                    {
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
            }
        }

        protected void Deletar_Click(object sender, EventArgs e)
        {
            using (var db = new ConexaoDB())
            {
                var q = Request.QueryString["id"];

                foreach (var documento in db.Documentos.Where(x => x.IDJogador == q))
                {
                    System.IO.File.Delete(documento.Caminho);
                }
                db.Documentos.RemoveRange(db.Documentos.Where(x => x.IDJogador == q));
                db.Jogadores.RemoveRange(db.Jogadores.Where(x => x.ID == q));
                System.IO.Directory.Delete(@"C:\Users\lcosta\Documents\ArquivosImportados\" + q.ToString());
                db.SaveChanges();
                Response.Redirect("Listagem.aspx");
            }
        }

        public void DownLoad(string FName)
        {
            string path = FName;
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            if (file.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name); Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream"; // download […]
            }
        }
    }
}