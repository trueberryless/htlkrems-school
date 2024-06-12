#!/usr/bin/env python
# coding: utf-8

# In[1]:


one = 1


# In[2]:


type(one)


# In[3]:


two = 2


# In[4]:


somestring = "a text"


# In[5]:


type(somestring)


# In[6]:


boolean = True


# In[7]:


type(boolean)


# In[8]:


if True:
    print("juhu")


# In[9]:


if False:
    print("Never see you again!")


# In[10]:


num = 1

while num <= 100:
    num*=2
    print("a")


# In[11]:


for i in range(1,10):
    print(i)


# In[12]:


for i in 1,2,3,4:
    print(i)


# In[13]:


[*range(1,11)]


# In[14]:


list(range(1,11))


# In[15]:


my_integers = [1, 2, 3, 4, 5]


# In[16]:


print(my_integers)


# In[17]:


type(my_integers)


# In[18]:


my_integers.append(6)


# In[19]:


dictionary = { "some_key": "some_value" }

for key in dictionary:
    print("%s --> %s" %(key, dictionary[key]))


# In[20]:


print(dictionary['some_key'])


# In[21]:


print(dictionary)

