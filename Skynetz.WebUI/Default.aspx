<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Skynetz.WebUI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <div class="row">
            <div class="col-sm-2">
                <div class="form-group">
                    <label>Origem</label>
                </div>
                <asp:DropDownList ID="DropDownOrigin" runat="server" Width="80%" Height="25px"></asp:DropDownList>
            </div>
            <div class="col-sm-2">
                <div class="form-group">
                    <label>Destino</label>
                </div>
                <asp:DropDownList ID="DropDownDestiny" runat="server" Width="80%" Height="25px"></asp:DropDownList>
            </div>
            <div class="col-sm-2">
                <div class="form-group">
                    <label>Plano</label>
                </div>
                <asp:DropDownList ID="DropDownFaleMais" runat="server" Width="80%" Height="25px"></asp:DropDownList>
            </div>
            <div class="col-sm-2">
                <div class="form-group">
                    <label>Minutos</label>
                </div>
                <asp:TextBox ID="TextBoxMinutes" runat="server" Width="80%" TextMode="Number" Height="25px"></asp:TextBox>
            </div>
            <div class="col-sm-2">
                <input type="button" id="buttonSearch" value="Consultar" class="btn btn-primary" style="margin-top: 30px; background-color: black" />
            </div>
        </div>
    </div>

    <div>
        <table id="mainTable" class="table table-striped"></table>
    </div>

    
    <script src="Scripts/jquery-3.6.1.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#buttonSearch").click(function () {

                let origin = $("#MainContent_DropDownOrigin option:selected").text();
                let destiny = $("#MainContent_DropDownDestiny option:selected").text();
                let idPlan = $("#MainContent_DropDownFaleMais option:selected").val();
                let minutes = $("#MainContent_TextBoxMinutes").val();

                var DTO = {
                    origin: origin,
                    destiny: destiny,
                    idPlan: idPlan,
                    minutes: minutes
                };

                $.ajax({
                    type: "POST",
                    url: '<%= ResolveUrl("Default.aspx/GetPlanFaleMaisSearch") %>',
                    data: JSON.stringify(DTO),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $("#mainTable").empty();
                        if (data.d.length > 0) {

                            $("#mainTable").append("<tbody><tr><th>" +
                                "ORIGEM" + "</th><th>" +
                                "DESTINO" + "</th><th>" +
                                "PLANO" + "</th><th>" +
                                "TEMPO" + "</th><th>" +
                                "COM FALE MAIS" + "</th><th>" +
                                "SEM FALE MAIS" + "</th></tr>");

                            for (var i = 0; i < data.d.length; i++) {
                                $("#mainTable").append("<tr><td>" +
                                    data.d[i].Origin + "</td><td>" +
                                    data.d[i].Destiny + "</td><td>" +
                                    data.d[i].Name + "</td><td>" +
                                    data.d[i].MinuteTime + "</td><td>" +
                                    data.d[i].WithFalaMais + "</td><td>" +
                                    data.d[i].WithoutFalaMais + "</td></tr>");
                            }
                            $("#mainTable").append("</tbody>");
                        }
                        else {
                            $("#mainTable").append("Não encontrado!");
                        }
                    },
                    failure: function (response) {
                        alert(response.d);
                    },
                    error: function (response) {
                        alert(response.d);
                    }
                });
            });
        })
    </script>

</asp:Content>
