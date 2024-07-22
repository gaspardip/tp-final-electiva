<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header text-center">
                        <h3>Login</h3>
                    </div>
                    <div class="card-body">
                        <div class="mb-3">
                            <asp:Label ID="LabelUsername" runat="server" Text="Dominio del vehículo:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="TextBoxUsername" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <asp:Label ID="LabelPassword" runat="server" Text="Contraseña:" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                        </div>
                        <asp:Button ID="ButtonLogin" runat="server" Text="Login" CssClass="btn btn-primary w-100" OnClick="ButtonLogin_Click" />
                        <br />
                        <asp:Label ID="LabelMessage" runat="server" Text="" ForeColor="Red" CssClass="form-text mt-2"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
