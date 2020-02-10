<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="PV._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>S A C C</h1>
        <p class="lead">Ser una empresa consolidada en el mercado y con una cartera de clientes estables para ir creciendo con el paso del tiempo.</p>        
    </div>
    <div class="Container">
    <!-- Main Area -->
    <div id="main_area">
        <!-- Slider -->
        <div class="row">
            <div class="span12" id="slider">
                <!-- Top part of the slider -->
                <div class="row">
                    <div class="span8" id="carousel-bounding-box">
                        <div id="myCarousel" class="carousel slide" >
                            <!-- Carousel items -->
                            <%--<div class="carousel-inner" >
                                <div class="active item" data-slide-number="0" >
                                <img src="Imagenes/11.jpg"/>
                                </div>
                                <div class="item" data-slide-number="1">
                                    <img src="Imagenes/22.jpg"/>
                                </div>
                                <div class="item" data-slide-number="2">
                                    <img src="Imagenes/33.jpg"/>
                                </div>
                                <div class="item" data-slide-number="3">
                                    <img src="Imagenes/44.jpg"/>
                                </div>                                
                            </div>--%>
                            <!-- Carousel nav --> <a class="carousel-control left" href="#myCarousel" data-slide="prev">‹</a>
                            <a class="carousel-control right" href="#myCarousel" data-slide="next">›</a>
                        </div>
                    </div>                   
                </div>
            </div>
        </div>
        <!--/Slider-->        
</div>
</div>  
</asp:Content>
