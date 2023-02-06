<%@ Page Title="" Language="C#" MasterPageFile="~/Project/SitePR.Master" AutoEventWireup="true" CodeBehind="Windows.aspx.cs" Inherits="VuThao.Train.Project.Windows" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css_js/cssNgoai.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <button id="testWindow">here</button>
   <div id="content">
                    <div class="test">
                        <div>
                            <div class="k-dropzone" style="text-align: center;">
                                <div class="k-button k-button-md k-rounded-md k-button-solid k-button-solid-base k-upload-button" style="width: /* -webkit-fill-available*/200px; margin: 0 auto 0 auto">

                                    <input type="file" id="UpBook" />
                                     <span>Chọn ảnh</span>
                                </div>
                            </div>
                            <%--<div id="image-holder"></div>--%>
                            <div id="products" style="margin: 0 auto 0 auto"></div>
                            <p id="demoImage"></p>
                            <%--    <a class="demo-hint" style="color: red;">You can only upload <strong>GIF</strong>, <strong>JPG</strong>, <strong>PNG</strong> files.</a>--%>
                            <input type="text" id="ResUserName" style="max-width: 450px; min-width: 300px" placeholder="Tên truyện" />
                        </div>

                    </div>
                    <div class="grid-container-main" <%--style="position: absolute;"--%>>
                        <div>
                            <label>Actor</label>
                            <input id="comboboxActor" style="width: 250px;" />
                        </div>
                         <div>
                            <label style="margin-right:-50px; font-size:18px">Team</label>
                            <input id="combobox" style="width: 250px;" />
                        </div>
                       
                    </div>
                   
                    <div class="grid-container-main " style="grid-template-columns: 100%;">
                         <div>
                            <label>Thể loại</label>
                           <%-- <input id="Category" style="width: 350px;" />--%>
                             <select id="Category" multiple="multiple" style="width:750px"></select>
                        </div>

                    </div>
                    <div class="grid-content">
                        <%--<label style="margin: 0 10px 0 0; color: dodgerblue;">Mô tả cơ bản</label>
                        <textarea id="editor" style="width: 80%; min-height: 40px"></textarea>--%>
                        <label style="margin: 0 10px 0 0; color: dodgerblue;"></label>
                        <div class="k-d-flex k-justify-content-center" <%--style="padding-top: 54px; --%>">
                            <div class="k-w-300">
                                <textarea id="description"></textarea>
                            </div>
                        </div>
                  
                        <style>
                            .k-floating-label-container {
                                width: 750px;
                            }
                        </style>
                    </div>
                    <div class="test">
                       
                        <button id="saveBook" class="fa fa-save" style="font-size: 20px; color: blue; height: 30px; width: 100px" onclick="SaveBook()">SAVE</button><ion-icon name="log-out-outline"></ion-icon>

                    </div>
              <%--       <div class="test">--%>
                         <a class="button1" ">
                        <span class="btn1" id="updateBook" style="color:#ffffff">Update</span>
                    </a>
                    <%--</div>--%>
                   
                </div>
</asp:Content>
