#!/usr/bin/env python
# coding: utf-8

# In[2]:


# Imports
import numpy as np
import pandas as pd
import matplotlib.pyplot as plt

import sklearn
from sklearn import datasets
from sklearn.model_selection import train_test_split
from sklearn.ensemble import RandomForestClassifier
from sklearn.metrics import accuracy_score

import re as regex


# In[3]:


heart = pd.read_csv('heart.csv')
# heart.columns = [regex.sub([A-Z]) for column in heart]
heart.head()


# In[19]:


X = heart.iloc[:, 0:-1]
y = heart.iloc[:, -1]

print(X['Sex'].unique())
print(X.info())

# Daten aufbereiten
X['Sex'] = X['Sex'].map({
    'M': 0,
    'F': 1
})

X['ChestPainType'] = X['ChestPainType'].map({
    'ATA': 0,
    'NAP': 1,
    'ASY': 2,
    'TA': 3
})

X['RestingECG'] = X['RestingECG'].map({
    'Normal': 0,
    'ST': 1,
    'LVH': 2
})

X['ExerciseAngina'] = X['ExerciseAngina'].map({
    'N': 0,
    'Y': 1
})

X['ST_Slope'] = X['ST_Slope'].map({
    'Up': 0,
    'Flat': 1,
    'Down': 2
})


# In[5]:


clf = RandomForestClassifier(max_depth = 50, n_estimators=200, random_state=69)


# In[6]:


X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=.33, random_state=420)


# In[7]:


clf.fit(X_train, y_train)


# In[8]:


y_pred = clf.predict(X_test)


# In[9]:


accuracy_score(y_test, y_pred)


# In[10]:


clf.feature_importances_


# In[11]:


plt.scatter(X.values[:, 0], X.values[:, 7], c=y, cmap=plt.cm.coolwarm)
plt.xlabel('Age')
plt.ylabel('Max Heart Rate')
plt.title('Age & MaxHR')
plt.show()


# In[25]:


plt.hist(X['Age'])
plt.xlabel('Age')
plt.ylabel('Count')
plt.title('Age distribution')
plt.show()

