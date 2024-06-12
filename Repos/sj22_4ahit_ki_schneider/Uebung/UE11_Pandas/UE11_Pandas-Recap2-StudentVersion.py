#!/usr/bin/env python
# coding: utf-8

# # Übung 11 - Pandas Recap 2
# Arbeiten Sie nachfolgenden Aufgabenstellungen durch und dokumentieren Sie, wenn notwendig, ihre Erkenntnisse. 

# In[1]:


import pandas as pd


# ## Task 11.1
# Erstellen Sie basierend auf den 3 Listen `name`, `population` und `country` das *Dictionary* `cities`. Verwenden Sie die List-Bezeichner als *Keys*. Im nächsten Schritt gilt es mit dem *Dictionary* das *DataFrame* `city_df` zu erstellen. Gesuchte Ausgabe:
# 
# ```Python
#       name 	population   country
# 0 	London 	8615246 	England
# 1 	Berlin 	3562166 	Germany
# 2 	Madrid 	3165235 	Spain
# 3 	Rome 	2874038 	Italy
# 4 	Paris 	2273305 	France
# 5 	Vienna 	1805681 	Austria
# ...
# ```

# In[2]:


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


# ## Task 11.2
# Die Reihenfolge der Spalten kann bei der Erstellung des *DataFrames* festgelegt werden. Dazu dient das Schlüsselwort `columns` beim Instanziieren eines *DataFrames*. Ändern Sie diese, dass folgende Spaltenreihenfolge gegeben ist: *name* - *country* - *population*. Verwenden Sie hierzu die Liste `new_order`. Erstellen Sie mit `city_df` ein neues *DataFrame*.

# In[3]:


new_order = ["name", "country", "population"]

# Your code...
city_df = pd.DataFrame(city_df, columns=new_order)
city_df


# # Task 11.3
# Man kann den Index entweder beim Erstellen eines *DataFrames* explizit definieren oder mit `set_index()` im Nachhinein ändern. Definieren Sie die Spalte *country* als neuen Index bei `city_df`. Wichtig: `set_index()` liefert ein neues DF-Objekt, was wir aber nicht möchten. Die Änderung soll in `city_df` direkt erfolgen!
# 
# Quelle: https://pandas.pydata.org/pandas-docs/stable/reference/api/pandas.DataFrame.set_index.html?highlight=set_index#pandas-dataframe-set-index

# In[4]:


# Your code...
city_df.set_index('country', inplace=True)
city_df


# ## Task 11.4
# Gesucht sind a) alle Städte Deutschlands und b) alle Städt Deutschlands und Frankreichs. Zur Erinnerung: Die Spalte *country* bildet den Index.
# 
# > **Remember**: `loc`und `iloc` durchsuchen ein *DataFrame* anhand des Index; es sind ausschließlich Werte der Index-Spalte zulässigt. Ignoriert man das, erhält man einen *Key Error*. Also bevor man loslegt, sollte man kurz innehalten und überlegen, was kann ich wie suchen und - hoffentlich - finden!
# 
# Den Index eines DataFrames kann man mit dem Property `index` ausgeben.

# In[5]:


city_df.index


# In[6]:


# Your code...
city_df.loc['Germany']


# In[7]:


city_df.loc[['Germany', 'France']]


# ## Task 11.5
# Gesucht sind alle jene Städte, deren *Population* > 2Mio. ist. 

# In[8]:


# Your code...
city_df[city_df['population'] > 2e6]


# ## Task 11.6
# Aufgabenstellung 11.5 kann man auf mehrere Arten lösen. Legen Sie dar, warum die `loc`-Varianten funktioniert - vor allem unter den in 10.5 diskutierten Gesichtspunkten?

# In[23]:


# Your code...
city_df.loc[city_df['population'] > 2e6]


# 
# Das funktioniert, weil die Überprüfung (innerhalb der [geschwungenen Klammern]) einen boolschen Wert (True - False) zurückliefert. Es wird dann immer nur eine Zeile selektiert, wenn True ist...

# ## Task 11.7
# Berechnen Sie die Gesamtsummer aller Städte.

# In[10]:


# Your code...
city_df['population'].sum()


# ## Task 11.8
# Fügen Sie dem *DataFrame* `city_df` die Spalte *area* mit den Werten der Liste `area` (Fläche in qkm) hinzu. Gesuchtes Ergebnis:
# 
# ```Python
#             name 	population 	area
# country 			
# England 	London 	8615246 	1572.00
# Germany 	Berlin 	3562166 	891.85
# Spain 	  Madrid 	3165235 	605.77
# Italy 	  Rome 	  2874038     1285.00
# France 	 Paris 	 2273305     105.40
# ```

# In[11]:


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


# ## Task 11.9
# Sortieren Sie die Ausgabe nach *area*, und zwar in absteigener Reihenfolge. Verwenden Sie `sort_values()`. Quelle: https://pandas.pydata.org/pandas-docs/stable/reference/api/pandas.DataFrame.sort_values.html

# In[12]:


# Your code...
city_df.sort_values('area', ascending=False, inplace=True)
city_df


# ## Task 11.10 - BITTE AUSLASSEN, HOLEN WIR NACH!
# Nehmen Sie spätestens jetzt den Abschnitt *Applying Functions* des Tutorials **Python Pandas Tutorial: A Complete Introduction for Beginners** (siehe Übung 09) durch. 
# 
# Ziel ist die Erstellung einer weiteren Spalte *megacities*, die für alle Städte, der *population* > 2Mio. ist, den Wert `True` enthält. Erstellen Sie hierzu die Funktion `def calc_megacities(population)`, in welcher die Abfrage zu implementieren ist. Das gesuchte Ergebnis (die unordentliche Darstellung ist dem JN geschuldet):
# 
# ```Python
#             name 	population 	area 	megacities
# country 				
# England 	London 	8615246 	1572.00 	True
# Italy       Rome 	2874038 	1285.00 	True
# Germany 	Berlin 	3562166 	891.85 	    True
# Germany 	Hamburg 1760433 	755.00 	    False
# Spain 	    Madrid 	3165235 	605.77 	    True
# ...
# ```

# In[13]:


# Your code...


# ## Task 11.11
# 
# Diese Aufgabe basiert auf einem Dataset, dass je Messzeitpunkt *t* sechs Temperaturwerte (Sensor 1 bis Sensor 6) umfasst. Das Messintervall betrug 15 Minuten.
# 
# Laden Sie a) das bereitgestellte Dataset *temperatures_with_NaN.csv* und geben Sie die Shape aus. 
# 
# Geben Sie b) die ersten 5 Zeilen aller Sensoren aus. Geben Sie c) ausschließlich die ersten 5 Zeilen der Sensoren 3 und 4 aus. 
# 
# Ermitteln Sie d) die Anzahl der NaN-Werte je Sensor sowie je Zeitpunkt *t*. **Hinweis**: Denken Sie an die Achsen-Thematik, diese ist bei `sum()` konfigurierbar (https://pandas.pydata.org/pandas-docs/stable/reference/api/pandas.DataFrame.sum.html?highlight=sum#pandas.DataFrame.sum. Ermitteln Sie außerdem die Gesamtanzahl der *NaN*-Werte. Hierzu ein kleiner Tipp: "doppelt hält besser"! 
# 
# e) Der letzte Punkte dieser Aufgabe widmet sich der Ermittlung des Mittelwertes zum Zeitpunkt t (siehe neue Spalte *mean*). Das gesuchte Ergebnis ist:
# 
# ```Python
#             time 	sensor1 	sensor2 	sensor3 	sensor4 	sensor5 	sensor6 	mean
#     0 	06:00:00 	14.3 	    13.7 	  14.2 	  14.3 	   13.5 	  13.6 	 13.933333
#     1 	06:15:00 	14.5 	    14.5 	  14.0 	  15.0 	   14.5 	  14.7 	 14.533333
#     3 	06:45:00 	14.8 	    14.5 	  15.6 	  15.2 	   14.7 	  14.6 	 14.900000
#     4 	07:00:00 	15.0 	    14.9 	  NaN 	   15.6 	   14.0 	  15.3 	 14.960000
#     6 	07:30:00 	15.4 	    15.3 	  NaN 	   15.6 	   14.7 	  15.1 	 15.220000
# ```
# 
# **Vorgehensweise**
# 
# Es wird ersichtlich, dass z.B. die Messung zum Zeitpunkt t2 fehlt. Hintergrund ist, dass all jene Messungen entfernt wurden, die mehr als **einen** NaN-Wert aufwiesen. Das lässt sich mit `dropna()` überauseinfach bewerkstelligen (siehe Argument `thresh`). Hierbei ist die Gesamtanzahl der Spalten - also inkl. *time* - zu berücksichtigen! Entfernt man all jene Zeilen, die mehr als einen NaN-Wert enthalten, reduziert sich die Anzahl der Zeilen im Dataset auf 35.
# 
# Den zweiten und letzten Schritt, um diese Aufgabe zu bewerkstelligen, stellt die Ermittlung des Mittelwertes je Messzeitpunkt t dar. Das Ergebnis ist in die neue Spalte *mean* zu schreiben.

# In[14]:


#a)
temperatures = pd.read_csv('temperatures_with_NaN.csv')
temperatures.shape


# In[26]:


#b)
temperatures.head(5)


# In[27]:


#c)
temperatures.iloc[:5,3:5]
# temperatures[['sensor3', 'sensor4']]
# temperatures.iloc[:5][['sensor3', 'sensor4']]


# In[17]:


#d)
temperatures.isnull().sum()


# In[18]:


#d)
temperatures.isnull().sum(axis=1)


# In[19]:


#d)
temperatures.isnull().sum().sum()


# In[20]:


#e)
temperatures['mean'] = temperatures.mean(axis=1)
get_ipython().run_line_magic('pinfo', 'temperatures.dropna')
temperatures

