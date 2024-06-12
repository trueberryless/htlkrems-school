#!/usr/bin/env python
# coding: utf-8

# # 1. `if-elif-else`
# Fill missing pieces (`____`) of the following code such that prints make sense.

# In[1]:


name = 'John Doe'


# In[7]:


if len(name) >= 20:
    print('Name "{}" is more than 20 chars long'.format(name))
    length_description = 'long'
elif len(name) >= 15:
    print('Name "{}" is more than 15 chars long'.format(name))
    length_description = 'semi long'
elif len(name) >= 10:
    print('Name "{}" is more than 10 chars long'.format(name))
    length_description = 'semi long'
elif len(name) in (8, 9, 10):
    print('Name "{}" is 8, 9 or 10 chars long'.format(name))
    length_description = 'semi short'
else:
    print('Name "{}" is a short name'.format(name))
    length_description = 'short'


# In[8]:


assert length_description == 'semi short'
