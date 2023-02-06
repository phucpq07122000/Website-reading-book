<%@ Page Title="" Language="C#" MasterPageFile="~/Project/SitePR.Master" AutoEventWireup="true" CodeBehind="PageFollow.aspx.cs" Inherits="VuThao.Train.Project.PageFollow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="leftPart">
            <div id="listView" style="margin:5px 15% 5px 15%"></div>

            <script type="text/x-kendo-template" id="template">
        <div class="product2">
          <%--  <img src="../content/web/foods/#= product222ID #.jpg" alt="#: product222Name # image" />--%>
            <img src='data:image/png;base64,#=Image#''/>
            <h3>#:Name#</h3>
           <%-- <p>#:kendo.toString(UnitPrice, "c")#</p>--%>
        </div>
            </script>

            <script>
                $(function () {
                    $("#listView").kendoListView({
                        dataSource: {
                            transport: {
                                read: function (e) {

                                    dataType: "json";
                                    var idTeam = sessionStorage.getItem("IdUser");
                                    var api = "/api/handler.ashx?tbl=Book&func=Follow";
                                    funcPostAPI({
                                        data: idTeam
                                    }, api,
                                        function (httpRequest) {
                                            e.success(httpRequest.data);
                                        }, function (retData) {

                                      });
                                },

                            },
                            schema: {
                                data: function (response) {
                                    return response; // trả giá trị data debug chỗ này để xem kết quả
                                }
                            },
                            pageSize: 21
                        },
                        selectable: "multiple",
                        pageable: true,
                        dataBound: onDataBound,
                       /* change: onChange,*/
                        template: kendo.template($("#template").html()),
                      
                    });
                    function onDataBound() {
                        $(".product2").on("dblclick", function () {
                            var listView = $("#listView").data("kendoListView");
                            var idx = $(this).index();
                            var item = listView.dataSource.view()[idx];
                            sessionStorage.setItem("IdBook", item.IdBook)
                            window.location.href ="pageDoc.aspx";
                          
                            
                        });
                    }
                    //function onChange() {
                    //    var data = this.dataSource.view(),
                    //        selected = $.map(this.select(), function (item) {
                    //            return data[$(item).index()].IdBook;
                    //        });

                    //    console.log("Selected: " + selected.length + " item(s), [" + selected.join() + "]");
                    //}
                });
            </script>

            <style>
                #listView {
                    padding: 10px 5px;
                    margin-bottom: -1px;
                    min-height: 510px;
                }

                .k-listview-content {
                    overflow: hidden;
                }

                .product2 {
                    float: left;
                    position: relative;
                    width: auto;
                    height:auto;
                    margin: 0 5px;
                    padding: 6px;
                }

                    .product2 img {
                        width: 110px;
                        height: 150px;
                    }

                    .product2 h3 {
                        margin: 0;
                        padding: 3px 5px 0 0;
                        max-width: 96px;
                        overflow: hidden;
                        line-height: 1.1em;
                        font-size: .9em;
                        font-weight: normal;
                        text-transform: uppercase;
                        color: #999;
                    }

                    .product2 p {
                        visibility: hidden;
                    }

                    .product2:hover p {
                        visibility: visible;
                        position: absolute;
                        width: 110px;
                        height: 110px;
                        top: 0;
                        margin: 0;
                        padding: 0;
                        line-height: 110px;
                        vertical-align: middle;
                        text-align: center;
                        color: #fff;
                        background-color: rgba(0,0,0,0.75);
                        transition: background .2s linear, color .2s linear;
                        -moz-transition: background .2s linear, color .2s linear;
                        -webkit-transition: background .2s linear, color .2s linear;
                        -o-transition: background .2s linear, color .2s linear;
                    }

                .k-listview:after {
                    content: ".";
                    display: block;
                    height: 0;
                    clear: both;
                    visibility: hidden;
                }
            </style>
        </div>

</asp:Content>
