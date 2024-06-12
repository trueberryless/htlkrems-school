in Zusammenarbeit mit Yanik Latzka

# Mikrocontrollertechnik

## Begrifflichkeiten

### Evaluation Kit/Board

Ein Evaluation Board ist eine System was man um ein Bauteil oder System herum baut, bzw. gibt es sie manchmal vorgefertigt. Dieses Board/Kit braucht man damit das Teil funktioniert. Für ein Evalutions Board für eine CPU bräuchte man zum Beispiel RAM, eine SD-Card usw...

### Hardwarenahe Programmierung

Eine hardwarenahe Programmierung ermöglicht dem Programmierer in erster Linie, auf mehrere `tiefere` (näher bei der Hardware befindend) Elemente der Hardware zuzugreifen. Dabei unterscheidet man `höhere` (in Abstraktion und Komplexität von der Ebene der Maschinensprachen deutlich entfernte) Programmiersprachen, wie zum Beispiel C, Javascript, usw., und "tiefe" Sprachen, wie Assembler. Letztere Programmiersprache ermöglicht bereits den Zugriff auf CPU-Register, welches viele andere höhere Programmiersprachen nicht unterstützen.

Einige komplexe Programme können jedoch leider nur schwer oder gar nicht mit hardwarenahen Programmiersprachen umgesetzt werden. Aus diesem Grund haben Dennis Richie und Ken Thompson die Programmiersprache C entwickelt, mit dessen Hilfe sie dann Unix entwickelt haben...

### Assembler und „C“

Wie bereits um oberen Absatz angeschnitten, sind Assembler und C eher hardwarenahe Programmiersprachen. Wobei allerdings der wichtige Unterschied ist, dass C zu einer Hochsprache zählt und Assembler nicht. Dafür kann man mit Assembler wirklich Kerne programmieren. Was man mit Assembler allerdings nicht kann, ist das Entwickeln von komplexen Programmen, weil dies nicht dem "Komfort" eines Programmierers entspricht (quasi viel zu kompliziert...).

Wie es dieser [Artikel](https://www.mikrocontroller.net/articles/ASM_vs_C "ASM vs C") ausführlich erklärt, hat jede Programmiersprache ihre Existenzberechtigung. Allerdings kann man nicht mit jeder Programmiersprache alles erreichen, wie es dieses Zitat verdeutlichen soll (Z3-11):

    Bei zeit- und prozessoroptimierten Assemblerprogrammen sind viel mehr Adaptionen zu leisten, als bei den Hochsprachen. Bei typischen Applikationen für AVR, 8051 oder PIC ist dies meist noch relativ problemlos mögich, da die Codegröße und Strukturvielfalt begrenzt sind. [...] Bei einem ARM7, mit seiner 3-stufigen Pipeline, wird dies schon schwieriger [...]. Der Konstrukteur des Compilers [...] kann dies besser, da er erstens die Architektur sehr gut kennt und sich zweitens mit nichts anderem als Codegeneration beschäftigt.

### Compiler

Der Compiler wandelt den Programmcode, den wir entwickelt haben (zum Beispiel: .c, .h, ... - Files) in eine .hex-Datei, die der Mikrocontroller interpretieren und damit arbeiten kann. Der Vorgang, den dieser Compiler durchführt, heißt dann logischerweise `compilen`.

### Plattformabhängigkeit

Wie es dieser [Artikel](https://www.mikrocontroller.net/articles/Plattformunabh%C3%A4ngige_Programmierung_in_C "Plattformunabhängige Programmierung in C") äußerst ausführlich beschreibt, bleibt der Programmcode laut Definition immer plattformabhängig. Jedoch kann man durch geschicktes Verwenden verschiedener Datentypen eine gewisse Plattformunabhängigkeit herbeiführen. Das bedeutet jedoch nicht, dass man eine Anwendung für einen AVR-µC unverändert für einen PC kompilieren kann, da der PC unter anderem nicht über die gleiche Peripherie (Timer, I/O-Ports, Datenbusse, ...) verfügt.

Aus diesem Grund sollte man immer plattformabhängige und plattformunabhängige Programmierung teilen und separat schreiben. Wenn man nämlich den plattformabhängigen Teil isoliert programmiert, muss man nur diesen Teil umschreiben, damit man den Code für andere Geräte kompilieren kann.

### AVR

AVR ist eine Familie von 8-Bit-Microcontrollern die weit verbreitet sind, da sie einfach gebaut sind, aber auch leicht programmierbar sind. Wir verwenden auch einen AVR Chip (einen ATmega) und verwenden die Atmel IDE, da die AVR-Familie auch von Atmel stammt.

### Port

Unter einem Port versteht man in der Elektronik einen Digitalen I/O Port mit dem man einfach einen Bitzustand darstellt. Der Zustand ist dann entweder 1-5V oder 0V. Sie werden hauptsächlich für das ein- und auslesen von digitalen signalen verwendet, aber auch manchmal für A/D oder D/A Wandler.
