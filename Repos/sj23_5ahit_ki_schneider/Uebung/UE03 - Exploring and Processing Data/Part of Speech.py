#!/usr/bin/env python
# coding: utf-8

# # Pipeline

# In[1]:


import re, spacy
# nlp = spacy.load("de_core_news_sm")
nlp = spacy.load("en_core_web_sm")

class NLP:
    def __init__(self, text):
        self.text = text
        self.normalized = False
        self.tokenized = False

    def to_lower(self):
        self.text = self.text.lower()
        self.normalized = True
        return self
    
    def remove_url(self):
        if self.normalized == False:
            raise Exception("Text must be normalized first. Use `.to_lower()` to normalize!")
        
        return self
    
    def remove_email(self):
        if self.normalized == False:
            raise Exception("Text must be normalized first. Use `.to_lower()` to normalize!")
        
        return self
    
    def remove_punctuation(self):
        if self.normalized == False:
            raise Exception("Text must be normalized first. Use `.to_lower()` to normalize!")
        
        self.text = re.sub("[^a-z0-9 ]", '', self.text)
        return self
    
    def remove_stopword(self):
        if self.normalized == False:
            raise Exception("Text must be normalized first. Use `.to_lower()` to normalize!")
            
        stop_words = spacy.lang.en.stop_words.STOP_WORDS
        doc = nlp(self.text)
        
        filtered_tokens = [token for token in doc if not token.is_stop] 
        self.text = ' '.join([token.text for token in filtered_tokens])
        
        return self
    
    def lemmatize_word(self):
        if self.normalized == False:
            raise Exception("Text must be normalized first. Use `.to_lower()` to normalize!")
        
        return self


# # NLTK

# In[2]:


import nltk
from nltk.tokenize import word_tokenize
from nltk.corpus import stopwords
nltk.download('averaged_perceptron_tagger')
nltk.download('stopwords')

text = "I love NLP and I will learn NLP in 2 month"
stop_words = set(stopwords.words('english'))
words = [token for token in word_tokenize(text) if token not in
stop_words]
print(nltk.pos_tag(words)) 


# In[3]:


nltk.download('tagsets')
nltk.help.upenn_tagset() 


# In[4]:


with open('dataScientistJobDesc.txt', 'r', encoding="UTF-8") as file:
    data = file.read()
    words = word_tokenize(data)
    words_pos = nltk.pos_tag(words)
    nouns_list = [word for word, pos in words_pos if pos == 'NN' or pos == 'NNP' or pos == 'NNPS' or pos == 'NNS']
    verbs_list = [word for word, pos in words_pos if pos == 'VB' or pos == 'VBD' or pos == 'VBG' or pos == 'VBN' or pos == 'VBP' or pos == 'VBZ']
    
    nouns = len(nouns_list)
    verbs = len(verbs_list)
    print(nouns)


# # Spacy

# In[5]:


import spacy
nlp = spacy.load("en_core_web_sm")
doc = nlp(text)
words=[token for token in doc if token.is_stop == False]
for token in words:
    print(token.text, token.pos_)


# In[6]:


with open('dataScientistJobDesc.txt', 'r', encoding="UTF-8") as file:
    data = file.read()
    words = nlp(data)
    nouns_list = [token.text for token in words if token.pos_ == 'NOUN' or token.pos_ == 'PROPN']
    verbs_list = [token.text for token in words if token.pos_ == 'VERB']
    
    nouns = len(nouns_list)
    verbs = len(verbs_list)
    print(nouns)


# ### Word Type Counter

# In[7]:


import collections
from collections import Counter

with open('dataScientistJobDesc.txt', 'r', encoding="UTF-8") as file:
    data = file.read()
    data = NLP(data).to_lower().remove_punctuation().remove_stopword().text
    words = nlp(data)

    counter = Counter([token.pos_ for token in words])
    print(counter.most_common())


# In[8]:


import pandas as pd
import matplotlib.pyplot as plt
import seaborn as sns

df = pd.DataFrame(counter.most_common(), columns=["Part of Speech", "Count"])

sns.barplot(x="Count", y="Part of Speech", data=df, palette="viridis")

# Set labels and title
plt.xlabel("Count")
plt.ylabel("Part of Speech")
plt.title("Part of Speech Distribution")

# Show the plot
plt.show()


# ### Word Counter

# In[9]:


import collections
from collections import Counter

with open('dataScientistJobDesc.txt', 'r', encoding="UTF-8") as file:
    data = file.read()
    data = NLP(data).to_lower().remove_punctuation().remove_stopword().text
    words = nlp(data)
    
    counter = Counter([token.text for token in words])

    print(counter.most_common(20))


# In[10]:


import pandas as pd
import matplotlib.pyplot as plt
import seaborn as sns

df = pd.DataFrame(counter.most_common(20), columns=["Word", "Count"])

sns.barplot(x="Count", y="Word", data=df, palette="muted")

# Set labels and title
plt.xlabel("Count")
plt.ylabel("Word")
plt.title("Word Frequency Distribution")

# Show the plot
plt.show()

