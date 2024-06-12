# Übung 10 - Pandas Exercises 1
Arbeiten Sie nachfolgenden Aufgabenstellungen durch und dokumentieren Sie, wenn notwendig, ihre Erkenntnisse. 

## Task 10.0
Importieren Sie *pandas*.


```python
import pandas as pd
```

## Task 10.1
Erstellen Sie mit `data` ein *Series*-Objekt und geben Sie dessen Werte sowie Indizes aus. Zeigen Sie außerdem, dass
- das erstellte Objekt vom Typ *Series*
- die Werte ein vom Typ *numpy*
- die Indizes vom Typ *RangeIndex*

ist/sind.


```python
data = [11, 28, 72, 3, 5, 8]

numbers = pd.Series(data)
print("Objekt: ", numbers)
print("Typ von Objekt: ", type(numbers))
print("Typ von Werten in Objekt: ", type(numbers.values))
print("Typ von Indexen des Objekts: ", type(numbers.index))
```

    Objekt:  0    11
    1    28
    2    72
    3     3
    4     5
    5     8
    dtype: int64
    Typ von Objekt:  <class 'pandas.core.series.Series'>
    Typ von Werten in Objekt:  <class 'numpy.ndarray'>
    Typ von Indexen des Objekts:  <class 'pandas.core.indexes.range.RangeIndex'>
    

## Task 10.2
Erstellen Sie mit `quantities` eine *Series*. Verwenden Sie hierbei `fruits` als Indizes. Gesuchtes Ergebnis:

```python
apples      20
oranges     23
cherries    45
pears       10
dtype: int64
```
> Ein Vorteil gegenüber NumPy-Arrays ist: Man kann beliebige Indizes verwenden! 


```python
fruits = ['apples', 'oranges', 'cherries', 'pears']
quantities = [20, 23, 45, 10]

myseries = pd.Series(quantities, index=fruits)
print(myseries)
```

    apples      20
    oranges     23
    cherries    45
    pears       10
    dtype: int64
    


```python
pd.Series?
```

## Task 10.3
Man kann zwei *Series*-Objekte mit denselben Indizes addieren. Das Ergebnis ist ein neues *Series*-Objekt. Addieren sie die Quantities `q1` und `q2`. Bilden Sie außerdem die Summe der beiden *Series*-Objekte. Gesuchtes Ergebnis:

```python
apples      30
oranges     36
cherries    70
pears       11
dtype: int64
Summe: 147
```


```python
fruits = ['apples', 'oranges', 'cherries', 'pears']

q1 = [20, 23, 45, 10]
q2 = [10, 13, 25, 1]

s1 = pd.Series(q1, index=fruits)
s2 = pd.Series(q2, index=fruits)

s_sum = s1 + s2
print(s_sum)
print("Sum: ", s_sum.sum())
```

    apples      30
    oranges     36
    cherries    70
    pears       11
    dtype: int64
    Sum:  147
    

## Task 10.4
Die Indizes müssen nicht zwingend identisch sein - Indizes können auch komplett verschieden sein! Erstellen zwei *Series'*, addieren Sie diese und geben Sie das neue *Series*-Objekt aus. Gesuchtes Ergebnis:

```python
apples      30.0
cherries    70.0
oranges     36.0
peaches      NaN
pears        NaN
dtype: float64
```


```python
f1 = ['apples', 'oranges', 'cherries', 'pears']
f2 = ['apples', 'oranges', 'cherries', 'peaches']

q1 = [20, 23, 45, 10]
q2 = [10, 13, 25, 1]

s1 = pd.Series(q1, index=f1)
s2 = pd.Series(q2, index=f2)

s_sum = s1 + s2
print(s_sum)
```

    apples      30.0
    cherries    70.0
    oranges     36.0
    peaches      NaN
    pears        NaN
    dtype: float64
    

## Task 10.5
Index-basierter Zugriff erfolgt mit (zwei) eckigen Klammern (z.B. `my_series['foo']` oder `my_series[['foo', 'bar']]`) 

Geben Sie 
* die Anzahl der *Äpfel* aus.
* die Anzahl der *Äpfel*, *Orangen* und *Kirschen* aus. 


```python
fruits = ['apples', 'oranges', 'cherries', 'pears']
quantities = [20, 23, 45, 10]

s = pd.Series(quantities, index=fruits)
print(s['apples'])
print(s[['apples', 'oranges', 'cherries']].sum())
```

    20
    88
    

## Task 10.6
Ein Problem bei Aufgaben in der Datenanalyse besteht in fehlenden Daten. Gegeben ist das Dictionary `cities`, das für ausgewählte Städte die Einwohnerzahl bereithält. a) Erstellen Sie daraus eine *Series*-Objekt und geben Sie dieses aus. 


```python
cities = {
    'London': 8615246,
    'Berlin': 3562166,
    'Madrid': 3165235,
    'Rome': 2874038,
    'Paris': 2273305,
    'Vienna': 1805681,
    'Bucharest': 1803425,
    'Hamburg': 1760433,
    'Budapest': 1754000,
    'Warsaw': 1740119,
    'Barcelona': 1602386,
    'Munich': 1493900,
    'Milan': 1350690
}

s = pd.Series(cities)
s
```




    London       8615246
    Berlin       3562166
    Madrid       3165235
    Rome         2874038
    Paris        2273305
    Vienna       1805681
    Bucharest    1803425
    Hamburg      1760433
    Budapest     1754000
    Warsaw       1740119
    Barcelona    1602386
    Munich       1493900
    Milan        1350690
    dtype: int64



Erstellen Sie b) zwei weitere *Series*-Objekte, die aber mit `my_cities1` und `my_cities2` neuen Indizes verwendet. Wie intrepretieren Sie das Ergebnis, was fällt Ihnen auf?


```python
my_cities1 = ['London', 'Paris', 'Zurich', 'Berlin', 'Stuttgart', 'Hamburg']

my_cities2 = ['London', 'Paris', 'Berlin', 'Hamburg']

s_c1 = pd.Series(cities, index=my_cities1)
print(s_c1)

print()

s_c2 = pd.Series(cities, index=my_cities2)
print(s_c2)
```

    London       8615246.0
    Paris        2273305.0
    Zurich             NaN
    Berlin       3562166.0
    Stuttgart          NaN
    Hamburg      1760433.0
    dtype: float64
    
    London     8615246
    Paris      2273305
    Berlin     3562166
    Hamburg    1760433
    dtype: int64
    

`nan`steht für *not a number*. Das ist in unserem Fall als "fehlt" zu verstehen. Mit den Methoden `isnull`und `notnull` kann man auf fehlende Werte überprüfen. Führen Sie c) diese Überprüfung durch, sodass folgendes Ergebnis zu Buch steht:

```Python
London       False
Paris        False
Zurich        True
Berlin       False
Stuttgart     True
Hamburg      False
dtype: bool
```


```python
s_c1.isnull()
```




    London       False
    Paris        False
    Zurich        True
    Berlin       False
    Stuttgart     True
    Hamburg      False
    dtype: bool



Filtern Sie d) die fehlende Werte mit `dropna()`. Gesuchtes Ergebnis:
```python
London     8615246.0
Paris      2273305.0
Berlin     3562166.0
Hamburg    1760433.0
dtype: float64
```


```python
s_c1.dropna()
```




    London     8615246.0
    Paris      2273305.0
    Berlin     3562166.0
    Hamburg    1760433.0
    dtype: float64



Oftmals will man die fehlenden Daten gar nicht filtern, sondern mit "passenden" Werten auffüllen. Eine Möglichkeit bietet sich mit der Methode `fillna()`. Man könnte bspw. lauter "0" eintragen. Setzen Sie e) diesen Vorschlag um:

```Python
London       8615246.0
Paris        2273305.0
Zurich             0.0
Berlin       3562166.0
Stuttgart          0.0
Hamburg      1760433.0
dtype: float64
```


```python
print(s_c1.fillna(0))
print()
print(s_c1.fillna(s_c1.mean()))
```

    London       8615246.0
    Paris        2273305.0
    Zurich             0.0
    Berlin       3562166.0
    Stuttgart          0.0
    Hamburg      1760433.0
    dtype: float64
    
    London       8615246.0
    Paris        2273305.0
    Zurich       4052787.5
    Berlin       3562166.0
    Stuttgart    4052787.5
    Hamburg      1760433.0
    dtype: float64
    

## Task 10.7
Ein *Dataframe* hat einen Zeilen- und Spaltenindex. Um mehrere *Series'* zusammenzufügen, stellt Pandas die `concat`-Methode zur Verfügung (https://pandas.pydata.org/pandas-docs/stable/reference/api/pandas.concat.html). Erstellen Sie a) das Dataframe `shops_df`, indem Sie die 3 *Series'* zusammenfügen. Das Ergebnis gestaltet sich im ersten Schritt folgendermaßen:

```Python
2014    2409.14
2015    2941.01
2016    3496.83
2017    3119.55
2014    1203.45
2015    3441.62
2016    3007.83
2017    3619.53
2014    3412.12
2015    3491.16
2016    3457.19
2017    1963.10
dtype: float64
```


```python
#Die Jahre 2014, 2015, 2016 und 2017 erstellen, die als Index einer Series dienen:
years = range(2014, 2018)

shop1 = pd.Series([2409.14, 2941.01, 3496.83, 3119.55], index=years)
shop2 = pd.Series([1203.45, 3441.62, 3007.83, 3619.53], index=years)
shop3 = pd.Series([3412.12, 3491.16, 3457.19, 1963.10], index=years)

shops_df = pd.concat([shop1, shop2, shop3])
shops_df
```




    2014    2409.14
    2015    2941.01
    2016    3496.83
    2017    3119.55
    2014    1203.45
    2015    3441.62
    2016    3007.83
    2017    3619.53
    2014    3412.12
    2015    3491.16
    2016    3457.19
    2017    1963.10
    dtype: float64



Das Ergebnis ist mehr oder weniger unbrauchbar. Der Grund: `concat` verwendet als Default-Wert für den *axis*-Paramter den Wert 0. Das bedeutet, es wird Zeile um Zeile (der jeweiligen *Series*) aneinandergefügt (vgl. NumPy-Einführung, Leserichtung bei 2D-Tensoren). Abhilfe schafft eine spaltenweise "Additiion" der einzelnen *Series'*. Die Umsetzung erfolgt mit dem Argument `axis=1` bei `concat`. Verwenden Sie b) das `axis=1`-Argument beim Zusammenfügen der *Series'*. Das Ergebnis:

```Python
            0        1        2
2014  2409.14  1203.45  3412.12
2015  2941.01  3441.62  3491.16
2016  3496.83  3007.83  3457.19
2017  3119.55  3619.53  1963.10
```


```python
shops_df = pd.concat([shop1, shop2, shop3], axis=1)
shops_df
```




<div>
<style scoped>
    .dataframe tbody tr th:only-of-type {
        vertical-align: middle;
    }

    .dataframe tbody tr th {
        vertical-align: top;
    }

    .dataframe thead th {
        text-align: right;
    }
</style>
<table border="1" class="dataframe">
  <thead>
    <tr style="text-align: right;">
      <th></th>
      <th>0</th>
      <th>1</th>
      <th>2</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>2014</th>
      <td>2409.14</td>
      <td>1203.45</td>
      <td>3412.12</td>
    </tr>
    <tr>
      <th>2015</th>
      <td>2941.01</td>
      <td>3441.62</td>
      <td>3491.16</td>
    </tr>
    <tr>
      <th>2016</th>
      <td>3496.83</td>
      <td>3007.83</td>
      <td>3457.19</td>
    </tr>
    <tr>
      <th>2017</th>
      <td>3119.55</td>
      <td>3619.53</td>
      <td>1963.10</td>
    </tr>
  </tbody>
</table>
</div>



Die vorher erzielte Darstellungsform der Daten ist definitiv sinnvoller, einzig die Spaltennamen sind noch nicht das Gelbe vom Ei. Es ist bekannt, dass ein *DataFrame* über das **Property** `columns` verfügt. Diesem kann man neue Werte (z.B. als Liste) zuweisen. Weisen Sie c) dem DataFrame `shops_df` die neuen Spaltenbezeichner (siehe Liste `cities`) zu. Das Ergebnis:

```Python
         Wien     Graz  Salzburg
2014  2409.14  1203.45   3412.12
2015  2941.01  3441.62   3491.16
2016  3496.83  3007.83   3457.19
2017  3119.55  3619.53   1963.10
```


```python
cities = ['Wien', 'Graz', 'Salzburg'] 

shops_df.columns = cities
shops_df
```




<div>
<style scoped>
    .dataframe tbody tr th:only-of-type {
        vertical-align: middle;
    }

    .dataframe tbody tr th {
        vertical-align: top;
    }

    .dataframe thead th {
        text-align: right;
    }
</style>
<table border="1" class="dataframe">
  <thead>
    <tr style="text-align: right;">
      <th></th>
      <th>Wien</th>
      <th>Graz</th>
      <th>Salzburg</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>2014</th>
      <td>2409.14</td>
      <td>1203.45</td>
      <td>3412.12</td>
    </tr>
    <tr>
      <th>2015</th>
      <td>2941.01</td>
      <td>3441.62</td>
      <td>3491.16</td>
    </tr>
    <tr>
      <th>2016</th>
      <td>3496.83</td>
      <td>3007.83</td>
      <td>3457.19</td>
    </tr>
    <tr>
      <th>2017</th>
      <td>3119.55</td>
      <td>3619.53</td>
      <td>1963.10</td>
    </tr>
  </tbody>
</table>
</div>



Geben Sie d) die Inhalte der Spalte "Graz" aus und vergewissern Sie sich, ob die Spalte vom Typ *Series* ist.


```python
print(shops_df['Graz'])
print(type(shops_df['Graz']))
```

    2014    1203.45
    2015    3441.62
    2016    3007.83
    2017    3619.53
    Name: Graz, dtype: float64
    <class 'pandas.core.series.Series'>
    


```python
print(shops_df.iloc[0:2][['Wien', 'Graz']])
```

             Wien     Graz
    2014  2409.14  1203.45
    2015  2941.01  3441.62
    
