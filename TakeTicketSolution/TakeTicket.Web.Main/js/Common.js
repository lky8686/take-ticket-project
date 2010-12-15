(function(window) {
    window.jDoc = window.jDoc || function(id) {
        if (typeof id == "string") {
            if (id.startWith("#")) {
                id = id.substring(1, id.length)
            }
            return document.getElementById(id);
        }
        return id;
    };
    jDoc.site = {};
    jDoc.site.host = ".enntrading.com";
    if (window.location.host.indexOf("900ku.com") >= 0) {
        jDoc.site.host = ".900ku.com";
    }
    jDoc.site.buy = function() { return "http://buy" + jDoc.site.host };
    jDoc.site.trade = function() { return "http://trade" + jDoc.site.host };
    jDoc.site.passport = function() { return "http://passport" + jDoc.site.host };
    jDoc.site.bidding = function() { return "http://bidding" + jDoc.site.host };
    jDoc.site.main = function() { return "http://www" + jDoc.site.host };
    jDoc.site.js = function() { return "http://js" + jDoc.site.host };
    jDoc.site.css = function() { return "http://css" + jDoc.site.host };
    jDoc.site.search = function() { return "http://search" + jDoc.site.host };
    jDoc.site.help = function() { return "http://help" + jDoc.site.host };
    jDoc.site.www = function() { return "http://www" + jDoc.site.host };
    jDoc.site.dl = function() { return "http://dl" + jDoc.site.host };

    Object.extend(
    window.jDoc
    , {
        getElementsBy: function(rangeID, tagName, applyFn) {
            var rangeEle = jDoc(rangeID);
            if (!rangeEle) { rangeEle = document.body || document.documentElement }
            var resultList = [];
            if (tagName) {
                var tagNameList = [];
                if (tagName.join === undefined) {
                    tagNameList.push(tagName);
                } else {
                    tagNameList = tagName;
                }
                for (var i = 0, len = tagNameList.length; i < len; i++) {
                    var eleList = rangeEle.getElementsByTagName(tagNameList[i]);
                    var fn = (typeof applyFn == "function") ? applyFn : function(param) { return true; };
                    for (var k = 0, kLen = eleList.length; k < kLen; k++) {
                        var result = fn(eleList[k]);
                        if (result == "-1") {
                            break;
                        } else if (result) {
                            resultList.push(eleList[k]);
                        }
                    }
                }
            } else {
                alert("tagName is not null")
            }
            return resultList;
        }
        , formatEvent: function(oEvent) {
            if ($.browser.msie) {
                oEvent.charCode = (oEvent.type == "keypress") ? oEvent.keyCode : 0;
                oEvent.eventPhase = 2;
                oEvent.isChar = (oEvent.charCode > 0);
                oEvent.pageX = oEvent.clientX + document.body.scrollLeft;
                oEvent.pageY = oEvent.clientY + document.body.scrollTop;
                oEvent.preventDefault = function() {
                    this.returnValue = false;
                };

                if (oEvent.type == "mouseout") {
                    oEvent.relatedTarget = oEvent.toElement;
                } else if (oEvent.type == "mouseover") {
                    oEvent.relatedTarget = oEvent.fromElement;
                }

                oEvent.stopPropagation = function() {
                    this.cancelBubble = true;
                };

                oEvent.target = oEvent.srcElement;
                oEvent.time = (new Date).getTime();
            }
            return oEvent;
        }
        , getEvent: function() {
            if (window.event) {
                return this.formatEvent(window.event);
            } else {
                var o = jDoc.getEvent.caller;
                while (o) {
                    if (typeof o.arguments[0]["charCode"] == "number") {
                        return o.arguments[0];
                    } else {
                        o = o.caller;
                    }
                }
                //return jDoc.getEvent.caller.arguments[0];
            }
        }
        , addEventHandler: function(oTarget, sEventType, fnHandler) {
            if (oTarget.addEventListener) {
                oTarget.addEventListener(sEventType, fnHandler, false);
            } else if (oTarget.attachEvent) {
                oTarget.attachEvent("on" + sEventType, fnHandler);
            } else {
                oTarget["on" + sEventType] = fnHandler;
            }
        }
        , removeEventHandler: function(oTarget, sEventType, fnHandler) {
            if (oTarget.removeEventListener) {
                oTarget.removeEventListener(sEventType, fnHandler, false);
            } else if (oTarget.detachEvent) {
                oTarget.detachEvent("on" + sEventType, fnHandler);
            } else {
                oTarget["on" + sEventType] = null;
            }
        }
        , parseJSONText: function(text) {
            return (new Function("return " + text))();
        }
        , createHtml: function(oHtmlAttr) {
            var html = [];
            html.push("<input ");

            for (var e in oHtmlAttr) {
                html.push(" " + e + "='" + oHtmlAttr[e] + "'");
            }

            html.push("></input>");

            return html.join("");
        },
        reload: function(hashValue) {
            if (hashValue != undefined) {
                var url = [];
                url.push(window.location.href.replace(/(_hv_)[^&]*/, ""));
                if (url[0].indexOf("?") > 0) {
                    if (url[0].endWith("&") == false) {
                        url.push("&");
                    }
                } else {
                    url.push("?")
                }
                url.push("_hv_=" + hashValue);
                window.location.replace(url.join(""));
            }
            else {
                window.location.replace(window.location);
            }
        },
        setHashByUrl: function() {
            var hv = jDoc.queryStringByUrl("_hv_");
            if (hv != null && hv.trim() != "") {
                if (jDoc("a_" + hv)) {
                    jDoc("a_" + hv).scrollIntoView(true);
                } else {
                    window.location.hash = "";
                    window.location.hash = hv;
                }
            }
        },
        delayLoadingImage: function(range) {
            function delayFn() {
                var win = $(window), winScrollTop = win.height() + win.scrollTop(), imgTop;
                jDoc.getElementsBy(range
                    , "img"
                    , function(elem) {
                        if (elem.getAttribute("value")) {
                            imgTop = $(elem).offset().top;
                            if (imgTop <= winScrollTop) {
                                elem.src = elem.getAttribute("value");
                                elem.setAttribute("value", "");
                            }
                        }
                    })
            }
            jDoc.addEventHandler(window, "scroll", delayFn);
            delayFn();
        },
        queryStringByUrl: function(paramName, url) {
            url = url ? url : window.location.search;
            var reg = new RegExp("(^|&)" + paramName.toLowerCase() + "=([^&]*)(&|$)");
            var r = "";
            if (url.indexOf("?") == 0) {
                r = url.toLowerCase().substr(1).match(reg);
            } else {
                r = url.toLowerCase().match(reg);
            }
            if (r != null) {
                return (r[2]); //unescape
            }
            return null;
        },
        addBookmark: function(title, url) {
            title = title == undefined ? document.title : title;
            url = url == undefined ? document.location : url;
            if (window.sidebar) {
                window.sidebar.addPanel(title, url, "");
            } else if (document.all) {
                window.external.AddFavorite(url, title);
            } else if (window.opera && window.print) {
                return true;
            }
        }
    }
    , false);
})(window);
var CheckBox = {
    selected: function(selectRange, checked, excludeName) {
        var eles = selectRange.getElementsByTagName("input");
        for (var i = 0, len = eles.length; i < len; i++) {
            if (eles[i].type == "checkbox" && eles[i].name != excludeName) {
                eles[i].checked = checked;
            }
        }
    },
    selectedByNamePre: function(selectRange, namePre, checked) {
        this.selectedByProperty(selectRange, namePre, checked, "name");
    },
    selectedByIDPre: function(selectRange, idPre, checked) {
        this.selectedByProperty(selectRange, idPre, checked, "id");
    },
    selectedByProperty: function(selectRange, propertyValuePre, checked, propertyName) {
        var eles = selectRange.getElementsByTagName("input");
        for (var i = 0, len = eles.length; i < len; i++) {
            if (eles[i].type == "checkbox" && eles[i][propertyName].toLowerCase().indexOf(propertyValuePre.toLowerCase()) >= 0) {
                eles[i].checked = checked;
            }
        }
    },
    check: function(selectRange, showMessage, failMessage) {
        if (selectRange) {
            var eles = selectRange.getElementsByTagName("input");
            for (var i = 0, len = eles.length; i < len; i++) {
                if (eles[i].type == "checkbox" && eles[i].name != 'allbox') {
                    if (eles[i].checked) {
                        if (showMessage != "") {
                            return confirm(showMessage);
                        } else {
                            return true;
                        }
                    }
                }
            }
        }
        if (failMessage != undefined && failMessage.trim() != "") {
            alert(failMessage);
        }
        return false;
    },
    isAll: function(selectRange, allBoxIDList, idPre) {
        var eles = selectRange.getElementsByTagName("input");
        var flag = true;
        for (var i = 0, len = eles.length; i < len; i++) {
            if (eles[i].type == "checkbox") {
                if (idPre != undefined) {
                    if (eles[i].id.indexOf(idPre) >= 0 && eles[i].checked == false && allBoxIDList.contains(eles[i].id) == false) {
                        flag = false; break;
                    }
                } else {
                    if (eles[i].checked == false && allBoxIDList.contains(eles[i].id) == false) {
                        flag = false; break;
                    }
                }
            }
        }
        for (var i = 0, len = allBoxIDList.length; i < len; i++) {
            var temp = jDoc(allBoxIDList[i]);
            if (temp) {
                temp.checked = flag;
            }
        }
    }
};