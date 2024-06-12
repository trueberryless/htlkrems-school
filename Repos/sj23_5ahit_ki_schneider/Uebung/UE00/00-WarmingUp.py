#!/usr/bin/env python
# coding: utf-8

# In[31]:


import pandas as pd


# In[32]:


df = pd.read_csv('movie.csv')


# In[33]:


# 0.1
df.shape # Das df verfügt über 28 Colums und 4916 Einträgen / Zeilen


# In[34]:


# 0.2
df.head() 


# In[35]:


# 0.3
type(df['actor_2_name'])


# In[36]:


# 0.4
df['has_seen'] = 0
df.head()


# In[37]:


# 0.5a

exclude_cols = [ 'cast_total_facebook_likes', 'movie_facebook_likes' ]

# need to set to 0 first, because 'likes' is in self colname
df['director_actor_facebook_likes'] = 0
df['director_actor_facebook_likes'] = df[[col for col in df.columns if 'likes' in col]].sum(axis=1) - (df[[col for col in exclude_cols]].sum(axis=1))

df.head()


# In[38]:


# 0.5b
# Die Summe ergibt NaN, wenn zumindest ein Summand NaN ist, es sei denn, man verwendet die Methode sum, da diese NaN-Werte herausfiltert.


# In[39]:


# 0.5c
sum(df['director_actor_facebook_likes'].isnull())


# In[40]:


# 0.5d
df['director_actor_facebook_likes'] = df['director_actor_facebook_likes'].fillna(0)
df['director_facebook_likes'] = df['director_facebook_likes'].fillna(0)
df['actor_1_facebook_likes'] = df['actor_1_facebook_likes'].fillna(0)
df['actor_2_facebook_likes'] = df['actor_2_facebook_likes'].fillna(0)
df['actor_3_facebook_likes'] = df['actor_3_facebook_likes'].fillna(0)
df.head()


# In[41]:


# 0.6
print(round(df['budget'].mean() / 1000000, 2), "Million")
# Durchschnittlich kostet die Filmproduktion ca. 37 Millionen, was bedeutet, dass 22 Mio nicht kostenspielig sind.


# In[42]:


# 0.7a
spam = pd.read_csv('spam.csv', encoding="ANSI")
spam.head()


# In[43]:


# 0.7b
spam['message_length'] = spam['v2'].str.len()
spam.head()


# In[44]:


# 0.7 rename and drop columns
spam.rename(columns= { "v1" : "label", "v2" : "message" }, inplace=True)
spam.drop(columns= { "Unnamed: 2", "Unnamed: 3", "Unnamed: 4" }, inplace=True)
spam.head()

