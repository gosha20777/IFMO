#Домашнее задание 5. Вычисление выражений
### Программы написаны на java и C#
##Basic
1. Разработайте классы Const, Variable, Add, Subtract, Multiply, Divide для вычисления выражений с одной переменной.
2. Классы должны позволять составлять выражения вида
 
        new Subtract(
         new Multiply(
          new Const(2),
          new Variable("x")
         ),
         new Const(3)
        ).evaluate(5)                        
3. При вычислении такого выражения вместо каждой переменной подставляется значение, переданное в качестве параметра методу `evaluate` (на данном этапе имена переменных игнорируются). Таким образом, результатом вычисления приведенного примера должно стать число 7.
4. Для тестирования программы должен быть создан класс `Main`, который вычисляет значение выражения <code>x<sup>2</sup>−2x+1</code>, для `x`, заданного в командной строке.
5. При выполнение задания следует обратить внимание на:
	* Выделение общего интерфейса создаваемых классов.
	* Выделение абстрактного базового класса для бинарных операций.

##Easy
Реализовать интерфейс `DoubleExpression`

##Hard
Реализовать интерфейс `TripleExpression`