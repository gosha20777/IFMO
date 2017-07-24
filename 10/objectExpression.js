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

BinaryOperator.prototype.simplify = function() {
	if (this.left instanceof Const && this.right instanceof Const) {
		return new Const(this.evaluate(0,0,0));
	} else {
		var simpl = new this.constructor(this.left.simplify(), this.right.simplify());
		if(this.toString() == simpl.toString()){
			return simpl;
		} else {
			return simpl.simplify();
		}
	}
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

Const.prototype.diff = function(v) {
	return new Const(0);
};

Const.prototype.simplify = function() {
	return new Const(this.value);
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

Variable.prototype.diff = function(v) {
	if (v == this.name) {
		return new Const(1);
	} else {
		return new Const(0);
	}
};

Variable.prototype.simplify = function() {
	return new Variable(this.name);
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

Add.prototype.simplify = function() {
	var ret = BinaryOperator.prototype.simplify.call(this);
	if (this.left.value === 0) {
		return this.right.simplify();
	} else if (this.right.value === 0) {
		return this.left.simplify();
	} else {
		return ret;
	}
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

Subtract.prototype.simplify = function() {
	var ret = BinaryOperator.prototype.simplify.call(this);
	if (this.left.value === 0) {
		return (new Negate(this.right.simplify())).simplify();
	} else if (this.right.value === 0) {
		return this.left.simplify();
	} else {
		return ret;
	}
}

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

Multiply.prototype.simplify = function() {
	var ret = BinaryOperator.prototype.simplify.call(this);
	if (this.left.value === 0 || this.right.value === 0) {
		return new Const(0);
	} else if (this.right.value === 1) {
		return this.left.simplify();
	} else if (this.left.value === 1) {
		return this.right.simplify();
	} else {
		return ret;
	}
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

Divide.prototype.simplify = function() {
	var ret = BinaryOperator.prototype.simplify.call(this);
	if (this.left.value === 0) {
		return new Const(0);
	} else if (this.right.value === 1) {
		return this.left.simplify();
	} else {
		return ret;
	}
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

UnaryOperator.prototype.simplify = function() {
	//console.log('Kek!');
	if (this.operand instanceof Const) {
		return new Const(this.evaluate(0,0,0));
	} else {
		var simpl = new this.constructor(this.operand.simplify()); 
		if (this.toString() == simpl.toString() ) {
			return simpl;
		} else {
			return simpl.simplify();
		}
	}
}


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


//Sinh=======================/
function Sinh(operand) {
	UnaryOperator.call(this, operand);
	this.operator = 'sinh';
}

Sinh.prototype = Object.create(UnaryOperator.prototype);
Sinh.prototype.constructor = Sinh;

Sinh.prototype.apply = function(a) {
	return Math.sinh(a);
};

Sinh.prototype.diff = function(v) {
	return new Multiply(new Cosh(this.operand), this.operand.diff(v));
};


//Cos=======================/
function Cosh(operand) {
	UnaryOperator.call(this, operand);
	this.operator = 'cosh';
}

Cosh.prototype = Object.create(UnaryOperator.prototype);
Cosh.prototype.constructor = Cosh;

Cosh.prototype.apply = function(a) {
	return Math.cosh(a);
};

Cosh.prototype.diff = function(v) {
	return new Multiply(new Negate(new Sinh(this.operand)), this.operand.diff(v));
};

function parse(expr) {
    var binOperators = { '+': Add,
                         '-': Subtract,
                         '*': Multiply,
                         '/': Divide 
    };
    var unOperators = { 'negate': Negate,
                        'sinh': Sinh,
                        'cosh': Cosh
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

/*var op = new Subtract(new Const(2), new Const(1));*/
//console.log(parse('x y + cos').diff('x').simplify().toString());