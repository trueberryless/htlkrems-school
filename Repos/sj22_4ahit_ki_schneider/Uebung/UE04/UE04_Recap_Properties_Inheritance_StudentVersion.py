#!/usr/bin/env python
# coding: utf-8

# ## Wiederholung Properties und Inheritance
# 
# ### Bsp. 04.1
# Vervollständigen Sie nachfolgende Klasse `Robot` mit dem Ziel der *Blacklist*-Überprüfung. Generell gilt: Wird beim Instanziieren keine Name angegeben oder ist dieser in der Blacklist `_fobidden_names` angeführt, gilt es den *Default*-Namen *Marvin* zuzuweisen. In allen anderen Fällen ist der Name gemäß Argument zu setzen.    

# In[40]:


class Robot:
    
    _forbidden_names = ["Charly", "Alan"]
    _standard_name = "Martin"
    
    def __init__(self, name=_standard_name):
        self.set_name(name)
        
    
    def get_name(self):
        return self.name
    
    
    def set_name(self, name):
        if(name in self._forbidden_names):
            self.name = self._standard_name
        else:
            self.name = name 


# **Testszenarien**: Zeigen Sie die Funktionsweise anhand nachfolgender Tests!

# In[41]:


r = Robot()
r.get_name()
# Output: 'Marvin'


# In[42]:


r2=Robot("Alan")
r2.get_name()
# Output: 'Marvin'


# In[43]:


r3=Robot("Markus")
r3.get_name()
# Output: 'Markus'


# ### Bsp. 04.2
# Durch den Einsatz der *Decorators* `@property` und `@...setter` kann man, wie es in Python üblich ist, via Attribut zugreifen - also "pythonsich". Adaptieren Sie den Code vom ersten Bsp.:

# In[44]:


class Robot:
    
    _forbidden_names = ["Charly", "Alan"]
    _standard_name = "Marvin"
    
    def __init__(self, name=_standard_name):
        self.name = name
        
    @property
    def name(self):
        return self._name
    
    @name.setter
    def name(self, name=_standard_name):
        if(name in self._forbidden_names):
            self._name = self._standard_name
        else:
            self._name = name 


# **Testszenarien**: Zeigen Sie die Funktionsweise anhand nachfolgender Tests!

# In[45]:


r = Robot("Charly")
print(r.name)
r.name="Alan"
print(r.name)
r.name="Flo"
print(r.name)


# ### Bsp. 04.3 - Inheritance
# Gegeben ist die Klasse `Robot` mit folgender Implementierung:

# In[46]:


class Robot():
    
    _standard_name = "Marvin"
    
    def __init__(self, name=_standard_name):
        self.name=name
    
    
    def say_hello(self):
        return f"Hello, I'm {self.name}"


# `say_hello` liefert folgenden Output:

# In[47]:


r3 = Robot()
r3.say_hello()


# Die Klasse `MedicalRobot` ist von `Robot` abgeleitet und ergänzt diese um die Methode `heal`, die einen beliebigen Namen als Argument übernimmt und ausgibt.

# In[48]:


class MedicalRobot(Robot):
    
    def heal(self, name):
        return f"{name} is healed now, or maybe not!"


# In[49]:


mr2 = MedicalRobot()
mr2.heal("Kelvin")


# Überschreiben Sie in der Klasse `MedicalRobot` die Methode `say_hello` mit dem Ziel, dass nachfolgende Tests das definierte Ergebnis liefern.

# In[50]:


class MedicalRobot(Robot):
    
    def heal(self, x):
        return f"{x} is healed now, or maybe not!"
    
    def say_hello(self):
        return f"Hello, I'm {self.name}, your personal nurse!"


# **Tests**:

# In[51]:


mr = MedicalRobot("Kelvin")
print(mr.say_hello())
# Output: Hello, I'm Kelvin, your personal nurse!

