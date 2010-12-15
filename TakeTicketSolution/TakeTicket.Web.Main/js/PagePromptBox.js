/**
* @author zhangdaijun 20061227
*页面提示框
*随着窗体大小改变阴影
*/
if (!webPromptBox) {
    var webPromptBox = {};
}
webPromptBox.PageUI = function() {
    this.isScroll = false;
    this.msgClassName = "layer";
    this.bgDivId = "_divWebPromptBoxBg";
    this.msgDivId = "_divWebPromptBoxMsg";
}
webPromptBox.resizeCallbacks = [];
webPromptBox.scrollCallbacks = [];
webPromptBox.resize = function() {
    for (var i = 0; i < webPromptBox.resizeCallbacks.length; i++) {
        webPromptBox.resizeCallbacks[i].call();
    }
}
webPromptBox.scroll = function() {
    for (var i = 0; i < webPromptBox.scrollCallbacks.length; i++) {
        webPromptBox.scrollCallbacks[i].call();
    }
}
webPromptBox.isReady = false;
webPromptBox.readyList = [];
webPromptBox.PageUI.prototype = {
    init: function(w, h) {
        this.propmtBoxW = w;
        this.propmtBoxH = h;
        //this.propmtBoxBorderColor = pbBorderColor;
    },
    render: function() {
        if (this.$(this.bgDivId)) return;
        var div = document.createElement("div");
        div.id = this.bgDivId;
        div.style.display = "none";
        document.body.appendChild(div);

        div = document.createElement("div");
        div.id = this.msgDivId;
        div.style.display = "none";
        document.body.appendChild(div);
        webPromptBox.isReady = true;
        if (webPromptBox.readyList.length > 0) {
            webPromptBox.readyList[0]();
        }
    },
    showDialog: function(strHTML) {

        var _self = this, arg = arguments;
        if (!webPromptBox.isReady) {
            webPromptBox.readyList[0] = function() {
                _self.showDialog.apply(_self, arg);
            }
            return;
        }
        webPromptBox.resizeCallbacks = []; //clear
        webPromptBox.scrollCallbacks = []; //clear

        var msgw, msgh, bordercolor, sWidth, sHeight, sWinObj = this.getWAndHOfWindow();
        msgw = parseInt(this.propmtBoxW) ? this.propmtBoxW : 400; /*box width*/
        msgh = parseInt(this.propmtBoxH) ? this.propmtBoxH : 145; /*box height*/
        this.propmtBoxW = msgw;
        this.propmtBoxH = msgh;
        bordercolor = this.propmtBoxBorderColor ? this.propmtBoxBorderColor : "#336699"; /*box border color*/
        this.hiddenSel("none");
        
        sWidth = sWinObj.w;
        sHeight = sWinObj.h
        var bgObj = this.$(this.bgDivId);
        bgObj.style.display = "";
        bgObj.className = "bg";
        with (bgObj.style) {
            //     position="absolute";
            //      background="#777";
            //      top="0";
            //     filter="progid:DXImageTransform.Microsoft.Alpha(opacity=40)";
            //     opacity="0.6";
            //     left="0";
            //       width=sWidth + "px";
            position="absolute";
            //z-index= "99";
            filter="alpha(opacity=50)";
            background="#fff";
            opacity= "0.5";
           // -moz-opacity=" 0.5";
            left= "0";
            top= "0";
            height="100%";
            width="100%";
            height = sHeight + "px";
            zIndex = "1000";
            display = "";
        }
        var msgObj = this.$(this.msgDivId)
        msgObj.style.display = "";
        msgObj.className = this.msgClassName;
        with (msgObj.style) {
            position = "absolute";
            top = 200 + this.getScrollPos().top + "px";
            left = sWinObj.w / 2 - msgw / 2 + "px";
            zIndex = "10001";
            display = "";
        }
        msgObj.innerHTML = strHTML;
        var _self = this;
        webPromptBox.resizeCallbacks[webPromptBox.resizeCallbacks.length] = function() { _self.resize(_self) };
        webPromptBox.scrollCallbacks[webPromptBox.scrollCallbacks.length] = function() { _self.scroll(_self) };

    },
    hiddenSel: function(val) {
        if ($.browser.msie) {
            var eles = document.getElementsByTagName("select");
            for (var i = 0; i < eles.length; i++) {
                eles[i].style.display = val;
            }
        }
    },
    close: function() {
        var eles = document.getElementsByTagName("select");
        for (var i = 0; i < eles.length; i++) {
            eles[i].style.display = "";
        }
        if (this.$(this.msgDivId)) {
            this.$(this.msgDivId).innerHTML = "";
            this.$(this.msgDivId).style.display = "none";
        }
        if (this.$(this.bgDivId)) {
            this.$(this.bgDivId).style.display = "none";
        }
    },
    resize: function(_self) {
        var sWinObj = _self.getWAndHOfWindow();
        var w = sWinObj.w, h = sWinObj.h;
        var overlay = _self.$(_self.bgDivId);
        if (this.$("_bgDiv")) {
            if (overlay.width != '0px') {
                with (overlay.style) {
                    width = w + 'px';
                    height = h + 'px';
                    left = '0px';
                    top = '0px';
                }
                var msgObj = _self.$(_self.msgDivId);
                var msgw = _self.propmtBoxW;
                if (msgObj != null) {
                    with (msgObj.style) {
                        top = 200 + _self.getScrollPos().top + "px";
                        left = w / 2 - msgw / 2;
                    }
                }
            }
        }
    },
    scroll: function(_self) {
        if (!this.isScroll) { return; }
        var sWinObj = _self.getWAndHOfWindow(), w = sWinObj.w;
        var msgObj = _self.$(_self.msgDivId);
        if (msgObj != null) {
            with (msgObj.style) {
                top = 200 + _self.getScrollPos().top + "px";
                left = w / 2 - _self.propmtBoxW / 2 + "px";
            }
        }
    },
    getWAndHOfWindow: function() {
        var w =
              (window.innerWidth && window.scrollMaxX) ? window.innerWidth + window.scrollMaxX
            : (document.body.scrollWidth > document.body.offsetWidth) ? document.body.scrollWidth
            : document.body.offsetWidth;
        var h =
              (window.innerHeight && window.scrollMaxY) ? window.innerHeight + window.scrollMaxY
            : (document.body.scrollHeight > document.body.offsetHeight) ? document.body.scrollHeight
            : document.body.offsetHeight;

        return { "w": w, "h": h };
    },
    getScrollPos: function() {
        var scrollPos = { top: 0, left: 0 };
        if (typeof window.pageYOffset != 'undefined') {
            scrollPos.top = window.pageYOffset;
            scrollPos.left = window.pageXOffset;
        }
        else if (typeof document.compatMode != 'undefined' && document.compatMode != 'BackCompat') {
            scrollPos.top = document.documentElement.scrollTop;
            scrollPos.left = document.documentElement.scrollLeft;
        }
        else if (typeof document.body != 'undefined') {
            scrollPos.top = document.body.scrollTop;
            scrollPos.left = document.body.scrollLeft;
        }
        return scrollPos;
    },
    $: function(id) {
        if (typeof (id) == "string") { return document.getElementById(id); }
        else { return id; }
    }
}
$("window").bind(
    {
        resize: webPromptBox.resize
        , scroll: webPromptBox.scroll
    }
);
//$("window").bind("resize", webPromptBox.resize);
//$("window").bind("scroll", webPromptBox.scroll);
var webPB = new webPromptBox.PageUI(); ;
$(document).ready(
    function() {
        webPB.render();
        webPB.close();
    }
    );
function showTimeOutPromptBox() {
    var msgHTML = new Array();
    msgHTML.push("<div class='alert_lay' style='margin-left:-150px'>");
    msgHTML.push('<!--背景圆角上-->');
    msgHTML.push("<div class='alert_t'></div>");
    msgHTML.push("<div class='box'>");
    msgHTML.push('<h1><span>查询超时！</span><a href="###" class="butn3" onclick="webPB.close();"></a></h1>');
    msgHTML.push("<div class='sech_layt' style='background:#fff'>");
    msgHTML.push("<div style='padding:30px 20px 10px 10px;text-align:center'>");
    msgHTML.push('如果您使用<b>关键词</b>查询，请尝试使用<a onclick="webPB.close();" id="openResumeSearch6" href="Search6.aspx?FromTimeout50=1" target="_blank">英才简历搜索5.1</a>。');
    msgHTML.push("<div style='margin:20px 0;text-align:center'>");
    msgHTML.push('<input type="button" class="btn" onclick="window.open(\'Search6.aspx?FromTimeout50=1\');webPB.close();" value="使用英才简历搜索5.1" />');
    msgHTML.push('</div>');
    msgHTML.push('</div>');
    msgHTML.push('</div>');
    msgHTML.push('</div>');
    msgHTML.push('<!--背景圆角下-->');
    msgHTML.push('<div class="alert_b"><img src="http://image.mychinahr.com/a/sjob6.0/style/image/laybj_br.gif" alt=""/></div>');
    msgHTML.push('</div>');
    webPB.showDialog(msgHTML.join(""));
}
//$(document).ready(function() { showTimeOutPromptBox(); })