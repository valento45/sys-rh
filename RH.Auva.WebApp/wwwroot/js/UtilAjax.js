var util = util || {};

var frameId = "frameWebApp";



window.addEventListener('load', function () {
    util.frame.redimensionIframe();
    util.frame.scrollTop(0);
});



util.storage = {
    setItem: function (name, object) {
        var json = JSON.stringify(object);
        sessionStorage.setItem(name, json);
    },
    getItem: function (name) {
        return JSON.parse(sessionStorage.getItem(name));
    },
    clear: function () {
        sessionStorage.clear();
    }
};

util.ajax = {
    post: function (url, model, callBackSuccess, callBackError) {
        $('.c-loader-overlay').css('display', 'flex');
        var form = $('#__AjaxAntiForgeryForm');
        var __RequestVerificationToken = $('input[name="__RequestVerificationToken"]', form).val();

        if (!model) {
            model = {

            }
        }

        $.ajax({
            url: url,
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(model),
            beforeSend: function (xhr) {
                xhr.setRequestHeader("X-CSRF-TOKEN", __RequestVerificationToken);
            },
            success: function (data) {
                $('.c-loader-overlay').css('display', 'none');
                if (data && !data.crcValido && data.urlRedirect) {
                    window.location.href = data.urlRedirect;
                }
                else {
                    if (callBackSuccess) {
                        callBackSuccess(data);
                    }
                }
            },
            error: function (xhr, status, errorThrown) {
                $('.c-loader-overlay').css('display', 'none');
                var err = "Status: " + status + " " + errorThrown;
                console.log(err);

                if (callBackError) {
                    callBackError(xhr);
                }
            }
        });
    },



    get: function (url, model, callBackSuccess, callBackError) {
        $('.c-loader-overlay').css('display', 'flex');
        var form = $('#__AjaxAntiForgeryForm');
        var __RequestVerificationToken = $('input[name="__RequestVerificationToken"]', form).val();

        if (!model) {
            model = {

            }
        }

        $.ajax({
            url: url,
            type: 'GET',
            contentType: 'application/json',
            data: JSON.stringify(model),
            beforeSend: function (xhr) {
                xhr.setRequestHeader("X-CSRF-TOKEN", __RequestVerificationToken);
            },
            success: function (data) {
                $('.c-loader-overlay').css('display', 'none');
                if (data && !data.crcValido && data.urlRedirect) {
                    window.location.href = data.urlRedirect;
                }
                else {
                    if (callBackSuccess) {
                        callBackSuccess(data);
                    }
                }
            },
            error: function (xhr, status, errorThrown) {
                $('.c-loader-overlay').css('display', 'none');
                var err = "Status: " + status + " " + errorThrown;
                console.log(err);

                if (callBackError) {
                    callBackError(xhr);
                }
            }
        });
    }
};

util.url = {
    getParam: function (name) {
        var url = location.href;

        var spt = url.split('?');

        if (spt.length > 1) {
            for (let spt2 of spt[1].split('&')) {
                if (spt2.indexOf(name) >= 0) {
                    var spt3 = spt2.split('=');
                    return spt3[1].replace('%', '');
                }
            }
        }

        return "";
    },
};



