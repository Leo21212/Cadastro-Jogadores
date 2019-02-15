<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="Cadastro_Jogador.Cadastro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<!doctype html>
<html lang="en">
</html>
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
                <asp:Literal ID="LtrTitulo" runat="server" Text="Cadastro de Jogadores"></asp:Literal>
            </p>
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
        <br />
        <br />
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
                <asp:ListItem Text="Meia" ></asp:ListItem>
                <asp:ListItem Text="Volante" ></asp:ListItem>
                <asp:ListItem Text="Atacante" ></asp:ListItem>
            </asp:DropDownList>
        <br />
        <br />
            <p>
            <asp:Literal ID="LtrTime" runat="server" Text="Time" ></asp:Literal>
            <asp:TextBox ID="TxTTime" runat="server"  ></asp:TextBox>
            </p>
            
        </p>
            <p>
            <asp:Literal ID="LtrCarregar" runat="server" Text="Carregar arquivos:"></asp:Literal>
            <asp:FileUpload ID="FileUploadDoc" style=" margin-left:20px;" runat="server" /> 
            </p>
        <p>
            
            <asp:DropDownList ID="Tipos_de_arquivo" runat="server">
                <asp:ListItem Text="RG" ></asp:ListItem>
                <asp:ListItem Text="CPF" ></asp:ListItem>
                <asp:ListItem Text="Exame Médico" ></asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="Import" runat="server" Text="Importar arquivos" OnClick="BUpload" class="btn btn-outline-secondary"/>
            <asp:Literal ID="Status" runat="server"></asp:Literal>
        </p>
           
        <asp:GridView ID="GridDOC" runat="server" OnRowCommand="GridDOC_RowCommand" class="table table-striped table-dark">
            <Columns>
                <asp:ButtonField ButtonType="Button" Text="Excluir" />
            </Columns>
        </asp:GridView>


        <p>
            <p>
            <asp:Button ID="Voltar" runat="server" Text="Voltar" OnClick="Voltar_Click" class="btn btn-outline-secondary"/>
            <asp:Button ID="SalvarJog" runat="server" Text="Salvar" OnClick="Salvar_Click"  class="btn btn-outline-secondary"/>
            </p>
        </p>
    </form>
</body>
</html>
