﻿## Проблемы:
- Типы CanonPrinter и EpsonPrinter абсолютно идентичны, за исключением значений передаваемых параметров и 
самого названия типа, как результат большое дублирование кода.

- Отсутствуют банальные проверки для входящих данных

- Внутри PrinterManager не должна участвовать консоль для ввода информации о новом принтере, эти действия перекладываются 
на вызывающий код

- Множество if'ов при выборе на консоли тоже не годится, нужно сделать что-то вроде словаря, с ключом номера
в последовательности принтера и знаением - его класса

- Нужно избавиться от любого упоминания консоли в нашей системе типов

- Способ ввода новых данных принтера нужно вывести на консоль в место, откуда идёт управление принтерами (Program.cs)

- Изначально ПО не работало, бросая исключение при работе с файлом, т.к тот не был закрыт после перового открытия,
обернул в using участок инициализации потока вывода. Некорректное завершение консольного приложения. А так же
внутри файла Programm копипастятся методы вызова Print из PrinterManager, эти вызовы должны делаться без таких
посредников и вызываться одинаково вне зависимости от того, какой принтер мы используем, меняться должен только тип принтера

- Модификаторы доступа некоторых типов не позволяют увидеть себя из других библиотек, соответственно их protection
level нужно сделать более открытым

 ## Решение. Последовательность действий:

 1) В тип PrinterManager добавил событие с использование делегата EventHandler, в качестве передаваемой информации. Cообщение
 при начала/окончания печати. Тип пришлось сделать экземплярным. Подписчки - принтеры, в типе принтера
 реализован метод, которым подписываемся/отписываемся

 2) Нужно что-то сделать с иерархией принтеров. !!! Не понятно, зачем нам типы Canon и Epson, если пользователь может
 динамически добавть новые принтеры других брендов и моделей. Решил от них избавиться и унифицировать интерфейс создания
 нового принтера. Будет один класс Printer, объект которого будет уникально идентифицироваться по модели и названию

 3) Теперь надо разобраться с добавлением нового принтера в PrinterManager, добавить недостающие валидаторы. Для сравнения,
 видимо, предётся релаизовывать у класса Printer интерфейс IEquatable.  Выделил отдеальный статический класс для работы с меню
 Пользовательская консоль была модифицирована, теперь меню динамически расширяется при добавлении нового принтера.
 ### Результат вывода:
 ![](https://github.com/Nekliukov/ExtTraining.Summer.2018.5/blob/master/No8.Solution/pics/RESULTS_3_COMMIT.png)

 4) Нужно реализовать логгер, чтобы избавиться от вывода на консоль, проросшего во всю нашу систему типов. Выделяю интерфейс ILogger
 и реализовываю его новым классом Logger (что-то добавил, но уже голова не варит.) Всё, что успел