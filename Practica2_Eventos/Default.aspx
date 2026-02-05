<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Practica2_Eventos.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .oculto {
            display: none;
        }

        .table-hover tbody tr:hover {
            background-color: #f8f9fa;
        }
<<<<<<< HEAD
        body {
            background-color: #121212;
        }
        .pagination a,
        .pagination span {
            padding: 6px 12px;
            margin: 0 3px;
            border-radius: 6px;
            text-decoration: none;
        }
    </style>

    <script>
        function filtrarConEnter(e) {
            if (e.key === "Enter") {
                e.preventDefault();
                document.getElementById('<%= btnFiltrar.ClientID %>').click();
                return false;
            }
            return true;
        }
</script>

=======

        body {
            background-color: #121212;
        }
    </style>

>>>>>>> d307e7339e7e932130540a6fe9099db4c9d69add
    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
    <ContentTemplate>

    <div class="row justify-content-center mb-4">
        <div class="col-lg-10">
            <div class="row g-2 align-items-center">

                <!-- Texto -->
                <div class="col-md-4">
                    <asp:TextBox
                        ID="txtFiltro"
                        runat="server"
                        CssClass="form-control"
<<<<<<< HEAD
                        placeholder="Buscar modelo..." 
                        onkeydown="return filtrarConEnter(event);"/>
=======
                        placeholder="Buscar modelo..." />
>>>>>>> d307e7339e7e932130540a6fe9099db4c9d69add
                </div>

                <!-- Color -->
                <div class="col-md-3">
                    <asp:DropDownList
                        ID="ddlColorFiltro"
                        runat="server"
                        CssClass="form-select">
                        <asp:ListItem Text="Todos los colores" Value="" />
                        <asp:ListItem Text="Blanco" />
                        <asp:ListItem Text="Negro" />
                        <asp:ListItem Text="Azul" />
                        <asp:ListItem Text="Rojo" />
<<<<<<< HEAD
                        <asp:ListItem Text="Gris" />
                        <asp:ListItem Text="Amarillo" />
=======
>>>>>>> d307e7339e7e932130540a6fe9099db4c9d69add
                    </asp:DropDownList>
                </div>

                <!-- Origen -->
                <div class="col-md-3">
                    <asp:DropDownList
                        ID="ddlOrigenFiltro"
                        runat="server"
                        CssClass="form-select">
                        <asp:ListItem Text="Todos los orígenes" Value="" />
                        <asp:ListItem Text="Nacional" Value="Nacional" />
                        <asp:ListItem Text="Importado" Value="Importado" />
                    </asp:DropDownList>
                </div>

                <!-- Botones -->
                <div class="col-md-2 d-flex gap-2">
                    <asp:Button
                        ID="btnFiltrar"
                        runat="server"
                        Text="Filtrar"
                        CssClass="btn btn-primary w-100"
                        OnClick="btnFiltrar_Click" />

                    <asp:Button
                        ID="btnLimpiar"
                        runat="server"
                        Text="Limpiar"
                        CssClass="btn btn-outline-secondary w-100"
                        OnClick="btnLimpiar_Click" />
                </div>

            </div>
        </div>
    </div>

    <div class="container mt-4">
        <div class="card shadow-sm">
            <div class="card-header d-flex justify-content-between align-items-center">
                <h5 class="mb-0">Listado de Autos</h5>
                <a href="AutoForm.aspx" class="btn btn-success btn-sm">➕ Agregar Auto
            </a>
            </div>

            <div class="card-body">
<<<<<<< HEAD
                <asp:Label
                    ID="lblResultados"
                    runat="server"
                    CssClass="text-muted text-center d-block mb-2"
                    Visible="false" />
=======
>>>>>>> d307e7339e7e932130540a6fe9099db4c9d69add
                <asp:GridView
                    runat="server"
                    ID="dgvAutos"
                    DataKeyNames="Id"
                    CssClass="table table-striped table-hover align-middle"
                    AutoGenerateColumns="False"
                    OnSelectedIndexChanged="dgvAutos_SelectedIndexChanged"
                    OnRowDeleting="dgvAutos_RowDeleting"
                    OnRowDataBound="dgvAutos_RowDataBound"
                    RowStyle-CssClass="align-middle"
                    AllowPaging="true"
<<<<<<< HEAD
                    PageSize="8"
                    OnPageIndexChanging="dgvAutos_PageIndexChanging"
                    >
=======
                    PageSize="5"
                    OnPageIndexChanging="dgvAutos_PageIndexChanging"
                    PagerStyle-HorizontalAlign="Center"
                    PagerStyle-CssClass="text-center mt-3">
>>>>>>> d307e7339e7e932130540a6fe9099db4c9d69add

                    <Columns>
                        <asp:BoundField HeaderText="Modelo" DataField="Modelo" />
                        <asp:BoundField HeaderText="Color" DataField="Color" />
                        <asp:TemplateField HeaderText="Caracter">
                            <ItemTemplate>
                                <asp:Label ID="lblUsado" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Origen">
                            <ItemTemplate>
                                <asp:Label ID="lblOrigen" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:CommandField
                            ShowSelectButton="true"
                            SelectText="✏️ Editar"
                            ButtonType="Button"
                            ControlStyle-CssClass="btn btn-sm btn-warning me-1" />

<<<<<<< HEAD
                        <asp:TemplateField>
=======
                        <asp:TemplateField HeaderText="Acciones">
>>>>>>> d307e7339e7e932130540a6fe9099db4c9d69add
                            <ItemTemplate>
                                <asp:LinkButton
                                    ID="btnBorrar"
                                    runat="server"
                                    Text="🗑️ Borrar"
                                    CssClass="btn btn-sm btn-danger"
                                    CommandName="Delete"
                                    OnClientClick="return confirm('¿Seguro que querés borrar este auto?');">
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

<<<<<<< HEAD
                        <asp:TemplateField>
                            <ItemTemplate>
                                <a
                                    href='DetalleAuto.aspx?id=<%# Eval("Id") %>'
                                    class="btn btn-sm btn-outline-info">Ver Detalle
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerTemplate>
                        <nav>
                            <ul class="pagination justify-content-center">
                                <li class="page-item">
                                    <asp:LinkButton
                                        runat="server"
                                        CommandName="Page"
                                        CommandArgument="Prev"
                                        CssClass="page-link">
                                         Anterior
                                    </asp:LinkButton>
                                </li>
                                <li class="page-item">
                                    <asp:LinkButton
                                        runat="server"
                                        CommandName="Page"
                                        CommandArgument="Next"
                                        CssClass="page-link">
                                        Siguiente
                                    </asp:LinkButton>
                                </li>
                            </ul>
                        </nav>
                    </PagerTemplate>
=======
                    </Columns>
>>>>>>> d307e7339e7e932130540a6fe9099db4c9d69add
                </asp:GridView>
            </div>
        </div>
    </div>


    <div class="mt-4 text-center">
        <asp:Label
            ID="lblVacio"
            runat="server"
            CssClass="alert alert-info d-inline-block px-4"
            Text="❌ No hay resultados para el filtro aplicado."
            Visible="false" />
    </div>

    </ContentTemplate>

        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="txtFiltro" EventName="TextChanged" />
            <asp:AsyncPostBackTrigger ControlID="btnLimpiar" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="dgvAutos" EventName="PageIndexChanging" />
        </Triggers>

    </asp:UpdatePanel>

</asp:Content>
