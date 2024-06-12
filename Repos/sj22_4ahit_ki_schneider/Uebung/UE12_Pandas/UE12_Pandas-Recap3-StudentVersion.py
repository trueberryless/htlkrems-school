#!/usr/bin/env python
# coding: utf-8

# # Übung 12 - Pandas Recap 3
# 
# Arbeiten Sie nachfolgenden Aufgabenstellungen durch und dokumentieren Sie, wenn notwendig, ihre Erkenntnisse. 

# In[1]:


# Importieren Sie pandas
import pandas as pd


# ## Task 12.1
# 
# Erstellen Sie a) das DataFrame `person_df` mit folgendem Inhalt:
# 
# <table>
#     <tr><th></th><th>Gewicht</th><th>Größe</th></tr>
#      <tr><td>Henry</td><td>75</td><td>179</td></tr>
#     <tr><td>Sarah</td><td>68</td><td>165</td></tr>
#     <tr><td>Elke</td><td>68</td><td>172</td></tr>
#     <tr><td>Susi</td><td>55</td><td>164</td></tr>
#     <tr><td>Vera</td><td>58</td><td>160</td></tr>
#     <tr><td>Toni</td><td>99</td><td>189</td></tr>
#     <tr><td>Maria</td><td>68</td><td>176</td></tr>
#     <tr><td>Chris</td><td>60</td><td>175</td></tr>    
# </table>
# 

# In[2]:


#a)
persons = {
    "weight": [75, 68, 68, 55, 58, 99, 68, 60],
    "size": [179, 165, 172, 164, 160, 189, 176, 175]
}

index_names = ['Henry','Sarah','Elke','Susi','Vera','Toni','Maria','Chirs']

person_df = pd.DataFrame(persons, index=index_names)
person_df


# Der sog. *Body Mass Index* [1] berechnet sich durch Körpermasse [kg] / Körpergröß [m]². Berechnen Sie b) den BMI für alle Personen des DataFrames `person_df` und geben Sie ausschließlich jene aus, deren BMI > 20 und < 25 ist. 
# 
# **Hinweis**: Erstellen Sie KEINE neue Spalte im DataFrame. Es ist ausschließlich folgendes Ergebnis in der Zelle auszugeben:
# 
# ```Python
# Henry    23.407509 
# Sarah    24.977043 
# Elke     22.985398  
# Susi     20.449137  
# Vera     22.656250  
# Maria    21.952479
# dtype: float64
# ``` 
# [1] https://de.wikipedia.org/wiki/Body-Mass-Index 

# In[3]:


# b - klassische Ansatz ohne apply & lambda)

bmi_df = pd.DataFrame(index=person_df.index)
bmi_df['bmi'] = person_df['weight'] / ((person_df['size'] / 100) ** 2)
bmi_df[(bmi_df['bmi'] > 20) & (bmi_df['bmi'] < 25)]
# bmi['bmi'].apply(lambda x: x if (x > 20) & (x < 25) > 20 else False)


# Nachdem die Berechnung erfolgreich war, fügen Sie c) die ermittelten Werte (je Person) dem DataFrame `person_df` hinzu. Als Spaltenname ist *BMI* zu wählen.

# In[4]:


#c)
person_df['BMI'] = bmi_df['bmi']
person_df


# Geben Sie d) das erzeugte DataFrame absteigend sortiert nach dem BMI aus.

# In[5]:


#d)
person_df.sort_values('BMI', ascending=False)


# ## Task 12.2
# 
# Laden Sie das bereitgestellte Dataset *parks.csv* und verschaffen Sie sich einen Überblick über dessen Aufbau bzw. Inhalt.

# In[6]:


park_df = pd.read_csv('parks.csv', encoding='UTF-8')
park_df.head()


# a) Geben Sie den Park mit der ID 9 aus:

# In[7]:


#a)
park_df.loc[9]


# b) Geben Sie Parks mit der ID 3, 12 und 24 aus:

# In[8]:


#b)
park_df.loc[[3, 12, 24]]


# c) Wie ist das DataFrame `park_df` zu ändern, dass die Abfrage `park_df.loc['BIBE']` durchläuft und somit folgendes Ergebnis liefert:
# 
# ```Python
# Park Name    Big Bend National Park
# State                            TX
# Acres                        801163
# Latitude                      29.25
# Longitude                   -103.25
# Name: BIBE, dtype: object
# ```

# In[9]:


#c)
# park_df.index = parks_df['Park Code']
park_df.set_index('Park Code', inplace=True)

park_df.loc['BIBE']


# d) Geben Sie die ersten drei sowie den 4., 5. und 6 Park aus (zwei separate Anfragen mit `iloc`):

# In[10]:


#d)
pd.concat([park_df.iloc[0:3], park_df.iloc[3:6]], keys=['iloc1', 'iloc2'])


# e) Gesucht ist folgende Ausgabe der Spalte *Park Code*:
# 
# ```Python
# 0    ACAD
# 1    ARCH
# 2    BADL
# Name: Park Code, dtype: object
# ```

# In[11]:


#e)
park_df.reset_index()
# park_df.iloc[:3]['Park Code']


# Spaltennamen mit Leerzeichen (und Großbuchstaben) sind eine potenzielle Fehlerquelle, die es zu eliminieren gilt. Ändern Sie f) die Spaltennamen durch den Einsatz von `replace(...)` und `lower(...)` in einer *List Comprehension*. **Wichtig**: Die Liste mit den neuen Spaltennamen ist in der *List Comprehension* zu erstellen. Warum wir eine Liste benötigen, ist durch das Property *columns* von *DataFrame* definiert. `new_column_names` gestaltet sich nach Abarbeitung der *List Comprehension* wie folgt:
# 
# ```Python
# ['parkcode', 'parkname', 'state', 'acres', 'latitude', 'longitude']
# ```

# In[12]:


#f) Neue Spaltennamen
park_df.columns = [column.lower().replace(" ", "") for column in park_df]
park_df.head()


# Selektieren Sie g) den Parknamen und den Bundestaat der ersten 3 Zeilen im *DataFrame*.

# In[13]:


#g)
park_df.iloc[:3][['parkname', 'state']]


# h) Worin unterscheiden sich diese beiden Abfragen und was wäre eine logische Erklärung dafür?
# - `park_df.iloc[2]`
# - `park_df.iloc[[2]]`

# In[14]:


# h)
# Erstere Abfrage return eine Series, weil nur eine Spalte angegeben werden kann.
# Zweitere Abfrage return ein DataFrame, weil mehrere Spalten angegeben werden können.


# In[15]:


# das ist eine Series:
print(type(park_df.iloc[2]))
print(park_df.iloc[2])


# In[16]:


# das ist ein DataFrame:
print(type(park_df.iloc[[2]]))
print(park_df.iloc[[2]])


# i) Welche Parks befinden sich im Bundesstaat Utah (UT)?

# In[22]:


#i)
park_df[park_df['state'] == 'UT']

#import numpy as np
#park_df.iloc[np.where(park_df['state'] == 'UT')]


# j) Welche Parks erfüllen folgende Bedingung? 
# - latitude > 60 oder acres > 1000000

# In[18]:


#j)
park_df[(park_df['latitude'] > 60) | (park_df['acres'] > 1000000)]


# k) Finden Sie alle Parks, die sich in den Bundesstaaten *WA*, *OR* und *CA* befinden. Verwenden Sie hierzu `isin()` (https://pandas.pydata.org/pandas-docs/stable/reference/api/pandas.DataFrame.isin.html?highlight=isin#pandas.DataFrame.isin) 

# In[19]:


#k)
park_df[park_df['state'].isin(['WA', 'OR', 'CA'])]

