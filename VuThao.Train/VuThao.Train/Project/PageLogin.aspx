<%@ Page Title="Login" Language="C#" MasterPageFile="~/Project/SitePR.Master" AutoEventWireup="true" CodeBehind="PageLogin.aspx.cs" Inherits="VuThao.Train.Project.PageLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1ogin">
        <section>
            <%--start resgesiter--%>
            <div id="window">
                <section>
                    <div class="noi-dung">
                        <div class="form">
                            <div style="text-align: center">
                                <h2>Register Form</h2>
                            </div>
                            <form name="fromResigter">
                                <div class="input-form">
                                    <span>User Name</span>
                                    <input type="text" id="ResUserName" />
                                </div>
                                <div class="input-form">
                                    <span>PassWord</span>
                                    <input type="password" id="ResPass" />
                                </div>
                                <div class="input-form">
                                    <span>Gmail</span>
                                    <input type="email" id="ResGmail" />
                                </div>
                                <div class="grid-container-Sex">
                                    <label style="margin-right: 40px; width:60px">Giới Tính</label>
                                    <input type="radio" name="gender" id="genderNam" value="Nam" />
                                    <input type="radio" name="gender" id="genderNu" value="Nữ" />
                                </div>


                                <div class="input-form">
                                    <input type="button" id="Resigter" value="Đăng Ký" />
                                </div>
                                <div class="input-form">
                                    <p>Bạn Đã Có Tài Khoản? <a  href="PageLogin.aspx" >Đăng Nhập</a></p>
                                </div>
                            </form>

                        </div>
                    </div>
                </section>

            </div>
            <%-- end resiger--%>
            <!--Bắt Đầu Phần Nội Dung-->
            <div class="noi-dung">
                <div class="form">
                    <div style="text-align: center">
                        <h2>Login Form</h2>
                    </div>
                    <form action="">
                        <div class="input-form">
                           <%-- <span>User Name</span>--%>
                            <input id="txtUserName" />
                        </div>
                        <div class="input-form">
                           <%-- <span>PassWord</span>--%>
                            <input type="password" id="txtPass" />
                        </div>
                        <div class="nho-dang-nhap">
                            <%-- <label>
                         <input type="checkbox" name="" />
                         Nhớ Đăng Nhập</label>--%>
                            <input type="checkbox" id="chboxRemLogin" />
                        </div>


                        <div class="input-form">
                            <input type="button" id="Login" value="Đăng Nhập" />
                        </div>
                        <div class="input-form" style="margin:auto; width: 400px">
                            <p style="text-align:center">Bạn Chưa Có Tài Khoản?</p>
                            <input id="undo" type="button" value="Đăng ký" onclick="Resigter()"/>
                           
                        </div>
                    </form>

                </div>
            </div>
            <!--Kết Thúc Phần Nội Dung-->
        </section>

    </form>
</asp:Content>
