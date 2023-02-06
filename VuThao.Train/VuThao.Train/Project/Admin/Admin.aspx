<%@ Page Title="Admin Page" Language="C#" MasterPageFile="~/Project/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="VuThao.Train.Project.Admin.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="example">
        <!--Main-->
            <main class="bg-white-500 flex-1 p-3 overflow-hidden">

                <div class="flex flex-col">
                    <!-- Card Sextion Starts Here -->
                    <div class="flex flex-1  flex-col md:flex-row lg:flex-row mx-2">
                        <!--Horizontal form-->
                        <div class="mb-2 border-solid border-grey-light rounded border shadow-sm w-full md:w-1/2 lg:w-1/2">
                            <div class="bg-gray-300 px-2 py-3 border-solid border-gray-400 border-b">
                                Bordered Table
                            </div>
                            <div class="p-3">
                                <table class="table-fixed">
                                    <thead>
                                      <tr>
                                        <th class="border w-1/2 px-4 py-2">Title</th>
                                        <th class="border w-1/4 px-4 py-2">Author</th>
                                        <th class="border w-1/4 px-4 py-2">Views</th>
                                      </tr>
                                    </thead>
                                    <tbody>
                                      <tr>
                                        <td class="border px-4 py-2">Intro to CSS</td>
                                        <td class="border px-4 py-2">Adam</td>
                                        <td class="border px-4 py-2">858</td>
                                      </tr>
                                      <tr class="bg-gray-100">
                                        <td class="border px-4 py-2">A Long and Winding Tour of the History of UI Frameworks and Tools and the Impact on Design</td>
                                        <td class="border px-4 py-2">Adam</td>
                                        <td class="border px-4 py-2">112</td>
                                      </tr>
                                      <tr>
                                        <td class="border px-4 py-2">Into to JavaScript</td>
                                        <td class="border px-4 py-2">Chris</td>
                                        <td class="border px-4 py-2">1,280</td>
                                      </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <!--/Horizontal form-->

                        <!--Underline form-->
                        <div class="mb-2 md:mx-2 lg:mx-2 border-solid border-gray-200 rounded border shadow-sm w-full md:w-1/2 lg:w-1/2">
                            <div class="bg-gray-200 px-2 py-3 border-solid border-gray-200 border-b">
                                Colored Table
                            </div>
                            <div class="p-3">
                                <table class="table-fixed">
                                    <thead>
                                      <tr>
                                        <th class="border-b bg-black text-white w-1/2 px-4 py-2">Title</th>
                                        <th class="border-b bg-black text-white w-1/4 px-4 py-2">Author</th>
                                        <th class="border-b bg-black text-white w-1/4 px-4 py-2">Views</th>
                                      </tr>
                                    </thead>
                                    <tbody>
                                      <tr>
                                        <td class="border-b bg-blue-400 text-white px-4 py-2">Intro to CSS</td>
                                        <td class="border-b bg-blue-400 text-white px-4 py-2">Adam</td>
                                        <td class="border-b bg-blue-400 text-white px-4 py-2">858</td>
                                      </tr>
                                      <tr class="bg-gray-100">
                                        <td class="border-b bg-green-400 text-white px-4 py-2">A Long and Winding Tour of the History of UI Frameworks and Tools and the Impact on Design</td>
                                        <td class="border-b bg-green-400 text-white px-4 py-2">Adam</td>
                                        <td class="border-b bg-green-400 text-white px-4 py-2">112</td>
                                      </tr>
                                      <tr>
                                        <td class="border-b bg-red-500 text-white px-4 py-2">Into to JavaScript</td>
                                        <td class="border-b bg-red-500 text-white px-4 py-2">Chris</td>
                                        <td class="border-b bg-red-500 text-white px-4 py-2">1,280</td>
                                      </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <!--/Underline form-->
                    </div>
                    <!-- /Cards Section Ends Here -->

                    <!--Grid Form-->

                    <div class="flex flex-1  flex-col md:flex-row lg:flex-row mx-2">
                        <div class="mb-2 border-solid border-gray-300 rounded border shadow-sm w-full">
                            <div class="bg-gray-200 px-2 py-3 border-solid border-gray-200 border-b">
                                Full Table
                            </div>
                            <div class="p-3">
                            <%--    <table class="table-responsive w-full rounded"  id="grid">
                                    <thead>
                                      <tr>
                                        <th class="border w-1/4 px-4 py-2">Idbook</th>
                                        <th class="border w-1/6 px-4 py-2">NameBook</th>
                                        <th class="border w-1/6 px-4 py-2">Name</th>
                                        <th class="border w-1/6 px-4 py-2">Fee</th>
                                        <th class="border w-1/7 px-4 py-2">Status</th>
                                        <th class="border w-1/5 px-4 py-2">Actions</th>
                                      </tr>
                                    </thead>
                                    <tbody>

            <script id="altRowTemplate" type="text/x-kendo-tmpl">
	   <tr>
                                            <td class="border px-4 py-2">Micheal Clarke</td>
                                            <td class="border px-4 py-2">Sydney</td>
                                            <td class="border px-4 py-2">MS</td>
                                            <td class="border px-4 py-2">900 $</td>
                                            <td class="border px-4 py-2">
                                                <i class="fas fa-check text-green-500 mx-2"></i>
                                            </td>
                                            <td class="border px-4 py-2">
                                                <a class="bg-teal-300 cursor-pointer rounded p-1 mx-1 text-white">
                                                        <i class="fas fa-eye"></i></a>
                                                <a class="bg-teal-300 cursor-pointer rounded p-1 mx-1 text-white">
                                                        <i class="fas fa-edit"></i></a>
                                                <a class="bg-teal-300 cursor-pointer rounded p-1 mx-1 text-red-500">
                                                        <i class="fas fa-trash"></i>
                                                </a>
                                            </td>

                                        </tr>
            </script>
                                    </tbody>
                                </table>--%>
                                 <div id="grid"></div>
                                 <div id="gridVol"></div>
                                 <div id="gridUser"></div>
                             
                                     
                          
                                <div id="popup" style="width: 33%">                             
                                    <input id="combobox" />
                                </div>
                               

                                <%-- <script id="name-template" type="text/x-kendo-template">
                       <button onclick="hello2()"> <a class="bg-teal-300 cursor-pointer rounded p-1 mx-1 text-white">
                            <i class="fas fa-eye"></i></a></button>
                      <a class="bg-teal-300 cursor-pointer rounded p-1 mx-1 text-white">
                            <i class="fas fa-edit"></i></a>
                        <a class="bg-teal-300 cursor-pointer rounded p-1 mx-1 text-red-500">
                            <i class="fas fa-trash"></i>
                        </a>

            </script>--%>
                            </div>
                        </div>
                    </div>
                    <!--/Grid Form-->
                </div>
            </main>
            <!--/Main-->
       
        <script>
          
        </script>
    </div>

    <style type="text/css">
        .customer-photo {
            display: inline-block;
            width: 32px;
            height: 32px;
            border-radius: 50%;
            background-size: 32px 35px;
            background-position: center center;
            vertical-align: middle;
            line-height: 32px;
            box-shadow: inset 0 0 1px #999, inset 0 0 10px rgba(0,0,0,.2);
            margin-left: 5px;
        }

        .customer-name {
            display: inline-block;
            vertical-align: middle;
            line-height: 32px;
            padding-left: 3px;
        }
    </style>
    <script type="text/x-kendo-template" id="template">
   
        #var createTemp = kendo.template($("\#editTemplate").html());#
        #=createTemp(data)#
  
    </script>
  
    <script type="text/x-kendo-template" id="editTemplate">
   
        <label>Change Team: </label>
        <input id="Team">
   <span type="button" id="btnsave" class="k-grid-update k-button k-button-md k-rounded-md k-button-solid k-button-solid-primary"><span class="k-icon k-i-check k-button-icon"></span><span class="k-button-text">Update</span></span>
    </script>

</asp:Content>
