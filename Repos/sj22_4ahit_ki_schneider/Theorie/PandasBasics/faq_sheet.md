# Frequently Asked Questions

## Was ist eine "list comprehension"?

Oft muss man bestimmte Anweisung für jedes Element einer Liste oder eines Arrays durchführen. Während hierbei in vielen anderen Programmiersprachen auf altmodische for-Schleifen zurückgegriffen werden muss, gibt es eine pythonische Variante, diese Aufgabe schnell und einfach zu bewältigen:

Nehmen wir an, es gibt eine Liste numbers mit Nummern, z.B.: 1-5. Nun wollen wir daraus einen Liste mit den zugehörigen Quadratzahlen erstellen. In Python ist das ein Oneliner:

    squares = [x**2 for x in numbers]

In anderen Programmiersprachen (C#) ist das eine Challange:

    IEnumberable<int> squares = new IEnumberable<int>();
    foreach(var item in numbers) {
        squares.Add(Math.Power(item, 2));
    }

## Was versteht man unter "mean of values"?

Das ist das arithmetische Mittel bestimmter Werte. Mithilfe von NumPy ist dieser bei Arrays ganz einfach mittels

    myarray.mean()

auszurechnen. Natürlich kann man das arithmetische Mittel auch nur auf bestimmte Datensätze der Shape des Arrays einschränken, wie zum Beispiel hier:

    myarray[2:3,1].mean()

## Was bezeicht die Wendung "from the scratch"?

Die Phrase "from the scratch" bedeutet, etwas von Anfang an zu beginnen, nur mit grundlegenden Materialien oder Ressourcen. Es wird oft verwendet, um zu betonen, dass etwas vollständig unabhängig und ohne externe Hilfe oder vorhandene Materialien gemacht oder erledigt wird.

## Was sind "Qua(r|n)tiles"?

Quantile sind Werte, die eine Menge an Daten in verschiedene Bereiche unterteilen. Dabei gibt es meistens 3 Quatile, die 4 differenzierte Bereiche bilden. Der Interquartilsabstand ist dabei der Abstand zwischen erstem (also bei Zahlen kleinstem) und drittem (also bei Zahlen größtem) Quartile.

## Was versteht man unter "imputation"?

Fehlende Daten schlau zu füllen, zum Beispiel mit dem Mittelwert.

## Was versteht man unter Korrelation?

Korrelation beschreibt die Abhängigkeiten zwischen Daten / Beziehung zwischen Variablen. Zum Beispiel sieht man bei einer Heat Map die Abhängigkeiten zwischen den einzelnen Daten.

## Was ist ein scatter plot?

Ein Scatter Plot, auch Streudiagramm genannt, ist ein graphisches Darstellungsmittel, das zur Visualisierung von zwei kontinuierlichen Variablen in einer Datenmenge verwendet wird. Ein Scatter Plot ist besonders nützlich, wenn man die Beziehung zwischen zwei Variablen untersuchen möchte

## Was ist ein Histogramm?

Histogramme eignen sich besonders gut zur Darstellung von großen Datenmengen und können eine schnelle Übersicht über die Verteilung der Werte der Variablen geben. Sie werden in vielen Bereichen, wie beispielsweise in der Statistik, der Wirtschaft oder der Psychologie, verwendet.

<img src="https://upload.wikimedia.org/wikipedia/commons/8/82/Thist_german.png" width="500" />
