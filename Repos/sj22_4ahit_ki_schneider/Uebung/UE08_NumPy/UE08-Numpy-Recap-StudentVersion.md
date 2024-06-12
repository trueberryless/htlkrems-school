## NumPy Recap


```python
# mandatory imports
import numpy as np
```

### Erstellung N-dimensional NumPy Arrays

1) Gesucht ist folgendes Ergebnis:

```
array([1, 2, 3, 4], dtype=int32)
```


```python
#1) a vector: the argument to the array function is a Python list
lst = [1,2,3,4.0]
lst = np.array(lst, 'int32')
print(lst)
```

    [1 2 3 4]
    

Geben Sie den Datentyp des Arrays aus:

```
dtype('int32')
```


```python
# get its datatype
lst.dtype
```




    dtype('int32')



2) Gesucht ist folgendes Ergebnis:

```
array([[1, 2],
       [3, 4]])
```


```python
#2) a matrix: the argument to the array function is a nested Python list (can also be a tuple of tuples)
np.arange(1, 5).reshape(2, 2)
```




    array([[1, 2],
           [3, 4]])



3) Gesucht ist folgendes Ergebnis:
```
array([[0., 0., 0., 0.],
       [0., 0., 0., 0.],
       [0., 0., 0., 0.]])
```


```python
#3) an array full of zero values
np.zeros([3, 4])
```




    array([[0., 0., 0., 0.],
           [0., 0., 0., 0.],
           [0., 0., 0., 0.]])



#### A note on datatypes
If no datatype is specified during array construction using `np.array()`, NumPy assigns a default dtype. This is dependent on the OS (32 or 64 bit) and the elements of the array.


```python
# get the list of all supported data types
np.sctypes
```




    {'int': [numpy.int8, numpy.int16, numpy.int32, numpy.int64],
     'uint': [numpy.uint8, numpy.uint16, numpy.uint32, numpy.uint64],
     'float': [numpy.float16, numpy.float32, numpy.float64],
     'complex': [numpy.complex64, numpy.complex128],
     'others': [bool, object, bytes, str, numpy.void]}



### Array slicing

4) Gesucht ist folgendes Ergebnis:

```
array([[ 1,  2,  3,  4,  5,  6,  7,  8,  9, 10, 11, 12, 13, 14, 15],
       [16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30],
       [31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45]])
```

Verwenden Sie hierzu `arange` in Kombination mit `reshape`. 


```python
#4)
array = np.arange(1, 46).reshape(3, 15)
array
```




    array([[ 1,  2,  3,  4,  5,  6,  7,  8,  9, 10, 11, 12, 13, 14, 15],
           [16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30],
           [31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45]])



5) Selektieren Sie! By the way: Die Indizierung eines 2-D benötigt 2 Indizes.


```python
# value at last row and last column
array[-1, -1]
```




    45




```python
# get all elments in the last row
array[-1,]
```




    array([31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45])




```python
# get the value 23 
array[array == 23][0]
```




    23




```python
# get the first two rows and 3 columns
array[:2,:3]
```




    array([[ 1,  2,  3],
           [16, 17, 18]])




```python
# get following matrix
# array([[ 7,  8,  9],
#       [22, 23, 24],
#       [37, 38, 39]])
array[:3,6:9]
```




    array([[ 7,  8,  9],
           [22, 23, 24],
           [37, 38, 39]])



### Computing statistics

6) Erstellen Sie folgende Matrix:

```
array([[ 0,  1,  2,  3,  4,  5],
       [ 6,  7,  8,  9, 10, 11],
       [12, 13, 14, 15, 16, 17],
       [18, 19, 20, 21, 22, 23],
       [24, 25, 26, 27, 28, 29]])
```



```python
#6)
array = np.arange(0, 30).reshape(5,6)
array
```




    array([[ 0,  1,  2,  3,  4,  5],
           [ 6,  7,  8,  9, 10, 11],
           [12, 13, 14, 15, 16, 17],
           [18, 19, 20, 21, 22, 23],
           [24, 25, 26, 27, 28, 29]])



Berechnen Sie den Mittelwert für die Achse 0, also spaltenweise. Gesuchtes Ergebnis:
``` array([[12., 13., 14., 15., 16., 17.]]) ```

Verwenden Sie hierzu https://numpy.org/doc/stable/reference/generated/numpy.mean.html


```python
array.mean(axis=0)
```




    array([12., 13., 14., 15., 16., 17.])



### Just for fun

Erstellen Sie ein 3x3 Pixel großes SW-Bild; wobei ausschließlich mittlere Pixel weiß ist (siehe unten). Es gilt:
- 0 = sw
- 1 = weiß


```python
# Hint: Matrix is not just a movie!
img = np.zeros([3,3])
middle = (int(img.shape[0] / 2), int(img.shape[1] / 2))
img[middle[0], middle[1]] = 1


import matplotlib.pyplot as plt
plt.imshow(img,cmap="gray")
```
