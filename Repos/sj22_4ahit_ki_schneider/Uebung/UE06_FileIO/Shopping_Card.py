#!/usr/bin/env python
# coding: utf-8

# In[1]:


shopping_card = []
shopping_card2 = []


# In[2]:


import os

def read_shopping_card():   
    shopping_card = []
    
    with open(os.path.join(os.path.dirname(os.getcwd()), 'UE06\\data', 'shopping_card.txt'), encoding="UTF-8") as sc1:
        next(sc1)
        for line in sc1:
            values = line.split(";")
            shopping_card.append({
                'Nr' : values[0],
                'Menge' : values[1],
                'Einzelpreis' : values[2],
                'Bezeichnung' : values[3].strip()
            })
            
    return shopping_card

shopping_card = read_shopping_card()


# In[3]:


def create_second_shopping_card():
    shopping_card2 = []
    
    for element in shopping_card:
        shopping_card2.append({
            'Nr' : element['Nr'],
            'Gesamtpreis' : round(float(element['Menge']) * float(element['Einzelpreis']), 2),
            'Bezeichnung' : element['Bezeichnung']
        })
        
    return shopping_card2
        
shopping_card2 = create_second_shopping_card()


# In[4]:


def write_shopping_card2():
    
    f = open(os.path.join(os.path.dirname(os.getcwd()), 'UE06\\data', 'shopping_card2.txt'), "w", encoding="UTF-8")
    f.write("#Nr;#Gesamtpreis;#Bezeichnung\n")
    for element in shopping_card2:
        f.write(str(element['Nr']) + ";" + str(element['Gesamtpreis']) + ";" + str(element['Bezeichnung']) + "\n")
    f.close()
    
write_shopping_card2()


# In[5]:


def assert_values():
    shopping_card_values = []
    shopping_card2_values = []
    
    with open(os.path.join(os.path.dirname(os.getcwd()), 'UE06\\data', 'shopping_card.txt'), encoding="UTF-8") as sc1:
        next(sc1)
        for line in sc1:
            values = line.split(";")
            shopping_card_values.append(round(float(values[1]) * float(values[2]), 2))
    
    with open(os.path.join(os.path.dirname(os.getcwd()), 'UE06\\data', 'shopping_card2.txt'), encoding="UTF-8") as sc2:
        next(sc2)
        for line in sc2:
            values = line.split(";")
            shopping_card2_values.append(float(values[1]))

    assert shopping_card_values == shopping_card2_values
    
assert_values()

