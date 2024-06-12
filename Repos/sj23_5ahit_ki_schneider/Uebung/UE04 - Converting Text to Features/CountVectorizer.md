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



# Count Vectorizer


```python
text = ["Tom's family includes 5 kids 2 dogs and 1 cat",
        "The dogs are friendly. The cat is beautiful",
        "The dog is 11 years old",
        "Tom loves in the United States of America"]
```


```python
from sklearn.feature_extraction.text import CountVectorizer
```


```python
vectorizer = CountVectorizer()
vectorizer.fit(text)
```




<style>#sk-container-id-2 {color: black;}#sk-container-id-2 pre{padding: 0;}#sk-container-id-2 div.sk-toggleable {background-color: white;}#sk-container-id-2 label.sk-toggleable__label {cursor: pointer;display: block;width: 100%;margin-bottom: 0;padding: 0.3em;box-sizing: border-box;text-align: center;}#sk-container-id-2 label.sk-toggleable__label-arrow:before {content: "▸";float: left;margin-right: 0.25em;color: #696969;}#sk-container-id-2 label.sk-toggleable__label-arrow:hover:before {color: black;}#sk-container-id-2 div.sk-estimator:hover label.sk-toggleable__label-arrow:before {color: black;}#sk-container-id-2 div.sk-toggleable__content {max-height: 0;max-width: 0;overflow: hidden;text-align: left;background-color: #f0f8ff;}#sk-container-id-2 div.sk-toggleable__content pre {margin: 0.2em;color: black;border-radius: 0.25em;background-color: #f0f8ff;}#sk-container-id-2 input.sk-toggleable__control:checked~div.sk-toggleable__content {max-height: 200px;max-width: 100%;overflow: auto;}#sk-container-id-2 input.sk-toggleable__control:checked~label.sk-toggleable__label-arrow:before {content: "▾";}#sk-container-id-2 div.sk-estimator input.sk-toggleable__control:checked~label.sk-toggleable__label {background-color: #d4ebff;}#sk-container-id-2 div.sk-label input.sk-toggleable__control:checked~label.sk-toggleable__label {background-color: #d4ebff;}#sk-container-id-2 input.sk-hidden--visually {border: 0;clip: rect(1px 1px 1px 1px);clip: rect(1px, 1px, 1px, 1px);height: 1px;margin: -1px;overflow: hidden;padding: 0;position: absolute;width: 1px;}#sk-container-id-2 div.sk-estimator {font-family: monospace;background-color: #f0f8ff;border: 1px dotted black;border-radius: 0.25em;box-sizing: border-box;margin-bottom: 0.5em;}#sk-container-id-2 div.sk-estimator:hover {background-color: #d4ebff;}#sk-container-id-2 div.sk-parallel-item::after {content: "";width: 100%;border-bottom: 1px solid gray;flex-grow: 1;}#sk-container-id-2 div.sk-label:hover label.sk-toggleable__label {background-color: #d4ebff;}#sk-container-id-2 div.sk-serial::before {content: "";position: absolute;border-left: 1px solid gray;box-sizing: border-box;top: 0;bottom: 0;left: 50%;z-index: 0;}#sk-container-id-2 div.sk-serial {display: flex;flex-direction: column;align-items: center;background-color: white;padding-right: 0.2em;padding-left: 0.2em;position: relative;}#sk-container-id-2 div.sk-item {position: relative;z-index: 1;}#sk-container-id-2 div.sk-parallel {display: flex;align-items: stretch;justify-content: center;background-color: white;position: relative;}#sk-container-id-2 div.sk-item::before, #sk-container-id-2 div.sk-parallel-item::before {content: "";position: absolute;border-left: 1px solid gray;box-sizing: border-box;top: 0;bottom: 0;left: 50%;z-index: -1;}#sk-container-id-2 div.sk-parallel-item {display: flex;flex-direction: column;z-index: 1;position: relative;background-color: white;}#sk-container-id-2 div.sk-parallel-item:first-child::after {align-self: flex-end;width: 50%;}#sk-container-id-2 div.sk-parallel-item:last-child::after {align-self: flex-start;width: 50%;}#sk-container-id-2 div.sk-parallel-item:only-child::after {width: 0;}#sk-container-id-2 div.sk-dashed-wrapped {border: 1px dashed gray;margin: 0 0.4em 0.5em 0.4em;box-sizing: border-box;padding-bottom: 0.4em;background-color: white;}#sk-container-id-2 div.sk-label label {font-family: monospace;font-weight: bold;display: inline-block;line-height: 1.2em;}#sk-container-id-2 div.sk-label-container {text-align: center;}#sk-container-id-2 div.sk-container {/* jupyter's `normalize.less` sets `[hidden] { display: none; }` but bootstrap.min.css set `[hidden] { display: none !important; }` so we also need the `!important` here to be able to override the default hidden behavior on the sphinx rendered scikit-learn.org. See: https://github.com/scikit-learn/scikit-learn/issues/21755 */display: inline-block !important;position: relative;}#sk-container-id-2 div.sk-text-repr-fallback {display: none;}</style><div id="sk-container-id-2" class="sk-top-container"><div class="sk-text-repr-fallback"><pre>CountVectorizer()</pre><b>In a Jupyter environment, please rerun this cell to show the HTML representation or trust the notebook. <br />On GitHub, the HTML representation is unable to render, please try loading this page with nbviewer.org.</b></div><div class="sk-container" hidden><div class="sk-item"><div class="sk-estimator sk-toggleable"><input class="sk-toggleable__control sk-hidden--visually" id="sk-estimator-id-2" type="checkbox" checked><label for="sk-estimator-id-2" class="sk-toggleable__label sk-toggleable__label-arrow">CountVectorizer</label><div class="sk-toggleable__content"><pre>CountVectorizer()</pre></div></div></div></div></div>




```python
print(vectorizer.get_feature_names_out())
```

    ['11' 'america' 'and' 'are' 'beautiful' 'cat' 'dog' 'dogs' 'family'
     'friendly' 'in' 'includes' 'is' 'kids' 'loves' 'of' 'old' 'states' 'the'
     'tom' 'united' 'years']
    


```python
vectorizer = CountVectorizer(token_pattern=u'(?u)\\b\\w+\\b')
vectorizer.fit(text)
print(vectorizer.get_feature_names_out())
```

    ['1' '11' '2' '5' 'america' 'and' 'are' 'beautiful' 'cat' 'dog' 'dogs'
     'family' 'friendly' 'in' 'includes' 'is' 'kids' 'loves' 'of' 'old' 's'
     'states' 'the' 'tom' 'united' 'years']
    


```python
vectorizer = CountVectorizer(token_pattern=u'(?u)\\b\\w+\\b',
                             stop_words=['is','are','and','in','the'])
vectorizer.fit(text)
print(vectorizer.get_feature_names_out())
```

    ['1' '11' '2' '5' 'america' 'beautiful' 'cat' 'dog' 'dogs' 'family'
     'friendly' 'includes' 'kids' 'loves' 'of' 'old' 's' 'states' 'tom'
     'united' 'years']
    


```python
print(vectorizer.vocabulary_)
```

    {'tom': 18, 's': 16, 'family': 9, 'includes': 11, '5': 3, 'kids': 12, '2': 2, 'dogs': 8, '1': 0, 'cat': 6, 'friendly': 10, 'beautiful': 5, 'dog': 7, '11': 1, 'years': 20, 'old': 15, 'loves': 13, 'united': 19, 'states': 17, 'of': 14, 'america': 4}
    


```python
vector = vectorizer.transform(text)
vector.shape
```




    (4, 21)




```python
print(vector.toarray())
```

    [[1 0 1 1 0 0 1 0 1 1 0 1 1 0 0 0 1 0 1 0 0]
     [0 0 0 0 0 1 1 0 1 0 1 0 0 0 0 0 0 0 0 0 0]
     [0 1 0 0 0 0 0 1 0 0 0 0 0 0 0 1 0 0 0 0 1]
     [0 0 0 0 1 0 0 0 0 0 0 0 0 1 1 0 0 1 1 1 0]]
    


```python
import pandas as pd
```


```python
pd.DataFrame(vector.toarray(), columns=vectorizer.get_feature_names_out())
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
      <th>1</th>
      <th>11</th>
      <th>2</th>
      <th>5</th>
      <th>america</th>
      <th>beautiful</th>
      <th>cat</th>
      <th>dog</th>
      <th>dogs</th>
      <th>family</th>
      <th>...</th>
      <th>includes</th>
      <th>kids</th>
      <th>loves</th>
      <th>of</th>
      <th>old</th>
      <th>s</th>
      <th>states</th>
      <th>tom</th>
      <th>united</th>
      <th>years</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>0</th>
      <td>1</td>
      <td>0</td>
      <td>1</td>
      <td>1</td>
      <td>0</td>
      <td>0</td>
      <td>1</td>
      <td>0</td>
      <td>1</td>
      <td>1</td>
      <td>...</td>
      <td>1</td>
      <td>1</td>
      <td>0</td>
      <td>0</td>
      <td>0</td>
      <td>1</td>
      <td>0</td>
      <td>1</td>
      <td>0</td>
      <td>0</td>
    </tr>
    <tr>
      <th>1</th>
      <td>0</td>
      <td>0</td>
      <td>0</td>
      <td>0</td>
      <td>0</td>
      <td>1</td>
      <td>1</td>
      <td>0</td>
      <td>1</td>
      <td>0</td>
      <td>...</td>
      <td>0</td>
      <td>0</td>
      <td>0</td>
      <td>0</td>
      <td>0</td>
      <td>0</td>
      <td>0</td>
      <td>0</td>
      <td>0</td>
      <td>0</td>
    </tr>
    <tr>
      <th>2</th>
      <td>0</td>
      <td>1</td>
      <td>0</td>
      <td>0</td>
      <td>0</td>
      <td>0</td>
      <td>0</td>
      <td>1</td>
      <td>0</td>
      <td>0</td>
      <td>...</td>
      <td>0</td>
      <td>0</td>
      <td>0</td>
      <td>0</td>
      <td>1</td>
      <td>0</td>
      <td>0</td>
      <td>0</td>
      <td>0</td>
      <td>1</td>
    </tr>
    <tr>
      <th>3</th>
      <td>0</td>
      <td>0</td>
      <td>0</td>
      <td>0</td>
      <td>1</td>
      <td>0</td>
      <td>0</td>
      <td>0</td>
      <td>0</td>
      <td>0</td>
      <td>...</td>
      <td>0</td>
      <td>0</td>
      <td>1</td>
      <td>1</td>
      <td>0</td>
      <td>0</td>
      <td>1</td>
      <td>1</td>
      <td>1</td>
      <td>0</td>
    </tr>
  </tbody>
</table>
<p>4 rows × 21 columns</p>
</div>




```python
vectorizer = CountVectorizer(token_pattern=u'(?u)\\b\\w+\\b',
                             stop_words=['is','are','and','in','the'],
                             ngram_range=(1,4))
vectorizer.fit(text)
print(vectorizer.get_feature_names_out())
```

    ['1' '1 cat' '11' '11 years' '11 years old' '2' '2 dogs' '2 dogs 1'
     '2 dogs 1 cat' '5' '5 kids' '5 kids 2' '5 kids 2 dogs' 'america'
     'beautiful' 'cat' 'cat beautiful' 'dog' 'dog 11' 'dog 11 years'
     'dog 11 years old' 'dogs' 'dogs 1' 'dogs 1 cat' 'dogs friendly'
     'dogs friendly cat' 'dogs friendly cat beautiful' 'family'
     'family includes' 'family includes 5' 'family includes 5 kids' 'friendly'
     'friendly cat' 'friendly cat beautiful' 'includes' 'includes 5'
     'includes 5 kids' 'includes 5 kids 2' 'kids' 'kids 2' 'kids 2 dogs'
     'kids 2 dogs 1' 'loves' 'loves united' 'loves united states'
     'loves united states of' 'of' 'of america' 'old' 's' 's family'
     's family includes' 's family includes 5' 'states' 'states of'
     'states of america' 'tom' 'tom loves' 'tom loves united'
     'tom loves united states' 'tom s' 'tom s family' 'tom s family includes'
     'united' 'united states' 'united states of' 'united states of america'
     'years' 'years old']
    


```python
vectorizer = CountVectorizer(token_pattern=u'(?u)\\b\\w+\\b',
                             stop_words=['is','are','and','in','the'],
                             ngram_range=(1,4),
                             vocabulary=['united states of america'])
vectorizer.fit(text)
print(vectorizer.get_feature_names_out())
```

    ['united states of america']
    
