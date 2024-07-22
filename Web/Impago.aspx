<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Impago.aspx.cs" Inherits="Web.Impago" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <div class="row">
            <div class="col-xs-4">
                <p style="margin-bottom: 0px">Registros de infracciones sin pagar</p>
                <asp:ListBox
                    ID="ListBoxInfraccionesImpagas"
                    Rows="20"
                    Width="450px"
                    SelectionMode="Single"
                    runat="server"></asp:ListBox>
                <br />
                <asp:Button
                    ID="ButtonGenerarPDF"
                    Text="Generar PDF"
                    CssClass="btn btn-primary mt-2"
                    OnClick="ButtonGenerarPDF_Click"
                    runat="server" />
                <br />
                <asp:Label
                    ID="LabelMensaje"
                    CssClass="mt-2"
                    EnableViewState="false"
                    runat="server" />
            </div>
        </div>
    </div>

</asp:Content>
