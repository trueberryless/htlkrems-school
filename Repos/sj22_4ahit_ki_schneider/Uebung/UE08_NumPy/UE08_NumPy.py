#!/usr/bin/env python
# coding: utf-8

# # NumPy fundamentals
# 
# Many thanks to: https://numpy.org/doc/stable/user/absolute_beginners.html
# 
# ## Introduction
# 
# There are 6 general mechanisms for creating arrays:
# 
# 1. Conversion from other Python structures (i.e. lists and tuples) 
# 
# 2. Intrinsic NumPy array creation functions (e.g. arange, ones, zeros, etc.)
# 
# 3. Replicating, joining, or mutating existing arrays
# 
# 4. Reading arrays from disk, either from standard or custom formats
# 
# 5. Creating arrays from raw bytes through the use of strings or buffers
# 
# 6. Use of special library functions (e.g. random)
# 
# In most case, we do it as described in 1 or 2.

# In[1]:


# Import numpy
import numpy as np


# In[2]:


get_ipython().system('pip list')


# ## How to create a basic array (=Vector)
# To create a NumPy array, you can use the function `np.array()`. All you need to do to create a simple array is pass a list to it.

# In[3]:


array = np.array([1, 2, 3])
print(type(array))
print(array)


# You can visualize your array this way:
# <img src="res/np_array.png">
# 
# ### How do we get the dimension, size or shape of an array?
# - `ndarray.ndim` will tell you the number of axes, or dimensions, of the array.
# 
# - `ndarray.size` will tell you the total number of elements of the array. This is the product of the elements of the array’s shape.
# 
# - `ndarray.shape` will display a tuple of integers that indicate the number of elements stored along each dimension of the array. If, for example, you have a 2-D array with 2 rows and 3 columns, the shape of your array is (2, 3).
# - `ndarray.dtype` will tell you the data type. The Elements are all of the same type.

# In[4]:


array.ndim


# In[5]:


array.size


# In[6]:


print(type(array.shape))
print(array.shape)


# In[7]:


array.dtype


# ### Intrinsic NumPy array creation functions
# - `np.zeros()` creates an array filled with 0’s
# - `np.ones()` creates an array filled with 1’s
# - `np.arange()` creates an array with a range of elements
# - `np.linspace()` creates an array with values that are spaced linearly in a specified interval 

# In[8]:


# Return a new array of given shape and type
print(np.zeros(2))
print()

# with tuples
print(np.zeros((2)))
print()
print(np.zeros((2, 2)))


# In[9]:


# Return a new array of given shape and type
print(np.ones(2))
print()

# with tuples
print(np.ones((2)))
print()
print(np.ones((2, 2)))


# In[10]:


# arange([start,] stop[, step,], dtype=None, *, like=None)
print(np.arange(10))
print(np.arange(3, 10))
print(np.arange(1, 10, 2))


# In[11]:


#np.linspace(start,stop,num=50,endpoint=True,retstep=False,dtype=None,axis=0)
print(np.linspace(1, 10))
print(np.linspace(1, 10, 5))
print(np.linspace(1, 10, 3))


# In[12]:


print(np.linspace(1, 10).shape) # default num is 50 by default


# ### Specifying your data type
# While the default data type is floating point (`np.float64`), you can explicitly specify which data type you want using the `dtype` keyword.

# In[13]:


dtype_example = np.arange(1, 10, 2, 'int8')
dtype_example = np.arange(1, 10, 2, dtype=np.int8)


# In[14]:


print(dtype_example)
print(dtype_example.dtype)


# ### What about reshaping an array?
# Yes, this is possible, but a little tricky! 
# 
# >Using `arr.reshape()` will give a new shape to an array without changing the data. Just remember that when you use the reshape method, the array you want to produce needs to have the **same number of elements** as the original array. If you start with an array with 12 elements, you’ll need to make sure that your new array also has a total of 12 elements.

# In[15]:


reshape_example = np.arange(1, 7)
print(reshape_example)


# To reshape this vector in an array with three rows and two columns, use `reshape(3,2)`.

# In[16]:


reshape_example = reshape_example.reshape((2, 3))
print(reshape_example)


# In[17]:


reshape_example = reshape_example.reshape((3, 2))
print(reshape_example)


# <img src="res/np_reshape.png" width="70%">

# Eureka! We converted a vector into a 2D array (Matrix). To convert the array back to a vector, use `reshape` again

# In[18]:


reshape_example = reshape_example.reshape((6,))
print(reshape_example)


# In[19]:


# fast and easy method to convert back to vector
reshape_example = reshape_example.reshape(-1)
print(reshape_example)


# ### Indexing and slicing
# You can index and slice NumPy arrays in the same ways you can slice Python lists.

# In[20]:


data = np.array([1, 2, 3])


# In[21]:


# looks more complicated that it is (it just prints every possibility)

for i in range(-len(data), len(data) + 1):
    other_i = True
    for j in range(-len(data), len(data) + 1):
        if i < 0 and other_i:
            print(f"data[{i}:]: {data[i:]}")
            other_i = False
        if i < j:
            if i < 0 and j >= 0: continue
            print(f"data[{i}:{j}]: {data[i:j]}")  


# <img src="res/np_indexing.png">

# ## Basic array operations
# ### Broadcasting
# There are times when you might want to carry out an operation between an array and a single number (also called an operation between a vector and a scalar). For example, your array (we’ll call it “data”) might contain information about distance in miles but you want to convert the information to kilometers. You can perform this operation with:

# In[22]:


data = np.array([1.0, 2.0])

data * 1.6


# <img src="res/np_multiply_broadcasting.png">

# ### Addition, subtraction, multiplication, division, and more

# In[23]:


data = np.array([1, 2])
ones = np.ones(2, dtype=int)


# <img src="res/np_data_plus_ones.png">

# In[24]:


data + ones


# In[25]:


data - ones


# In[26]:


data * ones


# In[27]:


data / data


# <img src="res/np_sub_mult_divide.png">

# ### More useful array operations

# In[28]:


data = np.array([1, 2, 3])


# In[29]:


data.max()


# In[30]:


data.min()


# In[31]:


data.sum()


# In[32]:


# doesn't work unfortunately
# data.average()


# <img src="res/np_aggregation.png">

# ## Creating 2D arrays (matrices)
# You can pass Python lists of lists to create a 2-D array (or “matrix”) to represent them in NumPy.

# In[33]:


data = np.arange(1, 7).reshape(3, 2)
print(data)


# <img src="res/np_create_matrix.png" width="90%">

# ### Indexing and slicing operations 

# In[34]:


# filter a value with their indices
print(data[0,1])


# In[35]:


print(data[1:3])
print(data[1:3,:]) # little bit more difficult


# In[36]:


print(data[0:2,0])
print(data[1:,1])


# <img src="res/np_matrix_indexing.png">

# ### Useful operations with matrices 

# In[37]:


data.max()


# In[38]:


data.min()


# In[39]:


data.sum()


# <img src="res/np_matrix_aggregation.png">

# You can aggregate all the values in a matrix and you can aggregate them across **columns** or **rows** using the `axis` parameter:

# In[40]:


data = np.array([[1, 2],[5, 3],[4, 6]])


# In[41]:


data.max(axis=0)


# In[42]:


data.max(axis=1)


# <img src="res/np_matrix_aggregation_row.png">

# Once you’ve created your matrices, you can add and multiply them using arithmetic operators if you have **two matrices** that are the **same size**.

# In[43]:


data = np.array([[1, 2], [3, 4]])
ones = np.array([[1, 1], [1, 1]])


# In[44]:


data + ones


# <img src="res/np_matrix_arithmetic.png">

# You can do these arithmetic operations on matrices of different sizes, but only if one matrix has only one column or one row. In this case, NumPy will use its **broadcast rules** for the operation.

# In[45]:


data = np.array([[1, 2], [3, 4], [5, 6]])
ones_row = np.array([[1, 1]])


# In[46]:


data + ones_row


# <img src="res/np_matrix_broadcasting.png">

# ### Transposing a matrix

# In[47]:


# turn around

print(data)
print("\n")
print(data.T)


# ### Flattening multidemsional arrays

# In[48]:


# variant 1
print(data.reshape(-1))

# variant 2
print(data.flatten())


# ### Dot product of two arrays

# In[52]:


a = np.array([1, 2, 3])
b = np.array([4, 5, 6])

# skalar product: a ⋅ b = ax * bx + ay * by + az * bz


# In[50]:


np.dot(a,b)


# In[53]:


a.dot(b)

