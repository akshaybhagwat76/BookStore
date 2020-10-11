"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var XmlHttpRequestHelper = /** @class */ (function () {
    function XmlHttpRequestHelper() {
    }
    XmlHttpRequestHelper.ajax = function (type, url, customHeaders, data, success) {
        var xhr = new XMLHttpRequest();
        debugger;
        xhr.onreadystatechange = function () {
            if (xhr.readyState === XMLHttpRequest.DONE) {
                if (xhr.status === 200) {
                    var result = JSON.parse(xhr.responseText);
                    success(result);
                }
                else if (xhr.status !== 0) {
                }
            }
        };
        url += (url.indexOf('?') >= 0 ? '&' : '?') + 'd=' + new Date().getTime();
        xhr.open(type, url, true);
        for (var property in customHeaders) {
            if (customHeaders.hasOwnProperty(property)) {
                xhr.setRequestHeader(property, customHeaders[property]);
            }
        }
        xhr.setRequestHeader('Content-type', 'application/json');
        if (data) {
            xhr.send(data);
        }
        else {
            xhr.send();
        }
    };
    return XmlHttpRequestHelper;
}());
exports.XmlHttpRequestHelper = XmlHttpRequestHelper;
//# sourceMappingURL=XmlHttpRequestHelper.js.map