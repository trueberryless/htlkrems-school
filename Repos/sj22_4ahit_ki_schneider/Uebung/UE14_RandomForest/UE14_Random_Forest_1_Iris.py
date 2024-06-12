#!/usr/bin/env python
# coding: utf-8

# In[60]:


# Libaries importieren
import numpy as np
import pandas as pd
import matplotlib.pyplot as plt

import sklearn
from sklearn import datasets

# Daten initialisieren
iris = datasets.load_iris()

# # Ehemalige Erstellung X und y
# df_data = pd.DataFrame(iris['data'], columns=iris['feature_names'])
# iris_df = df_data
# iris_df['Species'] = iris['target']
# iris_df
# X = iris_df.iloc[:, [0, 1, 2, 3]]
# y = iris_df['Species']

from sklearn.model_selection import train_test_split
from sklearn.ensemble import RandomForestClassifier

# Erstellen des Classifiers
clf = RandomForestClassifier(max_depth=30, n_estimators=10)

# X und y erstellen
X = iris['data']
y = iris['target']

# Daten teilen für lernen und testen
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=.3, random_state=12)

# Trainieren
clf.fit(X_train,y_train)

# Predicten
y_pred=clf.predict(X_test)

# ZIP
compare = pd.DataFrame(zip(y_pred, y_test), columns=['predicted', 'actual'])
# # oder: Ausimplementierung
# compare = pd.DataFrame(y_test)
# compare['predicted'] = y_pred
# compare.rename(columns= {"Species": "actual", "predicted": "predicted"}, inplace=True)

compare['correct'] = compare.apply(lambda row: 1 if row['actual'] == row['predicted'] else 0, axis=1)

# Mean für Durchschnitt
compare['correct'].mean()

# # oder: Ausimplementierung
# accurancy = compare['correct'].sum() / compare['correct'].count()


# In[39]:


clf.feature_importances_


# In[61]:


from sklearn.metrics import accuracy_score
accuracy_score(y_test, y_pred)


# In[47]:


plt.scatter(X[:, 0], X[:, 1], c=y, cmap=plt.cm.coolwarm)
plt.xlabel('Sepal length')
plt.ylabel('Sepal width')
plt.title('Sepal Width & Length')
plt.show()


# In[50]:


plt.scatter(X[:, 2], X[:, 3], c=y, cmap=plt.cm.coolwarm)
plt.xlabel('Petal length')
plt.ylabel('Petal width')
plt.title('Petal Width & Length')
plt.show()

