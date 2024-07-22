<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pago.aspx.cs" Inherits="Web.Pago" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <div class="row">
            <div class="col-xs-4">
                <p style="margin-bottom: 0px">Registros de infracciones pagas</p>
                <asp:ListBox
                    ID="ListBoxInfraccionesPagas"
                    Rows="20"
                    Width="450px"
                    SelectionMode="Single"
                    runat="server"></asp:ListBox>
            </div>
        </div>
    </div>

</asp:Content>
