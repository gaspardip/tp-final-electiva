<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div class="row">
            <section class="col-md-6">
                <asp:Button ID="ButtonImpago" runat="server" Text="Consultar infracciones impagas" CssClass="btn btn-primary w-100" OnClick="ButtonImpago_Click" />
            </section>
            <section class="col-md-6">
                <asp:Button ID="ButtonPago" runat="server" Text="Consultar infracciones pagas" CssClass="btn btn-primary w-100" OnClick="ButtonPago_Click" />
            </section>
            <br />
            <asp:Label
                ID="LabelMensaje"
                CssClass="mt-2"
                EnableViewState="false"
                runat="server" 
             />
        </div>
    </main>

</asp:Content>
