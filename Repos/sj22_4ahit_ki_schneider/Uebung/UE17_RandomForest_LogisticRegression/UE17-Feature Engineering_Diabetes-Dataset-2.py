#!/usr/bin/env python
# coding: utf-8

# In[37]:


import pandas as pd
diabetes_df = pd.read_csv('diabetes.csv')
diabetes_df.head(10)


# In[38]:


diabetes_df.isnull().sum()


# In[39]:


sensible_col = ['Glucose', 'BloodPressure', 'SkinThickness', 'Insulin', 'BMI', 'DiabetesPedigreeFunction', 'Age']
diabetes_df[sensible_col].eq(0).sum()


# # Magic
# 
# ====

# In[40]:


# Replace all 0 with median + watch out for Outcome value
masks = [ diabetes_df['Outcome'] == 0, diabetes_df['Outcome'] == 1 ]

for mask in masks:
    diabetes_df.loc[mask, sensible_col] = diabetes_df.loc[mask, sensible_col].replace(0, diabetes_df.loc[mask].mean())


# ====

# In[41]:


diabetes_df.head(10)


# # Test Accuracy

# In[42]:


from sklearn.ensemble import RandomForestClassifier
from sklearn.model_selection import train_test_split
from sklearn.metrics import accuracy_score

X = diabetes_df.drop('Outcome', axis=1)
y = diabetes_df['Outcome']
clf = RandomForestClassifier(max_depth = 50, n_estimators=200, random_state=69)
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=.33, random_state=420)
clf.fit(X_train, y_train)
y_pred = clf.predict(X_test)
accuracy_score(y_test, y_pred)


# Result is better and dataframe is much more beautiful!
