#!/usr/bin/env python
# coding: utf-8

# # One-Hot-Encoding

# In[9]:


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


# ## Products

# In[25]:


import pandas as pd
df = pd.read_csv('products.csv')
df = pd.get_dummies(df, columns=["kategorie"], dtype=int)
df.columns = map(str.lower, df.columns)
df

