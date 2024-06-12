#!/usr/bin/env python
# coding: utf-8

# In[2]:


import re


# In[4]:


p = re.compile("5")
print(p.findall("Für 5 Semmeln habe ich 3.90€ bezahlt.")) 


# In[5]:


p = re.compile("[0-9]")
print(p.findall("Für 5 Semmeln habe ich 3.90€ bezahlt."))


# In[6]:


p = re.compile(" [0-9] ")
print(p.findall("Für 5 Semmeln habe ich 3.90€ bezahlt."))


# In[7]:


p = re.compile("[0-9]\.[0-9][0-9]") 
print(p.findall("Für 5 Semmeln habe ich 3.90€ bezahlt."))


# In[10]:


p = re.compile("[0-9]\.[0-9][0-9][€$]") 
print(p.findall("Für 5 Semmeln habe ich 3.90€ bezahlt."))
print(p.findall("Für 5 Semmeln habe ich 3.90$ bezahlt."))


# In[12]:


p = re.compile(" [0-9] ")
print(p.findall("Für 5 Semmeln habe ich 3.90€ bezahlt."))
print(p.findall("Für 15 Semmeln habe ich 19.50$ bezahlt."))
print(p.findall("Für 150 Semmeln habe ich 190.50$ bezahlt.")) 


# In[14]:


# Also this pattern only matches if there are exactly three numbers.
p = re.compile(" [0-9][0-9][0-9] ")
print(p.findall("Für 5 Semmeln habe ich 3.90€ bezahlt."))
print(p.findall("Für 15 Semmeln habe ich 19.50$ bezahlt."))
print(p.findall("Für 150 Semmeln habe ich 190.50$ bezahlt.")) 


# In[16]:


p = re.compile(" [0-9]+ ")
print(p.findall("Für 5 Semmeln habe ich 3.90€ bezahlt."))
print(p.findall("Für 15 Semmeln habe ich 19.50$ bezahlt."))
print(p.findall("Für 150 Semmeln habe ich 190.50$ bezahlt."))


# In[17]:


p = re.compile(" [0-9]+\.[0-9][0-9][€$] ")
print(p.findall("Für 5 Semmeln habe ich 3.90€ bezahlt."))
print(p.findall("Für 15 Semmeln habe ich 19.50$ bezahlt."))
print(p.findall("Für 150 Semmeln habe ich 190.50$ bezahlt.")) 


# In[18]:


p = re.compile(" [0-9]+\.[0-9]{2}[€$] ")
print(p.findall("Für 5 Semmeln habe ich 3.90€ bezahlt."))
print(p.findall("Für 15 Semmeln habe ich 19.50$ bezahlt."))
print(p.findall("Für 150 Semmeln habe ich 190.50$ bezahlt.")) 


# In[21]:


p = re.compile(" [0-9]+[\.,][0-9]{2}[€$]? ")
print(p.findall("Für 5 Semmeln habe ich 3.90€ bezahlt."))
print(p.findall("Für 15 Semmeln habe ich 19.50$ bezahlt."))
print(p.findall("Für 150 Semmeln habe ich 190,50 bezahlt."))


# In[24]:


p = re.compile("Telefonnummer")
print(p.search("Meine Telefonnummer ist 0664 555 0 123. Ruf schnell an!")) 


# In[27]:


match = p.search("Meine Telefonnummer ist 0664 555 0 123. Ruf schnell an!")
print(match.span())
print(match.start())
print(match.end()) 


# In[32]:


match = p.match("Meine Telefonnummer ist 0664 555 0 123. Ruf schnell an!")
print(match) 


# In[31]:


match = p.finditer("Meine Telefonnummer ist 0664 555 0 123. Ruf schnell an!")
print(match)


# In[34]:


print(re.search("Frau|Herr", "Sehr geehrte Frau Musterfrau! Ich darf Sie darauf hinweisen, dass..."))
print(re.search("Frau|Herr", "Sehr geehrter Herr Mustermann! Ich darf Sie darauf hinweisen, dass...")) 


# In[35]:


re.findall(".und","Der Hund hat keinen Mund ")


# In[36]:


someText = ["a", "abc", "bac"]
for text in someText:
     print(re.findall("^a", text)) 


# In[37]:


someNewText = ["a", "formula", "bac"]
for text in someText:
     print(re.findall("a$", text)) 


# In[38]:


re.findall("[^ ]","Das ist ein Text mit Leerzeichen!") 


# In[ ]:




