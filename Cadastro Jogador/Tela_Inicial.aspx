<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tela_Inicial.aspx.cs" Inherits="Cadastro_Jogador.Tela_Inicial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Lista de jogadores" OnClick="Button1_Click" />
        </div>
        <p>
            <asp:Button ID="Button2" runat="server" Text="Cadastro/Edição" OnClick="Button2_Click" />
        </p>
    </form>
    
</body>
</html>
