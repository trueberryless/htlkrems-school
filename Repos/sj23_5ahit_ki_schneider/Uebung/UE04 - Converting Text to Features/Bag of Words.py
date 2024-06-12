#!/usr/bin/env python
# coding: utf-8

# # Bag of Words

# In[1]:


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


# ## Spam

# In[2]:


import pandas as pd

spam = pd.read_csv('spam.csv', encoding="ANSI")
spam.head()


# In[3]:


spam.rename(columns= { "v1" : "target", "v2" : "message" }, inplace=True)
spam.drop(columns= { "Unnamed: 2", "Unnamed: 3", "Unnamed: 4" }, inplace=True)
spam.head()


# ### Label Encoder

# In[4]:


from sklearn.preprocessing import LabelEncoder
le = LabelEncoder()
spam['target'] = le.fit_transform(spam['target'])
spam.head()


# ### Train Valid Split

# In[5]:


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


# In[6]:


X=vectorizer.fit(spam['message'])
print("Token Count:", len(vectorizer.get_feature_names_out())) 


# In[7]:


# Textdaten basierend auf Vokabular vektorisieren. Ergebnis ist BoW
X_train_vectorized = vectorizer.transform(X_train)
print("Bag of Words\n", X_train_vectorized.toarray())

print("\n")

print("X_train_vectorized:", X_train_vectorized.shape)


# In[8]:


# Textdaten basierend auf Vokabular vektorisieren. Ergebnis ist BoW
X_valid_vectorized = vectorizer.transform(X_valid)
print("Bag of Words\n", X_valid_vectorized.toarray())

print("\n")

print("X_valid_vectorized:", X_valid_vectorized.shape)


# In[9]:


y_train_num = le.fit_transform(y_train)
y_valid_num = le.fit_transform(y_valid)


# ###  Naive Bayes Classifiers

# In[11]:


from sklearn.naive_bayes import MultinomialNB
from sklearn.metrics import accuracy_score 

clf = MultinomialNB(alpha=0.2)
clf.fit(X_train_vectorized, y_train_num)

predictions = clf.predict(X_valid_vectorized)
accuracy_score(predictions, y_valid_num)


# In[12]:


msg = vectorizer.transform(["Congratulations! You've won a complimentary entry to the exclusive VIP event. Claim your free pass for the grand finale on June 15, 2023, by texting VIP to 44882. Standard text messaging rates apply. For more details, call 1-800-123-4567. Don't miss out on this incredible opportunity! Terms and conditions apply. Must be 18 or older to participate."])
clf.predict(msg)

