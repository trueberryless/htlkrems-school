#!/usr/bin/env python
# coding: utf-8

# In[6]:


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


# In[7]:


text = 'During the night of 21 September 1792, French troops under General Moutesquiou launched a surprise attack on the Duchy of Savoy, which at the time was a dependent territory of the Kingdom of Sardinia. The king, who was in residence at Chambéry, accompanied by his army, numerous administrators and clergy, fled across the Alps to his Piedmontese lands.'


# In[8]:


NLP(text).to_lower().remove_url().remove_email().remove_punctuation().remove_stopword().lemmatize_word().text

