<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Practica2_Eventos.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        body {
            background-color: #121212;
        }
<<<<<<< HEAD
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
=======
>>>>>>> d307e7339e7e932130540a6fe9099db4c9d69add
    </style>

    <div class="row justify-content-center mt-5">
        <div class="col-md-4">

<<<<<<< HEAD
            <div class="card shadow login-card">
                <div class="card-header text-center">
                <div class="text-center mb-4">
                    <h4 class="fw-bold mb-1">🔐Autos App</h4>
                    <small class="text-muted">Gestioná tu flota de forma simple y rápida.</small>
                </div>
=======
            <div class="card shadow-lg">
                <div class="card-header text-center">
                    <h4>🔐 Login</h4>
>>>>>>> d307e7339e7e932130540a6fe9099db4c9d69add
                </div>

                <div class="card-body">

                    <div class="mb-3">
<<<<<<< HEAD
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
=======
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
>>>>>>> d307e7339e7e932130540a6fe9099db4c9d69add

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

