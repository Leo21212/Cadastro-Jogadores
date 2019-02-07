<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="Cadastro_Jogador.Cadastro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<%--<script src="JQuery/Jquery.js" type="text/javascript">
</script>
<script src="JQuery/jquery.mask.js" type="text/javascript">
</script>
<script>$(function(){$(".data").mask('00/00/0000', {placeholder: "__/__/____"});})
</script>--%>

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
            <asp:TextBox ID="TxTData"  runat="server" TextMode="Date" ></asp:TextBox>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TxTData"
                Type="Date"
                EnableClientScript="false"
                Text="Errou!"></asp:RangeValidator>
        <p>
            <asp:Literal ID="LtrEndereco" runat="server" Text="Endereço"></asp:Literal>
            <asp:TextBox ID="TxTEndereco" runat="server"></asp:TextBox>
        </p>
            <asp:Literal ID="Literal2" runat="server" Text="CPF"></asp:Literal>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
            <asp:Literal ID="LtrPosicao" runat="server" Text="Posicao"></asp:Literal>
            <asp:TextBox ID="TxTPosicao" runat="server"></asp:TextBox>
        <p>
            <asp:Literal ID="LtrTime" runat="server" Text="Time"></asp:Literal>
            <asp:TextBox ID="TxTTime" runat="server" ></asp:TextBox>
            
        </p>
            <asp:Literal ID="Literal1" runat="server" Text="Carregar arquivos:"></asp:Literal>
            <asp:FileUpload ID="FileUpload1" style=" margin-left:30px;" runat="server" /> 
        <p>
            <asp:Button ID="Import" runat="server" Text="Importar arquivos" OnClick="Button1_Click" />
            <asp:Literal ID="Status" runat="server"></asp:Literal>
        </p>
        <asp:DataGrid id="ItemsGrid"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           AutoGenerateColumns="true"
           runat="server">

         <HeaderStyle BackColor="#00aaaa">
         </HeaderStyle> 
 
      </asp:DataGrid>
    </form>
</body>
</html>
