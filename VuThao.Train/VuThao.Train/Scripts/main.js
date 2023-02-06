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

//run onload
$(function () {
    if ($(".btnCallApiSuccess").length > 0) {
        $(".btnCallApiSuccess").click(function () {
            var o = new Object();
            o.ID = 1;
            o.Title = "Tên";
            var api = "/api/handler.ashx?tbl=like&func=insert";
            funcPostAPI({
                data: JSON.stringify(o)
            }, api,
                function (retData) {
                    alert(retData.data);
                },
                function (retData) {
                    
                }
            )
        })
    }

    if ($(".btnCallApiFail").length > 0) {
        $(".btnCallApiFail").click(function () {
            var o = new Object();
            o.ID = 1;
            o.Title = "Tên";
            var api = "/api/handler.ashx?tbl=like&func=delete";
            funcPostAPI({
                data: JSON.stringify(o)
            }, api,
                function (retData) {
                    alert(retData.mess.Value);
                },
                function (retData) {
                   
                }
            )
        })
    }
})

