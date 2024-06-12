# 3.2 


```python
tweets = [
    'This is introduction to NLP',
    'It is likely to be useful, to people ',
    'Machine learning is the new electrcity',
    'There would be less hype around AI and more action going forward',
    'python is the best tool!','R is good langauage',
    'I like this book','I want more books like this'
]

import pandas as pd
df = pd.DataFrame({'tweets': [col.lower() for col in tweets]})
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
      <th>tweets</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>0</th>
      <td>this is introduction to nlp</td>
    </tr>
    <tr>
      <th>1</th>
      <td>it is likely to be useful, to people</td>
    </tr>
    <tr>
      <th>2</th>
      <td>machine learning is the new electrcity</td>
    </tr>
    <tr>
      <th>3</th>
      <td>there would be less hype around ai and more ac...</td>
    </tr>
    <tr>
      <th>4</th>
      <td>python is the best tool!</td>
    </tr>
    <tr>
      <th>5</th>
      <td>r is good langauage</td>
    </tr>
    <tr>
      <th>6</th>
      <td>i like this book</td>
    </tr>
    <tr>
      <th>7</th>
      <td>i want more books like this</td>
    </tr>
  </tbody>
</table>
</div>



# 3.3


```python
import re
df.tweets = [re.sub("[^a-z0-9 .]", '', col) for col in df.tweets]
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
      <th>tweets</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>0</th>
      <td>this is introduction to nlp</td>
    </tr>
    <tr>
      <th>1</th>
      <td>it is likely to be useful to people</td>
    </tr>
    <tr>
      <th>2</th>
      <td>machine learning is the new electrcity</td>
    </tr>
    <tr>
      <th>3</th>
      <td>there would be less hype around ai and more ac...</td>
    </tr>
    <tr>
      <th>4</th>
      <td>python is the best tool</td>
    </tr>
    <tr>
      <th>5</th>
      <td>r is good langauage</td>
    </tr>
    <tr>
      <th>6</th>
      <td>i like this book</td>
    </tr>
    <tr>
      <th>7</th>
      <td>i want more books like this</td>
    </tr>
  </tbody>
</table>
</div>



# 3.4 


```python
text = "This is the first sentence. This is the second one."
list_of_words = text.split()
print(list_of_words)

import nltk
nltk.download('punkt')
from nltk.tokenize import word_tokenize
text="This is the first sentence. This is the second one."
print(word_tokenize(text)) 

# As you can see, NLTK slits the punctiations into it's own element of the list whereas slit just slits whitespaces.
```

    ['This', 'is', 'the', 'first', 'sentence.', 'This', 'is', 'the', 'second', 'one.']
    ['This', 'is', 'the', 'first', 'sentence', '.', 'This', 'is', 'the', 'second', 'one', '.']
    

    [nltk_data] Downloading package punkt to
    [nltk_data]     C:\Users\trueb\AppData\Roaming\nltk_data...
    [nltk_data]   Package punkt is already up-to-date!
    


```python
from nltk.tokenize import sent_tokenize
text="This is introduction to NLP. It is likely to be useful, to people."
print(sent_tokenize(text)) 
```

    ['This is introduction to NLP.', 'It is likely to be useful, to people.']
    


```python
from nltk.tokenize import WordPunctTokenizer
text="We're moving to N.Y.!"
Tokenizer=WordPunctTokenizer()
print(Tokenizer.tokenize(text)) 

```

    ['We', "'", 're', 'moving', 'to', 'N', '.', 'Y', '.!']
    


```python
from nltk.tokenize import RegexpTokenizer
text="We're moving to N.Y.!"
tokenizer = RegexpTokenizer(r"\w+")
print(tokenizer.tokenize(text)) 
```

    ['We', 're', 'moving', 'to', 'N', 'Y']
    

# 3.5


```python
df['tokenized'] = [tokenizer.tokenize(col) for col in df['tweets']]
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
      <th>tweets</th>
      <th>tokenized</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>0</th>
      <td>this is introduction to nlp</td>
      <td>[this, is, introduction, to, nlp]</td>
    </tr>
    <tr>
      <th>1</th>
      <td>it is likely to be useful to people</td>
      <td>[it, is, likely, to, be, useful, to, people]</td>
    </tr>
    <tr>
      <th>2</th>
      <td>machine learning is the new electrcity</td>
      <td>[machine, learning, is, the, new, electrcity]</td>
    </tr>
    <tr>
      <th>3</th>
      <td>there would be less hype around ai and more ac...</td>
      <td>[there, would, be, less, hype, around, ai, and...</td>
    </tr>
    <tr>
      <th>4</th>
      <td>python is the best tool</td>
      <td>[python, is, the, best, tool]</td>
    </tr>
    <tr>
      <th>5</th>
      <td>r is good langauage</td>
      <td>[r, is, good, langauage]</td>
    </tr>
    <tr>
      <th>6</th>
      <td>i like this book</td>
      <td>[i, like, this, book]</td>
    </tr>
    <tr>
      <th>7</th>
      <td>i want more books like this</td>
      <td>[i, want, more, books, like, this]</td>
    </tr>
  </tbody>
</table>
</div>



# 3.6


```python
from nltk.tokenize import word_tokenize
with open('dataScientistJobDesc.txt', 'r', encoding="UTF-8") as file:
    data= file.read()
    data_list = word_tokenize(data)
    print(len(data_list))
    data_set = set(data_list)
    print(len(data_set))
    nltk_tokens = data_set
```

    1373
    549
    

# 3.7


```python
import spacy
nlp = spacy.load("de_core_news_sm")
doc = nlp("Apple erwägt den Kauf eines österreichischen Startups um 6 Mio. Euro.")
print(doc)
```

    Apple erwägt den Kauf eines österreichischen Startups um 6 Mio. Euro.
    


```python
for token in doc:
    print(f"{token.text:{20}}",type(token)) 
```

    Apple                <class 'spacy.tokens.token.Token'>
    erwägt               <class 'spacy.tokens.token.Token'>
    den                  <class 'spacy.tokens.token.Token'>
    Kauf                 <class 'spacy.tokens.token.Token'>
    eines                <class 'spacy.tokens.token.Token'>
    österreichischen     <class 'spacy.tokens.token.Token'>
    Startups             <class 'spacy.tokens.token.Token'>
    um                   <class 'spacy.tokens.token.Token'>
    6                    <class 'spacy.tokens.token.Token'>
    Mio.                 <class 'spacy.tokens.token.Token'>
    Euro                 <class 'spacy.tokens.token.Token'>
    .                    <class 'spacy.tokens.token.Token'>
    


```python
with open('dataScientistJobDesc.txt', 'r', encoding="UTF-8") as file:
    data = file.read()
    data_list = nlp(data)
    print(len(data_list))
    data_set = set([token.text for token in data_list])
    print(len(data_set))
    spacy_tokens = data_set
```

    1436
    560
    


```python
# Spacy behandelt offensichtlich gewisse Zeichenketten (besonders Sonderzeichen) anders.
# Beispielsweise sieht man unten, dass Kommas, Punkte und Schrägstriche nicht gleich tokenized werden.
nltk_tokens.difference(spacy_tokens)
```




    {'1628,000', 'Director/VP/SVP', 'd3.js.', 'etc', 'industries/sectors', 's'}



# 3.8


```python
from nltk.corpus import stopwords

nltk.download('stopwords')
stop = stopwords.words('english')
text = "How to develop a chatbot in Python"
result = [word for word in text.split() if word not in stop]
result 

# Da How nicht in den Stopwords vorkommt, wurde es nicht aus dem Satz / der Liste entfernt
```

    [nltk_data] Downloading package stopwords to
    [nltk_data]     C:\Users\trueb\AppData\Roaming\nltk_data...
    [nltk_data]   Package stopwords is already up-to-date!
    




    ['How', 'develop', 'chatbot', 'Python']



# 3.9


```python
def remove_stopwords_and_join(text):
    words = text.split()
    filtered_words = [word for word in words if word.lower() not in stop]
    return ' '.join(filtered_words)

df['tweets'] = df['tweets'].apply(remove_stopwords_and_join)
df['tokenized'] = [tokenizer.tokenize(col) for col in df['tweets']]
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
      <th>tweets</th>
      <th>tokenized</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>0</th>
      <td>introduction nlp</td>
      <td>[introduction, nlp]</td>
    </tr>
    <tr>
      <th>1</th>
      <td>likely useful people</td>
      <td>[likely, useful, people]</td>
    </tr>
    <tr>
      <th>2</th>
      <td>machine learning new electrcity</td>
      <td>[machine, learning, new, electrcity]</td>
    </tr>
    <tr>
      <th>3</th>
      <td>would less hype around ai action going forward</td>
      <td>[would, less, hype, around, ai, action, going,...</td>
    </tr>
    <tr>
      <th>4</th>
      <td>python best tool</td>
      <td>[python, best, tool]</td>
    </tr>
    <tr>
      <th>5</th>
      <td>r good langauage</td>
      <td>[r, good, langauage]</td>
    </tr>
    <tr>
      <th>6</th>
      <td>like book</td>
      <td>[like, book]</td>
    </tr>
    <tr>
      <th>7</th>
      <td>want books like</td>
      <td>[want, books, like]</td>
    </tr>
  </tbody>
</table>
</div>


