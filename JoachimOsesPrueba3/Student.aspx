<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="JoachimOsesPrueba3.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row justify-content-center">
        <div class=" card col-5">
            <div class="card-header">
                Lista Alumnos
            </div>
            <div class="card-body">
                <asp:ListBox ID="lstStudents" runat="server" CssClass="w-100" OnSelectedIndexChanged="lstStudents_SelectedIndexChanged" AutoPostBack="true">

                </asp:ListBox>
                <asp:Label ID="lblNoRecords" runat="server" Text="No hay registros disponibles" Visible="False" CssClass="text-center text-danger"></asp:Label>
            </div>
        </div>
        <div class="card col-4">
            <div class="card-header text-center text-muted">
                Acciones
            </div>
            <div class="card-body p-1">
                <table class="w-100 mt-0 mb-1">
                    <tr>
                        <td class="text-right align-middle"><asp:Label ID="Label1" runat="server" Text="Rut" ></asp:Label></td>
                        <td><asp:TextBox ID="txtRut" runat="server" CssClass="w-100" MaxLength="10" onfocus="selectAllText(this)" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="text-right align-middle"><asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label></td> 
                        <td><asp:TextBox ID="txtStudentName" runat="server" CssClass="w-100" MaxLength="10" onfocus="selectAllText(this)"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="reset" runat="server" Text="Restablecer Campos" CssClass="w-100 btn btn-outline-secondary" OnClick="reset_Click" /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="studentId" runat="server" Text="" CssClass="d-none"></asp:Label>
                            <hr class="w-80"/>
                        </tr>
                    <tr>
                        <td colspan="2"><asp:Button ID="btnSave" runat="server" Text="Verificar" CssClass="w-100 btn btn-outline-primary" OnClick="btnSave_Click" /></td>
                    </tr>
                    <tr>
                        <td class="text-right align-middle"><asp:CheckBox ID="habilitateDelete" runat="server" Text="¿Eliminar?" OnCheckedChanged="habilitateDelete_CheckedChanged" AutoPostBack="true" /></td>
                        <td><asp:Button ID="btnDelete" runat="server" Text="Eliminar" CssClass="w-100 btn btn-sm btn-outline-danger" Enabled="False" OnClick="btnDelete_Click"/></td>
                    </tr>
                </table>
            </div>
            <div class="card-footer text-center">
                <asp:Label ID="lbldbManager" runat="server" Text="dbMessages"></asp:Label>
            </div>
        </div>
    </div>
   <script>
       function selectAllText(textbox) {
           textbox.select();
       }
   </script>

</asp:Content>
