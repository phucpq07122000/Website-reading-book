



//Menu knedo
$(document).ready(function () {
    $(".menu").kendoMenu();
});

// kendo USerNAme and password Email
$(document).ready(function () {
    $("#txtName").kendoTextBox({
        label: "Tên đăng nhập ",
    });

    $("#txtPassp").kendoTextBox({
        label: "PassWord",
    });
    $("#txtEmail").kendoTextBox({
        label: "Email",
    });
    /*$("b").css('color', 'red');*/
});
/// ?????
$(".btn").click(function () {
    $(".input").toggleClass("active").focus;
    $(this).toggleClass("animate");
    $(".input").val("");
});

//search 
$("#search").kendoButton({
    icon: "search"
});

//login  from
$(document).ready(function () {
    // create TextBox from input HTML element
    $("#txtUserName").kendoTextBox({
        placeholder: "User Name",

    });
    //TextBox passWord
    $("#txtPass").kendoTextBox({
        placeholder: "PassWord",

    });


});

$(document).ready(function () {
    $("#Category").kendoMultiSelect({
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
        dataSource: ["Fiction", "Romace", "School Life", "Super Power", "Supernatural", "Historical", "Drama", "Comedy"],
        placeholder: "Thể Loại"
    });
});

$(document).ready(function () {
    // create TextBox from input HTML element
    $("#chboxRemLogin").kendoCheckBox({
        label: "Nhớ mặt khẩu"
    });

    // Giới tính
    $('#genderNam').kendoRadioButton({
        label: "Nam",

    });
    $('#genderNu').kendoRadioButton({
        label: "Nữ"

    });
});

//window
$(document).ready(function () {
    var myWindow = $("#window"),
        undo = $("#undo"),
        luu = $("#save");
    testWindow = $("#testWindow");
    undo.click(function () {

        myWindow.data("kendoWindow").open();
        undo.fadeOut();
    });
    luu.click(function () {
        myWindow.data("kendoWindow").close();
        undo.fadeIn();
    });


    function onClose() {
        undo.fadeIn();
    }

    myWindow.kendoWindow({
        width: "70%",
        title: "Form nhân viên",
        visible: false,
        actions: [
            "Pin",
            "Minimize",
            "Maximize",
            "Close"

        ],
        close: onClose
    });

    // window vol
    var WindowVol = $("#windowAddVol")
    WindowVol.kendoWindow({
        width: "70%",
        title: "Form Addd Vol",
        visible: false,
        actions: [
            "Pin",
            "Minimize",
            "Maximize",
            "Close"

        ],
        close: onClose
    });

    testWindow.click(function () {

        WindowVol.data("kendoWindow").open();
        undo.fadeOut();
    });
});

$("#editor").kendoEditor({
    imageBrowser: {
        messages: {
            uploadFile: "Upload a file"
        }
    }
});

function Resigter() {
    var myWindow = $("#window");
    myWindow.data("kendoWindow").open();
}

// end loginfrom

//                                            start kendoProfile

//image
var idimage;
var formData = new FormData();
// add ảnh User
$("#Up").kendoUpload({
    multiple: false,
    validation: {
        allowedExtensions: [".jpg", ".jpeg", ".png", ".bmp", ".gif"]
    }, select: onSelect, showFileList: false,
    dropZone: ".dropZoneElement"
});

function onSelect(e) {
    if (e.files) {
        for (var i = 0; i < e.files.length; i++) {
            var file = e.files[i].rawFile;
            if (file) {
                var reader = new FileReader();

                reader.onloadend = function () {
                    $(".product").remove();
                    $("<div class='product'><img src=" + this.result + " /></div>").appendTo($("#products"));
                    //images = reader.result;

                    console.log(file);
                };
                var ses = new Object();
                ses.IdUser = sessionStorage.getItem("IdUser");
                ses.LoginName = sessionStorage.getItem("LoginName");
                formData.append('data', JSON.stringify(ses));
                formData.append('file', e.files[0].rawFile);
                $.ajax({
                    url: '/api/handler.ashx?tbl=Image&func=upload',
                    type: 'POST',
                    data: formData,
                    processData: false,  // tell jQuery not to process the data
                    contentType: false,  // tell jQuery not to set contentType
                    success: function (data) {
                        /*     return idimage = data.data.idImage;*/

                    }
                });
                reader.addEventListener("load", () => {
                    console.log(reader.result);
                    images = reader.result;
                });

                reader.readAsDataURL(file);

            }
        }

    }
}
//ảnh book
var files;
$("#UpBook").kendoUpload({
    multiple: false,
    validation: {
        allowedExtensions: [".jpg", ".jpeg", ".png", ".bmp", ".gif"]
    }, select: onSelectBook, showFileList: false,
    dropZone: ".dropZoneElement"
});

function onSelectBook(e) {
    if (e.files) {
        for (var i = 0; i < e.files.length; i++) {
            var file = e.files[i].rawFile;
            if (file) {
                var reader = new FileReader();

                reader.onloadend = function () {
                    $(".product").remove();
                    $("<div class='product'><img src=" + this.result + " /></div>").appendTo($("#products"));
                    //images = reader.result;

                    console.log(file);
                };
                /*     formData.append('file', e.files[0].rawFile);*/
                files = e.files[0].rawFile
                reader.addEventListener("load", () => {
                    console.log(reader.result);
                    images = reader.result;
                });

                reader.readAsDataURL(file);

            }
        }

    }
}


// add ảnh book

$(document).ready(function () {
    $("#description").kendoTextArea({
        label: {
            content: "Message",
            floating: true
        },
        rows: 5
    });
});
