<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tela_Inicial.aspx.cs" Inherits="Cadastro_Jogador.Tela_Inicial" %>

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
    <form id="form1" runat="server">
        <div class="mx-auto" style="width: 188px; margin-top:auto">
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
            <p>
                <asp:Button ID="Button1" runat="server" Text="Lista de jogadores" OnClick="Button1_Click" class="btn btn-primary" />
            </p>
            
        </div>
        <div class="mx-auto" style="width: 186px;">
            &nbsp;<asp:Button ID="Button2" runat="server" Text="Cadastro/Edição" OnClick="Button2_Click" class="btn btn-primary"/>
        </div>
    </form>
    
</body>
</html>
