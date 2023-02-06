function funcPostAPI(data, api, onSuccess, onFailed) {
    $.ajax({
        url: api,
        type: 'POST',
        cache: false,
        scriptCharset: "utf8",
        dataType: 'json',
        data: data,
        success: onSuccess,
        error: onFailed === undefined ? onRequestFailed : onFailed
    });
}

var UserProfile = new Object();
var datagrid;
dataSource = new kendo.data.DataSource({
    transport: {
        read: {
            url: "http://localhost:44398/api/handler.ashx?tbl=User&func=ReadTeam",
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
$("#combobox").kendoComboBox({
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
    dataTextField: "NameTeam",
    dataValueField: "IdTeam"
});







var myWindow = $("#window");

//sessionStorage.setItem("LoginName", " Login");


/*console.log(personName);*/

$("#logout").click(function () {
    /*sessionStorage.clear();*/

    window.location.href = "PageLogin.aspx";
    sessionStorage.removeItem("LoginName");
    sessionStorage.removeItem("IdUser");
    sessionStorage.removeItem("Role");
    sessionStorage.removeItem("IdTeam");
    window.location.reload();
});
////      Đang ký Acc

$("#Resigter").click(function () {

    var a = getDatalogin();
    console.log(a);
    var b = JSON.stringify(a);
    var api = "/api/handler.ashx?tbl=User&func=insert";
    funcPostAPI({
        data: b
    }, api,
        function (retData) {
            alert(retData.mess.Value);
        },
        function (retData) {

        }
    )


    myWindow.data("kendoWindow").close();
    clearFromlogin();

});

// login
$("#Login").click(function () {
    var CheckLogin = new Object();

    CheckLogin.UserName = document.getElementById("txtUserName").value;
    CheckLogin.PassWord = document.getElementById("txtPass").value;
    //CheckLogin.UserName = "PhucPQ";
    //CheckLogin.PassWord = 123456;
    var api = "/api/handler.ashx?tbl=User&func=check";
    funcPostAPI({
        data: JSON.stringify(CheckLogin)
    }, api,
        function (retData) {
            if (retData.data.length == 0 && retData.data != null) {
                /*   alert("Wrong user or pass");*/
                notification.show({
                    title: "Wrong Password or UserName",
                    message: "Please enter again."
                }, "error");
            } else {
                sessionStorage.setItem("LoginName", retData.data[0].UserName);
                sessionStorage.setItem("IdUser", retData.data[0].IdUser);
                sessionStorage.setItem("IdTeam", retData.data[0].IdTeam);
                sessionStorage.setItem("Role", retData.data[0].Role);

                /*sessionStorage.setItem("[UserProfile]", retData.data[0]);*/ // ko thê luu object

                //UserProfile = retData.data[0];
                //console.log(UserProfile);


                clearFromlogin();
                window.location.reload();
                window.location.href = "ProfileU.aspx";
            }
        },
        function (retData) {

        }
    )

});


// ko chạy vì ???

//$("#getuser").click(function () {

//    var CheckLogin = new Object();

//    //CheckLogin.UserName = document.getElementById("txtUserName").value;
//    //CheckLogin.PassWord = document.getElementById("txtPass").value;

//    CheckLogin.UserName = "PhucPQ";
//    CheckLogin.PassWord = 123456;
//    var api = "/api/handler.ashx?tbl=User&func=abv";
//    funcPostAPI({
//        data: JSON.stringify(CheckLogin)
//    }, api,
//        function (retData) {
//            alert(retData.data)
//        },
//        function (retData) {

//        }
//    )

//});

// chạy vì ???

//$("#profileUser").click(function () {

//    var CheckLogin = new Object();
//    CheckLogin.UserName = "PhucPQ";
//    CheckLogin.PassWord = 123456;
//    CheckLogin.IdUser = sessionStorage.getItem("IdUser");
//    CallServer(JSON.stringify(CheckLogin.IdUser));

//});

//function HandleResult(arg, context) {
//    const a = JSON.parse(arg)
//    console.log(a);
//};


function getDatalogin() {
    //var form = document.forms['form'];
    //form.onsubmit = function (e) {
    var User = new Object();
    /*    User.IdUser = null;*/
    User.UserName = document.getElementById("ResUserName").value;
    User.PassWord = document.getElementById("ResPass").value;
    User.Email = document.getElementById("ResGmail").value;
    var ele = document.getElementsByName('gender');
    //User.IDTeam = null;
    //User.Image = null;
    for (i = 0; i < ele.length; i++) {
        if (ele[i].checked)

            User.Sex = ele[i].value;
    }



    return User;

    //}
}

function clearFromlogin() {
    document.getElementById("ResUserName").value = '';
    document.getElementById("ResPass").value = '';
    document.getElementById("ResGmail").value = '';
    document.getElementById("txtUserName").value = '';
    document.getElementById("txtPass").value = '';
    var ele = document.getElementsByName('gender');

    for (i = 0; i < ele.length; i++) {
        if (ele[i].checked)

            ele[i].value = '';
    }

}
// use files in folder kendo
function SaveBook(e) {
    var book = new Object();
    book.Name = document.getElementById("ResUserName").value;

    book.IdActor = sessionStorage.getItem("IdActor");
    const select = document.getElementById('Category');
    book.Categories = JSON.stringify([...select.selectedOptions]
        .map(option => option.value));
    book.Description = document.getElementById("description").value;
    book.IdTeam = sessionStorage.getItem("IdTeam");
    console.log(JSON.stringify(book))
    if (files == null) {
        /* alert("ko dc bỏ trống ảnh");*/
        notification.show({
            title: "Some inform missing",
            message: "Image can't empty"
        }, "warning");
    } else {
        formData.append('data', JSON.stringify(book));
        formData.append('file', files);
        $.ajax({
            url: '/api/handler.ashx?tbl=Book&func=Create',
            type: 'POST',
            data: formData,
            processData: false,  // tell jQuery not to process the data
            contentType: false,  // tell jQuery not to set contentType
            success: function (data) {
                alert("add success");

            }
        });
        window.location.reload();
    }
}



//data item 
let btnUse = document.querySelector("#Mybook");
btnUse.addEventListener("click", () => {
    $(document).ready(function () {
        $("#grid").show();
        $("#gridVol").hide();
        $("#grid").kendoGrid({
            dataSource: dataSource,

            selectable: "true",
            navigatable: true,

            pageable: {
                alwaysVisible: false,
                pageSizes: [5, 10, 20, 100],

            },

            groupable: true,
            //height: 550,

            toolbar: kendo.template($("#templateBook").html()),
            columns: [
                {
                    field: "Image", title: "User's Image", width: "auto", headerAttributes: { style: 'text-align: center; justify-content: center' }, attributes: { style: 'text-align: center' },
                    //template: "<img src='#=Avatar#'/>",
                    template: "<img src='data: image/png; base64,#=Image#' width='69.3px' height='69.3px'/>",
                },
                { field: "Name", width: "auto", headerAttributes: { style: 'text-align: center; justify-content: center' }, attributes: { style: 'text-align: center' } },
                { field: "Categories", width: "auto", headerAttributes: { style: 'text-align: center; justify-content: center' }, attributes: { style: 'text-align: center' } },
                //{ field: "idImages", width: "auto", headerAttributes: { style: 'text-align: center; justify-content: center' }, attributes: { style: 'text-align: center' } },
                { field: "Description", width: "auto", headerAttributes: { style: 'text-align: center; justify-content: center' }, attributes: { style: 'text-align: center' } },
                { field: "NameActor", width: "auto", headerAttributes: { style: 'text-align: center; justify-content: center' }, attributes: { style: 'text-align: center' } },
                {
                    field: "Created", title: "CreUser and creDate", width: "auto", headerAttributes: { style: 'text-align: center; justify-content: center' }, attributes: { style: 'text-align: center' }
                    , template: " #:CreatedUser# <br/>#: kendo.toString(kendo.parseDate(Created),'dd/MM/yyyy hh:mm') #",

                },
                //{ field: "CreatedUser", title: "Người Tạo", width: "auto", headerAttributes: { style: 'text-align: center; justify-content: center' }, attributes: { style: 'text-align: center' } },

                {
                    command: [
                        { text: "Edit", iconClass: "k-icon k-i-edit", click: EDIT }
                        , { text: "Delete", iconClass: "k-icon k-i-delete", click: DeleteBook, }
                        , { text: "ShowVol", iconClass: "k-icon k-i-eye", click: ShowVol, }
                    ], attributes: { style: 'text-align: center' },

                    /* title: " ", width: "170px", background: "blue",*/
                },
            ],


        });
        dataSource = new kendo.data.DataSource({
            transport: {
                read: function (e) {

                    dataType: "json";
                    var idTeam = sessionStorage.getItem("IdTeam");
                    var api = "/api/handler.ashx?tbl=Book&func=SeBookByTeam";
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
            batch: true,
            autoHidePrevious: true,
            autoHideNext: true,
            pageSize: 5, // The number of items per page.
            page: 1,


        });
        var grid = $("#grid").data("kendoGrid");
        grid.setDataSource(dataSource);
    });
});

function EDIT(e) {
    e.preventDefault();
    var selectedItem = $("#grid").data("kendoGrid").dataItem($(e.currentTarget).closest("tr"));
    sessionStorage.setItem("IdBook", selectedItem.IdBook);
    window.location.href = "FormUpdateBook.aspx";
}
function ShowVol(e) {
    $("#grid").hide();
    $("#gridVol").show();
    e.preventDefault();
    var selectedItem = $("#grid").data("kendoGrid").dataItem($(e.currentTarget).closest("tr"));
    sessionStorage.setItem("IdBook", selectedItem.IdBook);
    //window.location.href = "pageDoc.aspx";

    $("#gridVol").kendoGrid({
        dataSource: dataSource2,

        /* change: onChange,*/
        selectable: "true",
        navigatable: true,

        pageable: {
            alwaysVisible: false,
            pageSizes: [5, 10, 20, 100],
            change(e) {
                console.log(pageSizes.pageSize)
            }
        },

        groupable: true,

        //height: 550,
        /* toolbar: ["excel",kendo.template($("#template2").html()), "search"],*/
        //height: 550,
        //toolbar: ["create", "save", "cancel"],
        toolbar: kendo.template($("#template2").html()),

        columns: [
            { field: "Part", width: "auto", headerAttributes: { style: 'text-align: center; justify-content: center' }, attributes: { style: 'text-align: center' } },
            { field: "IdVol", width: "auto", headerAttributes: { style: 'text-align: center; justify-content: center' }, attributes: { style: 'text-align: center' } },
            { field: "NameVol", width: "auto", headerAttributes: { style: 'text-align: center; justify-content: center' }, attributes: { style: 'text-align: center' } },
            {
                field: "CreDate", width: "auto", headerAttributes: { style: 'text-align: center; justify-content: center' }, attributes: { style: 'text-align: center' }
                , template: "#: kendo.toString(kendo.parseDate(CreDate),'dd/mm/yyyy hh:mm') #"
            },
            { field: "CreUser", width: "auto", headerAttributes: { style: 'text-align: center; justify-content: center' }, attributes: { style: 'text-align: center' } },

            {
                command: [
                    { text: "Edit", iconClass: "k-icon k-i-edit", click: EDITVOL }
                    , { text: "Delete", iconClass: "k-icon k-i-delete", click: DeleteVol, }
                    , { text: "ShowVol", iconClass: "k-icon k-i-eye", click: ToVol, }
                ], attributes: { style: 'text-align: center' },

                /* title: " ", width: "170px", background: "blue",*/
            },
        ],

    });
    var dataSource2 = new kendo.data.DataSource({
        transport: {
            read: function (e) {
                dataType: "json";
                var id = selectedItem.IdBook;
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
        pageSize: 3, // The number of items per page.
        page: 1,

        group: { field: "Part" },
    });
    var grid = $("#gridVol").data("kendoGrid");
    grid.setDataSource(dataSource2);
    $("#grid").hide();
    $("#gridVol").show();
}
function ToVol() {
    var grid = $("#gridVol").data("kendoGrid");
    var selectedItem = grid.dataItem(grid.select());
    // selectedDataItems contains all selected data items
    /* The result can be observed in the DevTools(F12) console of the browser. */
    /* console.log("Selected data items' name: " + selectedDataItems.map(e => e.NameVol).join(", "));*/
    console.log(selectedItem.NameVol);
    sessionStorage.setItem("Vol", selectedItem.Vol);
    console.log(sessionStorage.getItem("Vol"));

    window.location.href = "text.aspx";
}
function CreateVol() {
    var cloneVol = new Object();
    cloneVol.IdBook = sessionStorage.getItem("IdBook");
    cloneVol.CreUser = sessionStorage.getItem("LoginName");
    cloneVol.NameVol = document.getElementById("NameVol").value;
    cloneVol.IdVol = document.getElementById("CodeVol").value;
    cloneVol.Part = document.getElementById("Part").value;
    cloneVol.Vol = document.getElementById("editor").value;
    console.log(cloneVol);
    var b = JSON.stringify(cloneVol);
    var api = "/api/handler.ashx?tbl=Book&func=AddVol";
    funcPostAPI({
        data: b
    }, api,
        function (retData) {
            if (retData.data.length == 0 && retData.data != null) {
                /*   alert("Wrong user or pass");*/
                notification.show({
                    title: "Add Vol Failed",
                    message: "Please try again."
                }, "error");
            } else {
                notification.show({
                    message: "Create Successful"
                }, "success");
                clearFromVol();
                $("#UpdateVol").show();
            }

        },
        function (retData) {

        }
    )
}
function DeleteVol(e) {

    if (confirm("Are you sure? To restore, please contact to admin ")) {
        e.preventDefault();
        var selectedItem = $("#gridVol").data("kendoGrid").dataItem($(e.currentTarget).closest("tr"));
        var api = "/api/handler.ashx?tbl=Book&func=deleteVol";
        funcPostAPI({
            data: JSON.stringify(selectedItem.IdVol)
        }, api,
            function (retData) {
                notification.show({
                    message: "Delete Successful"
                }, "success");
                window.location.reload();
            },
            function (retData) {

            }
        )
    }
}
function DeleteBook(e) {

    if (confirm("Are you sure? To restore contact to admin ")) {
        e.preventDefault();
        var selectedItem = $("#grid").data("kendoGrid").dataItem($(e.currentTarget).closest("tr"));
        var api = "/api/handler.ashx?tbl=Book&func=deletebook";
        funcPostAPI({
            data: JSON.stringify(selectedItem.IdBook)
        }, api,
            function (retData) {
                notification.show({
                    message: "Delete Successful"
                }, "success");
                window.location.reload();
            },
            function (retData) {

            }
        )
    }
}
function myclick() {
    $("#addVol").show();
    var myWindow2 = $("#windowAddVol");
    myWindow2.data("kendoWindow").center().open();;
    $("#UpdateVol").hide();

}
function myback() {
    $("#grid").show();
    $("#gridVol").hide();
}
function EDITVOL(e) {
    $("#addVol").hide();
    $("#UpdateVol").show();
    var myWindow2 = $("#windowAddVol");
    myWindow2.data("kendoWindow").center().open();;
    e.preventDefault();
    var selectedItem = $("#gridVol").data("kendoGrid").dataItem($(e.currentTarget).closest("tr"));
    document.getElementById("NameVol").value = selectedItem.NameVol;
    document.getElementById("CodeVol").value = selectedItem.IdVol;
    document.getElementById("CodeVol").readOnly = true;
    document.getElementById("Part").value = selectedItem.Part;
    $("#editor").data("kendoEditor").value(selectedItem.Vol);
    /*sessionStorage.setItem("IdBook", selectedItem.IdBook);*/
    $("#UpdateVol").click(function () {
        var vol = new Object();
        vol.IdVol = document.getElementById("CodeVol").value;
        vol.NameVol = document.getElementById("NameVol").value;
        vol.Part = document.getElementById("Part").value;
        vol.Vol = document.getElementById("editor").value;
        vol.CreUser = sessionStorage.getItem("LoginName");
        console.log(vol);
        var b = JSON.stringify(vol);
        var api = "/api/handler.ashx?tbl=Book&func=UpdateVol";
        funcPostAPI({
            data: b
        }, api,
            function (retData) {
                if (retData.data.length == 0 && retData.data != null && retData.data == false) {
                    /*   alert("Wrong user or pass");*/
                    notification.show({
                        title: "New E-mail",
                        message: "You have 1 new mail message!"
                    }, "warning");
                } else {
                    notification.show({
                        message: "Update Successful"
                    }, "success");
                    clearFromVol();
                    $("#UpdateVol").hide();
                    $("#addVol").show();
                }

            },
            function (retData) {

            }
        )
    });

}

function clearFromVol() {
    document.getElementById("NameVol").value = '';
    document.getElementById("CodeVol").value = '';
    document.getElementById("editor").value = '';
    $("#editor").data("kendoEditor").value('');
    document.getElementById("Part").value = '';
}