﻿using System;
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
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            SelecaoInicial();
        }

        public void SelecaoInicial()
        {
            string _conect = @"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\CadastroJogador.mdf;integrated security=True;connect timeout=30;MultipleActiveResultSets=True;App=EntityFramework";
            var query = @"SELECT * FROM Jogadors ORDER BY Nome";
            SqlDataReader reader;
            DataTable dados = new DataTable();
            conn = new SqlConnection(_conect);
            SqlCommand cmd = new SqlCommand(query,conn);

            conn.Open();
            cmd.CommandText = query;
            cmd.Parameters.Clear();
            cmd.ExecuteNonQuery();
            reader = cmd.ExecuteReader();
            dados.Load(reader);
            reader.Close();
            conn.Close();
            GridViewJogadores.DataSource = dados;
            GridViewJogadores.DataBind();
        }

        public void AtualizarCadastro(Object sender, GridViewEditEventArgs e)
        {
             var l = GridViewJogadores.Rows[e.NewEditIndex].Cells[2].Text.ToString();

        }
    }
}