# One-Hot-Encoding


```python
import spacy
from sklearn.feature_extraction.text import CountVectorizer
nlp = spacy.load('en_core_web_sm')

text="Jim loves NLP. He will learn NLP in two monts. NLP is future."
def get_spacy_tokens(text):
    doc = nlp(text)
    return [token.text for token in doc]
text_tokens = get_spacy_tokens(text)
vectorizer = CountVectorizer(tokenizer=get_spacy_tokens, lowercase=False, token_pattern=None)

vectorizer.fit(text_tokens)
print("Vocabulary: ", vectorizer.vocabulary_)

vector = vectorizer.transform(text_tokens)
print("Encoded Document is:") 
print(vector.toarray()) 
```

    Vocabulary:  {'Jim': 2, 'loves': 8, 'NLP': 3, '.': 0, 'He': 1, 'will': 11, 'learn': 7, 'in': 5, 'two': 10, 'monts': 9, 'is': 6, 'future': 4}
    Encoded Document is:
    [[0 0 1 0 0 0 0 0 0 0 0 0]
     [0 0 0 0 0 0 0 0 1 0 0 0]
     [0 0 0 1 0 0 0 0 0 0 0 0]
     [1 0 0 0 0 0 0 0 0 0 0 0]
     [0 1 0 0 0 0 0 0 0 0 0 0]
     [0 0 0 0 0 0 0 0 0 0 0 1]
     [0 0 0 0 0 0 0 1 0 0 0 0]
     [0 0 0 1 0 0 0 0 0 0 0 0]
     [0 0 0 0 0 1 0 0 0 0 0 0]
     [0 0 0 0 0 0 0 0 0 0 1 0]
     [0 0 0 0 0 0 0 0 0 1 0 0]
     [1 0 0 0 0 0 0 0 0 0 0 0]
     [0 0 0 1 0 0 0 0 0 0 0 0]
     [0 0 0 0 0 0 1 0 0 0 0 0]
     [0 0 0 0 1 0 0 0 0 0 0 0]
     [1 0 0 0 0 0 0 0 0 0 0 0]]
    

## Products


```python
import pandas as pd
df = pd.read_csv('products.csv')
df = pd.get_dummies(df, columns=["kategorie"], dtype=int)
df.columns = map(str.lower, df.columns)
df
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
      <th>produkt_id</th>
      <th>kategorie_bücher</th>
      <th>kategorie_elektronik</th>
      <th>kategorie_kleidung</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>0</th>
      <td>1</td>
      <td>0</td>
      <td>1</td>
      <td>0</td>
    </tr>
    <tr>
      <th>1</th>
      <td>2</td>
      <td>0</td>
      <td>0</td>
      <td>1</td>
    </tr>
    <tr>
      <th>2</th>
      <td>3</td>
      <td>1</td>
      <td>0</td>
      <td>0</td>
    </tr>
    <tr>
      <th>3</th>
      <td>4</td>
      <td>0</td>
      <td>1</td>
      <td>0</td>
    </tr>
    <tr>
      <th>4</th>
      <td>5</td>
      <td>0</td>
      <td>1</td>
      <td>0</td>
    </tr>
    <tr>
      <th>5</th>
      <td>6</td>
      <td>1</td>
      <td>0</td>
      <td>0</td>
    </tr>
    <tr>
      <th>6</th>
      <td>7</td>
      <td>0</td>
      <td>0</td>
      <td>1</td>
    </tr>
    <tr>
      <th>7</th>
      <td>8</td>
      <td>1</td>
      <td>0</td>
      <td>0</td>
    </tr>
    <tr>
      <th>8</th>
      <td>9</td>
      <td>0</td>
      <td>1</td>
      <td>0</td>
    </tr>
    <tr>
      <th>9</th>
      <td>10</td>
      <td>0</td>
      <td>0</td>
      <td>1</td>
    </tr>
    <tr>
      <th>10</th>
      <td>11</td>
      <td>1</td>
      <td>0</td>
      <td>0</td>
    </tr>
    <tr>
      <th>11</th>
      <td>12</td>
      <td>0</td>
      <td>1</td>
      <td>0</td>
    </tr>
    <tr>
      <th>12</th>
      <td>13</td>
      <td>1</td>
      <td>0</td>
      <td>0</td>
    </tr>
    <tr>
      <th>13</th>
      <td>14</td>
      <td>0</td>
      <td>1</td>
      <td>0</td>
    </tr>
    <tr>
      <th>14</th>
      <td>15</td>
      <td>0</td>
      <td>0</td>
      <td>1</td>
    </tr>
    <tr>
      <th>15</th>
      <td>16</td>
      <td>0</td>
      <td>0</td>
      <td>1</td>
    </tr>
  </tbody>
</table>
</div>


