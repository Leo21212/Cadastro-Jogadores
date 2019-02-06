<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="Cadastro_Jogador.Cadastro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<script src="JQuery/Jquery.js" type="text/javascript">
</script>
<script src="JQuery/jquery.mask.js" type="text/javascript">
</script>
<script>$(function(){$(".data").mask("00/00/0000", {placeholder: "__/__/____"});})
</script>

<body>
    <form id="form1" runat="server">
        <div>
            <asp:Literal ID="LtrTitulo" runat="server" Text="Cadastro de Jogadores"></asp:Literal>
        </div>
        <p>
            <asp:Literal ID="LtrNome" runat="server" Text="Nome"></asp:Literal>
            <asp:TextBox ID="TxTNome" runat="server"></asp:TextBox>
        </p>
            <asp:Literal ID="LtrData" runat="server" Text="Data de Nascimento"></asp:Literal>
            <asp:TextBox ID="TxTNascimento"  runat="server" TextMode="Date" data-mask="00/00/0000" ></asp:TextBox>
            
  
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
