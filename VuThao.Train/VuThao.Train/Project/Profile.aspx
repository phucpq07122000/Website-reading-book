<%@ Page Title="" Language="C#" MasterPageFile="~/Project/SitePR.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="VuThao.Train.Project.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="grid-container ">
        <div class="leftPart">
              <%--<div class="grid-container-main">
                


                </div>--%>
            <div >
                   
                    <div>
                     <div class="k-dropzone">
                                <div class="k-button k-button-md k-rounded-md k-button-solid k-button-solid-base k-upload-button" style="width:-webkit-fill-available">

                                  
                                    <input type="file" id="Up"/>
                                    <span>Chọn ảnh đại diện</span>
                                       
                                </div>
                            </div>
                            <%--<div id="image-holder"></div>--%>
                            <div id="products"></div>
                           <p id="demoImage"></p>
                        <a class="demo-hint" style="color: red;">You can only upload <strong>GIF</strong>, <strong>JPG</strong>, <strong>PNG</strong> files.</a>
                    </div>
                    <h4 ></h4>
                </div>
        </div>


        <div class="rightPart">
         
             <div class="grid-container-main">
                <div><input type="text" id="txtName" style="width:250px;" /></div>
                 <div><input type="text" id="txtPassp" style="width:250px;"/></div>
            </div>

            <div class="grid-container-main">
                <div style="margin: auto 0 auto 0;">
                    <label style="margin-right: 60px">Giới Tính</label>
                    <input type="radio" name="gender" id="genderNam" value="Nam" />
                    <input type="radio" name="gender" id="genderNu" value="Nữ" />
                </div>
                <div>
                    <div><input type="text" id="txtEmail" style="width:250px;"/></div>
                </div>
            </div>
            <div class="grid-container-main">
                <div>
                    <label style="margin-right: 19px;">Team or reader</label>
                    <input id="combobox" style="width:250px;"/>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
