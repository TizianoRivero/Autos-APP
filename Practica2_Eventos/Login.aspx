<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Practica2_Eventos.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        body {
            background-color: #121212;
        }
    </style>

    <div class="row justify-content-center mt-5">
        <div class="col-md-4">

            <div class="card shadow-lg">
                <div class="card-header text-center">
                    <h4>🔐 Login</h4>
                </div>

                <div class="card-body">

                    <div class="mb-3">
                        <label>Email</label>
                        <asp:TextBox
                            ID="txtEmail"
                            runat="server"
                            CssClass="form-control"
                            TextMode="Email" />
                    </div>

                    <div class="mb-3">
                        <label>Password</label>
                        <asp:TextBox
                            ID="txtPassword"
                            runat="server"
                            CssClass="form-control"
                            TextMode="Password" />
                    </div>

                    <asp:Label
                        ID="lblError"
                        runat="server"
                        CssClass="text-danger mb-3 d-block"
                        Visible="false" />

                    <div class="d-grid">
                        <asp:Button
                            ID="btnLogin"
                            runat="server"
                            Text="Ingresar"
                            CssClass="btn btn-primary"
                            OnClick="btnLogin_Click" />
                    </div>

                </div>
            </div>

        </div>
    </div>


</asp:Content>

