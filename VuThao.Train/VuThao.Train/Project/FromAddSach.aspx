<%@ Page Title="Page Add book" Language="C#" MasterPageFile="~/Project/SitePR.Master" AutoEventWireup="true" CodeBehind="FromAddSach.aspx.cs" Inherits="VuThao.Train.Project.FromAddSach" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .grid-container-main input {
            border-style: inset;
            border: 3px solid #607db8;
            border-radius: 3px;
        }

        label {
            font-size: 19px;
        }

        textarea.k-input-inner {
            border: 2px solid rgb(128, 128, 128)
        }

        .k-input-inner {
            padding: 4px 8px;
            width: 100%;
            border: none;
            outline: 0;
            color: inherit;
            background: antiquewhite;
            font: inherit;
            -ms-flex: 1;
            flex: 1;
            position: relative;
            z-index: 1;
            overflow: hidden;
            text-overflow: ellipsis;
            -webkit-appearance: none;
        }

        @import url('https://fonts.googleapis.com/css2?family=Raleway:wght@100;500&display=swap');

        :root {
            --primary-color: #41C2CB;
            --secondary-color: #80D6DC;
        }

        content * {
            box-sizing: border-box;
        }



        content h1 {
            font-weight: bold;
            margin: 0;
        }

        content h2 {
            text-align: center;
        }

        content p {
            font-size: 14px;
            font-weight: 100;
            line-height: 20px;
            margin: 20px 0 30px;
        }

        content a {
            color: #333;
            font-size: 14px;
            text-decoration: none;
            margin: 15px 0;
        }

        content button {
            border-radius: 20px;
            border: 1px solid var(--primary-color);
            background-color: var(--secondary-color);
            color: #FFFFFF;
            font-size: 12px;
            font-weight: bold;
            padding: 12px 45px;
            text-transform: uppercase;
            cursor: pointer;
        }

            content button:hover {
                transform: scale(1.05);
            }

            content button.signup_btn {
                background-color: transparent;
                border-color: #FFFFFF;
            }

        content form {
            background-color: #FFFFFF;
            display: flex;
            align-items: center;
            justify-content: center;
            flex-direction: column;
            padding: 0 50px;
            height: 100%;
            text-align: center;
        }

        content input {
            background-color: #EDEDEE;
            border: none;
            padding: 12px 15px;
            margin: 8px 0;
            width: 100%;
        }

        content .container {
            background-color: #fff;
            border-radius: 10px;
            box-shadow: 0 14px 28px rgba(0,0,0,0.25), 0 10px 10px rgba(0,0,0,0.22);
            position: relative;
            overflow: hidden;
            width: 999px;
            max-width: 100%;
            min-height: 480px;
        }

        content .form {
            position: absolute;
            top: 0;
            height: 100%;
        }

        content .sign-in-container {
            left: 0;
            width: 50%;
        }

        content .overlay-container {
            position: absolute;
            top: 0;
            left: 50%;
            width: 50%;
            height: 100%;
            overflow: hidden;
        }

        content .overlay {
            background: #41C2CB;
            background: linear-gradient(to right, var(--secondary-color), var(--primary-color));
            background-repeat: no-repeat;
            background-size: cover;
            background-position: 0 0;
            color: #FFFFFF;
            position: relative;
            left: -100%;
            height: 100%;
            width: 200%;
        }

        content .overlay-panel {
            position: absolute;
            display: flex;
            align-items: center;
            justify-content: center;
            flex-direction: column;
            padding: 0 40px;
            text-align: center;
            top: 0;
            height: 100%;
            width: 50%;
        }

        content .overlay-right {
            right: 0;
        }

        content .social-container {
            margin: 20px 0;
        }

            content .social-container a {
                border: 1px solid var(--primary-color);
                border-radius: 50%;
                display: inline-flex;
                justify-content: center;
                align-items: center;
                margin: 0 5px;
                height: 40px;
                width: 40px;
            }

                content .social-container a:hover {
                    transform: scale(1.08);
                }
    </style>
    <script>
        var combobox;
        $(document).ready(function () {
            dataSource = new kendo.data.DataSource({
                transport: {
                    read: {
                        url: "http://localhost:44398/api/handler.ashx?tbl=User&func=ReadActor",
                        dataType: "json",
                    },
                },
                schema: {
                    data: function (response) {
                        return response.data;
                        // return response; // trả giá trị data debug chỗ này để xem kết quả
                    },
                },

            });
            $("#comboboxActor").kendoComboBox({
                animation: {
                    close: {
                        effects: "fadeOut zoom:out",
                        duration: 300
                    },
                    open: {
                        effects: "fadeIn zoom:in",
                        duration: 300
                    }
                },
                dataSource: dataSource,
                select: onSelect,
                dataTextField: "NameActor",
                dataValueField: "IdActor"
            });
            //var comboboxActor = $("#comboboxActor").data("kendoComboBox");
            //comboboxActor.value(0);
            function onSelect(e) {
                var dataItem = e.dataItem;
                console.log("event :: select (" + dataItem.NameActor + " : " + dataItem.IdActor + ")");
                sessionStorage.setItem("IdActor", dataItem.IdActor);
            };

        });
       /* var combobox = $("#combobox").data("kendoComboBox");*/



    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <content>
        <%--  <div class="grid-container-content ">
            <div class="leftPart">
            
            </div>
         
            <div class="rightPart">
            </div>
        </div>--%>
        <div class="container">
            <div class="form sign-in-container">
                <form action="#">
                    <h1>Add New Book</h1>

                    <input id="comboboxActor" <%--style="width: 250px; "--%> placeholder="Actor" />

                    <br />
                    <label>Category</label>
                    <%-- <input id="Category" style="width: 350px;" />--%>
                    <select id="Category" multiple="multiple" <%--style="width:750px"--%>></select>
                    <br />
                    <textarea id="description" style="width: 100%; background: none"></textarea>


                    <br />

                    <button id="saveBook" onclick="SaveBook()">SAVE</button>
                </form>
            </div>
            <div class="overlay-container">
                <div class="overlay">
                    <div class="overlay-panel overlay-right">
                        <div class="test">
                            <div>
                                <div class="k-dropzone" style="text-align: center;">
                                    <div class="k-button k-button-md k-rounded-md k-button-solid k-button-solid-base k-upload-button" style="width: /* -webkit-fill-available*/200px; margin: 0 auto 0 auto">

                                        <input type="file" id="UpBook" />
                                        <span>Image</span>
                                    </div>
                                </div>
                                <%--<div id="image-holder"></div>--%>
                                <div id="products" style="margin: 0 auto 0 auto"></div>
                                <p id="demoImage"></p>
                                <%--    <a class="demo-hint" style="color: red;">You can only upload <strong>GIF</strong>, <strong>JPG</strong>, <strong>PNG</strong> files.</a>--%>
                                <input type="text" id="ResUserName" style="max-width: 450px; min-width: 300px" placeholder="Book's Name" />
                            </div>

                        </div>
                    </div>
                </div>
            </div>


        </div>
    </content>
</asp:Content>
