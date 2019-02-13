using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cadastro_Jogador
{
    public partial class Listagem : System.Web.UI.Page
    {
        //SqlConnection conn;
        //string l;
        List<Jogador> lista = new List<Jogador>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
                SelecaoInicial();
        }

        public void SelecaoInicial()
        {
            //string _conect = @"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\CadastroJogador.mdf;integrated security=True;connect timeout=30;MultipleActiveResultSets=True;App=EntityFramework";
            //SqlDataReader reader;
            //DataTable dados = new DataTable();
            //conn = new SqlConnection(_conect);
            //SqlCommand cmd = new SqlCommand(query, conn);

            //conn.Open();
            //cmd.CommandText = query;
            //cmd.Parameters.Clear();
            //cmd.ExecuteNonQuery();
            //reader = cmd.ExecuteReader();
            //dados.Load(reader);
            //reader.Close();
            //conn.Close();
            //GridViewJogadores.DataSource = dados;
            //GridViewJogadores.DataBind();

            using (var db = new Model1())
            {
                GridViewJogadores.DataSource = db.Jogadores.ToList();
                GridViewJogadores.DataBind();
            }


        }

        protected void GridViewJogadores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EDT")
            {
                var l = GridViewJogadores.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;

                //foreach (Jogador d in lista)
                //{
                //    if (d.ID == l)
                //    Session["JOGOBJ"] = d;
                //}
                Response.Redirect("Edit.aspx?id="+l);
            }
        }
    }
}