#!/usr/bin/env python
# coding: utf-8

# In[1]:


# MNIST 1
import tensorflow

(x_train, y_train), (x_test, y_test) = tensorflow.keras.datasets.mnist.load_data()

# 3D-Tenosr mit 60000 Samples, jeweilige Größe von 28x28 Pixel
assert x_train.shape == (60000, 28, 28)
assert x_test.shape == (10000, 28, 28)
assert y_train.shape == (60000,)
assert y_test.shape == (10000,)

import pandas as pd

## Sequential
import tensorflow as tf
from tensorflow import keras
from tensorflow.keras import layers

model = keras.Sequential()
model.add(layers.Dense(64, activation="relu", input_shape=(784,)))
model.add(layers.Dense(10, activation="softmax"))

model.compile(optimizer="rmsprop", loss="categorical_crossentropy", metrics=["accuracy"])

model.summary()

# x_train Reshapen
x_train = x_train.reshape(60000, 784)
x_test = x_test.reshape(10000, 784)

# y_train reshapen, damit verglichen werden kann
# z.B.: [ 5 ]           -> shape: (1,)
#       [ 0000010000 ]  -> shape: (10,)

# https://keras.io/api/utils/python_utils/#to_categorical-function
# Erstellt uns in Abhängigkeit von 'num_classes' (= Anzahl der Klassen, die es im Dataset gibt => siehe alle unique 
# Antworten in y_train) einen Vektor, bei welchem jede Stelle '1' ist, die die gewünscht Ziffer (0, 1, 2, ...) repräsentiert.

from tensorflow.keras import utils
y_train = utils.to_categorical(y_train, 10)
y_test = utils.to_categorical(y_test, 10)


model_history = model.fit(x_train, y_train, epochs=32, batch_size=32, validation_data=(x_test, y_test))


# In[2]:


acc = model_history.history["accuracy"]
acc


# In[3]:


import matplotlib.pyplot as plt
import numpy as np
plt.plot(np.arange(1, len(acc) + 1), acc, 'b', label="Training")
plt.title("Korrektklassifizierungsrate Training")
plt.xlabel("Epochen")
plt.ylabel("Korrektklassifizierungsrate")
plt.legend()
plt.show() 


# In[4]:


loss = model_history.history["loss"]
loss


# In[5]:


import matplotlib.pyplot as plt
import numpy as np
plt.plot(np.arange(1, len(loss) + 1), loss, 'b', label="Loss")
plt.title("Losses")
plt.xlabel("Epochen")
plt.ylabel("Loss Rate")
plt.legend()
plt.show() 


# In[6]:


model.save('./model.h5')

