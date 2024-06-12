#!/usr/bin/env python
# coding: utf-8

# In[3]:


import tensorflow


# In[4]:


(x_train, y_train), (x_test, y_test) = tensorflow.keras.datasets.mnist.load_data()

# 3D-Tenosr mit 60000 Samples, jeweilige Größe von 28x28 Pixel
assert x_train.shape == (60000, 28, 28)
assert x_test.shape == (10000, 28, 28)
assert y_train.shape == (60000,)
assert y_test.shape == (10000,)


# In[5]:


import seaborn as sns
sns.heatmap(x_train[1])
y_train[0]


# In[6]:


import pandas as pd

# für Clf müssen matrix-förmige Bilddaten vektorisiert werden
x_train_df = pd.DataFrame(x_train.reshape(60000, 28*28))
# x_train_df = pd.DataFrame(x_train.reshape(x_train.shape[0], x_train.shape[1] *  x_train.shape[2]))
# x_train.reshape(60000, -1)

x_train_df


# In[8]:


pd.Series(y_train).describe()


# In[10]:


x_train[0].shape


# In[12]:


import matplotlib.pyplot as plt
plt.imshow(x_train[0], cmap="gray_r")

