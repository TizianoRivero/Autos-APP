<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Practica2_Eventos.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        body {
            background-color: #121212;
        }
        .timeline-item {
            display: flex;
            gap: 15px;
            position: relative;
            padding-bottom: 30px;
        }

            .timeline-item::before {
                content: "";
                position: absolute;
                left: 12px;
                top: 28px;
                bottom: 0;
                width: 2px;
                background-color: #444;
            }

        .timeline-icon {
            font-size: 22px;
            z-index: 2;
        }

        .timeline-content {
            background-color: #222;
            padding: 12px 16px;
            border-radius: 8px;
            width: 100%;
        }
        .chart-container {
            width: 250px;
            height: 250px;
        }
    </style>
    <script>
        document.addEventListener("DOMContentLoaded", function () {

            

            // Usados vs Nuevos
            new Chart(document.getElementById('chartUsadosNuevos'), {
                type: 'doughnut',
                data: {
                    labels: ['Usados', 'Nuevos'],
                    datasets: [{
                        data: [
                             <%= CantidadUsados %>,
                             <%= CantidadNuevos %>
                        ]
                    }]
                },
                options: {
                    responsive: true,
                    maintainAspectRatio: false
                }
            });

        // Importados vs Nacionales
        new Chart(document.getElementById('chartOrigen'), {
            type: 'doughnut',
            data: {
                labels: ['Importados', 'Nacionales'],
                datasets: [{
                    data: [
                        <%= CantidadImportados %>,
                        <%= CantidadNacionales %>
                    ]
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false
            }
        });

    });
</script>

        <h3 class="mb-4">📊 Dashboard</h3>

        <div class="row g-3">
            <div class="col-md-3">
                <div class="card text-center shadow-sm">
                    <div class="card-body">
                        <h6 class="text-muted">Total Autos</h6>
                        <h2 class="fw-bold">
                            <asp:Label ID="lblTotalAutos" runat="server" />
                        </h2>
                    </div>
                </div>
            </div>

            <div class="col-md-3">
                <div class="card text-center shadow-sm">
                    <div class="card-body">
                        <h6 class="text-muted">Usados</h6>
                        <h2 class="fw-bold text-warning">
                            <asp:Label ID="lblUsados" runat="server" />
                        </h2>
                    </div>
                </div>
            </div>

            <div class="col-md-3">
                <div class="card text-center shadow-sm">
                    <div class="card-body">
                        <h6 class="text-muted">Nuevos</h6>
                        <h2 class="fw-bold text-success">
                            <asp:Label ID="lblNuevos" runat="server" />
                        </h2>
                    </div>
                </div>
            </div>

            <div class="col-md-3">
                <div class="card text-center shadow-sm">
                    <div class="card-body">
                        <h6 class="text-muted">Importados</h6>
                        <h2 class="fw-bold text-info">
                            <asp:Label ID="lblImportados" runat="server" />
                        </h2>
                    </div>
                </div>
            </div>

            <div class="col-md-3">
                <div class="card text-center shadow-sm">
                    <div class="card-body">
                        <h6 class="text-muted">Nacionales</h6>
                        <h2 class="fw-bold text-primary">
                            <asp:Label ID="lblNacionales" runat="server" />
                        </h2>
                    </div>
                </div>
            </div>

         </div>

        <div class="row mt-4">

            <div class="col-md-6">
                <div class="card shadow-sm">
                    <div class="card-header">
                        🚘 Usados vs Nuevos        
                    </div>
                    <div class="card-body d-flex justify-content-center">
                        <div class="chart-container">
                            <canvas id="chartUsadosNuevos"></canvas>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-6">
                <div class="card shadow-sm">
                    <div class="card-header">
                        🌍 Importados vs Nacionales          
                    </div>
                    <div class="card-body d-flex justify-content-center">
                        <div class="chart-container">
                            <canvas id="chartOrigen"></canvas>
                        </div>
                    </div>
                </div>
            </div>

        </div>

    <div class="card shadow-sm mt-4">
        <div class="card-header">
            🕒 Últimos movimientos
   
        </div>
        <div class="card-body">
            <asp:Repeater ID="rptActividad" runat="server">
                <ItemTemplate>
                    <div class="timeline-item">
                        <div class="timeline-icon">
                            <%# Eval("Accion").ToString() == "Alta" ? "🟢" :
                Eval("Accion").ToString() == "Modificación" ? "🔵" :
                Eval("Accion").ToString() == "Baja" ? "🔴" : "⚪" %>
                        </div>

                        <div class="timeline-content">
                            <strong>
                                <%# Eval("Accion") %>
            </strong>
                            —
            Auto #<%# Eval("IdAuto") %> · <%# Eval("ModeloAuto") %>

                            <div class="text-muted mt-1">
                                <%# Eval("Descripcion") %>
                            </div>

                            <div class="small text-muted mt-2">
                                📅 Fecha: <%# ((DateTime)Eval("Fecha")).ToString("dd/MM/yyyy") %>
                &nbsp;—&nbsp;
                ⏰ Hora: <%# ((DateTime)Eval("Fecha")).ToString("HH:mm") %>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
