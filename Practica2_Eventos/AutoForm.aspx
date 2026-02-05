<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AutoForm.aspx.cs" Inherits="Practica2_Eventos.AutoForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        body {
            background-color: #121212;
        }
    </style>

    <div class="container mt-4">
        <div class="row justify-content-center">
            <div class="col-md-8">

                <div class="card shadow-sm">
                    <div class="card-header">
                        <h5 class="mb-0">Alta / Modificacion de Auto</h5>
                    </div>

                    <div class="card-body">

                        <div class="mb-3">
                            <label class="form-label">ID</label>
                            <asp:TextBox
                                runat="server"
                                ID="txtId"
                                CssClass="form-control"
                                Enabled="false" />
                        </div>

                        <div class="mb-3">
                            <label class="form-label">Modelo</label>
                            <asp:TextBox runat="server" ID="TxtModelo" CssClass="form-control" />
                        </div>

                        <div class="mb-3">
                            <label class="form-label">Descripción</label>
                            <asp:TextBox
                                runat="server"
                                ID="TxtDescripcion"
                                TextMode="MultiLine"
                                Rows="3"
                                CssClass="form-control" />
                        </div>

                        <div class="mb-3">
                            <label class="form-label">Color</label>
                            <asp:DropDownList
                                ID="ddlColores"
                                runat="server"
                                CssClass="form-select" />
                        </div>

                        <div class="mb-3">
                            <label class="form-label">Fecha de ingreso</label>
                            <asp:TextBox
                                runat="server"
                                ID="TxtFecha"
                                TextMode="Date"
                                CssClass="form-control" />

                            <asp:Label
                                ID="lblError"
                                runat="server"
                                CssClass="alert alert-danger mt-2 d-block"
                                Visible="false" />
                        </div>

                        

                        <div class="form-check mb-3">
                            <input
                                class="form-check-input"
                                type="checkbox"
                                id="chkUsado"
                                runat="server" />
                            <label class="form-check-label">
                                Nuevo
                       
                            </label>
                        </div>

                        <div class="mb-3">
                            <label class="form-label">Origen</label><br />
                            <asp:RadioButton
                                ID="RdbImportado"
                                Text=" Importado"
                                runat="server"
                                GroupName="Origen" />
                            <asp:RadioButton
                                ID="RdbNacional"
                                Text=" Nacional"
                                Checked="true"
                                runat="server"
                                GroupName="Origen" />
                        </div>

                        <div class="d-flex justify-content-end gap-2">
                            <asp:Button
                                Text="💾 Guardar"
                                ID="Button1"
                                CssClass="btn btn-primary"
                                runat="server"
                                OnClick="Button1_Click" />

                            

                            <a href="Default.aspx" class="btn btn-secondary">Cancelar
                        </a>
                        </div>

                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
