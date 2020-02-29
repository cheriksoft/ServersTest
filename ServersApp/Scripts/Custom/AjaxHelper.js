function AjaxGet(url, data, cb) {
    SendAjaxRequest(url, data, 'GET', cb);
}

function AjaxPost(url, data, cb) {
    SendAjaxRequest(url, data, 'POST', cb);
}

function SendAjaxRequest(url, data, method, cb) {
    $.ajax({
        url: url,
        dataType: 'json',
        data: JSON.stringify(data),       
        method: method,
        cache: false,
        contentType: 'application/json',
        beforeSend: function () {
            $('#blockUI').modal({
                backdrop: 'static',
                keyboard: false
            });
        }
    })
    .done(function (response) {
        if (cb) {
            cb(response);
        }
    })
    .always(function () {
        $('#blockUI').modal('hide');
    });
}