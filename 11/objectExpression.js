function BinaryOperator(left, right) {
	this.left = left;
	this.right = right;
}

BinaryOperator.prototype.evaluate = function(x, y, z) {
		return this.apply(this.left.evaluate(x, y, z), this.right.evaluate(x, y, z));
};

BinaryOperator.prototype.toString = function() {
	return this.left.toString() + ' ' + this.right.toString() + ' ' + this.operator;
};

BinaryOperator.prototype.prefix = function() {
	return '(' + this.operator + ' ' + this.left.prefix() + ' ' + this.right.prefix() + ')';
};


//Const=======================/
function Const(a) {
	this.value = a;
}

Const.prototype.evaluate = function(x, y, z) {
	return this.value;
};

Const.prototype.toString = function() {
	return '' + this.value;
};

Const.prototype.prefix = function() {
	return this.toString();
};

Const.prototype.diff = function(v) {
	return new Const(0);
};


//Variable=======================/
function Variable(name) {
	this.name = name;
}

Variable.prototype.evaluate = function(x, y, z) {
	if (this.name == 'x') {
		return x;
	} else if(this.name == 'y') {
		return y;
	} else {
		return z;
	}
};

Variable.prototype.toString = function() {
	return this.name;
};

Variable.prototype.prefix = function () {
	return this.toString();
};

Variable.prototype.diff = function(v) {
	if (v == this.name) {
		return new Const(1);
	} else {
		return new Const(0);
	}
};

//Add=======================/
function Add(left, right) {
	BinaryOperator.call(this, left, right);
	this.operator = '+';
}

Add.prototype = Object.create(BinaryOperator.prototype);
Add.prototype.constructor = Add;

Add.prototype.apply = function(a, b) {
	return a + b;
};

Add.prototype.diff = function(v) {
	return new Add(this.left.diff(v), this.right.diff(v));
};
//Subtract=======================/
function Subtract(left, right) {
	BinaryOperator.call(this, left, right);
	this.operator = '-';
}

Subtract.prototype = Object.create(BinaryOperator.prototype);
Subtract.prototype.constructor = Subtract;

Subtract.prototype.apply = function(a, b) {
	return a - b;
};

Subtract.prototype.diff = function(v) {
	return new Subtract(this.left.diff(v), this.right.diff(v));
};

//Multiply=======================/
function Multiply(left, right) {
	BinaryOperator.call(this, left, right);
	this.operator = '*';
}

Multiply.prototype = Object.create(BinaryOperator.prototype);
Multiply.prototype.constructor = Multiply;

Multiply.prototype.apply = function(a, b) {
	return a * b;
};

Multiply.prototype.diff = function(v) {
	return new Add(new Multiply(this.left, this.right.diff(v)), new Multiply(this.left.diff(v), this.right));
};

//Divide=======================/
function Divide(left, right) {
	BinaryOperator.call(this, left, right);
	this.operator = '/';
}

Divide.prototype = Object.create(BinaryOperator.prototype);
Divide.prototype.constructor = Divide;

Divide.prototype.apply = function(a, b) {
	return a / b;
};

Divide.prototype.diff = function(v) {
	return new Divide(
		new Subtract(
			new Multiply(this.left.diff(v), this.right), 
			new Multiply(this.left, this.right.diff(v))), 
		new Multiply(this.right, this.right));
};


//UnaryOperator=======================/
function UnaryOperator(operand) {
	this.operand = operand;
}

UnaryOperator.prototype.evaluate = function(x, y, z) {
	return this.apply(this.operand.evaluate(x, y, z));
};

UnaryOperator.prototype.toString = function() {
	return this.operand.toString()+ ' ' + this.operator;
};

UnaryOperator.prototype.prefix = function() {
	return '(' + this.operator + ' ' + this.operand.prefix() + ')';
};


//Negate=======================/
function Negate(operand) {
	UnaryOperator.call(this, operand);
	this.operator = 'negate';
}

Negate.prototype = Object.create(UnaryOperator.prototype);
Negate.prototype.constructor = Negate;
Negate.prototype.apply = function(a) {
	return -a;
};

Negate.prototype.diff = function(v) {
	return new Negate(this.operand.diff(v));
};


//Sin=======================/
function Sin(operand) {
	UnaryOperator.call(this, operand);
	this.operator = 'sin';
}

Sin.prototype = Object.create(UnaryOperator.prototype);
Sin.prototype.constructor = Sin;
Sin.prototype.apply = function(a) {
	return Math.sin(a);
};
Sin.prototype.diff = function(v) {
	return new Multiply(new Cos(this.operand), this.operand.diff(v));
};


//Cos=======================/
function Cos(operand) {
	UnaryOperator.call(this, operand);
	this.operator = 'cos';
}

Cos.prototype = Object.create(UnaryOperator.prototype);
Cos.prototype.constructor = Cos;
Cos.prototype.apply = function(a) {
	return Math.cos(a);
};
Cos.prototype.diff = function(v) {
	return new Multiply(new Negate(new Sin(this.operand)), this.operand.diff(v));
};


//Exp=======================/
function Exp(operand) {
	UnaryOperator.call(this, operand);
	this.operator = 'exp';
}

Exp.prototype = Object.create(UnaryOperator.prototype);
Exp.prototype.constructor = Exp;
Exp.prototype.apply = function(a) {
	return Math.exp(a);
};
Exp.prototype.diff = function(v) {
	return new Multiply(new Exp(this.operand), this.operand.diff(v));
};


//ArcTan=======================/
function ArcTan(operand) {
	UnaryOperator.call(this, operand);
	this.operator = 'atan';
}

ArcTan.prototype = Object.create(UnaryOperator.prototype);
ArcTan.prototype.constructor = ArcTan;
ArcTan.prototype.apply = function(a) {
	return Math.atan(a);
};
ArcTan.prototype.diff = function(v) {
	return new Multiply(this.operand.diff(v), new Divide(new Const(1), new Add(new Const(1), new Multiply(this.operand, this.operand))));
};

//=======================/
function parse(expr) {
    var binOperators = { '+': Add,
                         '-': Subtract,
                         '*': Multiply,
                         '/': Divide 
    };
    var unOperators = { 'negate': Negate,
                        'sin': Sin,
                        'cos': Cos,
                        'exp': Exp,
                        'atan': ArcTan
    };
    var rpn = [];
    var tokens = expr.split(/\s/);
    for (var i = 0; i < tokens.length; i++) {
        var token = tokens[i];
        if (token in binOperators) {
            var b = rpn.pop();
            var a = rpn.pop();
            rpn.push(new binOperators[token](a,b));
        } else if (token in unOperators) {
            rpn.push(new unOperators[token](rpn.pop()));
        } else if (/^x$|^y$|^z$/.test(token)) {
            rpn.push(new Variable(token));
        } else if (/^-?[0-9]+$/.test(token)) {
            rpn.push(new Const(parseInt(token)));
        }
    }
    return rpn.pop();
}

function parsePrefix(expr) {
	var bb = 0;
    for (var i = 0; i < expr.length() ; i++) {
        if (expr[i] == '(') {
            bb++;
        } else if(expr[i] == ')') {
            bb--;
        }
        if (bb < 0) {
            throw new Error('unexpected ")" at index:' + i);
        }
    }
    if (bb != 0) {
        throw new Error('expected ) at the end of expression');
    }
	expr = expr.replace(/\(|\)/g, ' ');
	var binOperators = { '+': Add,
                         '-': Subtract,
                         '*': Multiply,
                         '/': Divide 
    };
    var unOperators = { 'negate': Negate,
                        'sin': Sin,
                        'cos': Cos,
                        'exp': Exp,
                        'atan': ArcTan
    };
	expr = expr.trim();
	var tokens = expr.split(/\s+/);
	
	function parseRecur() {
		if(tokens.length == 0) {
			throw new Error('not enough operands');
		}
		var token = tokens.shift();
		if (token in binOperators) {
			return new binOperators[token](parseRecur(), parseRecur());
		} else if (token in unOperators) {
			return new unOperators[token](parseRecur());
		} else if(/^-?[0-9]+$/.test(token)) {
			return new Const(parseInt(token));
		} else if(/^x$|^y$|^z$/.test(token)) {
			return new Variable(token);
		} else {
			throw new Error('unrecognizable token: ' + token);
		}
	}
	
	var result = parseRecur();
	if (tokens.length > 0) {
		throw new Error('operator missing');
	}
	return result;
}

/*var op = new Subtract(new Const(2), new Const(1));*/
//println(new Divide(new Const(5), new Variable('z')).diff('x'));