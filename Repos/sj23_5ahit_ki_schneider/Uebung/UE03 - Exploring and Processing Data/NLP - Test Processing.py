#!/usr/bin/env python
# coding: utf-8

# # 3.2 

# In[10]:


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


# # 3.3

# In[11]:


import re
df.tweets = [re.sub("[^a-z0-9 .]", '', col) for col in df.tweets]
df


# # 3.4 

# In[12]:


text = "This is the first sentence. This is the second one."
list_of_words = text.split()
print(list_of_words)

import nltk
nltk.download('punkt')
from nltk.tokenize import word_tokenize
text="This is the first sentence. This is the second one."
print(word_tokenize(text)) 

# As you can see, NLTK slits the punctiations into it's own element of the list whereas slit just slits whitespaces.


# In[13]:


from nltk.tokenize import sent_tokenize
text="This is introduction to NLP. It is likely to be useful, to people."
print(sent_tokenize(text)) 


# In[14]:


from nltk.tokenize import WordPunctTokenizer
text="We're moving to N.Y.!"
Tokenizer=WordPunctTokenizer()
print(Tokenizer.tokenize(text)) 


# In[15]:


from nltk.tokenize import RegexpTokenizer
text="We're moving to N.Y.!"
tokenizer = RegexpTokenizer(r"\w+")
print(tokenizer.tokenize(text)) 


# # 3.5

# In[16]:


df['tokenized'] = [tokenizer.tokenize(col) for col in df['tweets']]
df


# # 3.6

# In[21]:


from nltk.tokenize import word_tokenize
with open('dataScientistJobDesc.txt', 'r', encoding="UTF-8") as file:
    data= file.read()
    data_list = word_tokenize(data)
    print(len(data_list))
    data_set = set(data_list)
    print(len(data_set))
    nltk_tokens = data_set


# # 3.7

# In[18]:


import spacy
nlp = spacy.load("de_core_news_sm")
doc = nlp("Apple erwägt den Kauf eines österreichischen Startups um 6 Mio. Euro.")
print(doc)


# In[19]:


for token in doc:
    print(f"{token.text:{20}}",type(token)) 


# In[23]:


with open('dataScientistJobDesc.txt', 'r', encoding="UTF-8") as file:
    data = file.read()
    data_list = nlp(data)
    print(len(data_list))
    data_set = set([token.text for token in data_list])
    print(len(data_set))
    spacy_tokens = data_set


# In[26]:


# Spacy behandelt offensichtlich gewisse Zeichenketten (besonders Sonderzeichen) anders.
# Beispielsweise sieht man unten, dass Kommas, Punkte und Schrägstriche nicht gleich tokenized werden.
nltk_tokens.difference(spacy_tokens)


# # 3.8

# In[32]:


from nltk.corpus import stopwords

nltk.download('stopwords')
stop = stopwords.words('english')
text = "How to develop a chatbot in Python"
result = [word for word in text.split() if word not in stop]
result 

# Da How nicht in den Stopwords vorkommt, wurde es nicht aus dem Satz / der Liste entfernt


# # 3.9

# In[43]:


def remove_stopwords_and_join(text):
    words = text.split()
    filtered_words = [word for word in words if word.lower() not in stop]
    return ' '.join(filtered_words)

df['tweets'] = df['tweets'].apply(remove_stopwords_and_join)
df['tokenized'] = [tokenizer.tokenize(col) for col in df['tweets']]
df

