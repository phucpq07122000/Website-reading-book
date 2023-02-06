<%@ Page Title="Page Content" Language="C#" MasterPageFile="~/Project/SitePR.Master" AutoEventWireup="true" CodeBehind="pageDoc.aspx.cs" Inherits="VuThao.Train.Project.pageDoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        b {
            color: #94e7e4;
        }

     
        .k-filter-row>td, .k-filter-row>th, .k-grid td, .k-grid-content-locked, .k-grid-footer, .k-grid-footer-locked, .k-grid-footer-wrap, .k-grid-header, .k-grid-header-locked, .k-grid-header-wrap, .k-grouping-header, .k-grouping-header .k-group-indicator, .k-header, th.k-header {
    border-color: aliceblue;
}
        @import url(https://fonts.googleapis.com/css?family=Open+Sans:400,600);

        *, *:before, *:after {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }
         .name {
            display: block;
            font-size: 1.1em;
        }
        body {
            background: #105469;
            font-family: 'Open Sans', sans-serif;
        }

        table {
            background: #012B39;
            border-radius: 0.25em;
            border-collapse: collapse;
            
            margin: 1em;
        }

        th {
            border-bottom: 1px solid #364043;
            color: #E2B842;
            font-size: 0.85em;
            font-weight: 600;
            padding: 0.5em 1em;
            text-align: left;
        }

        td {
            color: #fff;
            font-weight: 400;
            padding: 0.65em 1em;
        }

        .disabled td {
            color: #4F5F64;
        }

        tbody tr {
            transition: background 0.25s ease;
        }

            tbody tr:hover {
                background: #014055;
            }

             
    </style>
   

    <script>
        
        function EditVol(e) {
            e.preventDefault();
            var selectedItem = $("#grid").data("kendoGrid").dataItem($(e.currentTarget).closest("tr"));
            var myWindow2 = $("#windowAddVol");
            myWindow2.data("kendoWindow").center().open();
           
            document.getElementById("NameVol") = selectedItem.Name;
            document.getElementById("CodeVol") = selectedItem.CodeVol;
            document.getElementById("Part") = selectedItem.Part;
            document.getElementById("editor") = selectedItem.editor;
        };
        function onChange(e) {

            //var selectedRows = this.select();
            //var selectedDataItems = [];
            //for (var i = 0; i < selectedRows.length; i++) {
            //    var dataItem = this.dataItem(selectedRows[i]);
            //    selectedDataItems.push(dataItem);
            //}
            var grid = $("#gridVol").data("kendoGrid");
            var selectedItem = grid.dataItem(grid.select());
            // selectedDataItems contains all selected data items
            /* The result can be observed in the DevTools(F12) console of the browser. */
            /* console.log("Selected data items' name: " + selectedDataItems.map(e => e.NameVol).join(", "));*/
            console.log(selectedItem.NameVol);
            sessionStorage.setItem("Vol", selectedItem.Vol);
            console.log(sessionStorage.getItem("Vol"));
           
            window.location.href = "text.aspx";
        };
      

        $(window).load(function () {
            var idbook = sessionStorage.getItem("IdBook");
            CallServer(idbook);
        });

        function HandleResult(arg, context) {

            const clone = JSON.parse(arg)
            if (clone.Image != "" && clone.Image != null) {
                $(".product").remove();
                $("<div class='product'><img  src=data:image/png;base64," + clone.Image + " /></div>").appendTo($("#products"));


            }
            lblName.innerHTML = clone.Name;
            $("#lblNameActor").text(clone.NameActor);
            $("#lblTeam").text(clone.NameTeam);

            $("#lbldescp").html(clone.Description);
            $("#lbldescp").html($("#lbldescp").text())

            $("#lblCategory").text(clone.Categories);

            
        }
        window.addEventListener("load", LoadFollow);
        function LoadFollow() {
            var api = "/api/handler.ashx?tbl=Book&func=follow";
            var checkfollow = new Object();
            checkfollow.IdBook = sessionStorage.getItem("IdBook");
            checkfollow.IdUser = sessionStorage.getItem("IdUser");
            console.log(checkfollow);
            funcPostAPI({
                data: JSON.stringify(checkfollow)
            }, api,
                function (retData) {

                    if (retData.data < 1 && retData.data != null) {
                       
                        /*<img src="image/png-clipart-heart-gold-heart-icon-love-metal.png" />*/
                        //js add image to span
                        /*document.getElementById("f_name_mark").innerHTML = "<img src='images/icons/tick.png' class='mark'>";*/

                        //jquery add image to span
                        $("#clickfollow").remove();
                        $("#Follow").append("<img id='clickfollow' style='width:37px' src='image/png-clipart-heart-gold-heart-icon-love-metal.png' onclick='myfollow()'/>");
                        //notification.show({
                        //     message: "Upload Successful"
                        //    }, "success");
                    }
                    if (retData.data > 0  ) {

                        /*<img src="image/heart-icon.png" />*/
                        //js add image to span
                        /*document.getElementById("f_name_mark").innerHTML = "<img src='images/icons/tick.png' class='mark'>";*/

                        //jquery add image to span
                        $("#clickfollow").remove();
                        $("#Follow").append("<img id='clickfollow' style='width:37px' src='image/heart-icon.png' onclick='myfollow()' />");
                        //notification.show({
                        //     message: "Upload Successful"
                        //    }, "success");
                    }        
                },
                function (retData) {

                });
            /*document.getElementById("iconNumber").innerHTML = 2;*/
        }
        
        function clearFromvol() {
            document.getElementById("NameVol")='';
            document.getElementById("CodeVol")='';
            document.getElementById("Part")='';
            document.getElementById("editor")='';
        }

        /*let clickfollow = document.querySelector("#clickfollow");*/

        function myfollow() {
            var api = "/api/handler.ashx?tbl=Book&func=clickfollow";
            var checkfollow = new Object();
            checkfollow.IdBook = sessionStorage.getItem("IdBook");
            checkfollow.IdUser = sessionStorage.getItem("IdUser");
            console.log(checkfollow);
            funcPostAPI({
                data: JSON.stringify(checkfollow)
            }, api,
                function (retData) {

                    if (retData.data < 1 ) {

                      
                        notification.show({
                             message: "UnFollow"
                        }, "success");

                        window.location.reload();
                    }
                    if (retData.data > 0 ) {

                        notification.show({
                             message: "Follow"
                        }, "success");
                        window.location.reload();
                    }
                },
                function (retData) {

              });
        }
       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <form id="form1" runat="server">
        <div style="background-color: #3e3939; color: white; width: 80%; margin: 0 auto 0 auto">

            <div class="grid-container-content ">
                <div class="leftPart">
                    <div class="grid-container-doc">
                        <div class="test">
                            <div>
                                <div class="k-dropzone" style="text-align: center;">
                                    <div class="k-button k-button-md k-rounded-md k-button-solid k-button-solid-base k-upload-button" style="width: /* -webkit-fill-available*/200px; margin: 0 auto 0 auto">

                                        <h6 id="hlangue">VietNamese</h6>
                                        <%--   <input type="file" id="Up" />--%>
                                    </div>
                                </div>
                                <%--<div id="image-holder"></div>--%>
                                <div id="products" style="margin: 0 auto 0 auto;"></div>
                                <p id="demoImage"></p>
                                <%--    <a class="demo-hint" style="color: red;">You can only upload <strong>GIF</strong>, <strong>JPG</strong>, <strong>PNG</strong> files.</a>--%>
                            </div>
                            <div id="h4" style="height: /* -webkit-fill-available*/100%; margin: 0 auto 0 auto"></div>

                        </div>
                        <div class="detail">
                            <label id="lblName" style="width: 100%; color: #f1b6b6; margin-left: 0px">TEXT FORMATTINGTEXT FORMATTINGTEXT FORMATTINGTEXT FORMATTINGTEXT FORMATTINGTEXT FORMATTINGTEXT FORMATTING TEXT FORMATTING</label>
                            <br />
                            <b>Actor:</b>
                            <label id="lblNameActor">dsd</label>
                            <%--&ensp; &ensp;--%>
                            <br />
                            <br />
                            <b>TeamTranslate:</b>
                            <label id="lblTeam"></label>
                            <br />
                            <br />
                            <b>Categories:</b><label style="width: auto" id="lblCategory"></label>&ensp; &ensp;
                        <%--    <b>Giới tích:</b><label id="lblSex"></label>--%>
                             <br />
                             <br />
                            <span id="Follow" style="width:40px" ></span>
                        </div>


                    </div>
                    <div>
                        <hr style="border-top: 3px dotted #4cff00;" />
                        <b style="margin-left:15px">Descripton</b><br />
                        <span id="lbldescp" style="margin-left:15px"></span>
                        <hr style="border-top: 3px dotted #4cff00;" />


                    </div>

                    <div class="gridVol">
                        <%--    <div id="gridVol"></div>--%>
                      <script id="rowTemplate" type="text/x-kendo-tmpl">
	                    
                        <tbody>
                            <tr>
                                <td style="width: 150px; text-align: center; justify-content: center" >#: Part#</td>

                                <td class="details">
                                    <span class="name" >#: NameVol# </span>
                                    <span class="title" style="font-size: 12px" >#: kendo.toString(kendo.parseDate(CreDate), "dd/MM/yyyy") #
                                           
                                    </span>


                                </td>
                            </tr>
                        </tbody>
                  </script>
                 
                        <table id="gridVol">
                            <thead>
                                <tr>
                                    <th style="width:150px; text-align: center; justify-content: center">Part
                                    </th>
                                    <th style=" text-align: center; justify-content: center">Name
                                    </th>      
                                    
                                </tr>
                            </thead>
                            
                        </table>

                        <script>
                            $(document).ready(function () {
                                dataSource2 = new kendo.data.DataSource({
                                    transport: {
                                        read: function (e) {

                                            dataType: "json";
                                            var id = sessionStorage.getItem("IdBook");
                                            var api = "/api/handler.ashx?tbl=Book&func=ReadVol";
                                            funcPostAPI({
                                                data: id
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
                                    batch: true,
                                    autoHidePrevious: true,
                                    autoHideNext: true,
                                    pageSize: 5, // The number of items per page.
                                    page: 1,
                                    sort: { field: "Part", dir: "desc" }

                                });


                                $("#gridVol").kendoGrid({
                                    dataSource: dataSource2,
                                    change: onChange,
                                    selectable: "true",
                                    navigatable: true,

                                    pageable: {
                                        alwaysVisible: false,
                                        pageSizes: [5, 10, 20, 100],
                                        change(e) {
                                            console.log(pageSizes.pageSize)
                                        }
                                    },
                                
                                    //height: 550,
                                    //toolbar: ["create", "save", "cancel"],
                                /*    toolbar: kendo.template($("#template").html()),*/
                                    rowTemplate: kendo.template($("#rowTemplate").html()),
                                    
                                    height: 550,
                                    
                                    


                                });
                            });
                        </script>
                        <div id="windowVol">
                        </div>
                    </div>
                </div>
                <%--end left--%>
                <div class="rightPart">
                </div>
            </div>
        </div>
    </form>
</asp:Content>
