#!/usr/bin/env python
# coding: utf-8

# ### 17.3.1)
# 
# |                     	| qualitatives Merkmal 	| quantitatives Merkmal 	|
# |---------------------	|----------------------	|-----------------------	|
# | Körpergewicht       	| 0                     	| 1                      	|
# | Autobahnbezeichnung 	| 1                     	| 0                      	|
# | Lieblingsfarbe      	| 1                     	| 0                      	|
# | Taschengeld         	| 0                     	| 1                      	|
# | Hausnummer          	| 0                     	| 1                      	|

# ### 17.3.2)
# 
# | country     	| beer_servings 	| spirit_servings 	| wine_servings 	| total_litres_of_pure_alcohol 	| continent 	|
# |-------------	|---------------	|-----------------	|---------------	|------------------------------	|-----------	|
# | Afghanistan 	| 0             	| 0               	| 0             	| 0.0                          	| AS        	|
# | Albania     	| 89            	| 132             	| 54            	| 4.9                          	| EU        	|
# | Algeria     	| 25            	| 0               	| 14            	| 0.7                          	| AF        	|
# | Andorra     	| 245           	| 138             	| 312           	| 12.4                         	| EU        	|
# | Angola      	| 217           	| 57              	| 45            	| 5.9                          	| AF        	|
# 
# |                     	| qualitatives Merkmal 	| quantitatives Merkmal 	|
# |---------------------	|----------------------	|-----------------------	|
# | beer_servings       	| 0                     	| 1                      	|
# | spirit_servings 	    | 0                     	| 1                      	|
# | wine_servings      	| 0                     	| 1                      	|
# | total_litres_of_pure_alcohol         	| 0                     	| 1                      	|
# | continent          	| 1                     	| 0                      	|

# In[1]:


import pandas as pd

diabetes_db = pd.read_csv('diabetes.csv')
diabetes_db.head()


# In[2]:


import numpy as np

categories = ['A', 'B', 'C']
diabetes_db['Demo'] = pd.Categorical(np.random.choice(categories, diabetes_db.shape[0]))


# In[3]:


diabetes_db.head()


# In[4]:


diabetes_db['Demo'].describe()


# In[5]:


diabetes_db.info()

