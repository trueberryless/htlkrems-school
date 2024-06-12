# Übung 12 - Pandas Recap 3

Arbeiten Sie nachfolgenden Aufgabenstellungen durch und dokumentieren Sie, wenn notwendig, ihre Erkenntnisse. 


```python
# Importieren Sie pandas
import pandas as pd
```

## Task 12.1

Erstellen Sie a) das DataFrame `person_df` mit folgendem Inhalt:

<table>
    <tr><th></th><th>Gewicht</th><th>Größe</th></tr>
     <tr><td>Henry</td><td>75</td><td>179</td></tr>
    <tr><td>Sarah</td><td>68</td><td>165</td></tr>
    <tr><td>Elke</td><td>68</td><td>172</td></tr>
    <tr><td>Susi</td><td>55</td><td>164</td></tr>
    <tr><td>Vera</td><td>58</td><td>160</td></tr>
    <tr><td>Toni</td><td>99</td><td>189</td></tr>
    <tr><td>Maria</td><td>68</td><td>176</td></tr>
    <tr><td>Chris</td><td>60</td><td>175</td></tr>    
</table>



```python
#a)
persons = {
    "weight": [75, 68, 68, 55, 58, 99, 68, 60],
    "size": [179, 165, 172, 164, 160, 189, 176, 175]
}

index_names = ['Henry','Sarah','Elke','Susi','Vera','Toni','Maria','Chirs']

person_df = pd.DataFrame(persons, index=index_names)
person_df
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
      <th>weight</th>
      <th>size</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>Henry</th>
      <td>75</td>
      <td>179</td>
    </tr>
    <tr>
      <th>Sarah</th>
      <td>68</td>
      <td>165</td>
    </tr>
    <tr>
      <th>Elke</th>
      <td>68</td>
      <td>172</td>
    </tr>
    <tr>
      <th>Susi</th>
      <td>55</td>
      <td>164</td>
    </tr>
    <tr>
      <th>Vera</th>
      <td>58</td>
      <td>160</td>
    </tr>
    <tr>
      <th>Toni</th>
      <td>99</td>
      <td>189</td>
    </tr>
    <tr>
      <th>Maria</th>
      <td>68</td>
      <td>176</td>
    </tr>
    <tr>
      <th>Chirs</th>
      <td>60</td>
      <td>175</td>
    </tr>
  </tbody>
</table>
</div>



Der sog. *Body Mass Index* [1] berechnet sich durch Körpermasse [kg] / Körpergröß [m]². Berechnen Sie b) den BMI für alle Personen des DataFrames `person_df` und geben Sie ausschließlich jene aus, deren BMI > 20 und < 25 ist. 

**Hinweis**: Erstellen Sie KEINE neue Spalte im DataFrame. Es ist ausschließlich folgendes Ergebnis in der Zelle auszugeben:

```Python
Henry    23.407509 
Sarah    24.977043 
Elke     22.985398  
Susi     20.449137  
Vera     22.656250  
Maria    21.952479
dtype: float64
``` 
[1] https://de.wikipedia.org/wiki/Body-Mass-Index 


```python
# b - klassische Ansatz ohne apply & lambda)

bmi_df = pd.DataFrame(index=person_df.index)
bmi_df['bmi'] = person_df['weight'] / ((person_df['size'] / 100) ** 2)
bmi_df[(bmi_df['bmi'] > 20) & (bmi_df['bmi'] < 25)]
# bmi['bmi'].apply(lambda x: x if (x > 20) & (x < 25) > 20 else False)
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
      <th>bmi</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>Henry</th>
      <td>23.407509</td>
    </tr>
    <tr>
      <th>Sarah</th>
      <td>24.977043</td>
    </tr>
    <tr>
      <th>Elke</th>
      <td>22.985398</td>
    </tr>
    <tr>
      <th>Susi</th>
      <td>20.449137</td>
    </tr>
    <tr>
      <th>Vera</th>
      <td>22.656250</td>
    </tr>
    <tr>
      <th>Maria</th>
      <td>21.952479</td>
    </tr>
  </tbody>
</table>
</div>



Nachdem die Berechnung erfolgreich war, fügen Sie c) die ermittelten Werte (je Person) dem DataFrame `person_df` hinzu. Als Spaltenname ist *BMI* zu wählen.


```python
#c)
person_df['BMI'] = bmi_df['bmi']
person_df
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
      <th>weight</th>
      <th>size</th>
      <th>BMI</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>Henry</th>
      <td>75</td>
      <td>179</td>
      <td>23.407509</td>
    </tr>
    <tr>
      <th>Sarah</th>
      <td>68</td>
      <td>165</td>
      <td>24.977043</td>
    </tr>
    <tr>
      <th>Elke</th>
      <td>68</td>
      <td>172</td>
      <td>22.985398</td>
    </tr>
    <tr>
      <th>Susi</th>
      <td>55</td>
      <td>164</td>
      <td>20.449137</td>
    </tr>
    <tr>
      <th>Vera</th>
      <td>58</td>
      <td>160</td>
      <td>22.656250</td>
    </tr>
    <tr>
      <th>Toni</th>
      <td>99</td>
      <td>189</td>
      <td>27.714790</td>
    </tr>
    <tr>
      <th>Maria</th>
      <td>68</td>
      <td>176</td>
      <td>21.952479</td>
    </tr>
    <tr>
      <th>Chirs</th>
      <td>60</td>
      <td>175</td>
      <td>19.591837</td>
    </tr>
  </tbody>
</table>
</div>



Geben Sie d) das erzeugte DataFrame absteigend sortiert nach dem BMI aus.


```python
#d)
person_df.sort_values('BMI', ascending=False)
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
      <th>weight</th>
      <th>size</th>
      <th>BMI</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>Toni</th>
      <td>99</td>
      <td>189</td>
      <td>27.714790</td>
    </tr>
    <tr>
      <th>Sarah</th>
      <td>68</td>
      <td>165</td>
      <td>24.977043</td>
    </tr>
    <tr>
      <th>Henry</th>
      <td>75</td>
      <td>179</td>
      <td>23.407509</td>
    </tr>
    <tr>
      <th>Elke</th>
      <td>68</td>
      <td>172</td>
      <td>22.985398</td>
    </tr>
    <tr>
      <th>Vera</th>
      <td>58</td>
      <td>160</td>
      <td>22.656250</td>
    </tr>
    <tr>
      <th>Maria</th>
      <td>68</td>
      <td>176</td>
      <td>21.952479</td>
    </tr>
    <tr>
      <th>Susi</th>
      <td>55</td>
      <td>164</td>
      <td>20.449137</td>
    </tr>
    <tr>
      <th>Chirs</th>
      <td>60</td>
      <td>175</td>
      <td>19.591837</td>
    </tr>
  </tbody>
</table>
</div>



## Task 12.2

Laden Sie das bereitgestellte Dataset *parks.csv* und verschaffen Sie sich einen Überblick über dessen Aufbau bzw. Inhalt.


```python
park_df = pd.read_csv('parks.csv', encoding='UTF-8')
park_df.head()
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
      <th>Park Code</th>
      <th>Park Name</th>
      <th>State</th>
      <th>Acres</th>
      <th>Latitude</th>
      <th>Longitude</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>0</th>
      <td>ACAD</td>
      <td>Acadia National Park</td>
      <td>ME</td>
      <td>47390</td>
      <td>44.35</td>
      <td>-68.21</td>
    </tr>
    <tr>
      <th>1</th>
      <td>ARCH</td>
      <td>Arches National Park</td>
      <td>UT</td>
      <td>76519</td>
      <td>38.68</td>
      <td>-109.57</td>
    </tr>
    <tr>
      <th>2</th>
      <td>BADL</td>
      <td>Badlands National Park</td>
      <td>SD</td>
      <td>242756</td>
      <td>43.75</td>
      <td>-102.50</td>
    </tr>
    <tr>
      <th>3</th>
      <td>BIBE</td>
      <td>Big Bend National Park</td>
      <td>TX</td>
      <td>801163</td>
      <td>29.25</td>
      <td>-103.25</td>
    </tr>
    <tr>
      <th>4</th>
      <td>BISC</td>
      <td>Biscayne National Park</td>
      <td>FL</td>
      <td>172924</td>
      <td>25.65</td>
      <td>-80.08</td>
    </tr>
  </tbody>
</table>
</div>



a) Geben Sie den Park mit der ID 9 aus:


```python
#a)
park_df.loc[9]
```




    Park Code                              CAVE
    Park Name    Carlsbad Caverns National Park
    State                                    NM
    Acres                                 46766
    Latitude                              32.17
    Longitude                           -104.44
    Name: 9, dtype: object



b) Geben Sie Parks mit der ID 3, 12 und 24 aus:


```python
#b)
park_df.loc[[3, 12, 24]]
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
      <th>Park Code</th>
      <th>Park Name</th>
      <th>State</th>
      <th>Acres</th>
      <th>Latitude</th>
      <th>Longitude</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>3</th>
      <td>BIBE</td>
      <td>Big Bend National Park</td>
      <td>TX</td>
      <td>801163</td>
      <td>29.25</td>
      <td>-103.25</td>
    </tr>
    <tr>
      <th>12</th>
      <td>CRLA</td>
      <td>Crater Lake National Park</td>
      <td>OR</td>
      <td>183224</td>
      <td>42.94</td>
      <td>-122.10</td>
    </tr>
    <tr>
      <th>24</th>
      <td>GRSM</td>
      <td>Great Smoky Mountains National Park</td>
      <td>TN, NC</td>
      <td>521490</td>
      <td>35.68</td>
      <td>-83.53</td>
    </tr>
  </tbody>
</table>
</div>



c) Wie ist das DataFrame `park_df` zu ändern, dass die Abfrage `park_df.loc['BIBE']` durchläuft und somit folgendes Ergebnis liefert:

```Python
Park Name    Big Bend National Park
State                            TX
Acres                        801163
Latitude                      29.25
Longitude                   -103.25
Name: BIBE, dtype: object
```


```python
#c)
# park_df.index = parks_df['Park Code']
park_df.set_index('Park Code', inplace=True)

park_df.loc['BIBE']
```




    Park Name    Big Bend National Park
    State                            TX
    Acres                        801163
    Latitude                      29.25
    Longitude                   -103.25
    Name: BIBE, dtype: object



d) Geben Sie die ersten drei sowie den 4., 5. und 6 Park aus (zwei separate Anfragen mit `iloc`):


```python
#d)
pd.concat([park_df.iloc[0:3], park_df.iloc[3:6]], keys=['iloc1', 'iloc2'])
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
      <th></th>
      <th>Park Name</th>
      <th>State</th>
      <th>Acres</th>
      <th>Latitude</th>
      <th>Longitude</th>
    </tr>
    <tr>
      <th></th>
      <th>Park Code</th>
      <th></th>
      <th></th>
      <th></th>
      <th></th>
      <th></th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th rowspan="3" valign="top">iloc1</th>
      <th>ACAD</th>
      <td>Acadia National Park</td>
      <td>ME</td>
      <td>47390</td>
      <td>44.35</td>
      <td>-68.21</td>
    </tr>
    <tr>
      <th>ARCH</th>
      <td>Arches National Park</td>
      <td>UT</td>
      <td>76519</td>
      <td>38.68</td>
      <td>-109.57</td>
    </tr>
    <tr>
      <th>BADL</th>
      <td>Badlands National Park</td>
      <td>SD</td>
      <td>242756</td>
      <td>43.75</td>
      <td>-102.50</td>
    </tr>
    <tr>
      <th rowspan="3" valign="top">iloc2</th>
      <th>BIBE</th>
      <td>Big Bend National Park</td>
      <td>TX</td>
      <td>801163</td>
      <td>29.25</td>
      <td>-103.25</td>
    </tr>
    <tr>
      <th>BISC</th>
      <td>Biscayne National Park</td>
      <td>FL</td>
      <td>172924</td>
      <td>25.65</td>
      <td>-80.08</td>
    </tr>
    <tr>
      <th>BLCA</th>
      <td>Black Canyon of the Gunnison National Park</td>
      <td>CO</td>
      <td>32950</td>
      <td>38.57</td>
      <td>-107.72</td>
    </tr>
  </tbody>
</table>
</div>



e) Gesucht ist folgende Ausgabe der Spalte *Park Code*:

```Python
0    ACAD
1    ARCH
2    BADL
Name: Park Code, dtype: object
```


```python
#e)
park_df.reset_index()
# park_df.iloc[:3]['Park Code']
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
      <th>Park Code</th>
      <th>Park Name</th>
      <th>State</th>
      <th>Acres</th>
      <th>Latitude</th>
      <th>Longitude</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>0</th>
      <td>ACAD</td>
      <td>Acadia National Park</td>
      <td>ME</td>
      <td>47390</td>
      <td>44.35</td>
      <td>-68.21</td>
    </tr>
    <tr>
      <th>1</th>
      <td>ARCH</td>
      <td>Arches National Park</td>
      <td>UT</td>
      <td>76519</td>
      <td>38.68</td>
      <td>-109.57</td>
    </tr>
    <tr>
      <th>2</th>
      <td>BADL</td>
      <td>Badlands National Park</td>
      <td>SD</td>
      <td>242756</td>
      <td>43.75</td>
      <td>-102.50</td>
    </tr>
    <tr>
      <th>3</th>
      <td>BIBE</td>
      <td>Big Bend National Park</td>
      <td>TX</td>
      <td>801163</td>
      <td>29.25</td>
      <td>-103.25</td>
    </tr>
    <tr>
      <th>4</th>
      <td>BISC</td>
      <td>Biscayne National Park</td>
      <td>FL</td>
      <td>172924</td>
      <td>25.65</td>
      <td>-80.08</td>
    </tr>
    <tr>
      <th>5</th>
      <td>BLCA</td>
      <td>Black Canyon of the Gunnison National Park</td>
      <td>CO</td>
      <td>32950</td>
      <td>38.57</td>
      <td>-107.72</td>
    </tr>
    <tr>
      <th>6</th>
      <td>BRCA</td>
      <td>Bryce Canyon National Park</td>
      <td>UT</td>
      <td>35835</td>
      <td>37.57</td>
      <td>-112.18</td>
    </tr>
    <tr>
      <th>7</th>
      <td>CANY</td>
      <td>Canyonlands National Park</td>
      <td>UT</td>
      <td>337598</td>
      <td>38.20</td>
      <td>-109.93</td>
    </tr>
    <tr>
      <th>8</th>
      <td>CARE</td>
      <td>Capitol Reef National Park</td>
      <td>UT</td>
      <td>241904</td>
      <td>38.20</td>
      <td>-111.17</td>
    </tr>
    <tr>
      <th>9</th>
      <td>CAVE</td>
      <td>Carlsbad Caverns National Park</td>
      <td>NM</td>
      <td>46766</td>
      <td>32.17</td>
      <td>-104.44</td>
    </tr>
    <tr>
      <th>10</th>
      <td>CHIS</td>
      <td>Channel Islands National Park</td>
      <td>CA</td>
      <td>249561</td>
      <td>34.01</td>
      <td>-119.42</td>
    </tr>
    <tr>
      <th>11</th>
      <td>CONG</td>
      <td>Congaree National Park</td>
      <td>SC</td>
      <td>26546</td>
      <td>33.78</td>
      <td>-80.78</td>
    </tr>
    <tr>
      <th>12</th>
      <td>CRLA</td>
      <td>Crater Lake National Park</td>
      <td>OR</td>
      <td>183224</td>
      <td>42.94</td>
      <td>-122.10</td>
    </tr>
    <tr>
      <th>13</th>
      <td>CUVA</td>
      <td>Cuyahoga Valley National Park</td>
      <td>OH</td>
      <td>32950</td>
      <td>41.24</td>
      <td>-81.55</td>
    </tr>
    <tr>
      <th>14</th>
      <td>DENA</td>
      <td>Denali National Park and Preserve</td>
      <td>AK</td>
      <td>3372402</td>
      <td>63.33</td>
      <td>-150.50</td>
    </tr>
    <tr>
      <th>15</th>
      <td>DEVA</td>
      <td>Death Valley National Park</td>
      <td>CA, NV</td>
      <td>4740912</td>
      <td>36.24</td>
      <td>-116.82</td>
    </tr>
    <tr>
      <th>16</th>
      <td>DRTO</td>
      <td>Dry Tortugas National Park</td>
      <td>FL</td>
      <td>64701</td>
      <td>24.63</td>
      <td>-82.87</td>
    </tr>
    <tr>
      <th>17</th>
      <td>EVER</td>
      <td>Everglades National Park</td>
      <td>FL</td>
      <td>1508538</td>
      <td>25.32</td>
      <td>-80.93</td>
    </tr>
    <tr>
      <th>18</th>
      <td>GAAR</td>
      <td>Gates Of The Arctic National Park and Preserve</td>
      <td>AK</td>
      <td>7523898</td>
      <td>67.78</td>
      <td>-153.30</td>
    </tr>
    <tr>
      <th>19</th>
      <td>GLAC</td>
      <td>Glacier National Park</td>
      <td>MT</td>
      <td>1013572</td>
      <td>48.80</td>
      <td>-114.00</td>
    </tr>
    <tr>
      <th>20</th>
      <td>GLBA</td>
      <td>Glacier Bay National Park and Preserve</td>
      <td>AK</td>
      <td>3224840</td>
      <td>58.50</td>
      <td>-137.00</td>
    </tr>
    <tr>
      <th>21</th>
      <td>GRBA</td>
      <td>Great Basin National Park</td>
      <td>NV</td>
      <td>77180</td>
      <td>38.98</td>
      <td>-114.30</td>
    </tr>
    <tr>
      <th>22</th>
      <td>GRCA</td>
      <td>Grand Canyon National Park</td>
      <td>AZ</td>
      <td>1217403</td>
      <td>36.06</td>
      <td>-112.14</td>
    </tr>
    <tr>
      <th>23</th>
      <td>GRSA</td>
      <td>Great Sand Dunes National Park and Preserve</td>
      <td>CO</td>
      <td>42984</td>
      <td>37.73</td>
      <td>-105.51</td>
    </tr>
    <tr>
      <th>24</th>
      <td>GRSM</td>
      <td>Great Smoky Mountains National Park</td>
      <td>TN, NC</td>
      <td>521490</td>
      <td>35.68</td>
      <td>-83.53</td>
    </tr>
    <tr>
      <th>25</th>
      <td>GRTE</td>
      <td>Grand Teton National Park</td>
      <td>WY</td>
      <td>309995</td>
      <td>43.73</td>
      <td>-110.80</td>
    </tr>
    <tr>
      <th>26</th>
      <td>GUMO</td>
      <td>Guadalupe Mountains National Park</td>
      <td>TX</td>
      <td>86416</td>
      <td>31.92</td>
      <td>-104.87</td>
    </tr>
    <tr>
      <th>27</th>
      <td>HALE</td>
      <td>Haleakala National Park</td>
      <td>HI</td>
      <td>29094</td>
      <td>20.72</td>
      <td>-156.17</td>
    </tr>
    <tr>
      <th>28</th>
      <td>HAVO</td>
      <td>Hawaii Volcanoes National Park</td>
      <td>HI</td>
      <td>323431</td>
      <td>19.38</td>
      <td>-155.20</td>
    </tr>
    <tr>
      <th>29</th>
      <td>HOSP</td>
      <td>Hot Springs National Park</td>
      <td>AR</td>
      <td>5550</td>
      <td>34.51</td>
      <td>-93.05</td>
    </tr>
    <tr>
      <th>30</th>
      <td>ISRO</td>
      <td>Isle Royale National Park</td>
      <td>MI</td>
      <td>571790</td>
      <td>48.10</td>
      <td>-88.55</td>
    </tr>
    <tr>
      <th>31</th>
      <td>JOTR</td>
      <td>Joshua Tree National Park</td>
      <td>CA</td>
      <td>789745</td>
      <td>33.79</td>
      <td>-115.90</td>
    </tr>
    <tr>
      <th>32</th>
      <td>KATM</td>
      <td>Katmai National Park and Preserve</td>
      <td>AK</td>
      <td>3674530</td>
      <td>58.50</td>
      <td>-155.00</td>
    </tr>
    <tr>
      <th>33</th>
      <td>KEFJ</td>
      <td>Kenai Fjords National Park</td>
      <td>AK</td>
      <td>669983</td>
      <td>59.92</td>
      <td>-149.65</td>
    </tr>
    <tr>
      <th>34</th>
      <td>KOVA</td>
      <td>Kobuk Valley National Park</td>
      <td>AK</td>
      <td>1750717</td>
      <td>67.55</td>
      <td>-159.28</td>
    </tr>
    <tr>
      <th>35</th>
      <td>LACL</td>
      <td>Lake Clark National Park and Preserve</td>
      <td>AK</td>
      <td>2619733</td>
      <td>60.97</td>
      <td>-153.42</td>
    </tr>
    <tr>
      <th>36</th>
      <td>LAVO</td>
      <td>Lassen Volcanic National Park</td>
      <td>CA</td>
      <td>106372</td>
      <td>40.49</td>
      <td>-121.51</td>
    </tr>
    <tr>
      <th>37</th>
      <td>MACA</td>
      <td>Mammoth Cave National Park</td>
      <td>KY</td>
      <td>52830</td>
      <td>37.18</td>
      <td>-86.10</td>
    </tr>
    <tr>
      <th>38</th>
      <td>MEVE</td>
      <td>Mesa Verde National Park</td>
      <td>CO</td>
      <td>52122</td>
      <td>37.18</td>
      <td>-108.49</td>
    </tr>
    <tr>
      <th>39</th>
      <td>MORA</td>
      <td>Mount Rainier National Park</td>
      <td>WA</td>
      <td>235625</td>
      <td>46.85</td>
      <td>-121.75</td>
    </tr>
    <tr>
      <th>40</th>
      <td>NOCA</td>
      <td>North Cascades National Park</td>
      <td>WA</td>
      <td>504781</td>
      <td>48.70</td>
      <td>-121.20</td>
    </tr>
    <tr>
      <th>41</th>
      <td>OLYM</td>
      <td>Olympic National Park</td>
      <td>WA</td>
      <td>922651</td>
      <td>47.97</td>
      <td>-123.50</td>
    </tr>
    <tr>
      <th>42</th>
      <td>PEFO</td>
      <td>Petrified Forest National Park</td>
      <td>AZ</td>
      <td>93533</td>
      <td>35.07</td>
      <td>-109.78</td>
    </tr>
    <tr>
      <th>43</th>
      <td>PINN</td>
      <td>Pinnacles National Park</td>
      <td>CA</td>
      <td>26606</td>
      <td>36.48</td>
      <td>-121.16</td>
    </tr>
    <tr>
      <th>44</th>
      <td>REDW</td>
      <td>Redwood National Park</td>
      <td>CA</td>
      <td>112512</td>
      <td>41.30</td>
      <td>-124.00</td>
    </tr>
    <tr>
      <th>45</th>
      <td>ROMO</td>
      <td>Rocky Mountain National Park</td>
      <td>CO</td>
      <td>265828</td>
      <td>40.40</td>
      <td>-105.58</td>
    </tr>
    <tr>
      <th>46</th>
      <td>SAGU</td>
      <td>Saguaro National Park</td>
      <td>AZ</td>
      <td>91440</td>
      <td>32.25</td>
      <td>-110.50</td>
    </tr>
    <tr>
      <th>47</th>
      <td>SEKI</td>
      <td>Sequoia and Kings Canyon National Parks</td>
      <td>CA</td>
      <td>865952</td>
      <td>36.43</td>
      <td>-118.68</td>
    </tr>
    <tr>
      <th>48</th>
      <td>SHEN</td>
      <td>Shenandoah National Park</td>
      <td>VA</td>
      <td>199045</td>
      <td>38.53</td>
      <td>-78.35</td>
    </tr>
    <tr>
      <th>49</th>
      <td>THRO</td>
      <td>Theodore Roosevelt National Park</td>
      <td>ND</td>
      <td>70447</td>
      <td>46.97</td>
      <td>-103.45</td>
    </tr>
    <tr>
      <th>50</th>
      <td>VOYA</td>
      <td>Voyageurs National Park</td>
      <td>MN</td>
      <td>218200</td>
      <td>48.50</td>
      <td>-92.88</td>
    </tr>
    <tr>
      <th>51</th>
      <td>WICA</td>
      <td>Wind Cave National Park</td>
      <td>SD</td>
      <td>28295</td>
      <td>43.57</td>
      <td>-103.48</td>
    </tr>
    <tr>
      <th>52</th>
      <td>WRST</td>
      <td>Wrangell - St Elias National Park and Preserve</td>
      <td>AK</td>
      <td>8323148</td>
      <td>61.00</td>
      <td>-142.00</td>
    </tr>
    <tr>
      <th>53</th>
      <td>YELL</td>
      <td>Yellowstone National Park</td>
      <td>WY, MT, ID</td>
      <td>2219791</td>
      <td>44.60</td>
      <td>-110.50</td>
    </tr>
    <tr>
      <th>54</th>
      <td>YOSE</td>
      <td>Yosemite National Park</td>
      <td>CA</td>
      <td>761266</td>
      <td>37.83</td>
      <td>-119.50</td>
    </tr>
    <tr>
      <th>55</th>
      <td>ZION</td>
      <td>Zion National Park</td>
      <td>UT</td>
      <td>146598</td>
      <td>37.30</td>
      <td>-113.05</td>
    </tr>
  </tbody>
</table>
</div>



Spaltennamen mit Leerzeichen (und Großbuchstaben) sind eine potenzielle Fehlerquelle, die es zu eliminieren gilt. Ändern Sie f) die Spaltennamen durch den Einsatz von `replace(...)` und `lower(...)` in einer *List Comprehension*. **Wichtig**: Die Liste mit den neuen Spaltennamen ist in der *List Comprehension* zu erstellen. Warum wir eine Liste benötigen, ist durch das Property *columns* von *DataFrame* definiert. `new_column_names` gestaltet sich nach Abarbeitung der *List Comprehension* wie folgt:

```Python
['parkcode', 'parkname', 'state', 'acres', 'latitude', 'longitude']
```


```python
#f) Neue Spaltennamen
park_df.columns = [column.lower().replace(" ", "") for column in park_df]
park_df.head()
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
      <th>parkname</th>
      <th>state</th>
      <th>acres</th>
      <th>latitude</th>
      <th>longitude</th>
    </tr>
    <tr>
      <th>Park Code</th>
      <th></th>
      <th></th>
      <th></th>
      <th></th>
      <th></th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>ACAD</th>
      <td>Acadia National Park</td>
      <td>ME</td>
      <td>47390</td>
      <td>44.35</td>
      <td>-68.21</td>
    </tr>
    <tr>
      <th>ARCH</th>
      <td>Arches National Park</td>
      <td>UT</td>
      <td>76519</td>
      <td>38.68</td>
      <td>-109.57</td>
    </tr>
    <tr>
      <th>BADL</th>
      <td>Badlands National Park</td>
      <td>SD</td>
      <td>242756</td>
      <td>43.75</td>
      <td>-102.50</td>
    </tr>
    <tr>
      <th>BIBE</th>
      <td>Big Bend National Park</td>
      <td>TX</td>
      <td>801163</td>
      <td>29.25</td>
      <td>-103.25</td>
    </tr>
    <tr>
      <th>BISC</th>
      <td>Biscayne National Park</td>
      <td>FL</td>
      <td>172924</td>
      <td>25.65</td>
      <td>-80.08</td>
    </tr>
  </tbody>
</table>
</div>



Selektieren Sie g) den Parknamen und den Bundestaat der ersten 3 Zeilen im *DataFrame*.


```python
#g)
park_df.iloc[:3][['parkname', 'state']]
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
      <th>parkname</th>
      <th>state</th>
    </tr>
    <tr>
      <th>Park Code</th>
      <th></th>
      <th></th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>ACAD</th>
      <td>Acadia National Park</td>
      <td>ME</td>
    </tr>
    <tr>
      <th>ARCH</th>
      <td>Arches National Park</td>
      <td>UT</td>
    </tr>
    <tr>
      <th>BADL</th>
      <td>Badlands National Park</td>
      <td>SD</td>
    </tr>
  </tbody>
</table>
</div>



h) Worin unterscheiden sich diese beiden Abfragen und was wäre eine logische Erklärung dafür?
- `park_df.iloc[2]`
- `park_df.iloc[[2]]`


```python
# h)
# Erstere Abfrage return eine Series, weil nur eine Spalte angegeben werden kann.
# Zweitere Abfrage return ein DataFrame, weil mehrere Spalten angegeben werden können.
```


```python
# das ist eine Series:
print(type(park_df.iloc[2]))
print(park_df.iloc[2])
```

    <class 'pandas.core.series.Series'>
    parkname     Badlands National Park
    state                            SD
    acres                        242756
    latitude                      43.75
    longitude                    -102.5
    Name: BADL, dtype: object
    


```python
# das ist ein DataFrame:
print(type(park_df.iloc[[2]]))
print(park_df.iloc[[2]])
```

    <class 'pandas.core.frame.DataFrame'>
                             parkname state   acres  latitude  longitude
    Park Code                                                           
    BADL       Badlands National Park    SD  242756     43.75     -102.5
    

i) Welche Parks befinden sich im Bundesstaat Utah (UT)?


```python
#i)
park_df[park_df['state'] == 'UT']

#import numpy as np
#park_df.iloc[np.where(park_df['state'] == 'UT')]
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
      <th>parkname</th>
      <th>state</th>
      <th>acres</th>
      <th>latitude</th>
      <th>longitude</th>
    </tr>
    <tr>
      <th>Park Code</th>
      <th></th>
      <th></th>
      <th></th>
      <th></th>
      <th></th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>ARCH</th>
      <td>Arches National Park</td>
      <td>UT</td>
      <td>76519</td>
      <td>38.68</td>
      <td>-109.57</td>
    </tr>
    <tr>
      <th>BRCA</th>
      <td>Bryce Canyon National Park</td>
      <td>UT</td>
      <td>35835</td>
      <td>37.57</td>
      <td>-112.18</td>
    </tr>
    <tr>
      <th>CANY</th>
      <td>Canyonlands National Park</td>
      <td>UT</td>
      <td>337598</td>
      <td>38.20</td>
      <td>-109.93</td>
    </tr>
    <tr>
      <th>CARE</th>
      <td>Capitol Reef National Park</td>
      <td>UT</td>
      <td>241904</td>
      <td>38.20</td>
      <td>-111.17</td>
    </tr>
    <tr>
      <th>ZION</th>
      <td>Zion National Park</td>
      <td>UT</td>
      <td>146598</td>
      <td>37.30</td>
      <td>-113.05</td>
    </tr>
  </tbody>
</table>
</div>



j) Welche Parks erfüllen folgende Bedingung? 
- latitude > 60 oder acres > 1000000


```python
#j)
park_df[(park_df['latitude'] > 60) | (park_df['acres'] > 1000000)]
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
      <th>parkname</th>
      <th>state</th>
      <th>acres</th>
      <th>latitude</th>
      <th>longitude</th>
    </tr>
    <tr>
      <th>Park Code</th>
      <th></th>
      <th></th>
      <th></th>
      <th></th>
      <th></th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>DENA</th>
      <td>Denali National Park and Preserve</td>
      <td>AK</td>
      <td>3372402</td>
      <td>63.33</td>
      <td>-150.50</td>
    </tr>
    <tr>
      <th>DEVA</th>
      <td>Death Valley National Park</td>
      <td>CA, NV</td>
      <td>4740912</td>
      <td>36.24</td>
      <td>-116.82</td>
    </tr>
    <tr>
      <th>EVER</th>
      <td>Everglades National Park</td>
      <td>FL</td>
      <td>1508538</td>
      <td>25.32</td>
      <td>-80.93</td>
    </tr>
    <tr>
      <th>GAAR</th>
      <td>Gates Of The Arctic National Park and Preserve</td>
      <td>AK</td>
      <td>7523898</td>
      <td>67.78</td>
      <td>-153.30</td>
    </tr>
    <tr>
      <th>GLAC</th>
      <td>Glacier National Park</td>
      <td>MT</td>
      <td>1013572</td>
      <td>48.80</td>
      <td>-114.00</td>
    </tr>
    <tr>
      <th>GLBA</th>
      <td>Glacier Bay National Park and Preserve</td>
      <td>AK</td>
      <td>3224840</td>
      <td>58.50</td>
      <td>-137.00</td>
    </tr>
    <tr>
      <th>GRCA</th>
      <td>Grand Canyon National Park</td>
      <td>AZ</td>
      <td>1217403</td>
      <td>36.06</td>
      <td>-112.14</td>
    </tr>
    <tr>
      <th>KATM</th>
      <td>Katmai National Park and Preserve</td>
      <td>AK</td>
      <td>3674530</td>
      <td>58.50</td>
      <td>-155.00</td>
    </tr>
    <tr>
      <th>KOVA</th>
      <td>Kobuk Valley National Park</td>
      <td>AK</td>
      <td>1750717</td>
      <td>67.55</td>
      <td>-159.28</td>
    </tr>
    <tr>
      <th>LACL</th>
      <td>Lake Clark National Park and Preserve</td>
      <td>AK</td>
      <td>2619733</td>
      <td>60.97</td>
      <td>-153.42</td>
    </tr>
    <tr>
      <th>WRST</th>
      <td>Wrangell - St Elias National Park and Preserve</td>
      <td>AK</td>
      <td>8323148</td>
      <td>61.00</td>
      <td>-142.00</td>
    </tr>
    <tr>
      <th>YELL</th>
      <td>Yellowstone National Park</td>
      <td>WY, MT, ID</td>
      <td>2219791</td>
      <td>44.60</td>
      <td>-110.50</td>
    </tr>
  </tbody>
</table>
</div>



k) Finden Sie alle Parks, die sich in den Bundesstaaten *WA*, *OR* und *CA* befinden. Verwenden Sie hierzu `isin()` (https://pandas.pydata.org/pandas-docs/stable/reference/api/pandas.DataFrame.isin.html?highlight=isin#pandas.DataFrame.isin) 


```python
#k)
park_df[park_df['state'].isin(['WA', 'OR', 'CA'])]
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
      <th>parkname</th>
      <th>state</th>
      <th>acres</th>
      <th>latitude</th>
      <th>longitude</th>
    </tr>
    <tr>
      <th>Park Code</th>
      <th></th>
      <th></th>
      <th></th>
      <th></th>
      <th></th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>CHIS</th>
      <td>Channel Islands National Park</td>
      <td>CA</td>
      <td>249561</td>
      <td>34.01</td>
      <td>-119.42</td>
    </tr>
    <tr>
      <th>CRLA</th>
      <td>Crater Lake National Park</td>
      <td>OR</td>
      <td>183224</td>
      <td>42.94</td>
      <td>-122.10</td>
    </tr>
    <tr>
      <th>JOTR</th>
      <td>Joshua Tree National Park</td>
      <td>CA</td>
      <td>789745</td>
      <td>33.79</td>
      <td>-115.90</td>
    </tr>
    <tr>
      <th>LAVO</th>
      <td>Lassen Volcanic National Park</td>
      <td>CA</td>
      <td>106372</td>
      <td>40.49</td>
      <td>-121.51</td>
    </tr>
    <tr>
      <th>MORA</th>
      <td>Mount Rainier National Park</td>
      <td>WA</td>
      <td>235625</td>
      <td>46.85</td>
      <td>-121.75</td>
    </tr>
    <tr>
      <th>NOCA</th>
      <td>North Cascades National Park</td>
      <td>WA</td>
      <td>504781</td>
      <td>48.70</td>
      <td>-121.20</td>
    </tr>
    <tr>
      <th>OLYM</th>
      <td>Olympic National Park</td>
      <td>WA</td>
      <td>922651</td>
      <td>47.97</td>
      <td>-123.50</td>
    </tr>
    <tr>
      <th>PINN</th>
      <td>Pinnacles National Park</td>
      <td>CA</td>
      <td>26606</td>
      <td>36.48</td>
      <td>-121.16</td>
    </tr>
    <tr>
      <th>REDW</th>
      <td>Redwood National Park</td>
      <td>CA</td>
      <td>112512</td>
      <td>41.30</td>
      <td>-124.00</td>
    </tr>
    <tr>
      <th>SEKI</th>
      <td>Sequoia and Kings Canyon National Parks</td>
      <td>CA</td>
      <td>865952</td>
      <td>36.43</td>
      <td>-118.68</td>
    </tr>
    <tr>
      <th>YOSE</th>
      <td>Yosemite National Park</td>
      <td>CA</td>
      <td>761266</td>
      <td>37.83</td>
      <td>-119.50</td>
    </tr>
  </tbody>
</table>
</div>


