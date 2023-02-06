<%@ Page Title="Team's page Control" Language="C#" MasterPageFile="~/Project/SitePR.Master" AutoEventWireup="true" CodeBehind="DataTeam.aspx.cs" Inherits="VuThao.Train.Project.DataTeam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link
        rel="stylesheet"
        href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css"
        integrity="sha512-iBBXm8fW90+nuLcSKlbmrPcLa0OT92xO1BIsZ+ywDWZCvqsWgccV3gFoRBv0z+8dLJgyAHIhR35VZc2oM/gI1w=="
        crossorigin="anonymous" />
    <style>
        aside {
            color: #fff;
            width: auto;
            padding-left: 20px;
            height: 100%;
            background-image: linear-gradient(30deg, #0048bd, #44a7fd);
            border-top-right-radius: 80px;
        }

            aside a {
                font-size: 14px;
                color: #fff;
                display: block;
                padding: 12px;
                padding-left: 30px;
                text-decoration: none;
                -webkit-tap-highlight-color: transparent;
            }

                aside a:hover {
                    color: #3f5efb;
                    background: #fff;
                    outline: none;
                    position: relative;
                    background-color: #fff;
                    border-top-left-radius: 20px;
                    border-bottom-left-radius: 20px;
                }

                aside a i {
                    margin-right: 5px;
                }

                aside a:hover::after {
                    content: '';
                    position: absolute;
                    background-color: transparent;
                    bottom: 100%;
                    right: 0;
                    height: 35px;
                    width: 35px;
                    border-bottom-right-radius: 18px;
                    box-shadow: 0 20px 0 0 #fff;
                }

                aside a:hover::before {
                    content: '';
                    position: absolute;
                    background-color: transparent;
                    top: 38px;
                    right: 0;
                    height: 35px;
                    width: 35px;
                    border-top-right-radius: 18px;
                    box-shadow: 0 -20px 0 0 #fff;
                }

            aside p {
                margin: 0;
                padding: 40px 0;
            }
    </style>
   
    <script type="x-kendo/template" id="template">
      <%--<i class="fas fa-new"></i><input id="undo" style="font-size: 15px;" type="button"   value="Add" onclick="myclick()" />--%>
       <span class="k-icon k-i-edit" value="Add New"></span>
      <input id="undo" style="font-size: 15px;" type="button" value="Add New" onclick="myclick()" />
       
    </script>

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">
        <div>
            <div class="grid-container " style="background-color: white; grid-template-columns: 15% 85%">

                <div class="leftPart">
                    <aside>
                        <p>Menu</p>
                        <a href="#" id="Mybook">
                            <i class="fas fa-book"></i>

                            <span>My Book</span>
                        </a>
                        <%--<a href="#" id="ShowUserGrid">
                            <i class='bx bx-user'></i>

                            <span class="links_name">User</span>
                        </a>--%>
                        <a href="#">
                            <i id="Member" class="fas fa-users"></i>
                            Member
                        </a>
                        <a href="#">
                            <i class="fa fa-clone"></i>
                            Shared with me
                        </a>
                        <a href="#" id="pop">
                           <i class="fas fa-envelope-open-text"></i>
                            Message Admin
                        </a>
                        <a href="#">
                            <i class="fa fa-trash"></i>
                            Trash
                        </a>
                    </aside>
                </div>


                <div class="rightPart">
                    <div id="grid"></div>
                    <div id="gridVol"></div>
                    <div id="popupwindow" style="display:none;">
                        <textarea id="description" style="width: 100%; background: none"></textarea>
                        <br />
                        <a class="button1" style="margin-top: 10px">
                            <span class="btn1" id="updateBook" style="color: #ffffff">Send</span>
                        </a>
                    </div>
                </div>
                <script>
                    $(".button1").click(function () {
                        var clone = new Object();
                        clone.IdUser = sessionStorage.getItem("IdUser");
                        clone.IdBook = 0;
                        clone.content = document.getElementById("description").value;
                        clone.creUser = sessionStorage.getItem("LoginName");
                        console.log(clone);
                        var api = "/api/handler.ashx?tbl=User&func=SendMes";
                        funcPostAPI({
                            data: JSON.stringify(clone)
                        }, api,
                            function (retData) {
                                if (retData == false) {
                                    alert("send Fails");
                                } else {
                                    alert("sucsses");
                                }
                            },
                            function (retData) {

                            }
                        )
                    });

                    $(document).ready(function () {
                        kendowindow.InitKendoWindo();
                        $("#pop").click(function () {
                            $("#popupwindow").data("kendoWindow").open().center();
                        });
                    })

                    var kendowindow = {
                        InitKendoWindo: function () {
                            $("#popupwindow").kendoWindow({
                                title: "Send Message to Admin",
                                width: "400px",
                                modal: true,
                                actions: ["Pin", "Maximize", "Close"],
                                visible: false,
                            })
                        }
                    }
                </script>
                <%--    </div>
            <label id="lbl">Label State Before Calling the Server</label>
            <input id="Button1" type="button" value="Call Server" onload="CallServer('hello');" />

        </div>--%>
            </div>

        </div>
    </form>
</asp:Content>
