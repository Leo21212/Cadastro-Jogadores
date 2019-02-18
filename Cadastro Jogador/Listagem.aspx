<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Listagem.aspx.cs" Inherits="Cadastro_Jogador.Listagem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<!doctype html>
<html lang="en">
</html>
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous"/>
    <style type="text/css">
   body { background: rgba(232,232,232,1.00) !important; } /* Adding !important forces the browser to overwrite the default style applied by Bootstrap */
</style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" >
        <div class="col-md-4">

            <asp:Literal ID="LtrLista" runat="server" Text="Jogadores Cadastrados" ></asp:Literal>
            <asp:GridView ID="GridViewJogadores" runat="server" OnRowCommand="GridViewJogadores_RowCommand"  class="table table-striped table-dark">
                <Columns>
                    <asp:ButtonField ButtonType="Button" Text="Editar" CommandName="EDT" />
                </Columns>
            </asp:GridView>
            <p>
                <p>
                    <asp:Button ID="Voltar" runat="server" Text="Voltar" OnClick="Voltar_Click" class="btn btn-outline-secondary"/>
                </p>
            </p>
        </div>
    </form>
</body>
</html>
