#Домашнее задание 9. Функциональные выражения на JavaScript
### Программы написаны на js (C# не будет тк SJ != C#)
#Basic (done)
1. Разработайте функции `cnst`, `variable`, `add`, `subtract`, `multiply`, `divide` для вычисления выражений с одной переменной.
2. Функции должны позволять производить вычисления вида:
        
        var expr = subtract(
            multiply(
                cnst(2),
                variable("x")
            ),
            cnst(3)
        );
        println(expr(5));
                        
3. При вычислении такого выражения вместо каждой переменной подставляется значение, переданное в качестве параметра функции `expr` (на данном этапе имена переменных игнорируются). Таким образом, результатом вычисления приведенного примера должно стать число `7`.
4. Тестовая программа должна вычислять выражение `x^2−2x+1`, для `x` от `0` до `10`.

#Hard (done)
1. Требуется написать функцию `parse`, осуществляющую разбор выражений, записанных в обратной польской записи. Например, результатом
`parse("x x 2 - * x * 1 +")(5)` должно быть число `76`.

#by_gosha20777 (для себя) (done)
1. Дополнительное реализовать поддержку:
	* унарных операций:
		* `abs` — абсолютная величина числа, `-5 abs` равно `5`;
		* `log` — натуральный логарифм, `5 log` примерно равно `1.6`;
	* бинарных операций:
		* `mod` (`%`) — взятие по модулю, `5 2 %` равно `1`;
		* `power` (`**`) — взятие по модулю, `5 2 **` равно `25`.

#Простая 2. (not done) 
 Дополнительное реализовать поддержку:
    * констант:
        * `pi` — π;
        * `e` — основание натурального логарифма;
    * переменных-литералов `x`, `y`, `z`;
    * [Исходный код тестов](javascript/test/FunctionalPieTest.java)
        * Запускать c аргументом `hard` или `easy`
#Простая. (not done) 
 Дополнительное реализовать поддержку:
    * переменных `y`, `z`, `u`, `v`, `w`;
    * [Исходный код тестов](javascript/test/FunctionalVariablesTest.java)
        * Запускать c аргументом `hard` или `easy`.

#### P.s.		

//Ненавижу JS :-(
//лучше уж на Java. А еще лучше на С#! Runtime быстрее JWM!!!