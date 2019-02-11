﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="Cadastro_Jogador.Cadastro" %>

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
            <asp:RangeValidator ID="RangeValidatorData" runat="server" ControlToValidate="TxTData"
                Type="Date"
                EnableClientScript="false"
                Text="Data de nascimento inválida"></asp:RangeValidator>
        <p>
            <asp:Literal ID="LtrEndereco" runat="server" Text="Endereço"></asp:Literal>
            <asp:TextBox ID="TxTEndereco" runat="server"></asp:TextBox>
        </p>
            <asp:Literal ID="LtrCPF" runat="server" Text="CPF"></asp:Literal>
            <asp:TextBox ID="TxTCPF" runat="server"></asp:TextBox>
            <asp:RangeValidator id="RangeValidatorCPF"
               ControlToValidate="TxtCPF"
               MinimumValue="11"
               MaximumValue="11"
               Type="Integer"
               EnableClientScript="false"
               Text="CPF deve conter 11 digitos"
               runat="server"/>
        <br />
        <br />
            <asp:Literal ID="LtrPosicao" runat="server" Text="Posicao"></asp:Literal>
            <asp:TextBox ID="TxTPosicao" runat="server"></asp:TextBox>
        <p>
            <asp:Literal ID="LtrTime" runat="server" Text="Time"></asp:Literal>
            <asp:TextBox ID="TxTTime" runat="server" ></asp:TextBox>
            
        </p>
            <asp:Literal ID="LtrCarregar" runat="server" Text="Carregar arquivos:"></asp:Literal>
            <asp:FileUpload ID="FileUploadDoc" style=" margin-left:30px;" runat="server" /> 
        <p>
            
            <asp:DropDownList ID="Tipos_de_arquivo" runat="server">
                <asp:ListItem Text="RG" ></asp:ListItem>
                <asp:ListItem Text="CPF" ></asp:ListItem>
                <asp:ListItem Text="Exame Médico" ></asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="Import" runat="server" Text="Importar arquivos" OnClick="BUpload" />
            <asp:Literal ID="Status" runat="server"></asp:Literal>
        </p>
           
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>

        <p>
            <asp:Button ID="Voltar" runat="server" Text="Voltar" OnClick="Voltar_Click" />
            <asp:Button ID="SalvarJog" runat="server" Text="Salvar" OnClick="Salvar_Click"  />
        </p>
    </form>
</body>
</html>