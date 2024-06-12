#!/usr/bin/env python
# coding: utf-8

# # UE02 Python Einführung - Aufgaben 
# Arbeiten Sie nachfolgenden Aufgabenstellungen durch. 
# 
# >**Hinweis:** Abzugeben ist ein Python-File (Export siehe Menüeintrag `File > Download as`).

# ## Task 2.1.1 - Strings
# Beantworten Sie nachfolgende Frage bzw. schreiben Sie jenen Code, den es zur Erfüllung der jeweiligen Aufgabenstellung braucht:
# 1. Macht es einen Unterschied, ob man einfache oder doppelte Anführungsstriche verwendet? 
# 2. Erzeugen Sie mit <code>print(...)</code> folgende Ausgabe : **"Now, I'm able to use single quotes!"**
# 3. Geben Sie durch Verwendung von <code>x</code> und <code>y</code> die Zeichenkette **Hello, world!** mit <code>print(...)</code> aus.

# Antwort zu 1.:

# In[1]:


#1. Nein, python ist diesbezüglich ähnlich wie JS!


# In[2]:


#2.
print('"Now, I'+"'"+'m able to use single quotes!"')


# In[3]:


#3. 
hello, world = "Hello", "World"


# In[4]:


print(hello+", "+world.lower()+"!")


# ## Task 2.1.2 - Indexbasierte String-Manipulation
# Nehmen Sie vorher https://docs.python.org/3.8/tutorial/introduction.html#strings durch, und zwar ab der Textstelle "*Strings can be indexed...*" Als Bearbeitungsgrundlage dient <code>show</code>:
# 1. Geben Sie den zweiten Buchstaben der Zeichenkette aus
# 2. Geben Sie das Wort **eating** aus
# 3. Geben Sie alles nach **Software** aus
# 4. Geben Sie alles vor **the** aus
# 5. Geben Sie die letzten 3 Buchstaben der Zeichenkette aus

# In[5]:


show = "Software is eating the world!"


# In[6]:


show[1]


# In[7]:


show[12:18]


# In[8]:


show[8:]


# In[9]:


show[:19]


# In[10]:


show[-4:-1]


# ## Task 2.1.3 - if, elif, else Statements
# 
# Es gilt:
# - Wenn <code>x</code> 'true' ist, hat die Ausgabe '**x was True!**' zu erfolgen
# - sonst **'x was False!'**

# In[11]:


x = False

if x==True:
    print("x was True")
elif x==False:
    print("x was False")


# ## Task 2.2.4 - if, elif, else Statements
# 
# Es gilt:
# - Wenn <code>person</code> 'Georg' ist, hat die Ausgabe '**Welcome Georg**' zu erfolgen.
# - Ist <code>person</code> 'Jimmy', dann '**Welcome Jimmy**'.
# - Sonst '**Welcome, what is your name?**'

# In[12]:


person = 'Georg'

if person=="Georg":
    print("Welcome Georg")
elif person=="Jimmy":
    print("Welcome Jimmy")
else:
    "Welcome, what's your name?"


# ## Task 2.2.5 - Loops, Lists, Dicts etc. 

# Iterieren Sie über die Liste <code>list1</code> und fügen Sie hierbei alle geraden Einträge der neu zu erstellenden Liste <code>even</code> und alle ungeraden der Liste <code>odd</code> hinzu. Setzen Sie den Modulo-Operator ein.

# In[13]:


list1 = [1,2,3,4,5,6,7,8,9,10]

even=[]
odd=[]

for i in list1:
    if i%2==0:
        even.append(i)
    elif i%2==1:
        odd.append(i)

print(even)
print(odd)


# ## Task 2.2.6 - Loops, Lists, Dicts etc. 
# Geben Sie die *Keys* als auch die *Values* des Dictionaries <code>d1</code> aus.

# In[14]:


d1 = {'k1':1,'k2':2,'k3':3}


# In[15]:


for key in d1:
    print("%s: %s" %(key,d1[key]))


# ## Task 2.2.7 - Loops, Lists, Dicts etc. 
# Erstellen ein Dictionary mit ein paar Namenseinträgen. Erstellen Sie in Folge ein zweites Dictionary mit weiteren Namenseinträgen. Fügen Sie beide Dictionaries zusammen und stellen Sie hierbei sicher, dass im "neuen" Dictionary keine Duplikate vorhanden sind. (Anm.: Testszenario mit mind. einer Namensgleichheit. Die Überprüfung hat manuell zu erfolgen).

# In[16]:


n1, n2 = {1:"Tobias", 2:"Oliver", 3:"Julian"},{4:"Johannes", 5:"Manuel", 6:"Oliver"}

duplicate_found=False

for key2 in n2:
    for key1 in n1:
        if n1[key1]==n2[key2]:
            duplicate_found=True
    if duplicate_found==False:
        n1[key2]=n2[key2]
    duplicate_found=False

for key in n1:
    print("%s: %s" %(key, n1[key]))


# ## Task 2.2.8
# Erstellen Sie mithilfe der *Built-in Function* `range` eine Liste mit Werten, die folgende Werte enthält: `[0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100]`. Details bzgl. Verwendung von `range` liefert diese [Quelle](https://docs.python.org/3.8/library/functions.html).

# In[17]:


[*range(0,101,10)]


# In[19]:


print(list(range(30, -30, -3)))

