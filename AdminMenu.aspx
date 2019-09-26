<%@ Page Title="" Language="C#" MasterPageFile="~/landing.Master" AutoEventWireup="true" CodeBehind="AdminMenu.aspx.cs" Inherits="SomosTovee.AdminMenu" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Assets/Css/StyleSheetAdmin.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container contenido">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Usuarios registrados: "></asp:Label>
        <asp:Label ID="lblUsuarios" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Grupos registrados: "></asp:Label>
        <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
        <br />
        <a class="text-left" data-toggle="modal" data-dismiss="modal" data-target="#toveeModalRegistroAdmin">Registrar Usuarios</a>

        <%--<asp:Label Text="text" runat="server" />
        <asp:TextBox runat="server"></asp:TextBox>--%>

        <!-- Modal registro usuarios administrador-->
        <div class="modal fade" id="toveeModalRegistroAdmin" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Registro usuario
                        </h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="txtNombre">Nombre:</label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control "></asp:TextBox>
                            <div class="invalid-feedback">
                                Debe ingresar un nombre*
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="txtSegundoNombre">Segundo Nombre:</label>
                            <asp:TextBox ID="txtSegundoNombre" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtApellido">Apellido:</label>
                            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                            <div class="invalid-feedback">
                                Debe ingresar primer apellido*
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="txtSegundoApellido">Segundo Apellido:</label>
                            <asp:TextBox ID="txtSegundoApellido" runat="server" CssClass="form-control"></asp:TextBox>
                            <div class="invalid-feedback">
                                Debe ingresar segundo apellido*
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="txtCedula">Cedula:</label>
                            <asp:TextBox ID="txtCedula" runat="server" CssClass="form-control" TextMode="Number" Text="0" MaxLength="10"></asp:TextBox>
                            <div class="invalid-feedback">
                                Debe ingresar numero de cedula*
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="txtCorreo">Correo:</label>
                            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                            <div class="invalid-feedback">
                                <asp:Label ID="mensajeInformacionCorreo" Text="text" runat="server" />                                
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="txtcontraseña">Contraseña:</label>
                            <asp:TextBox ID="txtcontraseña" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                            <div class="invalid-feedback">
                                Debe ingresar contraseña*
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="txtvalidarContraseña">Repetir Contraseña:</label>
                            <asp:TextBox ID="txtvalidarContraseña" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                            <div class="invalid-feedback">
                                las contraseñas deben ser iguales*
                            </div>
                        </div>
                    </div>
                    <div class="botonModal">
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                        <asp:Button ID="btnAceptarRegistro" runat="server" Text="Button" CssClass="btn btn-primary" OnClick="btnAceptarRegistro_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
