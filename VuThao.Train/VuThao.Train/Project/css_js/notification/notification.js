

    var notification = $("#notification").kendoNotification({
        position: {
            pinned: true,
            top: 30,
            right: 30
        },
        autoHideAfter: 3000,
        stacking: "down",
        templates: [{
            type: "warning",
            template: $("#emailTemplate").html()
        }, {
            type: "error",
            template: $("#errorTemplate").html()
        }, {
            type: "success",
            template: $("#successTemplate").html()
        }]

    }).data("kendoNotification");

    //$("#showEmailNotification").click(function () {
    //    notification.show({
    //        title: "New E-mail",
    //        message: "You have 1 new mail message!"
    //    }, "warning);
    //});

    //$("#showErrorNotification").click(function () {
    //    notification.show({
    //        title: "Wrong Password",
    //        message: "Please enter your password again."
    //    }, "error");
    //    autoHideAfter: 0
    //});

    //$("#showSuccessNotification").click(function () {
    //    notification.show({
    //        message: "Upload Successful"
    //    }, "success");
    //});

    //$("#hideAllNotifications").click(function () {
    //    notification.hide();
    //});

    $(document).one("kendo:pageUnload", function () { if (notification) { notification.hide(); } });

$("#notification").kendoNotification({
    autoHideAfter: 3000
});
