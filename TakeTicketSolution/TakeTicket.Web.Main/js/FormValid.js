var RegValidator = {};
RegValidator.RegTextEnum = {};
RegValidator.RegTextEnum.postCode = /^\d{6}$/;
RegValidator.RegTextEnum.email = /^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$/;
RegValidator.RegTextEnum.mobile = /^(13|15|18)[0-9]{9}$/;
RegValidator.RegTextEnum.tel = /^(\d{3,4}\-{0,1})?(\d{7,8})(-\d{1,6})?$/;
RegValidator.RegTextEnum.date = /(([0-9]{3}[1-9]|[0-9]{2}[1-9][0-9]{1}|[0-9]{1}[1-9][0-9]{2}|[1-9][0-9]{3})-(((0[13578]|1[02])-(0[1-9]|[12][0-9]|3[01]))|((0[469]|11)-(0[1-9]|[12][0-9]|30))|(02-(0[1-9]|[1][0-9]|2[0-8]))))|((([0-9]{2})(0[48]|[2468][048]|[13579][26])|((0[48]|[2468][048]|[3579][26])00))-02-29)/

Object.extend(RegValidator
    , {
        validate: function(reg, text) {
            return reg.test(text);
        },
        isEMail: function(text) {
            return this.validate(RegValidator.RegTextEnum.email, text);
        },
        isMobile: function(text) {
            return this.validate(RegValidator.RegTextEnum.mobile, text);
        },
        isTel: function(text) {
            return this.validate(RegValidator.RegTextEnum.tel, text);
        },
        isPostcode: function(text) {
            return this.validate(RegValidator.RegTextEnum.postCode, text);
        },
        isDate: function(text) {
            return this.validate(RegValidator.RegTextEnum.date, text);
        }
    }
    , false);

/*文本框验证*/
function ElementValidatorParams() {
    this.len = { "text": null, "errorMsg": null, correctMsg: null };
    this.reg = { "text": [], "errorMsg": null, correctMsg: null }; //text 数组或正则
    this.tips = { "id": "", "errorMsg": "" };
    this.className = { error: "", def: "", focus: "", correct: "" };
    this.onCallback = null;
}
ElementValidatorParams.prototype = {
    id: null,
    focus: null,
    defTips: null
}
function ElementValidator() {
    this.list = [];
}
ElementValidator.className = { error: "", def: "", focus: "", correct: "" };
ElementValidator.format = function(rvp) {
    var attrNameList = ["reg", "len", "tips"], attrName = "";
    for (var i = 0, len = attrNameList.length; i < len; i++) {
        attrName = attrNameList[i];
        if (String.isNullOrEmpty(rvp[attrName])) { rvp[attrName] = {}; }
        rvp["has" + attrName] = true;
        if (attrName == "tips") {
            if (String.isNullOrEmpty(rvp["tips"]["id"])) { rvp["tips"]["id"] = rvp["id"] + "_tips_"; }
        } else {
            if (String.isNullOrEmpty(rvp[attrName]["text"])) {
                rvp[attrName]["text"] = null;
                rvp["has" + attrName] = false;
            }
        }
        if (String.isNullOrEmpty(rvp[attrName]["errorMsg"])) { rvp[attrName]["errorMsg"] = ""; }
        if (String.isNullOrEmpty(rvp[attrName]["correctMsg"])) { rvp[attrName]["correctMsg"] = ""; }
    }
    if (!rvp["className"]) { rvp["className"] = {} }
    Object.extend(rvp["className"], ElementValidator.className, false);
}
ElementValidator.showTips = function(rvp, msg, className, isError) {
    var defMsg = String.isNullOrEmpty(msg) ? rvp["tips"]["errorMsg"] : msg;
    if (!isError) { defMsg = String.isNullOrEmpty(msg) ? rvp["tips"]["correctMsg"] : msg; }
    if (String.isNullOrEmpty(defMsg)) { return; };
    var tipsId = rvp["tips"]["id"];
    var tipsElem = jDoc(tipsId);
    if (!tipsElem) {
        tipsElem = document.createElement("span");
        tipsElem.id = tipsId;
        var ele = jDoc(rvp["id"]);
        ele.parentNode.insertBefore(tipsElem, ele.nextSibling);
    }
    tipsElem.innerHTML = defMsg;
    if (typeof className === "string") { tipsElem.className = className; }
    tipsElem.style.display = "";
    return false;
}
ElementValidator.hideTips = function(rvp) {
    var errorEle = jDoc(rvp["tips"]["id"]);
    if (errorEle) { errorEle.style.display = "none"; }
}
ElementValidator.getCorrectMsg = function(correctMsg, rvp) {
    return String.isNullOrEmpty(correctMsg) ? rvp["tips"]["correctMsg"] : correctMsg;
}
ElementValidator.getErrorMsg = function(errorMsg, rvp) {
    return String.isNullOrEmpty(errorMsg) ? rvp["tips"]["errorMsg"] : errorMsg;
}
ElementValidator.getBlurFn = function(elem, elemType) {
    var unknown = false, fn = function() { };
    switch (elemType) {
        case "textarea":
        case "input":
            fn = function() {
                var value = jDoc(this["id"]).value, correctMsg = "";
                if (this["haslen"]) {
                    if (this["len"]["text"].test(value.trim()) == false) {
                        return ElementValidator.showTips(this, this["len"]["errorMsg"], this["className"]["error"], true);
                    } else {
                        correctMsg = ElementValidator.getCorrectMsg(this["len"]["correctMsg"], this);
                    }
                }
                if (String.isNullOrEmpty(value) == false && this["hasreg"]) {
                    var regList = this["reg"]["text"], errorList = this["reg"]["errorMsg"], flag = true;
                    if (regList.length == undefined) {
                        flag = regList.test(value);
                    } else {
                        for (var i = 0, len = regList.length; i < len; i++) {
                            flag = regList[i].test(value);
                            if (flag == false) { break; }
                        }
                    }
                    if (flag == false) {
                        return ElementValidator.showTips(this, errorList, this["className"]["error"]);
                    } else {
                        correctMsg = ElementValidator.getCorrectMsg(this["reg"]["correctMsg"], this); ;
                    }
                }
                if (correctMsg != "") {
                    ElementValidator.showTips(this, correctMsg, this["className"]["correct"]);
                } else if (String.isNullOrEmpty(this["defTips"]) == false) {
                    ElementValidator.showTips(this, this["defTips"], this["className"]["def"]);
                } else {
                    ElementValidator.hideTips(this);
                }
                return true;
            }
            break
        case "checkbox":
        case "radio":
            fn = function() {
                var elems = document.getElementsByName(elem), num = 0, errMsg = "", correctMsg = "", flag = true;
                for (var i = 0, len = elems.length; i < len; i++) {
                    if (elems[i].checked) {
                        if (this["hasreg"] && elems[i].value.trim() != "") {
                            if (this["reg"]["text"].test(elems[i].value)) {
                                errMsg = ElementValidator.getErrorMsg(this["reg"]["errorMsg"], this);
                                flag = false;
                                break;
                            }
                        }
                        num++;
                    }
                }
                correctMsg = flag ? ElementValidator.getCorrectMsg(this["reg"]["correctMsg"], this) : "";
                if (this["haslen"] && flag) {//maybe checkbox
                    flag = this["len"]["text"].test(num);
                    if (flag == false) {
                        errMsg = ElementValidator.getErrorMsg(this["len"]["errorMsg"], this);
                    }
                } else {
                    if (num == 0 && flag) {
                        errMsg = ElementValidator.getErrorMsg(this["len"]["errorMsg"], this);
                        flag = false;
                    }
                    correctMsg = flag ? ElementValidator.getCorrectMsg(this["len"]["correctMsg"], this) : "";
                }
                if (flag == false) {
                    ElementValidator.showTips(this, errMsg, this["className"]["error"]);
                } else if (correctMsg != "") {
                    ElementValidator.showTips(this, correctMsg, this["className"]["correct"]);
                } else {
                    ElementValidator.hideTips(this);
                }
                return flag;
            }
            break;
        case "select":
            fn = function() {
                var elem = jDoc(this["id"]), flag = true;
                if (elem.selectedIndex < 0) {
                    flag = false;
                } else {
                    if (this["len"]["text"].test(elem.selectedIndex)) {
                        flag = ElementValidator.showTips(this, this["len"]["errorMsg"], this["className"]["error"]);
                    }
                }
                if (flag) {
                    var correctMsg = ElementValidator.getCorrectMsg(this["len"]["correctMsg"], this);
                    if (correctMsg != "") {
                        ElementValidator.showTips(this, correctMsg, this["className"]["correct"]);
                    } else {
                        ElementValidator.hideTips(this);
                    }
                }
                return flag;
            }
            break;
        default: unknown = true; break;
    }
    if (unknown) {
        alert("该元素类型不能使用该方法" + rvp["id"]);
        return fn;
    }

    return fn;
}
ElementValidator.prototype = {
    init: function(rvp) {
        ElementValidator.format(rvp);
        rvp["onblur"] = function() { return true; };
        if (String.isNullOrEmpty(rvp["defTips"]) == false) {
            ElementValidator.showTips(rvp, rvp["defTips"], rvp["className"]["def"]);
        }
        if (String.isNullOrEmpty(rvp["focus"]) == false) {
            jDoc.addEventHandler(jDoc(rvp["id"]), "focus", function() { ElementValidator.showTips(this, this.focus, this["className"]["focus"]); } .bind(rvp));
        }
    },
    addText: function(rvp) {
        var ele = jDoc(rvp.id)
        if (ele) {
            this.init(rvp);
            if (rvp["haslen"] || rvp["hasreg"]) {
                rvp["onblur"] = ElementValidator.getBlurFn(ele, "input");
                jDoc.addEventHandler(ele, "blur", rvp["onblur"].bind(rvp));
            }
            this.list.push(rvp);
        }
    },
    addInputElem: function(rvp, type) {
        this.init(rvp);
        rvp["onblur"] = ElementValidator.getBlurFn(rvp.id, type);
        var elems = document.getElementsByName(rvp.id);
        for (var i = 0, len = elems.length; i < len; i++) {
            jDoc.addEventHandler(elems[i], "click", function() { rvp["onblur"].bind(rvp)(); });
        }
        this.list.push(rvp);
    },
    addRadio: function(rvp) {
        this.addInputElem(rvp, "radio");
    },
    addCheckbox: function(rvp) {
        this.addInputElem(rvp, "checkbox");
    },
    addSelect: function(rvp) {
        var ele = jDoc(rvp.id)
        if (ele) {
            this.init(rvp);
            rvp["onblur"] = ElementValidator.getBlurFn(rvp.id, "select");
            jDoc.addEventHandler(ele, "change", rvp["onblur"].bind(rvp));
            this.list.push(rvp);
        }
    },
    validate: function() {
        var errorNum = [];
        for (var i = 0, len = this.list.length; i < len; i++) {
            if (this.list[i]["onblur"]() == false) {
                errorNum[errorNum.length] = i;
            }
        }
        var nextNum = 0;
        while (nextNum < errorNum.length) {
            try {
                jDoc(this.list[errorNum[nextNum]].id).focus();
                nextNum = errorNum.length;
            } catch (e) {
                nextNum++;
            }
        }
        return errorNum.length > 0 ? false : true;
    }
}