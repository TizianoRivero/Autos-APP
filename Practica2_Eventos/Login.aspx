<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Practica2_Eventos.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        body {
            background-color: #121212;
        }
        .login-card {
            animation: fadeIn 0.6s ease-in-out;
        }

        @keyframes fadeIn {
            from {
                opacity: 0;
                transform: translateY(10px);
            }

            to {
                opacity: 1;
                transform: translateY(0);
            }
        }
        .card {
            border-radius: 14px;
        }
    </style>

    <div class="row justify-content-center mt-5">
        <div class="col-md-4">

            <div class="card shadow login-card">
                <div class="card-header text-center">
                <div class="text-center mb-4">
                    <h4 class="fw-bold mb-1">🔐Autos App</h4>
                    <small class="text-muted">Gestioná tu flota de forma simple y rápida.</small>
                </div>
                </div>

                <div class="card-body">

                    <div class="mb-3">
                        <div class="input-group mb-3">
                            <span class="input-group-text">
                                <i class="bi bi-envelope"></i>
                            </span>
                            <asp:TextBox
                                ID="txtEmail"
                                runat="server"
                                CssClass="form-control"
                                placeholder="Email" />
                        </div>
                    </div>

                    <div class="mb-3"> 
                        <div class="input-group mb-3">
                            <span class="input-group-text">
                                <i class="bi bi-lock"></i>
                            </span>
                            <asp:TextBox
                                ID="txtPassword"
                                runat="server"
                                TextMode="Password"
                                CssClass="form-control"
                                placeholder="Contraseña" />
                        </div>
                    </div>

                <asp:Label
                    ID="lblError"
                    runat="server"
                    CssClass="alert alert-danger text-center py-2"
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

