<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="Landing.aspx.cs" Inherits="JoachimOsesPrueba3.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 77px;
        }
        .auto-style2 {
            width: 195px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row justify-content-center">
        <div class="card  p-0 rounded col-3">
            <div class="card-header">
            <h5 class="card-title text-muted text-center">Navegación: </h5><asp:Label ID="lblLstData" runat="server" Text=""></asp:Label>
            </div>
            <div class="card-body">
                <div class="w-100">
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-outline-primary" Text="Alumnos" OnClick="Button1_Click1"  />   
                            </td>
                            <td>
                                 <asp:Button ID="Button2" runat="server" CssClass="btn btn-outline-primary" Text="Asignaturas" OnClick="Button2_Click"  />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:ListBox ID="lstData" runat="server" CssClass="w-100"  AutoPostBack="true" OnSelectedIndexChanged="lstData_SelectedIndexChanged"></asp:ListBox>
                            </td>
                        </tr>  
                    </table>
                </div>
            </div>
        </div>
        
        <div class="card p-0 col-5">
            <div class="card-body">
                <h5 class="card-title text-muted text-center">
                    <asp:Label ID="listStatus" runat="server" Text=""></asp:Label>
                </h5>
                <asp:Button ID="Button3" runat="server" Text="Mostrar Todos" CssClass=" btn btn-sm btn-outline-primary w-100" OnClick="Button3_Click" />
                <asp:DataGrid runat="server" ID="dgData" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" OnSelectedIndexChanged="dgData_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundColumn DataField="studentName" HeaderText="Alumno" />
                        <asp:BoundColumn DataField="subjectName" HeaderText="Ramo" />
                        <asp:BoundColumn DataField="semestre" HeaderText="Semestre" />
                        <asp:BoundColumn DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                    </Columns>
                </asp:DataGrid>
            </div>
        </div>
        
        <div class="card col-4">
            <div class="card-header">
                <h5 class="card-title">Inscripción de Ramos</h5>
            </div>

            <div class="card-body">
                    <table>
                        <tr><td><span> Alumno </span></td></tr>
                        <tr>
                            <td>
                                <label for="txtRut" class=" col-form-label">Rut:</label>
                            </td>
                            <td class="auto-style2">
                                <asp:TextBox ID="txtRut" runat="server" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td class="auto-style1">
                                 <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-outline-info w-100 h-100 " OnClick="btnBuscar_Click" Enabled="False" />   
                            </td>
                        </tr>
                        <tr>
                            <td>      
                                <label for="txtNombre" class=" col-form-label">Nombre:</label>
                            </td>
                            <td colspan="2" class="auto-style2">
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                            </td>
                            <!--
                            <td>
                                <asp:Button ID="btnBuscarNombre" runat="server" Text="Buscar" CssClass="btn btn-primary" />   
                                <label for="lblIdAlumno" class="d-none col-form-label">ID:</label>
                            </td>
                            -->
                        </tr>
                        <tr>
                            <td>
                                <span>Asignaturas:</span>
                            </td>
                            <td colspan="2">
                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="w-100 form-select">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-outline-secondary w-100" OnClick="btnReset_Click" />
                            </td>  
                            <td colspan="2">
                                <asp:Button ID="btnEjecutar" runat="server" Text="Ejecutar" CssClass="btn btn-outline-primary w-100" OnClick="btnEjecutar_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                    <label for="chkHabilitarCancelar" class="form-check-label d-none">Habilitar</label>
                                    <asp:CheckBox ID="chkHabilitarCancelar" runat="server" CssClass="form-check-input d-none" AutoPostBack="true" OnCheckedChanged="chkHabilitarCancelar_CheckedChanged" />
                            </td>
                            <td class="auto-style1">
                                <asp:Button ID="btnEliminarInscripcion" runat="server" Text="Cancelar Inscripción" CssClass="btn btn-danger d-none" Enabled="false" />
                            </td>
                        </tr>
                    </table>
            </div>
        </div>
    </div>
</asp:Content>

