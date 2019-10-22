<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GestionPaciente.aspx.cs" Inherits="CapaPresentacion.GestionPaciente" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h1 style="text-align: center">Registrar Paciente</h1>
    </section>
    <div class="content">
        <div class="row">
            <div class="col-md-12">
                <%-- Formulario izquierda --%>
                <div class="col-md-6">
                    <div class="box box-primary">
                        <div class="box-body">
                            <div class="form-group">
                                <label>DOCUMENTO DE IDENTIDAD</label>
                            </div>
                            <div class=" form-group">
                                <asp:TextBox ID="txtNroDocumento" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>NOMBRE</label>
                            </div>
                            <div class=" form-group">
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>APELLIDO PATERNO</label>
                            </div>
                            <div class=" form-group">
                                <asp:TextBox ID="txtApPaterno" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>APELLIDO MATERNO</label>
                            </div>
                            <div class=" form-group">
                                <asp:TextBox ID="txtApMaterno" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>

                <%-- Formulario derecha --%>
                <div class="col-md-6">
                    <div class="box box-primary">
                        <div class="box-body">
                            <div class="form-group">
                                <label>SEXO</label>
                            </div>
                            <div class=" form-group">
                                <asp:DropDownList ID="ddlSexo" runat="server" CssClass="form-control">
                                    <asp:ListItem>Masculino</asp:ListItem>
                                    <asp:ListItem>Femenino</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label>EDAD</label>
                            </div>
                            <div class=" form-group">
                                <asp:TextBox ID="txtEdad" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>TELEFONO</label>
                            </div>
                            <div class=" form-group">
                                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>DIRECCIÓN</label>
                            </div>
                            <div class=" form-group">
                                <asp:TextBox ID="txtDireccion" runat="server" CssClass=" form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>

                <div align="center">
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary" Text="Registrar" Width="200px" OnClick="btnRegistrar_Click" /></td>
                            <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            <td>
                                <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" Text="Cancelar" Width="200px" /></td>
                        </tr>
                    </table>
                </div>

            </div>

        </div>


        <%-- Tabla de pacientes --%>
        <br />
        <div class="row">
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="box-title">Lista de Pacientes</h3>
                    </div>
                    <div class="box box-body">
                        <div class="table table-responsive">
                            <table id="tbl_pacientes" class="table-bordered table-hover">
                                <thead>
                                    <tr>
                                        <th>Codigo</th>
                                        <th>Nombres</th>
                                        <th>Apellidos</th>
                                        <th>Sexo</th>
                                        <th>Edad</th>
                                        <th>Direccion</th>
                                        <th>Estado</th>
                                        <th>Accion</th>
                                    </tr>
                                </thead>
                                <tbody id="tbl_body_table">
                                    <%-- Data JQuery--%>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <%-- Modal --%>
    <div class="modal fade" id="imodal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dimiss="modal" aria-label="Close"><span aria-hidden="true" data-dismiss="modal">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel">Actualizar Registro</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Nombres</label>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtNames" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Apellidos</label>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtLastNames" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Direccion</label>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtAddress" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" id="btnActualizar">Actualizar</button>
                </div>
            </div>
        </div>
    </div>

    <script src="js/Paciente.js" type="text/javascript"></script>
</asp:Content>
