# Bag of Words


```python
from sklearn.feature_extraction.text import CountVectorizer

# Example text
text = [
 "NLP unlocks insights, NLP evolving.",
 "ML learns patterns; ML applications abound.",
 "NLP preprocessing crucial for NLP understanding."
]

# Initialize
vectorizer = CountVectorizer()

# Erstellt das Vokabular aus den Textdaten
X=vectorizer.fit(text)
print("Vokabular:", vectorizer.vocabulary_) 

print("\n")

# Features ausgeben
print("Features:", vectorizer.get_feature_names_out())

print("\n")

# Textdaten basierend auf Vokabular vektorisieren. Ergebnis ist BoW
X=vectorizer.transform(text)
print("Bag of Words\n", X.toarray())
```

    Vokabular: {'nlp': 8, 'unlocks': 12, 'insights': 5, 'evolving': 3, 'ml': 7, 'learns': 6, 'patterns': 9, 'applications': 1, 'abound': 0, 'preprocessing': 10, 'crucial': 2, 'for': 4, 'understanding': 11}
    
    
    Features: ['abound' 'applications' 'crucial' 'evolving' 'for' 'insights' 'learns'
     'ml' 'nlp' 'patterns' 'preprocessing' 'understanding' 'unlocks']
    
    
    Bag of Words
     [[0 0 0 1 0 1 0 0 2 0 0 0 1]
     [1 1 0 0 0 0 1 2 0 1 0 0 0]
     [0 0 1 0 1 0 0 0 2 0 1 1 0]]
    

## Spam


```python
import pandas as pd

spam = pd.read_csv('spam.csv', encoding="ANSI")
spam.head()
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
      <th>v1</th>
      <th>v2</th>
      <th>Unnamed: 2</th>
      <th>Unnamed: 3</th>
      <th>Unnamed: 4</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>0</th>
      <td>ham</td>
      <td>Go until jurong point, crazy.. Available only ...</td>
      <td>NaN</td>
      <td>NaN</td>
      <td>NaN</td>
    </tr>
    <tr>
      <th>1</th>
      <td>ham</td>
      <td>Ok lar... Joking wif u oni...</td>
      <td>NaN</td>
      <td>NaN</td>
      <td>NaN</td>
    </tr>
    <tr>
      <th>2</th>
      <td>spam</td>
      <td>Free entry in 2 a wkly comp to win FA Cup fina...</td>
      <td>NaN</td>
      <td>NaN</td>
      <td>NaN</td>
    </tr>
    <tr>
      <th>3</th>
      <td>ham</td>
      <td>U dun say so early hor... U c already then say...</td>
      <td>NaN</td>
      <td>NaN</td>
      <td>NaN</td>
    </tr>
    <tr>
      <th>4</th>
      <td>ham</td>
      <td>Nah I don't think he goes to usf, he lives aro...</td>
      <td>NaN</td>
      <td>NaN</td>
      <td>NaN</td>
    </tr>
  </tbody>
</table>
</div>




```python
spam.rename(columns= { "v1" : "target", "v2" : "message" }, inplace=True)
spam.drop(columns= { "Unnamed: 2", "Unnamed: 3", "Unnamed: 4" }, inplace=True)
spam.head()
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
      <th>target</th>
      <th>message</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>0</th>
      <td>ham</td>
      <td>Go until jurong point, crazy.. Available only ...</td>
    </tr>
    <tr>
      <th>1</th>
      <td>ham</td>
      <td>Ok lar... Joking wif u oni...</td>
    </tr>
    <tr>
      <th>2</th>
      <td>spam</td>
      <td>Free entry in 2 a wkly comp to win FA Cup fina...</td>
    </tr>
    <tr>
      <th>3</th>
      <td>ham</td>
      <td>U dun say so early hor... U c already then say...</td>
    </tr>
    <tr>
      <th>4</th>
      <td>ham</td>
      <td>Nah I don't think he goes to usf, he lives aro...</td>
    </tr>
  </tbody>
</table>
</div>



### Label Encoder


```python
from sklearn.preprocessing import LabelEncoder
le = LabelEncoder()
spam['target'] = le.fit_transform(spam['target'])
spam.head()
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
      <th>target</th>
      <th>message</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>0</th>
      <td>0</td>
      <td>Go until jurong point, crazy.. Available only ...</td>
    </tr>
    <tr>
      <th>1</th>
      <td>0</td>
      <td>Ok lar... Joking wif u oni...</td>
    </tr>
    <tr>
      <th>2</th>
      <td>1</td>
      <td>Free entry in 2 a wkly comp to win FA Cup fina...</td>
    </tr>
    <tr>
      <th>3</th>
      <td>0</td>
      <td>U dun say so early hor... U c already then say...</td>
    </tr>
    <tr>
      <th>4</th>
      <td>0</td>
      <td>Nah I don't think he goes to usf, he lives aro...</td>
    </tr>
  </tbody>
</table>
</div>



### Train Valid Split


```python
from sklearn.model_selection import train_test_split

# X und y erstellen
X = spam['message']
y = spam['target']

# Daten teilen für lernen und validieren
X_train, X_valid, y_train, y_valid = train_test_split(X, y, test_size = .3, random_state = 12)

print("X_train:", X_train.shape)
print("y_train:", y_train.shape)
print("X_valid:", X_valid.shape)
print("y_valid:", y_valid.shape)
```

    X_train: (3900,)
    y_train: (3900,)
    X_valid: (1672,)
    y_valid: (1672,)
    


```python
X=vectorizer.fit(spam['message'])
print("Token Count:", len(vectorizer.get_feature_names_out())) 
```

    Token Count: 8673
    


```python
# Textdaten basierend auf Vokabular vektorisieren. Ergebnis ist BoW
X_train_vectorized = vectorizer.transform(X_train)
print("Bag of Words\n", X_train_vectorized.toarray())

print("\n")

print("X_train_vectorized:", X_train_vectorized.shape)
```

    Bag of Words
     [[0 0 0 ... 0 0 0]
     [0 0 0 ... 0 0 0]
     [0 0 0 ... 0 0 0]
     ...
     [0 0 0 ... 0 0 0]
     [0 0 0 ... 0 0 0]
     [0 0 0 ... 0 0 0]]
    
    
    X_train_vectorized: (3900, 8673)
    


```python
# Textdaten basierend auf Vokabular vektorisieren. Ergebnis ist BoW
X_valid_vectorized = vectorizer.transform(X_valid)
print("Bag of Words\n", X_valid_vectorized.toarray())

print("\n")

print("X_valid_vectorized:", X_valid_vectorized.shape)
```

    Bag of Words
     [[0 0 0 ... 0 0 0]
     [0 0 0 ... 0 0 0]
     [0 0 0 ... 0 0 0]
     ...
     [0 0 0 ... 0 0 0]
     [0 0 0 ... 0 0 0]
     [0 0 0 ... 0 0 0]]
    
    
    X_valid_vectorized: (1672, 8673)
    


```python
y_train_num = le.fit_transform(y_train)
y_valid_num = le.fit_transform(y_valid)
```

###  Naive Bayes Classifiers


```python
from sklearn.naive_bayes import MultinomialNB
from sklearn.metrics import accuracy_score 

clf = MultinomialNB(alpha=0.2)
clf.fit(X_train_vectorized, y_train_num)

predictions = clf.predict(X_valid_vectorized)
accuracy_score(predictions, y_valid_num)
```




    0.9772727272727273




```python
msg = vectorizer.transform(["Congratulations! You've won a complimentary entry to the exclusive VIP event. Claim your free pass for the grand finale on June 15, 2023, by texting VIP to 44882. Standard text messaging rates apply. For more details, call 1-800-123-4567. Don't miss out on this incredible opportunity! Terms and conditions apply. Must be 18 or older to participate."])
clf.predict(msg)
```




    array([1], dtype=int64)


