#!/usr/bin/env python
# coding: utf-8

# In[1]:


import pandas as pd
from sklearn.ensemble import RandomForestClassifier
from sklearn.model_selection import train_test_split

from sklearn import datasets


# In[2]:


# ... Datenaufbereitung
heart = pd.read_csv('heart.csv')

mappings = {
    'Sex': {'M': 0, 'F': 1},
    'ChestPainType': {'ATA': 0, 'NAP': 1, 'ASY': 2, 'TA': 3},
    'RestingECG': {'Normal': 0, 'ST': 1, 'LVH': 2},
    'ExerciseAngina': {'N': 0, 'Y': 1},
    'ST_Slope': {'Up': 0, 'Flat': 1, 'Down': 2}
}

for col, mapping in mappings.items():
    heart[col] = heart[col].map(mapping)

X = heart.drop('HeartDisease', axis=1)
y = heart['HeartDisease']


# In[3]:


clf = RandomForestClassifier(max_depth=3, n_estimators=100, random_state=11)


# In[4]:


X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=.33, random_state=420)


# ## Hyperparameter Tuning
# 
# Mit `GridSearchCV` (Quelle: https://scikit-learn.org/stable/modules/generated/sklearn.model_selection.GridSearchCV.html). kann man die "optimalen" Parameter finden. By the way: CV steht für *Cross Validation*.

# In[5]:


from sklearn.model_selection import GridSearchCV


# ### Umsetzungsbeispiel für RFC
# Details bzgl. einzelner Parameter sind dem API zu entnehmen: https://sklearn.org/modules/generated/sklearn.ensemble.RandomForestClassifier.html

# In[6]:


# Diese Werte sind höchstwahrscheinlich alle etwas zu "gut gemeint" für das Heart Dataset.
param_grid = {
#    'bootstrap': [True],
    'max_depth': [25, 50, 75],
#    'max_features': [2, 3],
#    'min_samples_leaf': [3, 4, 5],
#    'min_samples_split': [8, 10, 12],
    'n_estimators': [50, 100, 150]
}


# Details bzgl. der `GridSearchCV`-Parameter sind dieser Quelle zu entnehmen: https://scikit-learn.org/stable/modules/generated/sklearn.model_selection.GridSearchCV.html

# In[7]:


grid_search = GridSearchCV(estimator = clf, param_grid = param_grid, n_jobs = -1, verbose = 2)


# In[8]:


grid_search.fit(X_train, y_train)


# In[9]:


print(grid_search.best_params_)
print(grid_search.best_score_)

