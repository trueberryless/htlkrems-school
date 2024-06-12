#!/usr/bin/env python
# coding: utf-8

# In[1]:


from tensorflow import keras
model = keras.models.load_model('./model.h5')


# In[2]:


model.summary()

