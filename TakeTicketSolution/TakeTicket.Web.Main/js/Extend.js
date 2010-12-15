/*object inherit*/
Object.extend = function(target, source, replace) {
    for (var prop in source) {
        if (replace == false && target[prop] != null) { continue; }
        target[prop] = source[prop];
    }
    return target;
};
Object.extend(
    Function.prototype, {
        bind: function(o) {
            if (Function._objs == null) {
                Function._objs = [];
                Function._fns = [];
            }

            var oId = o._id;
            if (!oId) {
                Function._objs[oId = o._id = Function._objs.length] = o;
            }

            var self = this, fnId = self._id;
            if (!fnId) {
                Function._fns[fnId = self._id = Function._fns.length] = self;
            }

            if (!o._closures) {
                o._closures = [];
            }

            var closure = o._closures[fnId];
            if (closure) {
                return closure;
            }
            /*
            return resultFn = function() {
            return self.apply(o,arguments);
            }*/
            return Function._objs[oId]._closures[fnId] = function() {
                return Function._fns[fnId].apply(Function._objs[oId], arguments);
            }
        }
    }, false
);

// String Extend Methods
Object.extend(
    String.prototype, {
        trimStart: function() {
            var tmp = this;
            return tmp.replace(/^\s*/g, "");
        },
        trimEnd: function() {
            var tmp = this;
            return tmp.replace(/\s*$/g, "");
        },
        trim: function() {
            var tmp = this;
            return tmp.trimStart().trimEnd();
        },
        startWith: function(prefix) {
            return (this.substr(0, prefix.length) == prefix);
        },
        endWith: function(suffix) {
            return (this.substr(this.length - suffix.length) == suffix);
        }
    }, false);
Object.extend(
    String, {
        format: function() {
            if (arguments.length > 1) {
                var tmpFormat = arguments[0], tmpArg = [];
                if (arguments[1] instanceof Array) {
                    tmpArg = arguments[1]
                } else {
                    tmpArg = [].slice.call(arguments).slice(1);
                }
                for (var i = 0; i < tmpArg.length; i++) {
                    tmpFormat = tmpFormat.replace("{" + i + "}", tmpArg[i]);
                }
                return tmpFormat;
            }
            return arguments[0] || "";
        },
        isNullOrEmpty: function(s) {
            if (s == undefined || s == null || (typeof s == "string" && s.trim() == "")) {
                return true;
            }
            return false;
        }
    }, false);

Object.extend(
    Number.prototype, {
        toFixed: function(digit) {
            var result = Math.round(this * Math.pow(10, digit)) / (Math.pow(10, digit));
            var arr = result.toString().split(".");
            if (arr.length == 1) {
                arr[1] = "0";
            }
            for (var num = 0; num < (digit - arr[1].length); num++) {
                arr[1] += "0";
            }

            return parseFloat(arr.join("."));
        },
        toStringBy: function(digit) {
            if (isNaN(digit)) {
                this.toString();
            }
            var arr = (new String(this)).split(".");
            if (arr.length == 1) {
                arr[1] = "0";
            }
            for (var num = 0; num < (digit - arr[1].length); num++) {
                arr[1] += "0";
            }

            return arr.join(".");
        },
        toFixedString: function(digit) {
            return this.toFixed(digit).toStringBy(digit);
        }
    }
    , true);
/*Array Extend Methods*/
Object.extend(
    Array.prototype, {
        splice: function() {// -- for ie 5 splice
            var start = arguments[0], deleteCount = arguments[1];
            var len = arguments.length - 2;
            var returnValue = this.slice(start);
            for (var i = 0; i < len; i++) {
                this[start + i] = arguments[i + 2];
            }
            for (var i = 0; i < returnValue.length - deleteCount; i++) {
                this[start + len + i] = returnValue[deleteCount + i];
            }
            this.length = start + len + returnValue.length - deleteCount;
            returnValue.length = deleteCount;
            return returnValue;
        },
        push: function(new_ele) {
            this[this.length] = new_ele;
            return this.length;
        },
        contains: function(value) {
            var exist = false;
            for (var i = 0; i < this.length; i++) {
                if (this[i] == value) {
                    exist = true;
                    break;
                }
            }
            return exist;
        },
        exists: function(attrName, value) {
            var exist = false;
            for (var i = 0, len = this.length; i < len; i++) {
                if (this[i][attrName] == value) {
                    exist = true;
                    break;
                }
            }
            return exist;
        },
        add: function(value) {
            if (!this.contains(value)) {
                this.push(value);
            }
        },
        addRange: function(items) {
            var length = items.length;
            if (length != 0) {
                for (var index = 0; index < length; index++) {
                    this.push(items[index]);
                }
            }
        },
        remove: function(value) {
            var len = this.length;
            for (var i = 0; i < len; i++) {
                if (this[i] == value) {
                    this.splice(i, 1);
                    break;
                }
            }
        },
        removeBy: function(name, value) {
            for (var i = 0, len = this.length; i < len; i++) {
                if (this[i][name] == value) {
                    this.splice(i, 1);
                    break;
                }
            }
        },
        removeAt: function(index) {
            this.splice(index, 1);
        },
        clear: function() {
            if (this.length > 0) {
                this.splice(0, this.length);
            }
        },
        clone: function() {
            var clonedArray = [];
            var len = this.length;
            for (var index = 0; index < len; index++) {
                clonedArray[index] = this[index];
            }
            return clonedArray;
        },
        indexOf: function(item) {
            var length = this.length;
            if (length != 0) {
                for (var index = 0; index < length; index++) {
                    if (this[index] == item) {
                        return index;
                    }
                }
            }
            return -1;
        },
        insert: function(index, item) {
            this.splice(index, 0, item);
        }
    }, false);

Object.convertJSONToString = function(json) {
    var result = [];
    for (var attr in json) {
        var attrValue = json[attr];
        var attrValueType = typeof attrValue;
        if (attrValueType == "object") {
            result.push(attr + "=" + arguments.callee(attrValue));
        } else if (attrValueType != "function") {
            result.push(attr + "=" + attrValue);
        }
    }
    if (json instanceof Array) {
        return result.join(",");
    }
    return result.join("\n");
}