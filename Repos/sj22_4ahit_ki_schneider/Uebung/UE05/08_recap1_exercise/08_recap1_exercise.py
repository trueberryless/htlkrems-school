#!/usr/bin/env python
# coding: utf-8

# # 1. Super vowels
# Implement `super_vowels` function which takes a string as an argument and returns a modified version of that string. In the return value of `super_vowels`, all vowels should be in upper case whereas all consonants should be in lower case. The vowels are listed in the `VOWELS` variable.

# In[2]:


VOWELS = ['a', 'e', 'i', 'o', 'u']


# In[1]:


# Your implementation here
def super_vowels(text):
    text = text.lower()
    newtext = ""
    
    for letter in text:
        is_vowel = False
        
        for vowel in VOWELS:
            if letter == vowel:
                is_vowel = True
        
        if is_vowel:
            newtext += letter.upper()
        else:
            newtext += letter
    
    return newtext


# In[3]:


assert super_vowels('hi wassup!') == 'hI wAssUp!'
assert super_vowels('HOw aRE You?') == 'hOw ArE yOU?'


# # 2. Playing board
# Implement `get_playing_board` function which takes an integer as an argument. The function should return a string which resemples a playing board (e.g. a chess board). The board should contain as many rows and columns as requested by the interger argument. See the cell below for examples of desired behavior.
# 

# In[6]:


# Your implementation here
def get_playing_board(number):
    board = ''
    
    for i in range(number):
        for j in range(number):
            if  i % 2 == 0 and j % 2 == 0:
                board += ' '
            elif i % 2 == 1 and j % 2 == 1:
                board += ' '
            else:
                board += '*'
        board += '\n'
    
    return board


# In[7]:


print(get_playing_board(10))


# In[8]:


board_of_5 = (
' * * \n'
'* * *\n'
' * * \n'
'* * *\n'
' * * \n'
)

board_of_10 = (
' * * * * *\n'
'* * * * * \n'
' * * * * *\n'
'* * * * * \n'
' * * * * *\n'
'* * * * * \n'
' * * * * *\n'
'* * * * * \n'
' * * * * *\n'
'* * * * * \n'
)

assert get_playing_board(5) == board_of_5
assert get_playing_board(10) == board_of_10

print(get_playing_board(50))

