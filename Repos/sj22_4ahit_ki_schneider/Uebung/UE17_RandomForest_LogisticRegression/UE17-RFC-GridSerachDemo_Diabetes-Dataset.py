#!/usr/bin/env python
# coding: utf-8

# In[10]:


import pandas as pd
import numpy as np
from sklearn.ensemble import RandomForestClassifier
from sklearn.linear_model import LogisticRegression
from sklearn.model_selection import train_test_split
from sklearn.metrics import accuracy_score

from sklearn import datasets
from sklearn.model_selection import GridSearchCV


# In[11]:


diabetes_db = pd.read_csv('diabetes.csv')
diabetes_db.head()


# In[12]:


X = diabetes_db.drop('Outcome', axis=1)
y = diabetes_db['Outcome']


# In[13]:


X.isnull().sum()


# # Seaborn

# In[14]:


import seaborn as sns


# In[15]:


print(sns.color_palette("pastel").as_hex())
sns.color_palette("pastel")


# In[16]:


sns.countplot(x=diabetes_db["Outcome"].map({ 0: "no diabetes", 1: "has diabetes"}))


# In[23]:


sns.set_theme(style="whitegrid")
sns.heatmap(diabetes_db.corr(), cmap=sns.color_palette("blend:#e1e6f2,#071d59", as_cmap=True))


# In[ ]:





# # Logistic Regression

# In[49]:


logModel = LogisticRegression(max_iter=124)


# In[50]:


param_grid = [    
    {
        'penalty' : ['l1', 'l2', 'elasticnet', 'none'],
        'C' : np.logspace(-4, 4, 20),
        'solver' : ['lbfgs','newton-cg','liblinear','sag','saga'],
        'max_iter' : [ 100, 1000, 2500, 5000 ]
    }
]


# In[62]:


clf_logreg = GridSearchCV(logModel, param_grid = param_grid, cv = 3, verbose=True, n_jobs=-1)


# In[52]:


best_clf = clf_logreg.fit(X,y)


# In[53]:


best_clf.best_estimator_


# In[54]:


print (f'Accuracy: {best_clf.score(X,y):.3f}')


# # Random Forest

# In[55]:


clf_ranfor = RandomForestClassifier(max_depth=3, n_estimators=100, random_state=11)


# In[56]:


X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=.33, random_state=200)


# In[57]:


clf_ranfor.fit(X_train, y_train)


# In[58]:


y_pred = clf_ranfor.predict(X_test)


# In[59]:


accuracy_score(y_test, y_pred)

