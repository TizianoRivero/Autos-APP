<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleAuto.aspx.cs" Inherits="Practica2_Eventos.DetalleAuto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        body {
            background-color: #121212;
        }
        .timeline-item {
            position: relative;
            padding-left: 30px;
        }

        .timeline-dot {
            position: absolute;
            left: 10px;
            top: 8px;
            width: 12px;
            height: 12px;
            background-color: #0d6efd;
            border-radius: 50%;
        }

        .timeline-item::before {
            content: '';
            position: absolute;
            left: 15px;
            top: 20px;
            bottom: -15px;
            width: 2px;
            background-color: #444;
        }

        .timeline-item:last-child::before {
            display: none;
        }
        @keyframes fadeSlideIn {
            from {
                opacity: 0;
                transform: translateY(10px);
            }

            to {
                opacity: 1;
                transform: translateY(0);
            }
        }

        .timeline-item {
            animation: fadeSlideIn 0.4s ease-out forwards;
            opacity: 0;
        }
        .timeline-content {
            transition: transform 0.2s ease, box-shadow 0.2s ease;
        }

        .timeline-item:hover .timeline-content {
            transform: translateX(3px);
            box-shadow: 0 4px 12px rgba(0,0,0,0.3);
        }
    </style>

    <h3 class="mb-4">Detalle</h3>

    <ul class="list-group">
        <li class="list-group-item"><strong>Modelo:</strong>
            <asp:Label ID="lblModelo" runat="server" /></li>
        <li class="list-group-item"><strong>Descripción:</strong>
            <asp:Label ID="lblDescripcion" runat="server" /></li>
        <li class="list-group-item"><strong>Color:</strong>
            <asp:Label ID="lblColor" runat="server" /></li>
        <li class="list-group-item"><strong>Fecha de ingreso:</strong>
            <asp:Label ID="lblFecha" runat="server" /></li>
        <li class="list-group-item"><strong>Estado:</strong>
            <asp:Label ID="lblUsado" runat="server" /></li>
        <li class="list-group-item"><strong>Origen:</strong>
            <asp:Label ID="lblOrigen" runat="server" /></li>
    </ul>

    <h4 class="mt-4">📜 Historial</h4>

    <asp:Repeater ID="rptHistorial" runat="server">
        <ItemTemplate>
            <div class="timeline-item"
                style='animation-delay: <%# Container.ItemIndex * 0.08 %>s'>

                <div class="timeline-dot"></div>

                <div class="timeline-content">
                    <span class='badge <%# Eval("Accion").ToString() == "Alta" ? "bg-success" : "bg-warning" %>'>
                        <%# Eval("Accion") %>
                </span>

                    <small class="text-muted ms-2">
                        <%# Eval("Fecha", "{0:dd/MM/yyyy HH:mm}") %>
                </small>

                    <div class="mt-1">
                        <%# Eval("Descripcion") %>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

    <a href="Default.aspx" class="btn btn-secondary mt-3">⬅ Volver</a>

    

</asp:Content>
