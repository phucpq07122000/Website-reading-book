<%@ Page Title="Profile User" Language="C#" MasterPageFile="~/Project/SitePR.Master" AutoEventWireup="true" CodeBehind="ProfileU.aspx.cs" Inherits="VuThao.Train.Project.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        /*  CallServer('hello')*/
        window.addEventListener("load", (event) => {
            var CheckLogin = new Object();
            CheckLogin.UserName = "PhucPQ";
            CheckLogin.PassWord = 123456;
            CheckLogin.IdUser = sessionStorage.getItem("IdUser");;


            CallServer(JSON.stringify(CheckLogin));

        });

        function HandleResult(arg, context) {

            const a = JSON.parse(arg)

            //console.log(a[0].IdUser);
            //lbl.innerHTML = arg;
            $("#txtName").val(a[0].UserName);
            $("#txtPassp").val(a[0].PassWord);
            $("#txtEmail").val(a[0].Email);
            /* $("#combobox").data("kendoComboBox").value(a[0].NameTeam);*/
            $("#combobox").kendoComboBox();
            $("#combobox").data("kendoComboBox").value(a[0].NameTeam);
            var combobox = $("#combobox").data("kendoComboBox");
            /*        alert(combobox.dataValueField());*/
            combobox.readonly(true);
            console.log(a[0].IdTeam);
            var checkSex = a[0].Sex.trim();
            if (checkSex == 'Nam') {


                document.getElementById("genderNam").checked = true;

            } else {

                document.getElementById("genderNu").checked = true;

            }

            if (a[0].Image != "" && a[0].Image != null) {
                $(".product").remove();
                $("<div class='product'><img  src=data:image/png;base64," + a[0].Image + " /></div>").appendTo($("#products"));


            }
            else {
                $(".product").remove();
                $("<div class='product'>Không có ảnh đại diện</div>").appendTo($("#products"));

            }

        }

    function Save() {
            var User = new Object();
            User.IdUser = sessionStorage.getItem("IdUser");
            User.UserName = document.getElementById("txtName").value;
            User.PassWord = document.getElementById("txtPassp").value;
            User.Email = document.getElementById("txtEmail").value;
            User.IDTeam = 0;
            var ele = document.getElementsByName('gender');

        
            //User.Image = null;
            for (i = 0; i < ele.length; i++) {
                if (ele[i].checked)

                    User.Sex = ele[i].value;
            }
            var api = "/api/handler.ashx?tbl=User&func=Update";
            funcPostAPI({
                data: JSON.stringify(User)
            }, api,
                function (retData) {
                    alert(retData.data)
                },
                function (retData) {

                }
            )

    };

    </script>
    <%--    <script>
        $("#getValue").click(function () {
            console.log(kendoComboBox);
         
        });
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div>
            <div class="grid-container " style="background-color:white">

                <div class="leftPart">
                    <%--<div class="grid-container-main">
                


                </div>--%>
                    <div>

                        <div>
                            <div class="k-dropzone">
                                <div class="k-button k-button-md k-rounded-md k-button-solid k-button-solid-base k-upload-button" style="width: -webkit-fill-available">


                                    <input type="file" id="Up" />
                                    <span>Chọn ảnh đại diện</span>

                                </div>
                            </div>
                            <%--<div id="image-holder"></div>--%>
                            <div id="products"></div>
                            <p id="demoImage"></p>
                            <a class="demo-hint" style="color: red;">You can only upload <strong>GIF</strong>, <strong>JPG</strong>, <strong>PNG</strong> files.</a>
                        </div>
                        <h4></h4>
                    </div>
                </div>


                <div class="rightPart">

                    <div class="grid-container-main" style="margin-top:30px">
                        <div>
                            <input type="text" id="txtName" style="width: 250px;" /></div>
                        <div>
                            <input type="password" id="txtPassp" style="width: 250px;" /></div>
                    </div>

                    <div class="grid-container-main">
                        <div style="margin: auto 0 auto 0;">
                            <label style="width: 120px">Giới Tính</label>
                            <input type="radio" name="gender" id="genderNam" value="Nam" />
                            <input type="radio" name="gender" id="genderNu" value="Nữ" />
                        </div>
                        <div>
                            <div>
                                <input type="text" id="txtEmail" style="width: 250px; /*margin-left: 35px*/" /></div>
                        </div>
                    </div>
                    <div class="grid-container-main">
                        <div>
                            <label style="margin-right: 8px;">Team or reader</label>
                            <input id="combobox" style="width: 250px;" />
                        </div>
                    </div>
                   <%-- <input id="getValue" type="button" value="Get" onclick="hi()" />--%>
                    <div id="btSave" style="height: 200px">
                        <button id="saveProfile" class="btn btn-success" style="margin-right: 130px" onclick="Save()"><i class="fas fa-save"></i>|Update</button>
                    </div>
                </div>
                <%--    </div>
            <label id="lbl">Label State Before Calling the Server</label>
            <input id="Button1" type="button" value="Call Server" onload="CallServer('hello');" />

        </div>--%>
            </div>

        </div>
    </form>
</asp:Content>
