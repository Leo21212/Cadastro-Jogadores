<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Listagem.aspx.cs" Inherits="Cadastro_Jogador.Listagem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" >
        <div>

            <asp:Literal ID="LtrLista" runat="server" Text="Jogadores Cadastrados"></asp:Literal>
            <asp:GridView ID="GridViewJogadores" runat="server" OnRowCommand="GridViewJogadores_RowCommand"  >
                <Columns>
                    <asp:ButtonField ButtonType="Button" Text="Editar" CommandName="EDT" />
                </Columns>
            </asp:GridView>
            <p>
                <asp:Button ID="Voltar" runat="server" Text="Voltar" OnClick="Voltar_Click" />
            </p>
        </div>
    </form>
</body>
</html>
