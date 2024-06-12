#!/usr/bin/env python
# coding: utf-8

# # Jupyter Notebook

# ## different cells

# ### Markdown cell

# Hello!
# 
# I'm Markdown. I have some cool features, such as:
# 
# # BIG HEADINGS
# 
# ## MEDIUM HEADINGS
# 
# ### AND SMALL HEADINGS
# 
# * an
# * unordered
# * list
# 
# or 
# 
# 1. an
# 2. ordered
# 3. list
# 
# | Tablehead |
# |:---:|
# | Tablebody |
# 
#     some code
#     this is cool
#     print("me")
# 
# This is an even better code example:
# 
# ```python
# # Python program to check if the number is an Armstrong number or not
# 
# # take input from the user
# num = int(input("Enter a number: "))
# 
# # initialize sum
# sum = 0
# 
# # find the sum of the cube of each digit
# temp = num
# while temp > 0:
#    digit = temp % 10
#    sum += digit ** 3
#    temp //= 10
# 
# # display the result
# if num == sum:
#    print(num,"is an Armstrong number")
# else:
#    print(num,"is not an Armstrong number")
# ```
# > and many important texts

# ### Code cell

# In[5]:


print("I can run python code.")


# ## particularities

# * run cells individually
# * however, variables exist in every cell, if used one time
# 
# > this leaves the option to run code in different order easily

# ## key combinations

# These are the most important keyboard shortcuts:
# 
# | Keyboard Shortcuts               	| Function                                                                           	| Menu Tools                              	|
# |:----------------------------------	|:------------------------------------------------------------------------------------	|:-----------------------------------------	|
# | STRG + ENTER                     	| run cell                                                                           	| Cell → Run Cell                         	|
# | Esc + s                          	| save notebook                                                                      	| File → Save and Checkpoint              	|
# | Esc + a (above), Esc + b (below) 	| create new cell                                                                    	| Insert → cell above Insert → cell below 	|
# | c                                	| copy cell                                                                          	| Copy Key                                	|
# | v                                	| paste cell                                                                         	| Paste Key                               	|
# | Esc + i i                        	| interrupt kernel                                                                   	| Kernel → Interrupt                      	|
# | Esc + 0 0                        	| restart kernel                                                                     	| Kernel → Restart                        	|
# | Esc + f                          	| find and replace on your code but not the outputs                                  	| N/A                                     	|
# | Shift + M                        	| merge multiple cells                                                               	| N/A                                     	|
# | ?                                	| When placed before a function Information  about a function from its documentation 	| N/A                                     	|
# 
# All keyboard shortcuts can be found and edited under Help → Keyboard Shortcuts.
