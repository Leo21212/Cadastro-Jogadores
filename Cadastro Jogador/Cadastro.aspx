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
            <asp:RangeValidator ID="RangeValidatorData" runat="server" ControlToValidate="TxTData"
                Type="Date"
                EnableClientScript="false"
                ErrorMessage="Data de nascimento inválida"></asp:RangeValidator>
        <p>
            <asp:Literal ID="LtrEndereco" runat="server" Text="Endereço"></asp:Literal>
            <asp:TextBox ID="TxTEndereco" runat="server"></asp:TextBox>
        </p>
            <asp:Literal ID="LtrCPF" runat="server" Text="CPF"></asp:Literal>
            <asp:TextBox ID="TxTCPF" runat="server"></asp:TextBox>
            <td>
                <asp:RegularExpressionValidator id="RegularExpressionValidatorCPF" 
                     ControlToValidate="TxTCPF"
                     ValidationExpression="\d{11}$"
                     Display="Static"
                     ErrorMessage="CPF deve conter 11 digitos"
                     EnableClientScript="False" 
                     runat="server"/>
             </td>
        <br />
        <br />
            <asp:Literal ID="LtrPosicao" runat="server" Text="Posição"></asp:Literal>
            <asp:DropDownList ID="DropDownListPosicao" runat="server">
                <asp:ListItem Text="Goleiro" ></asp:ListItem>
                <asp:ListItem Text="Zagueiro" ></asp:ListItem>
                <asp:ListItem Text="Lateral" ></asp:ListItem>
                <asp:ListItem Text="Volante" ></asp:ListItem>
                <asp:ListItem Text="Atacante" ></asp:ListItem>
            </asp:DropDownList>
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
           
        <asp:GridView ID="GridDOC" runat="server"></asp:GridView>


        <p>
            <asp:Button ID="Voltar" runat="server" Text="Voltar" OnClick="Voltar_Click" />
            <asp:Button ID="SalvarJog" runat="server" Text="Salvar" OnClick="Salvar_Click"  />
        </p>
    </form>
</body>
</html>
