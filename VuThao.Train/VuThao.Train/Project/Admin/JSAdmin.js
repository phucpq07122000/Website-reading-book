

$("#grid").hide();
$("#gridUser").hide();
$("#gridVol").hide();

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

function LoadETOButton() {
    var api = "/api/handler.ashx?tbl=Admin&func=ReadAlbert";
    funcPostAPI({
        data: null
    }, api,
        function (retData) {
            document.getElementById("iconNumber").innerHTML = retData.data;
        },
        function (retData) {

        });
    /*document.getElementById("iconNumber").innerHTML = 2;*/
}

window.addEventListener("load", LoadETOButton);

let btnBook = document.querySelector("#ShowBookGrid");
btnBook.addEventListener("click", () => {
    $("#gridUser").hide();
    $("#gridVol").hide();
    $("#grid").show();
    $(document).ready(function () {
        dataSource = new kendo.data.DataSource({
            transport: {
                read: function (e) {
                    dataType: "json"
                    var a = {
                        page: e.data.page,
                        pageSize: e.data.pageSize,
                    };
                    var api = "/api/handler.ashx?tbl=Book&func=phantrangbook";
                    funcPostAPI({
                        data: JSON.stringify(a)
                    }, api,
                        function (httpRequest) {
                            e.success(httpRequest.data);
                        }, function (retData) {

                        });
                },
            },
            schema: {
                data: function (response) {

                    return response.listBook;
                    // return response; // trả giá trị data debug chỗ này để xem kết quả
                },
                total: "total"

            },
            batch: true,
            serverPaging: true,
            pageSize: 4,
            page: 1,
            group: { field: "IsActivity" },

        });


        $("#grid").kendoGrid({
            dataSource: dataSource,
            /*      change: onChange,*/
            selectable: "true",
            editable: {
                mode: "popup",
                template: $("#template").html()
            },
            navigatable: true,
            dataBound: onDataBound,
            groupable: true,
            pageable: {
                alwaysVisible: false,


                pageSizes: [2, 3, 4, 5, 6, 7],


            },
            toolbar: ["excel", "pdf", "search"],
            columns: [
                {

                    field: "Row",
                    width: "80px", headerAttributes: { style: 'text-align: center; justify-content: center; ' }, attributes: { style: 'text-align: center' },

                },
                {
                    //field: "Image",
                    //template: "<img src='data: image/png; base64,#=Image#' width='69.3px' height='69.3px'/>",
                    field: "Name", headerAttributes: { style: 'text-align: center; justify-content: center' },
                    title: "Product Name",
                    template: "<div class='product-photo' style='background-image: url(data:image/png;base64,#=Image#);'></div><div class='product-name'>#: Name #</div>",
                    width: 300
                }, {

                    field: "IsActivity",
                    width: "100px", headerAttributes: { style: 'text-align: center; justify-content: center; ' }, attributes: { style: 'text-align: center' },
                    template: "<span id='badge_#=IdBook#' class='badgeTemplate'></span>",
                },
                {

                    field: "IdBook",
                    width: "100px", headerAttributes: { style: 'text-align: center; justify-content: center; ' }, attributes: { style: 'text-align: center' },

                },
                {
                    field: "Categories",
                    width: "250px", headerAttributes: { style: 'text-align: center; justify-content: center; ' }, attributes: { style: 'text-align: center' },
                },
                {

                    field: "NameTeam",
                    width: "100px", headerAttributes: { style: 'text-align: center; justify-content: center; ' }, attributes: { style: 'text-align: center' },
                },
                {

                    field: "NameActor",
                    width: "100px", headerAttributes: { style: 'text-align: center; justify-content: center; ' }, attributes: { style: 'text-align: center' },

                },
                {

                    field: "Created",
                    title: "User and cre date",
                    width: "150px", headerAttributes: { style: 'text-align: center; justify-content: center; ' }, attributes: { style: 'text-align: center' },
                    template: "<span class='name' >#:CreatedUser # </span><br/><span>#: kendo.toString(kendo.parseDate(Created), 'dd/MM/yyyy') #"

                },

                {

                    field: "Modify",

                    title: "User and date modify",
                    width: "150px", headerAttributes: { style: 'text-align: center; justify-content: center; ' }, attributes: { style: 'text-align: center' },
                    template: "<span class='name' >#:ModifyUser # </span><br/><span>#: kendo.toString(kendo.parseDate(Modify), 'dd/MM/yyyy') #"
                },
                {
                    command: [{ text: "Restore", iconClass: "k-icon k-i-undo", click: Restore },
                    { text: "Delete", iconClass: "k-icon k-i-delete", click: Delete,  }
                        , { text: "ShowVol", iconClass: "k-icon k-i-eye", click: ShowVol, }],
                    title: " ", width: "170px", background: "blue",
                },

            ],

        });
    });
});
//delete book
function Delete(e) {
    if (confirm("Are you sure? this action will delete all links to this book")) {
        e.preventDefault();
        var selectedItem = $("#grid").data("kendoGrid").dataItem($(e.currentTarget).closest("tr"));
        var api = "/api/handler.ashx?tbl=Book&func=Cleanbook";
        funcPostAPI({
            data: JSON.stringify(selectedItem.IdBook)
        }, api,
            function (retData) {
                alert(retData.data)
                var grid = $("#grid").data("kendoGrid");
                grid.setDataSource(dataSource);
                grid.refresh();
            },
            function (retData) {

            }
        )
    }
}
function Restore(e) {
    if (confirm("Are you sure? ")) {
        e.preventDefault();
        var selectedItem = $("#grid").data("kendoGrid").dataItem($(e.currentTarget).closest("tr"));
        var api = "/api/handler.ashx?tbl=Book&func=restorebook";
        funcPostAPI({
            data: JSON.stringify(selectedItem.IdBook)
        }, api,
            function (retData) {
                alert(retData.data)
                window.location.reload();
            },
            function (retData) {

            }
        )
    }
}
function onDataBound(e) {
    var grid = this;
    grid.table.find("tr").each(function () {
        var dataItem = grid.dataItem(this);
        var themeColor = dataItem.IsActivity ? 'success' : 'error';
        var text = dataItem.IsActivity ? 'available' : 'not available';

        $(this).find(".badgeTemplate").kendoBadge({
            themeColor: themeColor,
            text: text,
        });
    });
}

//user 
let btnUser = document.querySelector("#ShowUserGrid");
btnUser.addEventListener("click", () => {
    $("#grid").hide();
    $("#gridVol").hide();
    $("#gridUser").show();

    $(document).ready(function () {
        dataSource = new kendo.data.DataSource({
            transport: {
                read: function (e) {
                    dataType: "json"
                    var a = {
                        page: e.data.page,
                        pageSize: e.data.pageSize,
                    };
                    var api = "/api/handler.ashx?tbl=User&func=phantrangUser";
                    funcPostAPI({
                        data: JSON.stringify(a)
                    }, api,
                        function (httpRequest) {
                            e.success(httpRequest.data);
                        }, function (retData) {

                        });
                },
            },
            schema: {
                data: function (response) {

                    return response.listUser;
                    // return response; // trả giá trị data debug chỗ này để xem kết quả
                },
                total: "total"

            },
            batch: true,
            serverPaging: true,
            pageSize: 4,
            page: 1,
            group: {
                field: "NameTeam", aggregate: "count"

            },

        });


        $("#gridUser").kendoGrid({
            dataSource: dataSource,
            /*      change: onChange,*/
            selectable: "true",
            navigatable: true,
            groupable: true,
            dataBound: onDataBound2,
            toolbar: ["excel", "pdf", "search"],
            pageable: {
                alwaysVisible: false,


                pageSizes: [2, 3, 4, 5, 6, 7],


            }, editable: {
                mode: "popup",
                template: $("#template").html()
            },
            edit: function (e) {
                $("button").hide()
                var clone = new Object;
                clone.IDUser = e.model.IdUser;
                clone.Role = e.model.Role;
                clone.IdTeam = e.model.IdTeam;
                $("#Team").kendoComboBox({
                    autoBind: false,

                    placeholder: "Select new Team...",
                    dataTextField: "NameTeam",
                    dataValueField: "IdTeam",
                    select: onSelect,
                    dataSource: dataSourceTeam,
                });

                function onSelect(e) {
                    var dataItem = e.dataItem;
                    console.log("event :: select (" + dataItem.NameTeam + " : " + dataItem.IdTeam + " )");
                    clone.IdTeam = dataItem.IdTeam;
                };
                $("#btnsave").click(function () {
                    e.model.IdTeam
                    console.log(clone);
                    var api = "/api/handler.ashx?tbl=Admin&func=Update";
                    funcPostAPI({
                        data: JSON.stringify(clone)
                    }, api,
                        function (retData) {
                            if (retData.data.length == 0 && retData.data != null) {
                                alert("fail");
                            } else {
                                alert("succses");
                            }
                        }, function (retData) {

                        });
                });

            },
            toolbar: ["excel", "pdf", "search"],
            columns: [
                {

                    field: "Row",
                    width: "80px", headerAttributes: { style: 'text-align: center; justify-content: center; ' }, attributes: { style: 'text-align: center' },

                },
                {
                    //field: "Image",
                    //template: "<img src='data: image/png; base64,#=Image#' width='69.3px' height='69.3px'/>",
                    field: "UserName", headerAttributes: { style: 'text-align: center; justify-content: center' },
                    title: "Account",
                    template: "<div class='product-photo' style='background-image: url(data:image/png;base64,#=Image#);'></div><div class='product-name'>#: UserName #</div>",
                    width: 150
                }, {

                    field: "Role",
                    width: "100px", headerAttributes: { style: 'text-align: center; justify-content: center; ' }, attributes: { style: 'text-align: center' },
                    template: "<span id='badge_#=IdUser#' class='badgeTemplate'></span>",
                },
                //{

                //    field: "IdUser",
                //    width: "70px", headerAttributes: { style: 'text-align: center; justify-content: center; ' }, attributes: { style: 'text-align: center' },

                //},
                {
                    field: "Sex",
                    width: "100px", headerAttributes: { style: 'text-align: center; justify-content: center; ' }, attributes: { style: 'text-align: center' },
                    template: "<span id='badge_#=IdUser#' class='SexbadgeTemplate'></span>",
                },

                {

                    field: "IdTeam",
                    width: "150px", headerAttributes: { style: 'text-align: center; justify-content: center; ' }, attributes: { style: 'text-align: center' },
                    template: "#:IdTeam#:#:NameTeam#  ",

                },

                {

                    field: "Email",
                    width: "250px", headerAttributes: { style: 'text-align: center; justify-content: center; ' }, attributes: { style: 'text-align: center' },

                },
                {

                    field: "Created",
                    width: "150px", headerAttributes: { style: 'text-align: center; justify-content: center; ' }, attributes: { style: 'text-align: center' },
                    template: "#: kendo.toString(kendo.parseDate(Created),'dd/MM/yyyy') #"
                },
                {

                    field: "IsActivity",
                    width: "100px", headerAttributes: { style: 'text-align: center; justify-content: center; ' }, attributes: { style: 'text-align: center' },
                    template: "<span id='badge_#=IdUser#' class='IsActivitybadgeTemplate'></span>",
                },
                //{

                //    field: "Modify",
                //    width: "150px", headerAttributes: { style: 'text-align: center; justify-content: center; ' }, attributes: { style: 'text-align: center' },
                //    template: "#: kendo.toString(kendo.parseDate(CreDate),'dd/mm/yyyy hh:mm') #"
                //},
                //{

                //    field: "ModifyUser",
                //    width: "100px", headerAttributes: { style: 'text-align: center; justify-content: center; ' }, attributes: { style: 'text-align: center' },

                //},
                {
                    field: "Fuction",
                    width: "200px",
                    command: ["edit",
                        { text: "Delete", iconClass: "k-icon k-i-delete"/*, click: Delete, */ },
                        { text: "Ban", iconClass: "k-icon k-i-minus-circle", click: Ban },                     
                        { text: "Reban", iconClass: "k-icon k-i-sort-desc-sm", click: ReBan }
                    ]
                },

            ],

        });
    });
});

function onDataBound2(e) {
    var grid = this;
    grid.table.find("tr").each(function () {
        var dataItem = grid.dataItem(this);
        var themeColor = dataItem.Role ? 'success' : 'error';
        var text = dataItem.Role ? 'ADMIN' : 'USER';
        var themeColorSex = dataItem.Sex == "Nam" ? 'info' : 'tertiary';
        var textSex = dataItem.Sex == "Nam" ? 'Nam' : 'Nữ';
        var themeColorActive = dataItem.IsActivity ? 'success' : 'error';
        var textActive = dataItem.IsActivity ? 'Active' : 'Ban';
        $(this).find(".badgeTemplate").kendoBadge({
            themeColor: themeColor,
            text: text,
        });
        $(this).find(".SexbadgeTemplate").kendoBadge({
            themeColor: themeColorSex,
            text: textSex,
        });
        $(this).find(".IsActivitybadgeTemplate").kendoBadge({
            themeColor: themeColorActive,
            text: textActive,
        });
    });
}

var dataSourceTeam = new kendo.data.DataSource({
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
//$("#combobox").kendoDropDownList({
//    animation: {
//        close: {
//            effects: "fadeOut zoom:out",
//            duration: 300
//        },
//        open: {
//            effects: "fadeIn zoom:in",
//            duration: 300
//        }
//    },
//    dataSource: dataSource,
//    dataTextField: "NameTeam",
//    dataValueField: "IdTeam"
//});

//function ChangeTeam() {
//    $("#popup").kendoPopup();

//    var popup = $("#popup").data("kendoPopup");
//    popup.open();
//}


function ShowVol(e) {
    $("#grid").hide();
    $("#gridUser").hide();
    $("#gridVol").show();
    e.preventDefault();
    var selectedItem = $("#grid").data("kendoGrid").dataItem($(e.currentTarget).closest("tr"));
    sessionStorage.setItem("IdBook", selectedItem.IdBook);
    //window.location.href = "pageDoc.aspx";
    dataSource2 = new kendo.data.DataSource({
        transport: {
            read: function (e) {
                dataType: "json";
                var id = selectedItem.IdBook;
                var api = "/api/handler.ashx?tbl=Book&func=ReadVolAdmin";
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
    $("#gridVol").kendoGrid({
        dataSource: dataSource2,

        /* change: onChange,*/
        selectable: "true",
        navigatable: true,
        dataBound: onDataBound,
        pageable: {
            alwaysVisible: false,
            pageSizes: [5, 10, 20, 100],
            change(e) {
                console.log(pageSizes.pageSize)
            }
        },

        //height: 550,
        //toolbar: ["create", "save", "cancel"],
        //toolbar: kendo.template($("#template2").html()),

        columns: [
            { field: "Part", width: "auto", headerAttributes: { style: 'text-align: center; justify-content: center' }, attributes: { style: 'text-align: center' } },
            { field: "IdVol", width: "auto", headerAttributes: { style: 'text-align: center; justify-content: center' }, attributes: { style: 'text-align: center' } },
            {

                field: "IsActivity",
                width: "100px", headerAttributes: { style: 'text-align: center; justify-content: center; ' }, attributes: { style: 'text-align: center' },
                template: "<span id='badge_#=IdVol#' class='badgeTemplate'></span>",
            },
            { field: "NameVol", width: "auto", headerAttributes: { style: 'text-align: center; justify-content: center' }, attributes: { style: 'text-align: center' } },
            {
                field: "CreDate", width: "auto", headerAttributes: { style: 'text-align: center; justify-content: center' }, attributes: { style: 'text-align: center' }
                , template: "#: kendo.toString(kendo.parseDate(CreDate),'dd/MM/yyyy hh:mm') #"
            },
            { field: "CreUser", width: "auto", headerAttributes: { style: 'text-align: center; justify-content: center' }, attributes: { style: 'text-align: center' } },

            {
                command: [
                /*    { text: "Edit", iconClass: "k-icon k-i-edit", click: EDITVOL }*/
                    { text: "Delete", iconClass: "k-icon k-i-delete"/*, click: DeleteVol,*/ }
                    , { text: "Restore", iconClass: "k-icon k-i-undo"/*, click: ToVol,*/ }
                ]
            },
        ],

    });

    //var grid = $("#gridVol").data("kendoGrid");
    //grid.setDataSource(dataSource2);


}


function Ban(e) {
    e.preventDefault();
    var selectedItem = $("#gridUser").data("kendoGrid").dataItem($(e.currentTarget).closest("tr"));
    var chose = new Object();
    chose.code = selectedItem.IdUser
    chose.chosse = 0;
    var api = "/api/handler.ashx?tbl=Admin&func=Ban_Re";
    funcPostAPI({
        data: JSON.stringify(chose)
    }, api,
        function (retData) {
       
            var grid = $("#gridUser").data("kendoGrid");
            grid.setDataSource(dataSource);
            grid.refresh();
            
        },
        function (retData) {

        });
   
}

function ReBan(e) {
    e.preventDefault();
    var selectedItem = $("#gridUser").data("kendoGrid").dataItem($(e.currentTarget).closest("tr"));
    var chose = new Object();
    chose.code= selectedItem.IdUser
    chose.chosse = 1;
    var api = "/api/handler.ashx?tbl=Admin&func=Ban_Re";
    funcPostAPI({
        data: JSON.stringify(chose)
    }, api,
        function (retData) {
           
            var grid = $("#gridUser").data("kendoGrid");
            grid.setDataSource(dataSource);
            grid.refresh();
           
           
        },
        function (retData) {

        });

}
