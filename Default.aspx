<%@ Page Title="" Language="C#" MasterPageFile="~/landing.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SomosTovee._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- About Section -->
    <section id="about" class="about-section text-center">
        <div class="container">
            <div class="row">
                <div class="col-lg-8 mx-auto">
                    <h2 class="text-white mb-4">¿Quiénes Somos?</h2>
                    <p class="text-white-50">
                        Tovee group esta conformada por un grupo de empresas  asociadas, buscando el mejoramiento de los productos de nuestro mercado, dando una mejor 
                        accepcibilidad al mercado con precios al alcance de todo publico.Buscamos el mejoramiento de productos y la implementación de nuevas, mejores y renovadas ideas.
                    </p>
                </div>
            </div>
            <img src="Assets/lib/startbootstrap-grayscale/img/ipad.png" class="img-fluid" alt="">
        </div>
    </section>

    <!-- Projects Section -->
    <section id="projects" class="projects-section bg-light">
        <div class="container">

            <!-- Featured Project Row -->
            <div class="row align-items-center no-gutters mb-4 mb-lg-5">
                <div class="col-xl-8 col-lg-7">
                    <img class="img-fluid mb-3 mb-lg-0" src="Assets/lib/startbootstrap-grayscale/img/bg-masthead.jpg" alt="">
                </div>
                <div class="col-xl-4 col-lg-5">
                    <div class="featured-text text-center text-lg-left">
                        <h4>Misión</h4>
                        <p class="text-black-50 mb-0">
                            Mostrar el mundo de una manera diferente.
                        </p>
                    </div>
                </div>
            </div>
            <!-- Featured Project Row -->
            <div class="row align-items-center no-gutters mb-4 mb-lg-5">
                <div class="col-xl-4 col-lg-5">
                    <div class="featured-text text-center text-lg-left">
                        <h4>Visión</h4>
                        <p class="text-black-50 mb-0">
                            Estar en el top 5 de las empresas líder de mayor participación en el mercado en nuestras respectivas líneas, gracias a nuestros distinguidos e innovadores productos.
                        </p>
                    </div>
                </div>
                <div class="col-xl-8 col-lg-7">
                    <img class="img-fluid mb-3 mb-lg-0" src="Assets/lib/startbootstrap-grayscale/img/bg-masthead.jpg" alt="">
                </div>
            </div>

        </div>
    </section>

    <!-- Signup Section -->
    <section id="signup" class="signup-section">
        <div class="container">
            <div class="row">
                <div class="col-md-10 col-lg-8 mx-auto text-center">

                    <i class="far fa-paper-plane fa-2x mb-2 text-white"></i>
                    <h2 class="text-white mb-5">Subscribete para recibir noticias!</h2>

                    <div class="form-inline d-flex">
                        <div class="form-group col-12 txtSuscriptor">
                            <asp:TextBox ID="txtNombreSuscribe" runat="server" CssClass="form-control flex-fill mr-0 mr-sm-2 mb-3 mb-sm-0"  placeholder="Nombre" MaxLength="100"></asp:TextBox>
                            <div class="invalid-feedback">
                                Debe ingresar un nombre*
                            </div>
                        </div>
                        <div class="form-group col-12 txtSuscriptor">
                            <asp:TextBox ID="txtMovilSuscribe" runat="server" CssClass="form-control flex-fill mr-0 mr-sm-2 mb-3 mb-sm-0" TextMode="Number" placeholder="Movil" MaxLength="10"></asp:TextBox>
                            <div class="invalid-feedback">
                                Debe ingresar un numero de ceular*
                            </div>
                        </div>
                        <div class="form-group col-12 txtSuscriptor">
                            <asp:TextBox ID="txtEmailSuscribe" runat="server" CssClass="form-control flex-fill mr-0 mr-sm-2 mb-3 mb-sm-0" TextMode="Email" placeholder="correo electronico" MaxLength="100"></asp:TextBox>
                            <div class="invalid-feedback">
                                Debe ingresar un correo*
                            </div>
                        </div>
                        <br />
                        <div class="form-group col-12 txtSuscriptor">
                            <asp:Button Text="Subscribete" runat="server" CssClass="btn btn-primary mx-auto" ID="btnSuscribete" OnClick="txtSuscribete_Click" />
                        </div>

                    </div>

                </div>
            </div>
        </div>
    </section>
</asp:Content>
