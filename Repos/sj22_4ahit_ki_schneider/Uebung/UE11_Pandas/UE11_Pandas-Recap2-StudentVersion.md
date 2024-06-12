# Übung 11 - Pandas Recap 2
Arbeiten Sie nachfolgenden Aufgabenstellungen durch und dokumentieren Sie, wenn notwendig, ihre Erkenntnisse. 


```python
import pandas as pd
```

## Task 11.1
Erstellen Sie basierend auf den 3 Listen `name`, `population` und `country` das *Dictionary* `cities`. Verwenden Sie die List-Bezeichner als *Keys*. Im nächsten Schritt gilt es mit dem *Dictionary* das *DataFrame* `city_df` zu erstellen. Gesuchte Ausgabe:

```Python
      name 	population   country
0 	London 	8615246 	England
1 	Berlin 	3562166 	Germany
2 	Madrid 	3165235 	Spain
3 	Rome 	2874038 	Italy
4 	Paris 	2273305 	France
5 	Vienna 	1805681 	Austria
...
```


```python
name = ["London", "Berlin", "Madrid", "Rome",
        "Paris", "Vienna", "Bucharest", "Hamburg",
        "Budapest", "Warsaw", "Barcelona",
        "Munich", "Milan"]

population = [8615246, 3562166, 3165235, 2874038,
                2273305, 1805681, 1803425, 1760433,
                1754000, 1740119, 1602386, 1493900,
                1350680]

country = ["England", "Germany", "Spain", "Italy",
            "France", "Austria", "Romania",
            "Germany", "Hungary", "Poland", "Spain",
            "Germany", "Italy"]

# Your code...
cities = {
    'name': name,
    'population': population,
    'country': country
}
print(cities)

city_df = pd.DataFrame(cities)
city_df
```

    {'name': ['London', 'Berlin', 'Madrid', 'Rome', 'Paris', 'Vienna', 'Bucharest', 'Hamburg', 'Budapest', 'Warsaw', 'Barcelona', 'Munich', 'Milan'], 'population': [8615246, 3562166, 3165235, 2874038, 2273305, 1805681, 1803425, 1760433, 1754000, 1740119, 1602386, 1493900, 1350680], 'country': ['England', 'Germany', 'Spain', 'Italy', 'France', 'Austria', 'Romania', 'Germany', 'Hungary', 'Poland', 'Spain', 'Germany', 'Italy']}
    




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
      <th>name</th>
      <th>population</th>
      <th>country</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>0</th>
      <td>London</td>
      <td>8615246</td>
      <td>England</td>
    </tr>
    <tr>
      <th>1</th>
      <td>Berlin</td>
      <td>3562166</td>
      <td>Germany</td>
    </tr>
    <tr>
      <th>2</th>
      <td>Madrid</td>
      <td>3165235</td>
      <td>Spain</td>
    </tr>
    <tr>
      <th>3</th>
      <td>Rome</td>
      <td>2874038</td>
      <td>Italy</td>
    </tr>
    <tr>
      <th>4</th>
      <td>Paris</td>
      <td>2273305</td>
      <td>France</td>
    </tr>
    <tr>
      <th>5</th>
      <td>Vienna</td>
      <td>1805681</td>
      <td>Austria</td>
    </tr>
    <tr>
      <th>6</th>
      <td>Bucharest</td>
      <td>1803425</td>
      <td>Romania</td>
    </tr>
    <tr>
      <th>7</th>
      <td>Hamburg</td>
      <td>1760433</td>
      <td>Germany</td>
    </tr>
    <tr>
      <th>8</th>
      <td>Budapest</td>
      <td>1754000</td>
      <td>Hungary</td>
    </tr>
    <tr>
      <th>9</th>
      <td>Warsaw</td>
      <td>1740119</td>
      <td>Poland</td>
    </tr>
    <tr>
      <th>10</th>
      <td>Barcelona</td>
      <td>1602386</td>
      <td>Spain</td>
    </tr>
    <tr>
      <th>11</th>
      <td>Munich</td>
      <td>1493900</td>
      <td>Germany</td>
    </tr>
    <tr>
      <th>12</th>
      <td>Milan</td>
      <td>1350680</td>
      <td>Italy</td>
    </tr>
  </tbody>
</table>
</div>



## Task 11.2
Die Reihenfolge der Spalten kann bei der Erstellung des *DataFrames* festgelegt werden. Dazu dient das Schlüsselwort `columns` beim Instanziieren eines *DataFrames*. Ändern Sie diese, dass folgende Spaltenreihenfolge gegeben ist: *name* - *country* - *population*. Verwenden Sie hierzu die Liste `new_order`. Erstellen Sie mit `city_df` ein neues *DataFrame*.


```python
new_order = ["name", "country", "population"]

# Your code...
city_df = pd.DataFrame(city_df, columns=new_order)
city_df
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
      <th>name</th>
      <th>country</th>
      <th>population</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>0</th>
      <td>London</td>
      <td>England</td>
      <td>8615246</td>
    </tr>
    <tr>
      <th>1</th>
      <td>Berlin</td>
      <td>Germany</td>
      <td>3562166</td>
    </tr>
    <tr>
      <th>2</th>
      <td>Madrid</td>
      <td>Spain</td>
      <td>3165235</td>
    </tr>
    <tr>
      <th>3</th>
      <td>Rome</td>
      <td>Italy</td>
      <td>2874038</td>
    </tr>
    <tr>
      <th>4</th>
      <td>Paris</td>
      <td>France</td>
      <td>2273305</td>
    </tr>
    <tr>
      <th>5</th>
      <td>Vienna</td>
      <td>Austria</td>
      <td>1805681</td>
    </tr>
    <tr>
      <th>6</th>
      <td>Bucharest</td>
      <td>Romania</td>
      <td>1803425</td>
    </tr>
    <tr>
      <th>7</th>
      <td>Hamburg</td>
      <td>Germany</td>
      <td>1760433</td>
    </tr>
    <tr>
      <th>8</th>
      <td>Budapest</td>
      <td>Hungary</td>
      <td>1754000</td>
    </tr>
    <tr>
      <th>9</th>
      <td>Warsaw</td>
      <td>Poland</td>
      <td>1740119</td>
    </tr>
    <tr>
      <th>10</th>
      <td>Barcelona</td>
      <td>Spain</td>
      <td>1602386</td>
    </tr>
    <tr>
      <th>11</th>
      <td>Munich</td>
      <td>Germany</td>
      <td>1493900</td>
    </tr>
    <tr>
      <th>12</th>
      <td>Milan</td>
      <td>Italy</td>
      <td>1350680</td>
    </tr>
  </tbody>
</table>
</div>



# Task 11.3
Man kann den Index entweder beim Erstellen eines *DataFrames* explizit definieren oder mit `set_index()` im Nachhinein ändern. Definieren Sie die Spalte *country* als neuen Index bei `city_df`. Wichtig: `set_index()` liefert ein neues DF-Objekt, was wir aber nicht möchten. Die Änderung soll in `city_df` direkt erfolgen!

Quelle: https://pandas.pydata.org/pandas-docs/stable/reference/api/pandas.DataFrame.set_index.html?highlight=set_index#pandas-dataframe-set-index


```python
# Your code...
city_df.set_index('country', inplace=True)
city_df
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
      <th>name</th>
      <th>population</th>
    </tr>
    <tr>
      <th>country</th>
      <th></th>
      <th></th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>England</th>
      <td>London</td>
      <td>8615246</td>
    </tr>
    <tr>
      <th>Germany</th>
      <td>Berlin</td>
      <td>3562166</td>
    </tr>
    <tr>
      <th>Spain</th>
      <td>Madrid</td>
      <td>3165235</td>
    </tr>
    <tr>
      <th>Italy</th>
      <td>Rome</td>
      <td>2874038</td>
    </tr>
    <tr>
      <th>France</th>
      <td>Paris</td>
      <td>2273305</td>
    </tr>
    <tr>
      <th>Austria</th>
      <td>Vienna</td>
      <td>1805681</td>
    </tr>
    <tr>
      <th>Romania</th>
      <td>Bucharest</td>
      <td>1803425</td>
    </tr>
    <tr>
      <th>Germany</th>
      <td>Hamburg</td>
      <td>1760433</td>
    </tr>
    <tr>
      <th>Hungary</th>
      <td>Budapest</td>
      <td>1754000</td>
    </tr>
    <tr>
      <th>Poland</th>
      <td>Warsaw</td>
      <td>1740119</td>
    </tr>
    <tr>
      <th>Spain</th>
      <td>Barcelona</td>
      <td>1602386</td>
    </tr>
    <tr>
      <th>Germany</th>
      <td>Munich</td>
      <td>1493900</td>
    </tr>
    <tr>
      <th>Italy</th>
      <td>Milan</td>
      <td>1350680</td>
    </tr>
  </tbody>
</table>
</div>



## Task 11.4
Gesucht sind a) alle Städte Deutschlands und b) alle Städt Deutschlands und Frankreichs. Zur Erinnerung: Die Spalte *country* bildet den Index.

> **Remember**: `loc`und `iloc` durchsuchen ein *DataFrame* anhand des Index; es sind ausschließlich Werte der Index-Spalte zulässigt. Ignoriert man das, erhält man einen *Key Error*. Also bevor man loslegt, sollte man kurz innehalten und überlegen, was kann ich wie suchen und - hoffentlich - finden!

Den Index eines DataFrames kann man mit dem Property `index` ausgeben.


```python
city_df.index
```




    Index(['England', 'Germany', 'Spain', 'Italy', 'France', 'Austria', 'Romania',
           'Germany', 'Hungary', 'Poland', 'Spain', 'Germany', 'Italy'],
          dtype='object', name='country')




```python
# Your code...
city_df.loc['Germany']
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
      <th>name</th>
      <th>population</th>
    </tr>
    <tr>
      <th>country</th>
      <th></th>
      <th></th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>Germany</th>
      <td>Berlin</td>
      <td>3562166</td>
    </tr>
    <tr>
      <th>Germany</th>
      <td>Hamburg</td>
      <td>1760433</td>
    </tr>
    <tr>
      <th>Germany</th>
      <td>Munich</td>
      <td>1493900</td>
    </tr>
  </tbody>
</table>
</div>




```python
city_df.loc[['Germany', 'France']]
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
      <th>name</th>
      <th>population</th>
    </tr>
    <tr>
      <th>country</th>
      <th></th>
      <th></th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>Germany</th>
      <td>Berlin</td>
      <td>3562166</td>
    </tr>
    <tr>
      <th>Germany</th>
      <td>Hamburg</td>
      <td>1760433</td>
    </tr>
    <tr>
      <th>Germany</th>
      <td>Munich</td>
      <td>1493900</td>
    </tr>
    <tr>
      <th>France</th>
      <td>Paris</td>
      <td>2273305</td>
    </tr>
  </tbody>
</table>
</div>



## Task 11.5
Gesucht sind alle jene Städte, deren *Population* > 2Mio. ist. 


```python
# Your code...
city_df[city_df['population'] > 2e6]
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
      <th>name</th>
      <th>population</th>
    </tr>
    <tr>
      <th>country</th>
      <th></th>
      <th></th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>England</th>
      <td>London</td>
      <td>8615246</td>
    </tr>
    <tr>
      <th>Germany</th>
      <td>Berlin</td>
      <td>3562166</td>
    </tr>
    <tr>
      <th>Spain</th>
      <td>Madrid</td>
      <td>3165235</td>
    </tr>
    <tr>
      <th>Italy</th>
      <td>Rome</td>
      <td>2874038</td>
    </tr>
    <tr>
      <th>France</th>
      <td>Paris</td>
      <td>2273305</td>
    </tr>
  </tbody>
</table>
</div>



## Task 11.6
Aufgabenstellung 11.5 kann man auf mehrere Arten lösen. Legen Sie dar, warum die `loc`-Varianten funktioniert - vor allem unter den in 10.5 diskutierten Gesichtspunkten?


```python
# Your code...
city_df.loc[city_df['population'] > 2e6]
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
      <th>name</th>
      <th>population</th>
      <th>area</th>
    </tr>
    <tr>
      <th>country</th>
      <th></th>
      <th></th>
      <th></th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>England</th>
      <td>London</td>
      <td>8615246</td>
      <td>1572.00</td>
    </tr>
    <tr>
      <th>Italy</th>
      <td>Rome</td>
      <td>2874038</td>
      <td>1285.00</td>
    </tr>
    <tr>
      <th>Germany</th>
      <td>Berlin</td>
      <td>3562166</td>
      <td>891.85</td>
    </tr>
    <tr>
      <th>Spain</th>
      <td>Madrid</td>
      <td>3165235</td>
      <td>605.77</td>
    </tr>
    <tr>
      <th>France</th>
      <td>Paris</td>
      <td>2273305</td>
      <td>105.40</td>
    </tr>
  </tbody>
</table>
</div>




Das funktioniert, weil die Überprüfung (innerhalb der [geschwungenen Klammern]) einen boolschen Wert (True - False) zurückliefert. Es wird dann immer nur eine Zeile selektiert, wenn True ist...

## Task 11.7
Berechnen Sie die Gesamtsummer aller Städte.


```python
# Your code...
city_df['population'].sum()
```




    33800614



## Task 11.8
Fügen Sie dem *DataFrame* `city_df` die Spalte *area* mit den Werten der Liste `area` (Fläche in qkm) hinzu. Gesuchtes Ergebnis:

```Python
            name 	population 	area
country 			
England 	London 	8615246 	1572.00
Germany 	Berlin 	3562166 	891.85
Spain 	  Madrid 	3165235 	605.77
Italy 	  Rome 	  2874038     1285.00
France 	 Paris 	 2273305     105.40
```


```python
area = [1572, 891.85, 605.77, 1285,
        105.4, 414.6, 228, 755,
        525.2, 517, 101.9, 310.4,
        181.8]

# Your code...
# Neu Spalte immer mit: df['column']=np.nan
# Spalte löschen: del df['column']
#                 df.drop('column', axis=1, inplace=True)

city_df['area'] = area
city_df
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
      <th>name</th>
      <th>population</th>
      <th>area</th>
    </tr>
    <tr>
      <th>country</th>
      <th></th>
      <th></th>
      <th></th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>England</th>
      <td>London</td>
      <td>8615246</td>
      <td>1572.00</td>
    </tr>
    <tr>
      <th>Germany</th>
      <td>Berlin</td>
      <td>3562166</td>
      <td>891.85</td>
    </tr>
    <tr>
      <th>Spain</th>
      <td>Madrid</td>
      <td>3165235</td>
      <td>605.77</td>
    </tr>
    <tr>
      <th>Italy</th>
      <td>Rome</td>
      <td>2874038</td>
      <td>1285.00</td>
    </tr>
    <tr>
      <th>France</th>
      <td>Paris</td>
      <td>2273305</td>
      <td>105.40</td>
    </tr>
    <tr>
      <th>Austria</th>
      <td>Vienna</td>
      <td>1805681</td>
      <td>414.60</td>
    </tr>
    <tr>
      <th>Romania</th>
      <td>Bucharest</td>
      <td>1803425</td>
      <td>228.00</td>
    </tr>
    <tr>
      <th>Germany</th>
      <td>Hamburg</td>
      <td>1760433</td>
      <td>755.00</td>
    </tr>
    <tr>
      <th>Hungary</th>
      <td>Budapest</td>
      <td>1754000</td>
      <td>525.20</td>
    </tr>
    <tr>
      <th>Poland</th>
      <td>Warsaw</td>
      <td>1740119</td>
      <td>517.00</td>
    </tr>
    <tr>
      <th>Spain</th>
      <td>Barcelona</td>
      <td>1602386</td>
      <td>101.90</td>
    </tr>
    <tr>
      <th>Germany</th>
      <td>Munich</td>
      <td>1493900</td>
      <td>310.40</td>
    </tr>
    <tr>
      <th>Italy</th>
      <td>Milan</td>
      <td>1350680</td>
      <td>181.80</td>
    </tr>
  </tbody>
</table>
</div>



## Task 11.9
Sortieren Sie die Ausgabe nach *area*, und zwar in absteigener Reihenfolge. Verwenden Sie `sort_values()`. Quelle: https://pandas.pydata.org/pandas-docs/stable/reference/api/pandas.DataFrame.sort_values.html


```python
# Your code...
city_df.sort_values('area', ascending=False, inplace=True)
city_df
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
      <th>name</th>
      <th>population</th>
      <th>area</th>
    </tr>
    <tr>
      <th>country</th>
      <th></th>
      <th></th>
      <th></th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>England</th>
      <td>London</td>
      <td>8615246</td>
      <td>1572.00</td>
    </tr>
    <tr>
      <th>Italy</th>
      <td>Rome</td>
      <td>2874038</td>
      <td>1285.00</td>
    </tr>
    <tr>
      <th>Germany</th>
      <td>Berlin</td>
      <td>3562166</td>
      <td>891.85</td>
    </tr>
    <tr>
      <th>Germany</th>
      <td>Hamburg</td>
      <td>1760433</td>
      <td>755.00</td>
    </tr>
    <tr>
      <th>Spain</th>
      <td>Madrid</td>
      <td>3165235</td>
      <td>605.77</td>
    </tr>
    <tr>
      <th>Hungary</th>
      <td>Budapest</td>
      <td>1754000</td>
      <td>525.20</td>
    </tr>
    <tr>
      <th>Poland</th>
      <td>Warsaw</td>
      <td>1740119</td>
      <td>517.00</td>
    </tr>
    <tr>
      <th>Austria</th>
      <td>Vienna</td>
      <td>1805681</td>
      <td>414.60</td>
    </tr>
    <tr>
      <th>Germany</th>
      <td>Munich</td>
      <td>1493900</td>
      <td>310.40</td>
    </tr>
    <tr>
      <th>Romania</th>
      <td>Bucharest</td>
      <td>1803425</td>
      <td>228.00</td>
    </tr>
    <tr>
      <th>Italy</th>
      <td>Milan</td>
      <td>1350680</td>
      <td>181.80</td>
    </tr>
    <tr>
      <th>France</th>
      <td>Paris</td>
      <td>2273305</td>
      <td>105.40</td>
    </tr>
    <tr>
      <th>Spain</th>
      <td>Barcelona</td>
      <td>1602386</td>
      <td>101.90</td>
    </tr>
  </tbody>
</table>
</div>



## Task 11.10 - BITTE AUSLASSEN, HOLEN WIR NACH!
Nehmen Sie spätestens jetzt den Abschnitt *Applying Functions* des Tutorials **Python Pandas Tutorial: A Complete Introduction for Beginners** (siehe Übung 09) durch. 

Ziel ist die Erstellung einer weiteren Spalte *megacities*, die für alle Städte, der *population* > 2Mio. ist, den Wert `True` enthält. Erstellen Sie hierzu die Funktion `def calc_megacities(population)`, in welcher die Abfrage zu implementieren ist. Das gesuchte Ergebnis (die unordentliche Darstellung ist dem JN geschuldet):

```Python
            name 	population 	area 	megacities
country 				
England 	London 	8615246 	1572.00 	True
Italy       Rome 	2874038 	1285.00 	True
Germany 	Berlin 	3562166 	891.85 	    True
Germany 	Hamburg 1760433 	755.00 	    False
Spain 	    Madrid 	3165235 	605.77 	    True
...
```


```python
# Your code...
```

## Task 11.11

Diese Aufgabe basiert auf einem Dataset, dass je Messzeitpunkt *t* sechs Temperaturwerte (Sensor 1 bis Sensor 6) umfasst. Das Messintervall betrug 15 Minuten.

Laden Sie a) das bereitgestellte Dataset *temperatures_with_NaN.csv* und geben Sie die Shape aus. 

Geben Sie b) die ersten 5 Zeilen aller Sensoren aus. Geben Sie c) ausschließlich die ersten 5 Zeilen der Sensoren 3 und 4 aus. 

Ermitteln Sie d) die Anzahl der NaN-Werte je Sensor sowie je Zeitpunkt *t*. **Hinweis**: Denken Sie an die Achsen-Thematik, diese ist bei `sum()` konfigurierbar (https://pandas.pydata.org/pandas-docs/stable/reference/api/pandas.DataFrame.sum.html?highlight=sum#pandas.DataFrame.sum. Ermitteln Sie außerdem die Gesamtanzahl der *NaN*-Werte. Hierzu ein kleiner Tipp: "doppelt hält besser"! 

e) Der letzte Punkte dieser Aufgabe widmet sich der Ermittlung des Mittelwertes zum Zeitpunkt t (siehe neue Spalte *mean*). Das gesuchte Ergebnis ist:

```Python
            time 	sensor1 	sensor2 	sensor3 	sensor4 	sensor5 	sensor6 	mean
    0 	06:00:00 	14.3 	    13.7 	  14.2 	  14.3 	   13.5 	  13.6 	 13.933333
    1 	06:15:00 	14.5 	    14.5 	  14.0 	  15.0 	   14.5 	  14.7 	 14.533333
    3 	06:45:00 	14.8 	    14.5 	  15.6 	  15.2 	   14.7 	  14.6 	 14.900000
    4 	07:00:00 	15.0 	    14.9 	  NaN 	   15.6 	   14.0 	  15.3 	 14.960000
    6 	07:30:00 	15.4 	    15.3 	  NaN 	   15.6 	   14.7 	  15.1 	 15.220000
```

**Vorgehensweise**

Es wird ersichtlich, dass z.B. die Messung zum Zeitpunkt t2 fehlt. Hintergrund ist, dass all jene Messungen entfernt wurden, die mehr als **einen** NaN-Wert aufwiesen. Das lässt sich mit `dropna()` überauseinfach bewerkstelligen (siehe Argument `thresh`). Hierbei ist die Gesamtanzahl der Spalten - also inkl. *time* - zu berücksichtigen! Entfernt man all jene Zeilen, die mehr als einen NaN-Wert enthalten, reduziert sich die Anzahl der Zeilen im Dataset auf 35.

Den zweiten und letzten Schritt, um diese Aufgabe zu bewerkstelligen, stellt die Ermittlung des Mittelwertes je Messzeitpunkt t dar. Das Ergebnis ist in die neue Spalte *mean* zu schreiben.


```python
#a)
temperatures = pd.read_csv('temperatures_with_NaN.csv')
temperatures.shape
```




    (54, 7)




```python
#b)
temperatures.head(5)
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
      <th>time</th>
      <th>sensor1</th>
      <th>sensor2</th>
      <th>sensor3</th>
      <th>sensor4</th>
      <th>sensor5</th>
      <th>sensor6</th>
      <th>mean</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>0</th>
      <td>06:00:00</td>
      <td>14.3</td>
      <td>13.7</td>
      <td>14.2</td>
      <td>14.3</td>
      <td>13.5</td>
      <td>13.6</td>
      <td>13.933333</td>
    </tr>
    <tr>
      <th>1</th>
      <td>06:15:00</td>
      <td>14.5</td>
      <td>14.5</td>
      <td>14.0</td>
      <td>15.0</td>
      <td>14.5</td>
      <td>14.7</td>
      <td>14.533333</td>
    </tr>
    <tr>
      <th>2</th>
      <td>06:30:00</td>
      <td>14.6</td>
      <td>NaN</td>
      <td>14.8</td>
      <td>NaN</td>
      <td>14.0</td>
      <td>14.2</td>
      <td>14.400000</td>
    </tr>
    <tr>
      <th>3</th>
      <td>06:45:00</td>
      <td>14.8</td>
      <td>14.5</td>
      <td>15.6</td>
      <td>15.2</td>
      <td>14.7</td>
      <td>14.6</td>
      <td>14.900000</td>
    </tr>
    <tr>
      <th>4</th>
      <td>07:00:00</td>
      <td>15.0</td>
      <td>14.9</td>
      <td>NaN</td>
      <td>15.6</td>
      <td>14.0</td>
      <td>15.3</td>
      <td>14.960000</td>
    </tr>
  </tbody>
</table>
</div>




```python
#c)
temperatures.iloc[:5,3:5]
# temperatures[['sensor3', 'sensor4']]
# temperatures.iloc[:5][['sensor3', 'sensor4']]
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
      <th>sensor3</th>
      <th>sensor4</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>0</th>
      <td>14.2</td>
      <td>14.3</td>
    </tr>
    <tr>
      <th>1</th>
      <td>14.0</td>
      <td>15.0</td>
    </tr>
    <tr>
      <th>2</th>
      <td>14.8</td>
      <td>NaN</td>
    </tr>
    <tr>
      <th>3</th>
      <td>15.6</td>
      <td>15.2</td>
    </tr>
    <tr>
      <th>4</th>
      <td>NaN</td>
      <td>15.6</td>
    </tr>
  </tbody>
</table>
</div>




```python
#d)
temperatures.isnull().sum()
```




    time        0
    sensor1    11
    sensor2     8
    sensor3    13
    sensor4    15
    sensor5     9
    sensor6    11
    dtype: int64




```python
#d)
temperatures.isnull().sum(axis=1)
```




    0     0
    1     0
    2     2
    3     0
    4     1
    5     2
    6     1
    7     1
    8     3
    9     2
    10    3
    11    2
    12    0
    13    1
    14    2
    15    1
    16    0
    17    1
    18    0
    19    2
    20    1
    21    1
    22    0
    23    0
    24    1
    25    3
    26    2
    27    1
    28    0
    29    1
    30    2
    31    3
    32    4
    33    3
    34    3
    35    2
    36    2
    37    1
    38    1
    39    1
    40    1
    41    1
    42    0
    43    0
    44    2
    45    1
    46    0
    47    2
    48    0
    49    1
    50    1
    51    1
    52    0
    53    1
    dtype: int64




```python
#d)
temperatures.isnull().sum().sum()
```




    67




```python
#e)
temperatures['mean'] = temperatures.mean(axis=1)
temperatures.dropna?
temperatures
```

    C:\Users\trueberryless\AppData\Local\Temp\ipykernel_16196\755090853.py:2: FutureWarning: Dropping of nuisance columns in DataFrame reductions (with 'numeric_only=None') is deprecated; in a future version this will raise TypeError.  Select only valid columns before calling the reduction.
      temperatures['mean'] = temperatures.mean(axis=1)
    




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
      <th>time</th>
      <th>sensor1</th>
      <th>sensor2</th>
      <th>sensor3</th>
      <th>sensor4</th>
      <th>sensor5</th>
      <th>sensor6</th>
      <th>mean</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>0</th>
      <td>06:00:00</td>
      <td>14.3</td>
      <td>13.7</td>
      <td>14.2</td>
      <td>14.3</td>
      <td>13.5</td>
      <td>13.6</td>
      <td>13.933333</td>
    </tr>
    <tr>
      <th>1</th>
      <td>06:15:00</td>
      <td>14.5</td>
      <td>14.5</td>
      <td>14.0</td>
      <td>15.0</td>
      <td>14.5</td>
      <td>14.7</td>
      <td>14.533333</td>
    </tr>
    <tr>
      <th>2</th>
      <td>06:30:00</td>
      <td>14.6</td>
      <td>NaN</td>
      <td>14.8</td>
      <td>NaN</td>
      <td>14.0</td>
      <td>14.2</td>
      <td>14.400000</td>
    </tr>
    <tr>
      <th>3</th>
      <td>06:45:00</td>
      <td>14.8</td>
      <td>14.5</td>
      <td>15.6</td>
      <td>15.2</td>
      <td>14.7</td>
      <td>14.6</td>
      <td>14.900000</td>
    </tr>
    <tr>
      <th>4</th>
      <td>07:00:00</td>
      <td>15.0</td>
      <td>14.9</td>
      <td>NaN</td>
      <td>15.6</td>
      <td>14.0</td>
      <td>15.3</td>
      <td>14.960000</td>
    </tr>
    <tr>
      <th>5</th>
      <td>07:15:00</td>
      <td>15.2</td>
      <td>15.2</td>
      <td>NaN</td>
      <td>15.3</td>
      <td>15.5</td>
      <td>NaN</td>
      <td>15.300000</td>
    </tr>
    <tr>
      <th>6</th>
      <td>07:30:00</td>
      <td>15.4</td>
      <td>15.3</td>
      <td>NaN</td>
      <td>15.6</td>
      <td>14.7</td>
      <td>15.1</td>
      <td>15.220000</td>
    </tr>
    <tr>
      <th>7</th>
      <td>07:45:00</td>
      <td>15.5</td>
      <td>14.8</td>
      <td>15.4</td>
      <td>15.5</td>
      <td>NaN</td>
      <td>14.9</td>
      <td>15.220000</td>
    </tr>
    <tr>
      <th>8</th>
      <td>08:00:00</td>
      <td>NaN</td>
      <td>NaN</td>
      <td>15.9</td>
      <td>NaN</td>
      <td>15.4</td>
      <td>15.4</td>
      <td>15.566667</td>
    </tr>
    <tr>
      <th>9</th>
      <td>08:15:00</td>
      <td>NaN</td>
      <td>15.8</td>
      <td>15.9</td>
      <td>16.9</td>
      <td>16.0</td>
      <td>NaN</td>
      <td>16.150000</td>
    </tr>
    <tr>
      <th>10</th>
      <td>08:30:00</td>
      <td>16.1</td>
      <td>NaN</td>
      <td>NaN</td>
      <td>15.9</td>
      <td>NaN</td>
      <td>15.2</td>
      <td>15.733333</td>
    </tr>
    <tr>
      <th>11</th>
      <td>08:45:00</td>
      <td>NaN</td>
      <td>16.6</td>
      <td>17.3</td>
      <td>NaN</td>
      <td>16.4</td>
      <td>16.0</td>
      <td>16.575000</td>
    </tr>
    <tr>
      <th>12</th>
      <td>09:00:00</td>
      <td>16.8</td>
      <td>17.3</td>
      <td>17.7</td>
      <td>17.8</td>
      <td>15.9</td>
      <td>16.1</td>
      <td>16.933333</td>
    </tr>
    <tr>
      <th>13</th>
      <td>09:15:00</td>
      <td>17.1</td>
      <td>17.5</td>
      <td>17.5</td>
      <td>17.3</td>
      <td>16.6</td>
      <td>NaN</td>
      <td>17.200000</td>
    </tr>
    <tr>
      <th>14</th>
      <td>09:30:00</td>
      <td>17.7</td>
      <td>18.2</td>
      <td>18.2</td>
      <td>18.6</td>
      <td>NaN</td>
      <td>NaN</td>
      <td>18.175000</td>
    </tr>
    <tr>
      <th>15</th>
      <td>09:45:00</td>
      <td>18.4</td>
      <td>19.0</td>
      <td>19.0</td>
      <td>NaN</td>
      <td>18.4</td>
      <td>18.3</td>
      <td>18.620000</td>
    </tr>
    <tr>
      <th>16</th>
      <td>10:00:00</td>
      <td>19.0</td>
      <td>19.7</td>
      <td>18.8</td>
      <td>18.9</td>
      <td>17.5</td>
      <td>18.9</td>
      <td>18.800000</td>
    </tr>
    <tr>
      <th>17</th>
      <td>10:15:00</td>
      <td>19.7</td>
      <td>19.4</td>
      <td>NaN</td>
      <td>19.2</td>
      <td>19.7</td>
      <td>19.6</td>
      <td>19.520000</td>
    </tr>
    <tr>
      <th>18</th>
      <td>10:30:00</td>
      <td>20.4</td>
      <td>19.4</td>
      <td>20.0</td>
      <td>21.0</td>
      <td>20.2</td>
      <td>19.8</td>
      <td>20.133333</td>
    </tr>
    <tr>
      <th>19</th>
      <td>10:45:00</td>
      <td>21.1</td>
      <td>20.9</td>
      <td>NaN</td>
      <td>NaN</td>
      <td>19.7</td>
      <td>20.5</td>
      <td>20.550000</td>
    </tr>
    <tr>
      <th>20</th>
      <td>11:00:00</td>
      <td>21.8</td>
      <td>21.3</td>
      <td>NaN</td>
      <td>23.2</td>
      <td>21.1</td>
      <td>20.5</td>
      <td>21.580000</td>
    </tr>
    <tr>
      <th>21</th>
      <td>11:15:00</td>
      <td>NaN</td>
      <td>22.7</td>
      <td>23.7</td>
      <td>22.8</td>
      <td>22.9</td>
      <td>22.1</td>
      <td>22.840000</td>
    </tr>
    <tr>
      <th>22</th>
      <td>11:30:00</td>
      <td>23.4</td>
      <td>22.7</td>
      <td>23.0</td>
      <td>24.5</td>
      <td>22.3</td>
      <td>22.9</td>
      <td>23.133333</td>
    </tr>
    <tr>
      <th>23</th>
      <td>11:45:00</td>
      <td>24.2</td>
      <td>23.1</td>
      <td>25.3</td>
      <td>23.7</td>
      <td>24.5</td>
      <td>24.8</td>
      <td>24.266667</td>
    </tr>
    <tr>
      <th>24</th>
      <td>12:00:00</td>
      <td>24.0</td>
      <td>23.1</td>
      <td>23.1</td>
      <td>NaN</td>
      <td>22.5</td>
      <td>22.7</td>
      <td>23.080000</td>
    </tr>
    <tr>
      <th>25</th>
      <td>12:15:00</td>
      <td>NaN</td>
      <td>NaN</td>
      <td>24.8</td>
      <td>25.1</td>
      <td>NaN</td>
      <td>22.4</td>
      <td>24.100000</td>
    </tr>
    <tr>
      <th>26</th>
      <td>12:30:00</td>
      <td>NaN</td>
      <td>24.2</td>
      <td>23.6</td>
      <td>24.1</td>
      <td>22.1</td>
      <td>NaN</td>
      <td>23.500000</td>
    </tr>
    <tr>
      <th>27</th>
      <td>12:45:00</td>
      <td>23.4</td>
      <td>22.6</td>
      <td>23.7</td>
      <td>24.4</td>
      <td>NaN</td>
      <td>23.8</td>
      <td>23.580000</td>
    </tr>
    <tr>
      <th>28</th>
      <td>13:00:00</td>
      <td>23.2</td>
      <td>24.1</td>
      <td>24.0</td>
      <td>23.3</td>
      <td>23.5</td>
      <td>23.1</td>
      <td>23.533333</td>
    </tr>
    <tr>
      <th>29</th>
      <td>13:15:00</td>
      <td>23.1</td>
      <td>22.8</td>
      <td>23.2</td>
      <td>22.5</td>
      <td>23.2</td>
      <td>NaN</td>
      <td>22.960000</td>
    </tr>
    <tr>
      <th>30</th>
      <td>13:30:00</td>
      <td>NaN</td>
      <td>21.9</td>
      <td>22.9</td>
      <td>NaN</td>
      <td>22.9</td>
      <td>23.0</td>
      <td>22.675000</td>
    </tr>
    <tr>
      <th>31</th>
      <td>13:45:00</td>
      <td>NaN</td>
      <td>NaN</td>
      <td>NaN</td>
      <td>22.2</td>
      <td>21.0</td>
      <td>23.0</td>
      <td>22.066667</td>
    </tr>
    <tr>
      <th>32</th>
      <td>14:00:00</td>
      <td>NaN</td>
      <td>23.0</td>
      <td>NaN</td>
      <td>NaN</td>
      <td>NaN</td>
      <td>22.7</td>
      <td>22.850000</td>
    </tr>
    <tr>
      <th>33</th>
      <td>14:15:00</td>
      <td>22.3</td>
      <td>NaN</td>
      <td>21.9</td>
      <td>NaN</td>
      <td>22.5</td>
      <td>NaN</td>
      <td>22.233333</td>
    </tr>
    <tr>
      <th>34</th>
      <td>14:30:00</td>
      <td>22.1</td>
      <td>NaN</td>
      <td>NaN</td>
      <td>22.2</td>
      <td>NaN</td>
      <td>22.1</td>
      <td>22.133333</td>
    </tr>
    <tr>
      <th>35</th>
      <td>14:45:00</td>
      <td>22.0</td>
      <td>NaN</td>
      <td>21.5</td>
      <td>NaN</td>
      <td>20.2</td>
      <td>21.3</td>
      <td>21.250000</td>
    </tr>
    <tr>
      <th>36</th>
      <td>15:00:00</td>
      <td>21.8</td>
      <td>22.9</td>
      <td>22.2</td>
      <td>NaN</td>
      <td>21.0</td>
      <td>NaN</td>
      <td>21.975000</td>
    </tr>
    <tr>
      <th>37</th>
      <td>15:15:00</td>
      <td>21.6</td>
      <td>21.3</td>
      <td>21.7</td>
      <td>NaN</td>
      <td>21.9</td>
      <td>21.1</td>
      <td>21.520000</td>
    </tr>
    <tr>
      <th>38</th>
      <td>15:30:00</td>
      <td>21.4</td>
      <td>21.3</td>
      <td>NaN</td>
      <td>21.9</td>
      <td>21.0</td>
      <td>21.7</td>
      <td>21.460000</td>
    </tr>
    <tr>
      <th>39</th>
      <td>15:45:00</td>
      <td>21.3</td>
      <td>21.6</td>
      <td>21.6</td>
      <td>22.6</td>
      <td>NaN</td>
      <td>21.0</td>
      <td>21.620000</td>
    </tr>
    <tr>
      <th>40</th>
      <td>16:00:00</td>
      <td>21.1</td>
      <td>21.6</td>
      <td>20.7</td>
      <td>20.6</td>
      <td>NaN</td>
      <td>21.4</td>
      <td>21.080000</td>
    </tr>
    <tr>
      <th>41</th>
      <td>16:15:00</td>
      <td>NaN</td>
      <td>20.6</td>
      <td>20.8</td>
      <td>20.5</td>
      <td>20.3</td>
      <td>21.6</td>
      <td>20.760000</td>
    </tr>
    <tr>
      <th>42</th>
      <td>16:30:00</td>
      <td>20.8</td>
      <td>20.7</td>
      <td>20.7</td>
      <td>20.4</td>
      <td>20.2</td>
      <td>19.6</td>
      <td>20.400000</td>
    </tr>
    <tr>
      <th>43</th>
      <td>16:45:00</td>
      <td>20.6</td>
      <td>21.4</td>
      <td>20.3</td>
      <td>21.4</td>
      <td>19.1</td>
      <td>21.2</td>
      <td>20.666667</td>
    </tr>
    <tr>
      <th>44</th>
      <td>17:00:00</td>
      <td>NaN</td>
      <td>19.5</td>
      <td>20.3</td>
      <td>NaN</td>
      <td>19.9</td>
      <td>19.2</td>
      <td>19.725000</td>
    </tr>
    <tr>
      <th>45</th>
      <td>17:15:00</td>
      <td>20.3</td>
      <td>20.7</td>
      <td>19.6</td>
      <td>21.3</td>
      <td>19.8</td>
      <td>NaN</td>
      <td>20.340000</td>
    </tr>
    <tr>
      <th>46</th>
      <td>17:30:00</td>
      <td>20.1</td>
      <td>20.5</td>
      <td>19.7</td>
      <td>19.7</td>
      <td>18.7</td>
      <td>19.7</td>
      <td>19.733333</td>
    </tr>
    <tr>
      <th>47</th>
      <td>17:45:00</td>
      <td>19.9</td>
      <td>20.4</td>
      <td>NaN</td>
      <td>NaN</td>
      <td>20.0</td>
      <td>20.5</td>
      <td>20.200000</td>
    </tr>
    <tr>
      <th>48</th>
      <td>18:00:00</td>
      <td>19.8</td>
      <td>20.0</td>
      <td>19.1</td>
      <td>19.7</td>
      <td>20.1</td>
      <td>20.2</td>
      <td>19.816667</td>
    </tr>
    <tr>
      <th>49</th>
      <td>18:15:00</td>
      <td>19.6</td>
      <td>19.9</td>
      <td>NaN</td>
      <td>19.9</td>
      <td>20.0</td>
      <td>18.6</td>
      <td>19.600000</td>
    </tr>
    <tr>
      <th>50</th>
      <td>18:30:00</td>
      <td>19.5</td>
      <td>19.1</td>
      <td>19.2</td>
      <td>NaN</td>
      <td>18.3</td>
      <td>18.3</td>
      <td>18.880000</td>
    </tr>
    <tr>
      <th>51</th>
      <td>18:45:00</td>
      <td>19.3</td>
      <td>18.7</td>
      <td>20.3</td>
      <td>19.0</td>
      <td>18.8</td>
      <td>NaN</td>
      <td>19.220000</td>
    </tr>
    <tr>
      <th>52</th>
      <td>19:00:00</td>
      <td>19.2</td>
      <td>18.7</td>
      <td>20.1</td>
      <td>19.9</td>
      <td>18.3</td>
      <td>19.3</td>
      <td>19.250000</td>
    </tr>
    <tr>
      <th>53</th>
      <td>19:15:00</td>
      <td>19.0</td>
      <td>19.7</td>
      <td>18.9</td>
      <td>19.2</td>
      <td>18.5</td>
      <td>NaN</td>
      <td>19.060000</td>
    </tr>
  </tbody>
</table>
</div>


