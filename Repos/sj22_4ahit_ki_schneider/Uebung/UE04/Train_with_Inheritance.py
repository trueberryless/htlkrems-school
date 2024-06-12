#!/usr/bin/env python
# coding: utf-8

# In[145]:


class Passenger:    
    def __init__(self, name, valid_ticket):
        self._name = name
        self._valid_ticket = valid_ticket
        
class Train:
    def __init__(self):
        self._passengers = []
    
    def step_in(self, passenger):
        self._passengers.append(passenger)
            
    def step_out(self, passenger):
        self._passengers.remove(passenger)
    
    def print_passengers(self):
        for i in self._passengers:
            print (f"{i._name}, {i._valid_ticket}")

class RailJet(Train):
    def step_in(self, passenger):
        if passenger._valid_ticket is True:
            self._passengers.append(passenger)

class InterCity(Train):
    def __init__(self, ice_category):
        super().__init__()
        self._ICE_Category = ice_category


# In[146]:


p1 = Passenger('Yanik', False)
p2 = Passenger('Felix', True)
p3 = Passenger('Clemens', True)


# In[147]:


r1 = RailJet()


# In[148]:


r1.print_passengers()


# In[149]:


r1.step_in(p1)
r1.step_in(p2)
r1.step_in(p3)


# In[150]:


r1.print_passengers()


# In[151]:


r1.step_out(p2)


# In[152]:


r1.print_passengers()


# In[153]:


i1 = InterCity("ICE187")


# In[154]:


i1.print_passengers()


# In[155]:


i1.step_out(p2) # not working


# In[156]:


i1.step_in(p3)


# In[157]:


i1.print_passengers()

