var vars = ['x', 'y' ,'z'];

function binary(left, right, apply) {
    function evaluate() {
        return apply(left.apply(this, arguments), right.apply(this, arguments));
    }
    return evaluate;
}

function add(left, right) {
    return binary(left, right, function(a, b) { return a + b; });
}

function subtract(left, right) {
    return binary(left, right, function(a, b) { return a - b; });
}

function multiply(left, right) {
    return binary(left, right, function(a, b) { return a * b; });
}

function divide(left, right) {
    return binary(left, right, function(a, b) { return a / b; });
}

function cnst(val) {
    function evaluate() {
        return val;
    }
    return evaluate;
}

function variable(name) {
    function evaluate() {
        for (var i = 0; i < vars.length; i++) {
            if(vars[i] == name) {
                return arguments[i];
            }
        }
    }
    return evaluate;
}

function unary(operand, apply) {
    function evaluate() {
        return apply(operand.apply(this, arguments));
    }
    return evaluate;
}

function negate(operand) {
    return unary(operand, function(a) { return -a; });
}

function log(operand) {
    return unary(operand, function(a) { return Math.log(a); });
}

function abs(operand) {
    return unary(operand, function(a) { return Math.abs(a); });
}

function power(left, right) {
    return binary(left, right, function(a, b) { return Math.pow(a, b); });
}

function mod(left, right) {
    return binary(left, right, function(a, b) { return a % b; });
}

function parse(expr) {
    var binOperators = { '+': add,
                         '-': subtract,
                         '*': multiply,
                         '/': divide,
                         '**': power,
                         '%': mod 
    };
    var unOperators = { 'negate': negate,
                        'abs': abs,
                        'log': log
    };
    var rpn = [];
    var tokens = expr.split(/\s/);
    for (var i = 0; i < tokens.length; i++) {
        var token = tokens[i];
        if (token in binOperators) {
            var b = rpn.pop();
            var a = rpn.pop();
            rpn.push(binOperators[token](a,b));
        } else if (token in unOperators) {
            rpn.push(unOperators[token](rpn.pop()));
        } else if (vars.indexOf(token)!=-1) {
            rpn.push(variable(token));
        } else if (/^-?[0-9]+$/.test(token)) {
            rpn.push(cnst(parseInt(token)));
        }
    }
    return rpn.pop();
}
//console.log(parse('10')(0));
