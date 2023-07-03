<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="Asignaturas.aspx.cs" Inherits="JoachimOsesPrueba3.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row justify-content-center">

    <div class="card p-0 col-3">
        <div class="card-header w-100 text-muted">
            <asp:Label ID="lblcardHeader" runat="server" Text="Label"></asp:Label>
        </div>
        <div class="card-body">
            <asp:ListBox ID="lstAsignaturas" runat="server" AutoPostBack="true" CssClass="w-100" OnSelectedIndexChanged="lstAsignaturas_SelectedIndexChanged"></asp:ListBox>
        </div>

    </div>
    <div class="card p-0 col-5">
        <div class="card-header w-100">
            <asp:Label ID="lblDataHeader" runat="server" Text="Label"></asp:Label>
        </div>
        <div class="card-body">

       <table class="table">
    <tbody>
        <tr>
            <td class="text-end"><label for="codigo">Código:</label></td>
            <td><asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" Required="true"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="text-end"><label for="nombre">Nombre:</label></td>
            <td><asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Required="true"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="text-end"><label for="horas">Horas:</label></td>
            <td><asp:TextBox ID="txtHoras" runat="server" CssClass="form-control" Type="number"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="text-end"><label for="semestre">Semestre:</label></td>
            <td><asp:TextBox ID="txtSemestre" runat="server" CssClass="form-control" Type="number"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" class="text-center">
                <asp:Label ID="lblrecordId" runat="server" Text="Label" CssClass="d-none"></asp:Label>
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-outline-primary w-100" OnClick="btnGuardar_Click" />
            </td>
        </tr>
        <tr>
    <td colspan="2" class="text-center">
        <asp:Button ID="btnReset" runat="server" Text="Reset Fields" CssClass="btn btn-secondary w-100" OnClick="btnReset_Click" UseSubmitBehavior="false" />
    </td>
</tr>
        <tr>
            
                        <td class="text-right align-middle"><asp:CheckBox ID="habilitateDelete" runat="server" Text="¿Eliminar?" OnCheckedChanged="habilitateDelete_CheckedChanged" AutoPostBack="true" /></td>
                        <td><asp:Button ID="btnDelete" runat="server" Text="Eliminar" CssClass="w-100 btn btn-sm btn-outline-danger" Enabled="False" OnClick="btnDelete_Click"/></td>
            
        </tr>
    </tbody>
</table>
        </div>

    </div>
    </div>

</asp:Content>
