#!/usr/bin/env python
# coding: utf-8

# # One-Hot-Encoding

# In[20]:


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

# In[21]:


import pandas as pd
df = pd.read_csv('products.csv')
df = pd.get_dummies(df, columns=["kategorie"], dtype=int)
df.columns = map(str.lower, df.columns)
df


# # Count Vectorizer

# In[22]:


text = ["Tom's family includes 5 kids 2 dogs and 1 cat",
        "The dogs are friendly. The cat is beautiful",
        "The dog is 11 years old",
        "Tom loves in the United States of America"]


# In[23]:


from sklearn.feature_extraction.text import CountVectorizer


# In[24]:


vectorizer = CountVectorizer()
vectorizer.fit(text)


# In[25]:


print(vectorizer.get_feature_names_out())


# In[26]:


vectorizer = CountVectorizer(token_pattern=u'(?u)\\b\\w+\\b')
vectorizer.fit(text)
print(vectorizer.get_feature_names_out())


# In[27]:


vectorizer = CountVectorizer(token_pattern=u'(?u)\\b\\w+\\b',
                             stop_words=['is','are','and','in','the'])
vectorizer.fit(text)
print(vectorizer.get_feature_names_out())


# In[28]:


print(vectorizer.vocabulary_)


# In[29]:


vector = vectorizer.transform(text)
vector.shape


# In[30]:


print(vector.toarray())


# In[31]:


import pandas as pd


# In[32]:


pd.DataFrame(vector.toarray(), columns=vectorizer.get_feature_names_out())


# In[33]:


vectorizer = CountVectorizer(token_pattern=u'(?u)\\b\\w+\\b',
                             stop_words=['is','are','and','in','the'],
                             ngram_range=(1,4))
vectorizer.fit(text)
print(vectorizer.get_feature_names_out())


# In[34]:


vectorizer = CountVectorizer(token_pattern=u'(?u)\\b\\w+\\b',
                             stop_words=['is','are','and','in','the'],
                             ngram_range=(1,4),
                             vocabulary=['united states of america'])
vectorizer.fit(text)
print(vectorizer.get_feature_names_out())

