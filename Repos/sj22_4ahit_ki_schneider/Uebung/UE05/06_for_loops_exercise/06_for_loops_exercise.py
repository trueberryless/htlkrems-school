#!/usr/bin/env python
# coding: utf-8

# # 1. Fill the missing pieces
# Fill the `____` parts in the code below.

# In[1]:


words = ['PYTHON', 'JOHN', 'chEEse', 'hAm', 'DOE', '123']
upper_case_words = []

for word in words:
    if word.isupper():
        upper_case_words.append(word)


# In[2]:


assert upper_case_words == ['PYTHON', 'JOHN', 'DOE']


# # 2. Calculate the sum of dict values
# Calculate the sum of the values in `magic_dict` by taking only into account numeric values (hint: see [isinstance](https://docs.python.org/3/library/functions.html#isinstance)). 

# In[3]:


magic_dict = dict(val1=44, val2='secret value', val3=55.0, val4=1)


# In[4]:


# Your implementation
sum_of_values = 0

for i in magic_dict.values():
    if isinstance(i, (int, float)):
        sum_of_values += i
        
print(sum_of_values)


# In[5]:


assert sum_of_values == 100


# # 3. Create a list of strings based on a list of numbers
# The rules:
# * If the number is a multiple of five and odd, the string should be `'five odd'`
# * If the number is a multiple of five and even, the string should be `'five even'`
# * If the number is odd, the string is `'odd'`
# * If the number is even, the string is `'even'`

# In[6]:


numbers = [1, 3, 4, 6, 81, 80, 100, 95]


# In[9]:


# Your implementation
my_list = []

for i in range(len(numbers)):
    my_list.append("")
    if numbers[i] % 5 == 0:
        my_list[i] += "five "
    if numbers[i] % 2 == 1:
        my_list[i] += "odd"
    if numbers[i] % 2 == 0:
        my_list[i] += "even"


# In[11]:


# Your implementation - other method
my_list = []

for number in numbers:
    my_list.append("")
    if number % 5 == 0:
        my_list[len(my_list) - 1] += "five "
    if number % 2 == 1:
        my_list[len(my_list) - 1] += "odd"
    if number % 2 == 0:
        my_list[len(my_list) - 1] += "even"


# In[12]:


assert my_list == ['odd', 'odd', 'even', 'even', 'odd', 'five even', 'five even', 'five odd']

